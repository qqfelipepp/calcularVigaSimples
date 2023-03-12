namespace CalcularVigaSimples.Entities;
class Viga
{
    public double Altura { get; internal set; }
    public double Largura { get; internal set; }
    public double Comprimento { get; internal set; }

    public Viga(double largura, double altura, double comprimento)
    {
        Largura = largura;
        Altura = altura;
        Comprimento = comprimento;
    }

    public double MomentoViga()
    {
        double pesoEspecifico = 25;
        return Largura * Altura * pesoEspecifico / 10000;
    }

}