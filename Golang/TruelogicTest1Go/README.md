# Calculate optimal coordinates for party

Em um mundo 2D, a galera quer organizar uma festa que deve acontecer nas coordenadas (x, y).

A festa deve ocorrer no local cujo custo seja o mais baixo possível pra que todas as pessoas de todas as cidades do mundo compareçam.

A função recebe 3 argumentos: `numPeople`, `x` e `y`, todos arrays de `int32`.

- Cada item de `numPeople` representa o numero de habitantes de uma cidade,
- Cada elemento de `x` representa a coordenada x de uma cidade na posicao `i`,
- Cada elemento de `y` representa a coordenada y de uma cidade na posicao `i`.

```golang
cityPopulation := numPeople[i]
cityXPos := x[i]
cityYPos := y[i]
```

Considerando que estamos pensando em mover todo mundo de uma cidade N (x, y) pra um ponto qualquer no mundo (a, b), o custo pra mover todos da cidade N seria:

```golang
cost := cityPopulation * ( |x - a| + |y - b| )
// | must be replaced by an absolute function like math.Abs()
```

O calculo deve ser feito pra todas as coordenadas possiveis e pra todas as cidades. A função deve retornar apenas o menor custo.

O custo de cada cidade deve ser registrado em uma matriz, onde cada posição i e j, representam uma coordenada possível no mundo. O valor deve ser incrementado para cada cidade. Ao final, percorrer a matriz de possíveis coordenadas e retornar o menor custo.

Exemplo de como deveria funcionar com pseudocode:

```golang
numPeople := [1, 2]
x := [1, 3]
y := [1, 3]

city1Pop := numPeople[0] // 1
city1X := x[0] // 1
city1Y := y[0] // 1

totalCosts := make([][]int32, 0, highestValueInXAndY(x, y)) // highest is 3, so matrix is 3x3

totalCosts[0][0] := city1Pop * (|city1X - 1| + |city1Y - 1|) // 1 * |1 - 1| + |1 - 1| = 0
totalCosts[0][1] := city1Pop * (|city1X - 1| + |city1Y - 2|) // 1 * |1 - 1| + |1 - 2| = 1
// ... same until [2][2]

totalCosts[0][0] += city2Pop * (|city2X - 1| + |city2Y - 1|) // 2 * |3 - 1| + |3 - 1| = 8
totalCosts[0][1] += city2Pop * (|city2X - 1| + |city2Y - 2|) // 2 * |3 - 1| + |3 - 2| = 6
// ... same until [2][2]

fmt.Println(totalCosts)

/*
city 1:
    0   1   2
    1   2   3
    2   3   4
city 2:
    8   6   4
    6   4   2
    4   2   0
totalCosts (city 1 + city 2): 
    8   7   6
    7   6   5
    6   5   4
*/

return lowestCost(totalCosts) // 4
```

Fiz considerando todas as posições possíveis baseado no maior valor em x e em y (exemplo, se x = [1, 1, 4], ent as coordenadas x possiveis vao de 1 a 4 – 0 a 3 por se tratar de indices de array), mas alguns testes falharam, não deu pra descobrir porquê.

Talvez eu devesse considerar somente coordenadas das cidades ao inves de todas as coordenadas possíveis.

A implementação essencialmente consiste em criar uma segunda matriz onde cada posicao representa uma coordenada possivel e os valores em cada item representam o custo de mover todos de uma cidade qualquer pras coordenadas em questao. Exemplo:

Explicacao: Para mover o unico cidadao da cidade 1 (1, 1) para as coordenadas (1, 1), o custo seria 0, mas para mover os dois cidadaos da cidade 2 (3, 3) para as coordenadas (3, 3), o custo seria 4. Sendo assim, o custo total de mover todos (tanto da cidade 1 quanto da cidade 2) para as coordenadas (1, 1) seria 4 (0 da cidade 1, 4, da cidade 2). O mesmo calculo deve ser feito para todas as cidades. Por fim, a função deve retornar o menor valor na matriz, para indicar que este seria o local cujo custo seria o menor possivel.

É possível ter mais de 2 cidades, então o algoritmo deve preencher a matrix de soma dinamicamente, calculando o custo de cada cidade e então somando à coordenada atual:

sum[row][col] += costCityI
