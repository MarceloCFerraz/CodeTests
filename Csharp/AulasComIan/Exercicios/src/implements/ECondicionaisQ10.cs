using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    class ECondicionaisQ10 : ICodingExercise
    {
        public ECondicionaisQ10() { }

        public void TestCode()
        {
            // 10) A partir da idade informada de uma pessoa, elabore um algoritmo
            // que informe a sua classe eleitoral, sabendo que menores de 16 não votam,
            // que o voto é obrigatório para adultos entre 18 a 65 anos e que o voto é
            // opcional para eleitores entre 16 e 18, ou maiores de 65 anos.

            Console.WriteLine("Type your age:");
            var input = Console.ReadLine();

            var age = int.Parse(input);

            // if ( (age >= 16 && age <= 18) || age > 65)
            if (age >= 18 && age <= 65)
                Console.WriteLine("You're not only elegible for voting, but you're obliged to go vote");
            else if (age < 16)
                Console.WriteLine($"You're not elegible for voting yet. You're {16 - age} years away from that");
            else
                Console.WriteLine("You're elegible for voting, but it's optional for your class");
        }
    }
}