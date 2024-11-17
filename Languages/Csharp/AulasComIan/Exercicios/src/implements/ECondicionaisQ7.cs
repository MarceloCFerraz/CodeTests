using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    class ECondicionaisQ7 : ICodingExercise
    {
        public ECondicionaisQ7() { }

        public int TestCode()
        {
            // 7) Elabore um algoritmo que leia o valor de dois números inteiros e a operação aritmética desejada;
            // calcule, então, a resposta adequada. Utilize os símbolos da tabela a seguir para ler qual a operação
            // aritmética escolhida.
            // Símbolo	Operação aritmética
            // +        Adição
            // -        Subtração
            // *        Multiplicação
            // /	    Divisão

            Console.WriteLine("Type the first number");
            var input = Console.ReadLine();
            var num1 = int.Parse(input);

            Console.WriteLine("Type the second number");
            input = Console.ReadLine();
            var num2 = int.Parse(input);

            Console.WriteLine("Type one of the operation symbols from the list below:");
            Console.WriteLine("+\tSum");
            Console.WriteLine("-\tSubtract");
            Console.WriteLine("*\tMultiply");
            Console.WriteLine("/\tDivide");

            input = Console.ReadLine();
            double result;

            if (input == "+")
                result = num1 + num2;
            else if (input == "-")
                result = num1 - num2;
            else if (input == "*")
                result = num1 * num2;
            else if (input == "/")
            {
                if (num2 == 0)
                    throw new InvalidOperationException("Can't divide a number by zero");

                result = num1 / (double)num2; // to get correct division results, denominators must be double
            }
            else
                throw new InvalidDataException($"{input} is not a valid operation");

            Console.WriteLine($"{num1} {input} {num2} = {result}");
            return 1;
        }
    }
}