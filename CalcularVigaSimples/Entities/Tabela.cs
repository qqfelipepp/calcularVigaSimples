namespace CalcularVigaSimples.Entities
{
    class Tabela
    {
        //Tabela de Dimensionamento de Seção Retangular de acordo com a NBR 6118:2014
        public double[,] tab1 = new double[33, 5]
        {
            { 0.000, 0.000, 1.000, 0.000, 10.000 },
            { 0.005, 0.007, 0.917, 0.007, 10.000 },
            { 0.010, 0.015, 0.994, 0.150, 10.000 },
            { 0.015, 0.022, 0.991, 0.230, 10.000 },
            { 0.020, 0.030, 0.988, 0.310, 10.000 },
            { 0.025, 0.037, 0.985, 0.390, 10.000 },
            { 0.030, 0.045, 0.982, 0.470, 10.000 },
            { 0.035, 0.053, 0.979, 0.550, 10.000 },
            { 0.040, 0.060, 0.976, 0.640, 10.000 },
            { 0.045, 0.068, 0.973, 0.730, 10.000 },
            { 0.050, 0.076, 0.970, 0.820, 10.000 },
            { 0.055, 0.084, 0.967, 0.910, 10.000 },
            { 0.060, 0.092, 0.963, 1.010, 10.000 },
            { 0.065, 0.100, 0.960, 1.110, 10.000 },
            { 0.070, 0.108, 0.957, 1.210, 10.000 },
            { 0.075, 0.116, 0.954, 1.310, 10.000 },
            { 0.080, 0.124, 0.950, 1.410, 10.000 },
            { 0.085, 0.132, 0.947, 1.520, 10.000 },
            { 0.090, 0.140, 0.944, 1.630, 10.000 },
            { 0.095, 0.149, 0.941, 1.740, 10.000 },
            { 0.100, 0.157, 0.937, 1.860, 10.000 },
            { 0.105, 0.165, 0.934, 1.980, 10.000 },
            { 0.110, 0.174, 0.930, 2.100, 10.000 },
            { 0.115, 0.182, 0.927, 2.230, 10.000 },
            { 0.120, 0.191, 0.924, 2.360, 10.000 },
            { 0.125, 0.200, 0.920, 2.500, 10.000 },
            { 0.130, 0.209, 0.917, 2.640, 10.000 },
            { 0.135, 0.217, 0.913, 2.780, 10.000 },
            { 0.140, 0.226, 0.909, 2.930, 10.000 },
            { 0.145, 0.235, 0.906, 3.080, 10.000 },
            { 0.150, 0.244, 0.902, 3.240, 10.000 },
            { 0.155, 0.254, 0.899, 3.400, 10.000 },
            { 0.158, 0.259, 0.896, 3.500, 10.000 },//Devo terminar de completar esta tabela
        };

        //Tabela 17.3 - Taxas mínimas de armadura de flexão para vigas (NBR 6118:2014)
        public double[,] tab2 = new double[2, 15]
        {
           {20.0, 25.0, 30.0, 35.0, 40.0, 45.0, 50.0, 55.0, 60.0, 65.0, 70.0, 75.0, 80.0, 85.0, 90.0},
           { 0.150, 0.150, 0.150, 0.164, 0.179, 0.194, 0.208, 0.211, 0.219, 0.226, 0.233, 0.239, 0.245, 0.251, 0.256},
        };

        //Tabela de área de aço
        public double[,] tab3 = new double[2, 9]
       {
           {4.200, 5.000, 6.30, 8.00, 10.00, 12.50, 16.00, 20.00, 25.00}, //diâmentro em mm
           {0.138, 0.196, 0.31, 0.50, 0.790, 1.230, 2.010, 3.140, 4.910}, //área em cm²
       };

        //tabela de agregados (Tipos de Brita)      
        public double[][] tab4 = new double[][]
       {
           new double[] {0.0, 1.0, 2.0, 3.0}, //diâmentro em mm
           new double[] {9.50, 19.0, 38.0, 76.0}, //área em cm²
       };

        public int Tab1(double x)
        {
            int linha = -1;

            for (int i = 0; i < tab1.Length; i++)
            {
                if (tab1[i, 0] == x)
                {
                    linha = i;
                    break;
                }
                else if (tab1[i, 0] > x)
                {
                    linha = i;
                    break;
                }
            }

            return linha;
        }

        public int Tab2(double x)
        {
            int coluna = -1;

            for (int i = 0; i < tab1.Length; i++)
            {
                if (tab2[0, i] == x)
                {
                    coluna = i;
                    break;
                }
                else if (tab2[0, i] > x)
                {
                    coluna = i;
                    break;
                }
            }

            return coluna;
        }

        public int Tab3(double alturaViga, double alturaUtil, double areaAdotada)
        {
            double dl = alturaViga - alturaUtil;
            double a = areaAdotada;

            int coluna = -1;

            for (int i = 0; i < tab3.Length; i++)
            {

                if ((a / tab3[1, i]) < dl)
                {
                    coluna = i;
                    break;
                }
            }
            return coluna;
        }

        public void Tab1Linha(int linha)
        {
            if (linha == -1)
            {
                Console.WriteLine("Valor não encontrado na tabela");
                return;
            }
            Console.WriteLine("Kmd   Kx    Kz    Ec    Es");
            for (int j = 0; j < 5; j++)
            {
                Console.Write("{0:F3} ", tab1[linha, j]);

            }
        }

        public void Tab2Valores(int coluna)
        {
            double larg = tab2[0, coluna];
            double pmin = tab2[1, coluna];
            Console.WriteLine();
            Console.WriteLine($"Largura: {larg}");
            Console.WriteLine($"p Mim.:  {pmin}");
        }

        public void Tab3Valores(int coluna, double areaEncontrada)
        {
            double aco = tab3[0, coluna];
            double qte = Math.Ceiling(areaEncontrada / tab3[1, coluna]);
            Console.WriteLine();
            Console.WriteLine("Serão utilizados " + qte + " aços longitudinais de Ø" + aco + "mm na parte inferior da viga");
            Console.WriteLine("e 2 aços longitudinais de Ø" + aco + "mm na parte superior da viga");
        }

        public double ValorKmd(int linha)
        {
            double Kmd = tab1[linha, 0];
            return Kmd;
        }

        public double ValorKx(int linha)
        {
            double Kx = tab1[linha, 1];
            return Kx;
        }
        public double ValorKz(int linha)
        {
            double Kz = tab1[linha, 2];
            return Kz;
        }

        public double Pmin(int coluna)
        {
            double pmin = tab2[1, coluna];
            return pmin;
        }

        public double Aco(int coluna)
        {
            double Aco = tab3[0, coluna];
            return Aco;
        }
        public double Qte(int coluna, double areaEncontrada)
        {
            double qte = Math.Ceiling(areaEncontrada / tab3[1, coluna]);
            return qte;
        }

    }
}
