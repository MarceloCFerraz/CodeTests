
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