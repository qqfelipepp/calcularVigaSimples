namespace CalcularVigaSimples.Entities;
class Alvenaria
{
    private double largura;
    private double altura;

    public Alvenaria(double largura, double altura)
    {
        this.largura = largura;
        this.altura = altura;
    }

    public double MomentoAlvenaria()
    {
        double pesoEspecifico = 13;
        return largura * altura * pesoEspecifico/10000;
    }
}

