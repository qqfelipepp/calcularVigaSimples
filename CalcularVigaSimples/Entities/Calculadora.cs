namespace CalcularVigaSimples.Entities;
class Calculadora
{    
    private Viga viga;
    private Alvenaria alvenaria;
    private double diametroLongitudinal;
    private double diametroEstribo;
    private double fck;
       

    public Calculadora(Viga viga, Alvenaria alvenaria, double diametroLongitudinal, double diametroEstribo, double fck)
    {
        this.viga = viga;
        this.alvenaria = alvenaria;
        this.diametroLongitudinal = diametroLongitudinal;
        this.diametroEstribo = diametroEstribo;
        this.fck = fck;
    }

    public double MomentoFletor()
    {
        double momentoViga = viga.MomentoViga();
        double momentoAlvenaria = alvenaria.MomentoAlvenaria();
        double soma = momentoViga + momentoAlvenaria;
        double mf = soma * Math.Pow(viga.Comprimento, 2) / 8.0;
        return mf;
    }

    public double AltUtil()
    {
        double c = 2.5;
        double d1 = diametroLongitudinal / 10;
        double d2 = diametroEstribo / 10;
        double alturaUtil = viga.Altura - (c + d1 / 2.0 + d2);
        return alturaUtil;
    }

    public double Kmd()
    {
        double md = MomentoFletor() * 1.4;
        double largura = viga.Largura;
        double alturaUtil = AltUtil();
        double fckN = (fck / 1000.0) / 1.4;
        double kmd = md / (largura * Math.Pow(alturaUtil, 2) * (fckN));
        return kmd;
    }

    public double LinhaNeutra(double kx)
    {        
        return AltUtil() * kx;
    }

    public double AreaAco(double kz)
    {        
        double md = MomentoFletor() * 1.4;
        double alturaUtil = AltUtil() / 100;
        double ys = 1.15;//Coeficiente de ponderação da resistencia do Aço CA-50 conforme tabela 17.3 da NBR 6118:2014
        double fyd = 50 / ys;
        double areaAco = md / (kz * alturaUtil * fyd);
        return areaAco;
    }

    public double AreaMin(double pMin)
    {        
        double asMin = pMin * (viga.Largura * viga.Altura) / 100;
        return asMin;
    }

}

