using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    class ECondicionaisQ6 : ICodingExercise
    {
        public ECondicionaisQ6() { }

        public int TestCode()
        {
            // 6) Elabore um algoritmo que calcule o que deve ser pago por um produto,
            // considerando o preço normal de etiqueta e a escolha da condição de pagamento.
            // Utilize os códigos da tabela a seguir para ler qual a condição de pagamento escolhida
            // e efetuar o cálculo adequado.
            // Código	Condição de pagamento
            // 1        À vista no cartão de crédito, recebe 5% de desconto
            // 2        Em duas vezes, preço normal de etiqueta sem juros
            // 3        Em três vezes, preço normal de etiqueta mais juros de 10%
            // 4	    À vista em dinheiro ou cheque, recebe 10% de desconto

            var price = 1020.0;
            Console.WriteLine($"You're buying an item whose original price is ${price}");
            Console.WriteLine("Please choose an option on how you want to pay for it:");
            Console.WriteLine("1 - A single payment with credit card (5% 0FF)");
            Console.WriteLine("2 - Divided in two monthly payments");
            Console.WriteLine("3 - Divided in three monthly payments (10% total interest)");
            Console.WriteLine("4 - A single payment on cash/check (10% 0FF)");

            var input = Console.ReadLine();
            var option = int.Parse(input);

            double finalPrice;
            double rate;

            if (option == 1)
                rate = 1 - 0.05;
            else if (option == 2)
                rate = 1;
            else if (option == 3)
                rate = 1 + 0.1;
            else if (option == 4)
                rate = 1 - 0.1;
            else
                throw new InvalidDataException("You picked an invalid option. Valid options are 1 through 4");

            // simpler way:
            // Console.WriteLine($"Final Price: $ {price * rate}");

            // prettier way:
            Console.WriteLine($"Final Price: $ {(price * rate).ToString("n2")}");
            // reference: https://stackoverflow.com/a/18418762
            return 1;
        }
    }
}