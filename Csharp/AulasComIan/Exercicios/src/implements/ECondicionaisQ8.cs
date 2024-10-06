using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    class ECondicionaisQ8 : ICodingExercise
    {
        public ECondicionaisQ8() { }

        public void TestCode()
        {
            // 8) O Índice de Massa Corporal (IMC) é um critério da Organização Mundial de Saúde para dar
            // uma indicação sobre a condição de peso de uma pessoa adulta.
            // A fórmula é IMC = peso / (altura)^2. Elabore um algoritmo que leia o peso e a altura de um
            // adulto e mostre sua condição.
            // IMC	            Condição
            // Abaixo de 18,5   Abaixo do peso
            // Entre 18,5 e 25  Peso normal
            // Entre 25 e 30    Acima do peso
            // Acima de 30	    Obeso

            Console.WriteLine("Type your height in meters:");
            var input = Console.ReadLine();
            var height = double.Parse(input);

            Console.WriteLine("Type your weight:");
            input = Console.ReadLine();
            var weight = double.Parse(input);

            var imc = weight / Math.Pow(height, 2);

            if (imc < 18.5)
                Console.WriteLine($"You're below ideal weight. BMI: {imc:F}"); // another way of doing .ToString("F")
            if (imc >= 18.5 && imc < 25)
                Console.WriteLine($"You have your ideal weight. BMI: {imc:F}");
            if (imc >= 25 && imc <= 30)
                Console.WriteLine($"You're above ideal weight. BMI: {imc:f}"); // same as above
            if (imc > 30)
                Console.WriteLine($"You're one step away from having a heart attack. BMI: {imc:f}");
        }
    }
}