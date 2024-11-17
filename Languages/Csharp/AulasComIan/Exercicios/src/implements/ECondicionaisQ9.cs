using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    class ECondicionaisQ9 : ICodingExercise
    {
        public ECondicionaisQ9() { }

        public int TestCode()
        {
            // 9) Escreva um algoritmo que, a partir de um mês fornecido
            // (número inteiro de 1 a 12), apresente o nome dele por extenso
            // ou uma mensagem de mês inválido.

            Console.WriteLine("Type a month number (1 to 12):");
            var input = Console.ReadLine();

            var intMonth = int.Parse(input);

            if (intMonth < 1 || intMonth > 12)
                throw new InvalidDataException("Month can't be less than 1 or higher than 12");

            var date = new DateOnly(year: 2024, int.Parse(input), day: 1);

            Console.WriteLine($"Month is: {date:MMMM}"); // to get only the month of the date obj
            return 1;
        }
    }
}