using System;

namespace CalculoDaViga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a largura da viga (em cm): ");
            double l = double.Parse(Console.ReadLine());

            Console.Write("Digite a altura da viga (em cm): ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Digite a altura da alvenaria (em cm): ");
            double alv = double.Parse(Console.ReadLine());

            double pesoViga = new CalculadoraDePesoConcreto().CalcularPeso(l, a);
            double pesoAlvenaria = new CalculadoraDePesoAlvenaria().CalcularPeso(l, alv);

            double pesoTotal = pesoViga + pesoAlvenaria;

            Console.WriteLine();
            Console.WriteLine($"Peso da viga: {pesoViga:N2} kN/m");
            Console.WriteLine($"Peso da alvenaria: {pesoAlvenaria:N2} kN/m");
            Console.WriteLine($"Peso total: {pesoTotal:N2} kN/m");

            Console.ReadKey();
        }
    }
}