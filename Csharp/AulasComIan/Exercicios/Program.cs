using Exercicios.Implements;
using Exercicios.Interfaces;


var questions = new List<ICodingExercise>()
    {
        new ECondicionaisQ1(),
        new ECondicionaisQ2(),
        new ECondicionaisQ3(),
        new ECondicionaisQ4(),
        new ECondicionaisQ5(),
        new ECondicionaisQ6(),
        new ECondicionaisQ7(),
    };

// infinite loop
while (true)
{
    try
    {
        Console.Clear(); // clear previous messages on the terminal
        var question = PickAnOption(questions);

        if (question == null)
        {
            Console.WriteLine("You chose to leave, bye bye");
            Environment.Exit(0);
        }

        Console.Clear(); // clear again to make test easier

        question.TestCode();

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}. Please try again.");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}

ICodingExercise? PickAnOption(List<ICodingExercise> questions)
{
    var higherOption = questions.Count;

    Console.WriteLine($"Which question would you like to test? Type a number from 1 to {higherOption} or 0 to quit");
    var input = Console.ReadLine();

    ValidateInput(input, higherOption);

    var questionIndex = int.Parse(input);

    if (questionIndex == 0)
        return null; // quits the program

    return questions[questionIndex - 1];
}

static void ValidateInput(string? input, int higherOption)
{
    if (string.IsNullOrEmpty(input))
        throw new InvalidDataException("Input can't be null");

    if (!int.TryParse(input, out var questionIndex))
        throw new InvalidCastException($"Can't convert '{input}' to an int");

    if (questionIndex < 0 || questionIndex > higherOption)
        throw new InvalidDataException($"You must choose an option between 0 and {higherOption}");
}
