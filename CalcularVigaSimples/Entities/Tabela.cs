namespace CalcularVigaSimples.Entities
{
    class Tabela
    {

        public double[][] tab1 = new double[][]
        {
            new double[] {0.000, 0.000, 1.000, 0.000, 10.000},
            new double[] {0.005, 0.007, 0.917, 0.007, 10.000},
            new double[] {0.010, 0.015, 0.994, 0.150, 10.000},
            new double[] {0.015, 0.022, 0.991, 0.230, 10.000},
            new double[] {0.020, 0.030, 0.988, 0.310, 10.000},
            new double[] {0.025, 0.037, 0.985, 0.390, 10.000},
            new double[] {0.030, 0.045, 0.982, 0.470, 10.000},
            new double[] {0.035, 0.053, 0.979, 0.550, 10.000},
            new double[] {0.040, 0.060, 0.976, 0.640, 10.000},
            new double[] {0.045, 0.068, 0.973, 0.730, 10.000},
            new double[] {0.050, 0.076, 0.970, 0.820, 10.000},
            new double[] {0.055, 0.084, 0.967, 0.910, 10.000},
            new double[] {0.060, 0.092, 0.963, 1.010, 10.000},
            new double[] {0.065, 0.100, 0.960, 1.110, 10.000},
            new double[] {0.070, 0.108, 0.957, 1.210, 10.000},
            new double[] {0.075, 0.116, 0.954, 1.310, 10.000},
            new double[] {0.080, 0.124, 0.950, 1.410, 10.000},
            new double[] {0.085, 0.132, 0.947, 1.520, 10.000},
            new double[] {0.090, 0.140, 0.944, 1.630, 10.000},
            new double[] {0.095, 0.149, 0.941, 1.740, 10.000},
            new double[] {0.100, 0.157, 0.937, 1.860, 10.000},
            new double[] {0.105, 0.165, 0.934, 1.980, 10.000},
            new double[] {0.110, 0.174, 0.930, 2,100, 10.000},
            new double[] {0.115, 0.182, 0.927, 2.230, 10.000},
            new double[] {0.120, 0.191, 0.924, 2.360, 10.000},
            new double[] {0.125, 0.200, 0.920, 2.500, 10.000},
            new double[] {0.130, 0.209, 0.917, 2.640, 10.000},
            new double[] {0.135, 0.217, 0.913, 2.780, 10.000},
            new double[] {0.140, 0.226, 0.909, 2.930, 10.000},
            new double[] {0.145, 0.235, 0.906, 3.080, 10.000},
            new double[] {0.150, 0.244, 0.902, 3.240, 10.000},
        };

        public double[][] tab2 = new double[][]
        {
           new double[] {20.0, 25.0, 30.0, 35.0, 40.0, 45.0, 50.0, 55.0, 60.0, 65.0, 70.0, 75.0, 80.0, 85.0, 90.0},
           new double[] {0.150, 0.150, 0.150, 0.164, 0.179, 0.194, 0.208, 0.211, 0.219, 0.226, 0.233, 0.239, 0.245, 0.251, 0.256},
        };

        public int BuscarLinhaTab1(double x)
        {
            int linha = -1;

            for (int i = 0; i < tab1.Length; i++)
            {
                if (tab1[i][0] == x)
                {
                    linha = i;
                    break;
                }
                else if (tab1[i][0] > x)
                {
                    linha = i;
                    break;
                }
            }

            return linha;
        }

        public int BuscarColunaTab2(double x)
        {
            int coluna = -1;

            for (int i = 0; i < tab1.Length; i++)
            {
                if (tab2[0][i] == x)
                {
                    coluna = i;
                    break;
                }
                else if (tab2[0][i] > x)
                {
                    coluna = i;
                    break;
                }
            }

            return coluna;
        }

        public void ExibirLinhaTab1(int linha)
        {
            if (linha == -1)
            {
                Console.WriteLine("Valor não encontrado na tabela");
                return;
            }
            Console.WriteLine("Kmd   Kx    Kz    Ec    Es");
            Console.WriteLine(string.Join(" ", tab1[linha].Select(valor => valor.ToString("F3"))));
        }

        public void ExibirValoresColunaEncontradaTab2(int coluna)
        {
            double larg = tab2[0][coluna];
            double pmin = tab2[1][coluna];
            Console.WriteLine($"Largura: {larg}");
            Console.WriteLine($"p Mim.:  {pmin:F3}");
        }

        public double ValorKmd(int linha)
        {
            double Kmd = tab1[linha][0];
            return Kmd;
        }

        public double ValorKx(int linha)
        {
            double Kx = tab1[linha][1];
            return Kx;
        }
        public double ValorKz(int linha)
        {
            double Kz = tab1[linha][2];
            return Kz;
        }

        public double Pmin(int coluna)
        {
            double pmin = tab2[1][coluna];
            return pmin;
        }

    }
}
