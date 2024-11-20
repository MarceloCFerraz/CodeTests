namespace Program;

class Program
{
    public static void Main(string[] args)
    {
        // generate n panels (10x10) with only 0 | 1 distributed randomly
        // display the generated panel
        // save panels and try to find 2 wired positions on all panels
        Console.Clear();

        var panelsCount = 100;
        var n = 10; // for creating n x n panels

        var rand = new Random();

        var randX = rand.Next(n);
        var randY = rand.Next(n);
        var wiredX = PickANeighbourCoordinate(randX, n);
        var wiredY = PickANeighbourCoordinate(randY, n);

        var randPos = (randX, randY, wiredX, wiredY);
        var randVal = rand.Next(2);

        var i = 0;
        var panels = new int[panelsCount][][];


        Console.WriteLine($"Generating {panelsCount} Panels...");

        for (; i < panels.GetLength(0); i++)
        {
            panels[i] = GeneratePanel(n, randPos);
        }

        var possibleWires = GetPossibleWires(panels[0]);
        i = 1; // no need to check panel 0 again

        for (; possibleWires.Count > 0 && i < panels.Count(); i++)
        {
            possibleWires = RemoveFalseWires(possibleWires, panels[i]);
        }

        // we either went through all panels and 
        // 1. discovered there are no wired items
        // 2. we managed to remove all false positives and remained with only 2 wires
        // 2. couldn't get to less than 3 values wired or
        if (possibleWires.Count == 0)
            Console.WriteLine($"There are no wires on the generated panels. Checked panels: {i}");
        else if (possibleWires.Count == 2 && possibleWires.All(w => w.Value.Count == 1))
        {
            var kv = possibleWires.ElementAt(0);
            var v = kv.Key;
            var w = kv.Value[0];

            Console.WriteLine($"Item [{v.Item1},{v.Item2}] is wired to [{w.Item1},{w.Item2}]. Checked {i} panels");
            return;
        }
        else
        {
            Console.WriteLine("We went through all panels but we couldn't determine which items are definitely wired.");
            Console.WriteLine($"Here are the current options:");

            foreach (var coord in possibleWires.Keys)
            {
                Console.WriteLine($"[{coord.Item1},{coord.Item2}]");

                foreach (var neighbour in possibleWires[coord])
                {
                    Console.WriteLine($"\t[{neighbour.Item1},{neighbour.Item2}]");
                }
            }
        }
    }

    private static int[][] GeneratePanel(int n, (int rx, int ry, int wx, int wy)? randPos = null)
    {
        var hasOptionalParam = randPos != null;
        var hasEqualCoordinates = randPos?.rx == randPos?.wx && randPos?.ry == randPos?.wy;

        if (hasOptionalParam && hasEqualCoordinates)
            throw new ArgumentException($"Fixed positions for item and wired item shouldn't have the same coordinates: ({randPos?.rx},{randPos?.ry}), ({randPos?.wx},{randPos?.wy})");

        var matrix = new int[n][];
        var rand = new Random();

        var randX = randPos != null ? randPos.Value.rx : rand.Next(n);
        var randY = randPos != null ? randPos.Value.ry : rand.Next(n);

        var wiredX = randPos != null ? randPos.Value.wx : PickANeighbourCoordinate(randX, n);
        var wiredY = randPos != null ? randPos.Value.wy : PickANeighbourCoordinate(randY, n);

        // can't wire an item with itself
        while (wiredX == randX && wiredY == randY)
        {
            randX = PickANeighbourCoordinate(wiredX, n);
            randY = PickANeighbourCoordinate(wiredY, n);
        }

        Console.WriteLine($"[{randX}, {randY}] and [{wiredX}, {wiredY}] are wired");

        // first allocate memory for the whole matrix (this allow us to pick random positions after current row for the wired item)
        for (var x = 0; x < n; x++)
        {
            matrix[x] = new int[n];
        }

        var v = rand.Next(2);

        matrix[randX][randY] = v;
        matrix[wiredX][wiredY] = v;

        for (var x = 0; x < n; x++)
        {
            for (var y = 0; y < n; y++)
            {
                // these guys were filled already, no need to about with them
                if ((x == randX && y == randY) || (x == wiredX && y == wiredY))
                    continue;

                matrix[x][y] = rand.Next(2); // 0 or 1
            }
        }

        return matrix;
    }

    private static int PickANeighbourCoordinate(int c, int n)
    {
        // if c is at the last possible position, return one before
        if (c == n - 1)
            return c - 1;
        // if c is at the fist position, return one after
        else if (c == 0)
            return c + 1;
        // otherwise, pick a random position before, after or at the current row/col
        else
            return c + new Random().Next(-1, 1);
    }

    private static void PrintPanel(int[][] panel)
    {
        for (var x = 0; x < panel.Length; x++)
        {
            for (var y = 0; y < panel[x].Length; y++)
            {
                Console.Write(panel[x][y].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }

    private static Dictionary<(int, int), List<(int, int)>> GetPossibleWires(int[][] panel)
    {
        // Console.WriteLine("Getting initial wires from this panel:");
        // PrintPanel(panel);

        // each item at (x,y) with a neighbour with the same value is a possible wire
        // all matching neighbours have their coordinates added to the list
        var resp = new Dictionary<(int, int), List<(int, int)>>();

        for (var x = 0; x < panel.GetLength(0); x++)
        {
            for (var y = 0; y < panel[x].Length; y++)
            {
                var wires = new List<(int, int)>();

                var v = panel[x][y];

                // determining all possible positions a neighbour can be
                var directions = new List<(int dx, int dy)>
                {
                    (-1, -1), (-1, 0), (-1, 1), // top-left, top, top-right,
                    (0, -1), (0, 1),            // left, right
                    (1, -1), (1, 0), (1, 1)     // bottom-left, bottom, bottom-Right
                };

                foreach (var (dx, dy) in directions)
                {
                    int newX = x + dx;
                    int newY = y + dy;

                    if (newX >= 0 && newX < panel.Length && newY >= 0 && newY < panel[newX].Length)
                    {
                        var nv = panel[newX][newY];
                        if (nv == v)
                            wires.Add((newX, newY));
                    }
                }

                if (wires.Count > 0)
                    resp[(x, y)] = wires;

            }
        }

        // Console.ReadKey();

        return resp;
    }

    private static Dictionary<(int, int), List<(int, int)>> RemoveFalseWires(Dictionary<(int, int), List<(int, int)>> possibleWires, int[][] panel)
    {
        // Console.WriteLine("Removing false positives from this panel:");
        // PrintPanel(panel);

        var unwiredItems = new List<(int, int)>();

        for (var i = 0; i < possibleWires.Count; i++)
        {
            var valueCoordinate = possibleWires.ElementAt(i).Key;
            var neighbours = possibleWires[valueCoordinate];
            var value = panel[valueCoordinate.Item1][valueCoordinate.Item2];

            var wiredNeighbours = new List<(int, int)>();

            // evaluate if previous neighbours are still possible wires
            foreach (var n in neighbours)
            {
                var neighbourValue = panel[n.Item1][n.Item2];

                // if any are, register them to be kept (removing here causes an error with the for loop)
                if (neighbourValue == value)
                    wiredNeighbours.Add(n);
            }

            // and then update list of wired neighbours
            possibleWires[valueCoordinate] = wiredNeighbours;

            // if no neighbours are wired anymore, save which item should be removed from dict later (to avoid problems with the loop)
            if (wiredNeighbours.Count == 0)
                unwiredItems.Add(valueCoordinate);
        }

        // lastly remove items that aren't wired anymore before returning
        foreach (var coord in unwiredItems)
            possibleWires.Remove(coord);

        return possibleWires;
    }
}