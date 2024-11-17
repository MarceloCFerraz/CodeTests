using Exercicios.Interfaces;

namespace Exercicios.Implements;

class ECondicionaisQ2 : ICodingExercise
{
    public ECondicionaisQ2() { }

    #region main logic
    public int TestCode()
    {
        // 2) Tendo como dados de entrada a altura e o sexo de uma pessoa,
        // construa um algoritmo que calcule seu peso ideal, utilizando as seguintes fórmulas:
        // •	Para homens: (72,7 x h) - 58
        // •	Para mulheres: (62,1 x h) - 44,7

        char gender = ReadGender();
        double heightInMeters = ReadHeight();
        double idealWeight = CalculateIdealWeight(gender, heightInMeters);

        Console.WriteLine($"Your ideal weight is: {idealWeight} KG");
        return 1;
    }
    #endregion main logic

    #region functions
    private char ReadGender()
    {
        Console.WriteLine("Please, type your gender (M/F):");
        var input = Console.ReadLine();

        var gender = ValidateGender(input);

        return gender;
    }

    private char ValidateGender(string? input)
    {
        if (input == null || input == "empty")
            throw new InvalidDataException("Gender can't be null or empty");

        // making input have only CAPITAL LETTERS
        input = input.ToUpper();

        if (!char.TryParse(input, out char gender))
            throw new InvalidCastException($"Couldn't convert {input} to char");

        if (gender != 'M' && gender != 'F')
            throw new InvalidDataException($"Gender should be 'M' (male) or 'F' (female), given: '{gender}'");

        return gender;
    }

    private double ReadHeight()
    {
        Console.WriteLine("Please insert your height in meters (e.g.: 1.8):");
        var input = Console.ReadLine();

        var height = ValidateHeight(input);

        return height;
    }

    private double ValidateHeight(string? input)
    {
        if (!double.TryParse(input, out double height))
            throw new InvalidCastException($"Couldn't convert '{input}' to a double number");

        if (height <= 0)
            throw new InvalidDataException("You gotta be kidding me...");

        return height;
    }

    private double CalculateIdealWeight(char gender, double heightInMeters)
    {
        // •	Para homens: (72,7 x h) - 58
        // •	Para mulheres: (62,1 x h) - 44,7
        double response;

        if (gender == 'M')
            response = (72.7 * heightInMeters) - 58;
        else
            response = (62.1 * heightInMeters) - 44.7;

        return response;
    }
    #endregion functions
}