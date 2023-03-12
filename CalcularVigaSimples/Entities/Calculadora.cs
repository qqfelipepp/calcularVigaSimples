namespace CalcularVigaSimples.Entities;
class Calculadora
{    
    private Viga viga;
    private Alvenaria alvenaria;
    private double diametroLongitudinal;
    private double diametroEstribo;
    private double fck;
    private double brita;


    public Calculadora(Viga viga, Alvenaria alvenaria, double diametroLongitudinal, double diametroEstribo, double fck, int brita)
    {
        this.viga = viga;
        this.alvenaria = alvenaria;
        this.diametroLongitudinal = diametroLongitudinal;
        this.diametroEstribo = diametroEstribo;
        this.fck = fck;
        this.brita = brita;
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

    public double AreaAdotada(double kz, double pMin)
    {
        //Calculo da Área de Aço
        double md = MomentoFletor() * 1.4;
        double alturaUtil = AltUtil() / 100;
        double ys = 1.15;//Coeficiente de ponderação da resistencia do Aço CA-50 conforme tabela 17.3 da NBR 6118:2014
        double fyd = 50 / ys;
        double areaAco = md / (kz * alturaUtil * fyd);

        //Cálculo da área mínima de aço(NBR 6118:2014)
        double asMin = pMin * (viga.Largura * viga.Altura) / 100;

        double areaAdotada;
        areaAdotada = areaAco > asMin ? areaAco : asMin;
        return areaAdotada;
    }

    public double Agregado()
    {
        double b = brita;
        if (b == 0)
        {
            b = 9.5;
        }
        if (b == 1)
        {
            b = 19.0;
        }
        if (b == 2)
        {
            b = 38.0;
        }
        if (b == 3)
        {
            b = 76.0;
        }
        return b;
    }

    public double Eh(double acoAdotado, double qte)
    {
        double a = viga.Largura;
        double b = 2 * 2.5;
        double c = 2 * diametroEstribo / 10;
        double q = qte;
        double d = qte * acoAdotado / 10;
        double e = 1.2 * Agregado() / 10;


        double eh = (a - (b + c + d)) / (q - 1.00);

        if (eh > 2 && eh > c && eh > e)
        {
            eh = eh + 0.00;
        }

        return eh;
    }

    public double TxAco(double aco, double qte)
    {
        double r = aco / 2;
        double area = (Math.PI * Math.Pow(r, 2));
        double q = qte + 2;

        double txAco = ((area * q) / (viga.Largura * viga.Altura));
        return txAco;
    }

}

