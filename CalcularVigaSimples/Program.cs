using CalcularVigaSimples.Entities;
using System;
using System.Data;
using System.Reflection.Emit;

class Program
{
    static void Main(string[] args)
    {
        // Solicitando informações sobre a viga
        Console.Write("Informe a largura da viga (cm): ");
        double largura = double.Parse(Console.ReadLine());
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
        Console.Write("Informe o valor do fck do aço (em MPa): ");
        double fck = double.Parse(Console.ReadLine());
        Console.Write("Informe o número do tipo de brita que será utilizada: ");
        Console.Write("Escolha um número de 0 a 3: ");
        int brita = int.Parse(Console.ReadLine());

        // Instanciando objetos
        Viga viga = new Viga(largura, alturaViga, comprimentoViga);
        Alvenaria alvenaria = new Alvenaria(largura, alturaAlvenaria);
        Calculadora aco = new Calculadora(viga, alvenaria, diametroLongitudinal, diametroEstribo, fck, brita);
        Tabela tab = new Tabela();

        int kmd = tab.Tab1(aco.Kmd());
        int pMin = tab.Tab2(largura);
        Console.WriteLine();
        Console.WriteLine($"Coeficiente do momento fletor encontrado (Kmd): {aco.Kmd():F3}");
        tab.Tab1Linha(kmd);
        tab.Tab2Valores(pMin);
        double kx = aco.LinhaNeutra(tab.ValorKx(kmd));
        double areaAdotada = aco.AreaAdotada(tab.ValorKz(kmd), tab.Pmin(pMin));
        int acoAdotado = tab.Tab3(alturaViga, aco.AltUtil(), areaAdotada);
        tab.Tab3Valores(acoAdotado, areaAdotada);
        double x1 = tab.Aco(acoAdotado);
        double x2 = tab.Qte(acoAdotado, areaAdotada);
        double txAco = aco.TxAco(x1, x2);


        // Imprimindo resultados
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("RESULTADOS:");
        Console.WriteLine();
        Console.WriteLine($"Momento na viga: {viga.MomentoViga():F2} kN/m");
        Console.WriteLine($"Momento na alvenaria: {alvenaria.MomentoAlvenaria():F2} kN/m");
        Console.WriteLine($"Altura útil da viga: {aco.AltUtil()} cm");
        Console.WriteLine($"Profundidade da linha neutra: {kx:F2} cm");
        Console.WriteLine($"Área de aço adotada: {areaAdotada:F2} cm²");
        Console.WriteLine($"Espaçamento horizontal: {aco.Eh(x1, x2)} cm");
        Console.WriteLine($"Taxa de aço: {aco.TxAco(x1, x2):F2} %");
        Console.ReadKey();

    }
}