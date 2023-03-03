using CalcularVigaSimples.Entities;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Solicitando informações sobre a viga
        Console.Write("Informe a largura da viga (cm): ");
        double larguraViga = double.Parse(Console.ReadLine());
        Console.Write("Informe a altura da viga (cm): ");
        double alturaViga = double.Parse(Console.ReadLine());
        Console.Write("Informe o comprimento da viga (m): ");
        double comprimentoViga = double.Parse(Console.ReadLine());

        // Solicitando altura da alvenaria
        Console.Write("Informe a altura da alvenaria (cm): ");
        double alturaAlvenaria = double.Parse(Console.ReadLine());

        // Solicitando informações sobre o aço
        Console.Write("Informe o diâmetro da armadura longitudinal (mm): ");
        double diametroLongitudinal = double.Parse(Console.ReadLine());
        Console.Write("Informe o diâmetro do estribo (mm): ");
        double diametroEstribo = double.Parse(Console.ReadLine());
        Console.Write("Informe o valor do fck (em MPa): ");
        double fck = double.Parse(Console.ReadLine());

        // Instanciando objetos
        Viga viga = new Viga(larguraViga, alturaViga, comprimentoViga);
        Alvenaria alvenaria = new Alvenaria(larguraViga, alturaAlvenaria);
        Aco aco = new Aco(viga, alvenaria, diametroLongitudinal, diametroEstribo, fck);

        // Imprimindo resultados
        Console.WriteLine();
        Console.WriteLine($"Momento da Viga: {viga.MomentoViga():F2} kN/m");
        Console.WriteLine($"Momento da Alvenaria: {alvenaria.MomentoAlvenaria():F2} kN/m");
        Console.WriteLine($"Altura útil da viga: {aco.AltUtil():F2} cm");
        Console.WriteLine($"Coeficiente do momento fletor (Kmd): {aco.Kmd():F3}");
    }
}