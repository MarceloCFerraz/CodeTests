using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    public class ECondicionaisQ4 : ICodingExercise
    {
        public ECondicionaisQ4() { }

        public void TestCode()
        {
            // 4) Escreva um algoritmo que leia o código de um determinado produto e mostre a sua classificação.
            // Utilize a seguinte tabela como referências:
            // Código	                Classificação
            // 1                        Alimento não-perecível
            // 2, 3 ou 4                Alimento perecível
            // 5 ou 6                   Vestuário
            // 7                        Higiene pessoal
            // 8 até 15                 Limpeza e utensílios domésticos
            // Qualquer outro código	Inválido
            Console.WriteLine("Type in an option from 1 to 15 and I'll show you which product category it represents:");
            var input = Console.ReadLine();

            var option = int.Parse(input);

            if (option == 1)
                Console.WriteLine("Non-Perishable food");
            else if (option > 1 && option <= 4)
                Console.WriteLine("Perishable food");
            else if (option > 4 && option <= 6)
                Console.WriteLine("Clothing");
            else if (option == 7)
                Console.WriteLine("Personal Hygiene");
            else if (option > 7 && option <= 15)
                Console.WriteLine("That's cleaning and home stuff");
            else
                Console.WriteLine("That's an invalid option. Options have a limited range of 1 to 15");
        }
    }
}