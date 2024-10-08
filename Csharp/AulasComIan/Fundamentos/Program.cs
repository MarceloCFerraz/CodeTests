
// tipos primitivos
int numberI = 0;
long numberL = 0;
short numberSh = 0;

float numberF = 0f;
double numberD = 0d;
decimal numberDec = 0;

string numberS = "0";
char numberC = '0';

bool condition = true;

var unspecifiedVar = 0;

// exercicio:
// faça um programa que faz a divisão de dois números inteiros e depois
// imprima o resultado elevado à 3a potência

int A = 50;
int B = 3;

// assinatura de função
// visib.    tipo retorno nome    parametros
// public    float        Divisao(int A, int B)
float Divisao(int A, int B)
{
    if (B == 0)
    {
        Console.WriteLine("B is zero, aborting...");
        return 0;
    }

    return A / (float)B;
}

double Exponenciacao(double baseNum, double expoente)
{
    return Math.Pow(baseNum, expoente);
}

var div = Divisao(A, B);
Console.WriteLine(Exponenciacao(div, 3));


//SWITCH STATEMENT
var option = 3;

switch (option)
{
    case 1:
        Console.WriteLine("10% off");
        break; // keyword
    case 2:
        Console.WriteLine("5% off");
        break; // keyword
    case 3:
        Console.WriteLine("full price");
        break;
    case 4:
        Console.WriteLine("10% interest rate");
        break;
    default:
        Console.WriteLine("Invalid option");
        break;
}

Console.Clear(); // clear everything on the terminal

var index = 0;
//   ARRAYS                               0   1   2   3
var numbers = new double[3]; // "abc" = ['a','b','c']

// FOR LOOP
for (index = 0; index < numbers.Length; index += 1)
{
    Console.WriteLine($"Type value {index + 1}: ");
    var input = Console.ReadLine();

    var value = double.Parse(input);

    // numbers[0] = 10
    numbers[index] = value; // colocando
}

index = 0;

while (index < numbers.Length)
{
    var value = numbers[index]; // lendo
    Console.WriteLine($"Result {index + 1} = {value} + {value} = {value + value}");

    index += 1;
}

// do
// {
//     // DO SOMETHING THEN CHECK CONDITION
// } while (true);

// LIST

var list = new List<double>();

list.Add(2);
list.Add(21);
list.Add(3);

for (index = 0; index < list.Count; index += 1)
{
    // do something
}


