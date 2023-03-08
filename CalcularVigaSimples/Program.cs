using CalcularVigaSimples.Entities;
using System;
using System.Data;
using System.Reflection.Emit;

class Program
{
    static void Main(string[] args)
    {
        Tabela tab1 = new Tabela();

        // Solicitando informações sobre a viga
        Console.WriteLine("DADOS DA VIGA COM AÇO CA-50:");
        Console.WriteLine();

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
                
        int valor = tab1.BuscarLinha(aco.Kmd());
        Console.WriteLine();
        Console.WriteLine($"Coeficiente do momento fletor encontrado (Kmd): {aco.Kmd():F3}");
        tab1.ExibirLinha(valor);
        double kx = aco.LinhaNeutra(tab1.ValorKx(valor));
        double kz = aco.AreaAco(tab1.ValorKz(valor));

        // Imprimindo resultados
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("RESULTADOS:");
        Console.WriteLine();
        Console.WriteLine($"Momento na viga: {viga.MomentoViga():F2} kN/m");
        Console.WriteLine($"Momento na alvenaria: {alvenaria.MomentoAlvenaria():F2} kN/m");        
        Console.WriteLine($"Altura útil da viga: {aco.AltUtil():F2} cm");     
        Console.WriteLine($"Profundidade da linha neutra: {aco.LinhaNeutra(tab1.ValorKx(valor)):F2} cm");
        Console.WriteLine($"Valor da área do aço: {aco.AreaAco(tab1.ValorKz(valor)):F2} cm²");

        Console.ReadKey();

    }
}