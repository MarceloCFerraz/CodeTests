static void Recursive(int number)
{
    Console.Write(number + ", ");

    if (number == 0)
    {
        Console.WriteLine();
        return;
    }

    Recursive(number - 1);
}

Recursive(30);