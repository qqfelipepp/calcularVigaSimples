using CalculoDaViga;

class CalculadoraDePesoAlvenaria : ICalculadoraDePeso
{
    public double CalcularPeso(double largura, double altura)
    {
        double area = (largura / 100) * (altura / 100);
        double pesoEspecifico = 13;
        double peso = area * pesoEspecifico;
        return peso;
    }
}
