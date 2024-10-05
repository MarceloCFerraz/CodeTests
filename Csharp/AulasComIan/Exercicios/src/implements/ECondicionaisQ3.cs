using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    class ECondicionaisQ3 : ICodingExercise
    {
        public ECondicionaisQ3() { }

        public void TestCode()
        {
            // 3) Faça um algoritmo que leia o ano de nascimento de uma pessoa, calcule e mostre sua idade e,
            // também, verifique e mostre se:
            // 1. ela já tem idade para votar (16 anos ou mais); e
            // 2. para tirar a Carteira de Habilitação (18 anos ou mais).

            Console.WriteLine("Please type your year of birth:");
            var input = Console.ReadLine();

            var year = int.Parse(input); // let's just skip validations, shall we?

            var age = 2024 - year; // there's a better way to do this:
            age = DateTime.Now.Year - year; // this will get the date from the OS.
            // Classes DateTime and Date have many cool stuff besides this that will be covered on future exercises

            Console.WriteLine($"Your age is: {age}");
        }
    }
}