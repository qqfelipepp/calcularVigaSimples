using CalcularVigaSimples.Entities;
using System;
using System.Data;
using System.Reflection.Emit;

class Program
{
    static void Main(string[] args)
    {       
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
        Calculadora aco = new Calculadora(viga, alvenaria, diametroLongitudinal, diametroEstribo, fck);
        Tabela tab1 = new Tabela();
        Tabela tab2 = new Tabela();

        int valor = tab1.BuscarLinhaTab1(aco.Kmd());
        int valor2 = tab2.BuscarColunaTab2(larguraViga);
        Console.WriteLine();
        Console.WriteLine($"Coeficiente do momento fletor encontrado (Kmd): {aco.Kmd():F3}");
        tab1.ExibirLinhaTab1(valor);        
        tab2.ExibirValoresColunaEncontradaTab2(valor2);
        double kx = aco.LinhaNeutra(tab1.ValorKx(valor));
        double kz = aco.AreaAco(tab1.ValorKz(valor));
        double asMin = aco.AreaMin(tab2.Pmin(valor2));
        
        // Imprimindo resultados
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("RESULTADOS:");
        Console.WriteLine();
        Console.WriteLine($"Momento na viga: {viga.MomentoViga():F2} kN/m");
        Console.WriteLine($"Momento na alvenaria: {alvenaria.MomentoAlvenaria():F2} kN/m");        
        Console.WriteLine($"Altura útil da viga: {aco.AltUtil():F2} cm");     
        Console.WriteLine($"Profundidade da linha neutra: {aco.LinhaNeutra(tab1.ValorKx(valor)):F2} cm");
        Console.WriteLine($"Área de aço encontrada: {aco.AreaAco(tab1.ValorKz(valor)):F2} cm²");
        Console.WriteLine($"Área de aço mínima (NBR 6118): {aco.AreaMin(tab2.Pmin(valor2)):F2} cm²");
        Console.ReadKey();

    }
}