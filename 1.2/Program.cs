using System;
using System.Numerics;

class Ejer
{
    static void Main(string[] args)
    {
        //1

        /*Console.Write("Ingrese un número entero: ");
        int entero = int.Parse(Console.ReadLine()!);

        Console.Write("Ingrese un número real: ");
        double real = double.Parse(Console.ReadLine()!);

        double producto = entero * real;
        Console.WriteLine($"{producto:F2}\n");



        Console.Write("ingrese el valor del radio");
        double r=double.Parse(Console.ReadLine()!);
        double area=3.14*r*r;
        Console.WriteLine($"\nEl area del circulo es:{area}");




        Console.Write("ingrese el valor de a");
        double a=double.Parse(Console.ReadLine()!);

        Console.Write("ingrese el valor de b");
        double b=double.Parse(Console.ReadLine()!);

        Console.Write("ingrese el valor de c");
        double c=double.Parse(Console.ReadLine()!);

        double d = (b * b) - (4 * a * c);

        double raiz1 = (-b + Math.Sqrt(d)) / (2 * a);
        double raiz2 = (-b - Math.Sqrt(d)) / (2 * a);

        Console.Write($"\nRaíz 1: {raiz1}");
        Console.Write($"Raíz 2: {raiz2}");




        Console.Write("Introduce tu nombre: ");
        string nombre = Console.ReadLine()!;

        Console.Write("Introduce tu edad: ");
        int edad = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"\nTe llamas {nombre} y tienes {edad} años.");



        Console.Write("Introduce un numero: ");
        int numero = int.Parse(Console.ReadLine()!);

        int cuadrado = numero * numero;

        Console.WriteLine($"El cuadrado de {numero} es: {cuadrado}");

        

        Console.Write("Introduce los euros: ");
        double euros = double.Parse(Console.ReadLine()!);

        int centimos = (int)Math.Round(euros * 100);

        Console.WriteLine("\nMonedas necesarias:");

        int m2euros = centimos / 200;
        centimos = centimos % 200;
        if (m2euros > 0) Console.WriteLine($"- 2 euros: {m2euros}");

        int m1euro = centimos / 100;
        centimos = centimos % 100;
        if (m1euro > 0) Console.WriteLine($"- 1 euro: {m1euro}");

        int m50cts = centimos / 50;
        centimos = centimos % 50;
        if (m50cts > 0) Console.WriteLine($"- 50 céntimos: {m50cts}");

        int m20cts = centimos / 20;
        centimos = centimos % 20;
        if (m20cts > 0) Console.WriteLine($"- 20 céntimos: {m20cts}");

        int m10cts = centimos / 10;
        centimos = centimos % 10;
        if (m10cts > 0) Console.WriteLine($"- 10 céntimos: {m10cts}");

        int m5cts = centimos / 5;
        centimos = centimos % 5;
        if (m5cts > 0) Console.WriteLine($"- 5 céntimos: {m5cts}");

        int m2cts = centimos / 2;
        centimos = centimos % 2;
        if (m2cts > 0) Console.WriteLine($"- 2 céntimos: {m2cts}");

        int m1ct = centimos;
        if (m1ct > 0) Console.WriteLine($"- 1 céntimo: {m1ct}");*/



        //2

        /*Console.Write("Introduce un numero: ");
        int num = int.Parse(Console.ReadLine()!);

        if(num % 2 == 0)
        {
            Console.WriteLine("Es par");
        }
        else
        {
            Console.WriteLine("Es impar");
        }


        Console.Write("Introduce tu edad: ");
        int anos = int.Parse(Console.ReadLine()!);

        Console.Write("Introduce un numero: ");
        string esmayor = Console.ReadLine();

        Console.Write("Introduce un numero: ");
        string tienecarne = Console.ReadLine();


        Console.Write("Introduce un numero: ");
        double a = double.Parse(Console.ReadLine()!);

        Console.Write("Introduce un numero: ");
        double b = double.Parse(Console.ReadLine()!);

        Console.Write("Introduce un numero: ");
        double c = double.Parse(Console.ReadLine()!);

        if((a<b) && (a < c))
        {
            Console.WriteLine(a);
        } else if((b<a) && (b < c))
        {
            Console.WriteLine(b);
        }
        else
        {
            Console.WriteLine(c);
        }

        Console.Write("Introduce el primer número: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Introduce el segundo número: ");
        double num2 = double.Parse(Console.ReadLine());

        Console.Write("Introduce el tercer número: ");
        double num3 = double.Parse(Console.ReadLine());

        double menor = num1;

        if (num2 < menor)
        {
            menor = num2;
        }

        if (num3 < menor)
        {
            menor = num3;
        }

        Console.WriteLine($"\nEl menor de los tres números es: {menor}");*/


        //estas tu q hago esta

        //lo mismo

        //3

        /*int par;
        do
        {
            Console.Write("Introduce un numero: ");
            par = int.Parse(Console.ReadLine()!);
        }while(par%2==0);


        Console.Write("Introduce un numero menor a 1000: ");
        int n = int.Parse(Console.ReadLine()!);

        Console.Write("Introduce un numero entre 2 y 10: ");
        int k = int.Parse(Console.ReadLine()!);

        int cont=0;
 
        while (n % k == 0)
        {
            n=n/k;
            cont++;
        }
        Console.WriteLine(cont);


        Console.Write("Introduce un numero entero: ");
        int numero = int.Parse(Console.ReadLine()!);

        bool esPrimo = true;

        if (numero <= 1)
        {
            esPrimo = false;
        }
        else
        {
            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    esPrimo = false;           
                }
            }
        }

        if (esPrimo)
        {
            Console.WriteLine("El numero es primo.");
        }
        else
        {
            Console.WriteLine("El numero no es primo.");
        }*/



        //4

        /*int[] numeros = new int[10];

        int max = 0;
        int min = 99999;
        int pmax = 0;
        int pmin = 0;

        Console.WriteLine("escribe 10 numeros");
        
        for(int i = 0; i < 10; i++)
        {
            numeros[i] = Convert.ToInt32(Console.ReadLine());
        

            if (numeros[i] > max)
                {
                    max = numeros[i];
                    pmax = i;
                }

                if (numeros[i] < min)
                {
                    min = numeros[i];
                    pmin = i;
                }

        }

        Console.WriteLine($"El valor máximo es {max} y está en la posición (índice) {pmax}.");
        Console.WriteLine($"El valor mínimo es {min} y está en la posición (índice) {pmin}.");


        Random random = new Random();
        int[] numeros = new int[20];
        List<int> primosList = new List<int>();

        for (int i = 0; i < numeros.Length; i++)
        {
            numeros[i] = random.Next(0, 100); 
        }
        Console.WriteLine(numeros));


        int[] array1 = new int[5];
        int[] array2 = new int[5];
        int[] array3 = new int[5];

        Console.WriteLine("Valores para array1:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"array1[{i}]: ");
            array1[i] = int.Parse(Console.ReadLine()!);
        }

        Console.WriteLine("\nValores para array2:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"array2[{i}]: ");
            array2[i] = int.Parse(Console.ReadLine()!);
        }

        for (int i = 0; i < 5; i++)
        {
            array3[i] = array1[i] + array2[i];
        }

        Console.WriteLine("\nResultado (array3):");
        Console.WriteLine(string.Join(", ", array3));*/



        
    }    
}