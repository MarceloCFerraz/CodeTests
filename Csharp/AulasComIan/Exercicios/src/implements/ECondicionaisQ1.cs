// 1) Escreva um algoritmo que leia três valores inteiros e diferentes e mostre-os em ordem decrescente. 

using Exercicios.Interfaces;

namespace Exercicios.Implements;

class ECondicionaisQ1 : ICodingExercise
{
    public ECondicionaisQ1() { }

    public void TestCode()
    {
        #region main logic

        var value1 = ReadValue();
        var value2 = ReadValue();

        if (value2 == value1)
            return;

        var value3 = ReadValue();

        if (value3 == value2 || value3 == value1)
            return;

        PrintHighestValue(value1, value2, value3);
        PrintIntermediateValue(value1, value2, value3);
        PrintLowestValue(value1, value2, value3);

        #endregion main logic
    }



    #region functions
    private int ReadValue()
    {
        Console.WriteLine("Type a Value: ");
        var input = Console.ReadLine();

        // if for some reason input is an empty string or a null, quit the program with an error
        if (input == null || input == "")
            throw new InvalidDataException("User input was null or empty");

        // if user inserts a double number or a non-numerical input, quit with an error
        if (!int.TryParse(input, out int value))
            throw new InvalidCastException($"Can't convert {input} to an integer");

        return value;
    }

    private void PrintHighestValue(int? value1, int? value2, int? value3)
    {
        // check if value1 is the highest number
        if (value1 > value2 && value1 > value3)
            Console.WriteLine(value1);

        // check if value2 is the highest number
        else if (value2 > value1 && value2 > value3)
            Console.WriteLine(value2);

        // if none are the highest, only value3 can be
        else
            Console.WriteLine(value3);
    }

    private void PrintIntermediateValue(int? value1, int? value2, int? value3)
    {
        // check if value1 is the highest number
        if (value2 > value1 && value1 > value3)
            Console.WriteLine(value1);

        // check if value2 is the highest number
        else if (value1 > value2 && value2 > value3)
            Console.WriteLine(value2);

        // if none are the highest, only value3 can be
        else
            Console.WriteLine(value3);
    }

    private void PrintLowestValue(int? value1, int? value2, int? value3)
    {
        // check if value1 is the highest number
        if (value2 > value1 && value3 > value1)
            Console.WriteLine(value1);

        // check if value2 is the highest number
        else if (value1 > value2 && value3 > value2)
            Console.WriteLine(value2);

        // if none are the highest, only value3 can be
        else
            Console.WriteLine(value3);
    }
    #endregion functions
}