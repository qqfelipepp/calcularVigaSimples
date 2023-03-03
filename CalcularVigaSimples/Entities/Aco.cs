namespace CalcularVigaSimples.Entities;
class Aco
{
    private Viga viga;
    private Alvenaria alvenaria;
    private double diametroLongitudinal;
    private double diametroEstribo;
    private double fck;

    public Aco(Viga viga, Alvenaria alvenaria, double diametroLongitudinal, double diametroEstribo, double fck)
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
        double md = MomentoFletor();
        double largura = viga.Largura;
        double alturaUtil = AltUtil();
        double fckN = fck * 1000.0 / 1.4;
        double kmd = 1.4 * md / (largura * Math.Pow(alturaUtil, 2) * (fck / 1.4/1000));
        return kmd;
    }
}

