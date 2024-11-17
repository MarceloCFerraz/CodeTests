using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    class ECondicionaisQ5 : ICodingExercise
    {
        public ECondicionaisQ5() { }

        public int TestCode()
        {
            // 5) Elabore um algoritmo que, dada a idade de um nadador, classifique-o em uma das seguintes categorias:
            // Idade	            Categoria
            // 5 até 7 anos         Infantil A
            // 8 até 10 anos        Infantil B
            // 11 até 13 anos       Juvenil A
            // 14 até 17 anos       Juvenil B
            // Maiores de 18 anos	Adulto

            Console.WriteLine("Please type your age and we'll see if you're elegible for our swimming class: ");
            var input = Console.ReadLine();

            var age = int.Parse(input);

            if (age < 5)
                Console.WriteLine($"Age {age} is not elegible for this swimming class");
            if (age >= 5 && age <= 7)
                Console.WriteLine("Children's Class A");
            if (age >= 8 && age <= 10)
                Console.WriteLine("Children's Class A");
            if (age >= 11 && age <= 13)
                Console.WriteLine("Juvenile Class A");
            if (age >= 14 && age <= 17)
                Console.WriteLine("Juvenile Class B");
            if (age >= 18)
                Console.WriteLine("Adults Class");

            return 1;
        }
    }
}