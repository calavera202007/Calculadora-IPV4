namespace Calculadora
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public static int[] decimalBinario(int numero)
        {
            int i = 0;
            int[] array = new int[8];
            while (numero > 0)
            {
                array[i] = numero % 2;
                numero = numero / 2;
                i = i + 1;
            }
            return array;

        }

        public static int binarioDecimal(int binario)
        {
            int numero = 0;
            int digito = 0;
            const int DIVISOR = 10;
            for (long i = binario, j = 0; i > 0; i /= DIVISOR, j++)
            {
                digito = (int)i % DIVISOR;
                if (digito != 1 && digito != 0)
                {
                    return -1;
                }
                numero += digito * (int)Math.Pow(2, j);
            }
            return numero;
        }

        public static int conversion(int[] array)
        {
            string temporal = String.Join("", array);
            int numero = Int32.Parse(temporal);
            return numero;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            int n, n2, n3, n4, r, r2, prefijo, i;
            n = Convert.ToInt32(txtn.Text);
            n2 = Convert.ToInt32(txtn2.Text);
            n3 = Convert.ToInt32(txtn3.Text);
            n4 = Convert.ToInt32(txtn4.Text);
            prefijo = Convert.ToInt32(txtprefijo.Text);
            int[] bin1 = new int[8];
            int[] bin2 = new int[8];
            int[] bin3 = new int[8];
            int[] bin4 = new int[8];
            int[] binid1 = new int[8];
            int[] binid2 = new int[8];
            int[] binid3 = new int[8];
            int[] binid4 = new int[8];
            int[] binbroad1 = new int[8];
            int[] binbroad2 = new int[8];
            int[] binbroad3 = new int[8];
            int[] binbroad4 = new int[8];
            /////////////Error Prefijo
            if ((n >= 0 && n <= 127) && prefijo >= 8 || (n >= 128 && n <= 191) && prefijo >= 16 || (n >= 192 && n <= 223) && prefijo >= 24)
            {
                /////////////Calculo Subredes
                r = prefijo / 8;
                r2 = prefijo - (r * 8);
                double totalsubred = Math.Pow(2, r2);
                txtsubredes.Text = Convert.ToString(totalsubred);
                /////////////Calculo Host
                int elevado = 0;
                elevado = 32 - prefijo;
                double totalhost = (Math.Pow(2, elevado)) - 2;
                txthost.Text = Convert.ToString(totalhost);

                binid1 = decimalBinario(n);
                binid2 = decimalBinario(n2);
                binid3 = decimalBinario(n3);
                binid4 = decimalBinario(n4);
                Array.Reverse(binid1);
                Array.Reverse(binid2);
                Array.Reverse(binid3);
                Array.Reverse(binid4);
                for (i = 0; i < 8; i++)
                {
                    bin1[i] = 1;

                }
                //2do octeto
                if (r == 1 && r2 != 0)
                {
                    for (i = 0; i < 8; i++)
                    {

                        bin2[i] = 0;
                        bin3[i] = 0;
                        bin4[i] = 0;
                    }
                    for (i = 0; i < r2; i++)
                    {
                        bin2[i] = 1;
                    }
                    for (i = 0; i < 8; i++)
                    {
                        binid1[i] = binid1[i] * bin1[i];
                        binid2[i] = binid2[i] * bin2[i];
                        binid3[i] = binid3[i] * bin3[i];
                        binid4[i] = binid4[i] * bin4[i];
                        binbroad1[i] = binid1[i];
                        binbroad2[i] = binid2[i];
                        binbroad3[i] = binid3[i];
                        binbroad4[i] = binid4[i];
                    }
                    for (i = r2; i < 8; i++)
                    {
                        binbroad2[i] = 1;
                    }
                    for (i = 0; i < 8; i++)
                    {
                        binbroad3[i] = 1;
                        binbroad4[i] = 1;
                    }
                    int octmac1 = conversion(bin1);
                    int octmac2 = conversion(bin2);
                    int octmac3 = conversion(bin3);
                    int octmac4 = conversion(bin4);
                    int ip1 = binarioDecimal(octmac1);
                    int ip2 = binarioDecimal(octmac2);
                    int ip3 = binarioDecimal(octmac3);
                    int ip4 = binarioDecimal(octmac4);
                    int oct1 = conversion(binid1);
                    int oct2 = conversion(binid2);
                    int oct3 = conversion(binid3);
                    int oct4 = conversion(binid4);
                    int numid1 = binarioDecimal(oct1);
                    int numid2 = binarioDecimal(oct2);
                    int numid3 = binarioDecimal(oct3);
                    int numid4 = binarioDecimal(oct4);
                    int octbroad1 = conversion(binbroad1);
                    int octbroad2 = conversion(binbroad2);
                    int octbroad3 = conversion(binbroad3);
                    int octbroad4 = conversion(binbroad4);
                    int numbroad1 = binarioDecimal(octbroad1);
                    int numbroad2 = binarioDecimal(octbroad2);
                    int numbroad3 = binarioDecimal(octbroad3);
                    int numbroad4 = binarioDecimal(octbroad4);
                    txtid1.Text = Convert.ToString(numid1);
                    txtid2.Text = Convert.ToString(numid2);
                    txtid3.Text = Convert.ToString(numid3);
                    txtid4.Text = Convert.ToString(numid4);
                    txtr1.Text = Convert.ToString(numid1);
                    txtr2.Text = Convert.ToString(numid2);
                    txtr3.Text = Convert.ToString(numid3);
                    txtr4.Text = Convert.ToString(numid4+1);
                    txtr5.Text = Convert.ToString(numbroad1);
                    txtr6.Text = Convert.ToString(numbroad2);
                    txtr7.Text = Convert.ToString(numbroad3);
                    txtr8.Text = Convert.ToString(numbroad4-1);
                    txtm1.Text = Convert.ToString(ip1);
                    txtm2.Text = Convert.ToString(ip2);
                    txtm3.Text = Convert.ToString(ip3);
                    txtm4.Text = Convert.ToString(ip4);
                    txtb1.Text = Convert.ToString(numbroad1);
                    txtb2.Text = Convert.ToString(numbroad2);
                    txtb3.Text = Convert.ToString(numbroad3);
                    txtb4.Text = Convert.ToString(numbroad4);

                }
                else
                {
                    if (r == 1 && r2 == 0)
                    {
                        for (i = 0; i < 8; i++)
                        {
                            bin1[i] = 1;
                            bin2[i] = 0;
                            bin3[i] = 0;
                            bin4[i] = 0;
                        }
                        for (i = 0; i < 8; i++)
                        {
                            binid1[i] = binid1[i] * bin1[i];
                            binid2[i] = binid2[i] * bin2[i];
                            binid3[i] = binid3[i] * bin3[i];
                            binid4[i] = binid4[i] * bin4[i];
                            binbroad1[i] = binid1[i];
                            binbroad2[i] = binid2[i];
                            binbroad3[i] = binid3[i];
                            binbroad4[i] = binid4[i];
                        }
                        for (i = 0; i < 8; i++)
                        {
                            binbroad2[i] = 1;
                            binbroad3[i] = 1;
                            binbroad4[i] = 1;
                        }
                        int octmac1 = conversion(bin1);
                        int octmac2 = conversion(bin2);
                        int octmac3 = conversion(bin3);
                        int octmac4 = conversion(bin4);
                        int ip1 = binarioDecimal(octmac1);
                        int ip2 = binarioDecimal(octmac2);
                        int ip3 = binarioDecimal(octmac3);
                        int ip4 = binarioDecimal(octmac4);
                        int oct1 = conversion(binid1);
                        int oct2 = conversion(binid2);
                        int oct3 = conversion(binid3);
                        int oct4 = conversion(binid4);
                        int numid1 = binarioDecimal(oct1);
                        int numid2 = binarioDecimal(oct2);
                        int numid3 = binarioDecimal(oct3);
                        int numid4 = binarioDecimal(oct4);
                        int octbroad1 = conversion(binbroad1);
                        int octbroad2 = conversion(binbroad2);
                        int octbroad3 = conversion(binbroad3);
                        int octbroad4 = conversion(binbroad4);
                        int numbroad1 = binarioDecimal(octbroad1);
                        int numbroad2 = binarioDecimal(octbroad2);
                        int numbroad3 = binarioDecimal(octbroad3);
                        int numbroad4 = binarioDecimal(octbroad4);
                        txtid1.Text = Convert.ToString(numid1);
                        txtid2.Text = Convert.ToString(numid2);
                        txtid3.Text = Convert.ToString(numid3);
                        txtid4.Text = Convert.ToString(numid4);
                        txtr1.Text = Convert.ToString(numid1);
                        txtr2.Text = Convert.ToString(numid2);
                        txtr3.Text = Convert.ToString(numid3);
                        txtr4.Text = Convert.ToString(numid4 + 1);
                        txtr5.Text = Convert.ToString(numbroad1);
                        txtr6.Text = Convert.ToString(numbroad2);
                        txtr7.Text = Convert.ToString(numbroad3);
                        txtr8.Text = Convert.ToString(numbroad4 - 1);
                        txtm1.Text = Convert.ToString(ip1);
                        txtm2.Text = Convert.ToString(ip2);
                        txtm3.Text = Convert.ToString(ip3);
                        txtm4.Text = Convert.ToString(ip4);
                        txtb1.Text = Convert.ToString(numbroad1);
                        txtb2.Text = Convert.ToString(numbroad2);
                        txtb3.Text = Convert.ToString(numbroad3);
                        txtb4.Text = Convert.ToString(numbroad4);
                    }
                }
                if (r == 2 && r2 != 0)
                {
                    for (i = 0; i < 8; i++)
                    {

                        bin2[i] = 1;
                        bin3[i] = 0;
                        bin4[i] = 0;
                    }
                    for (i = 0; i < r2; i++)
                    {
                        bin3[i] = 1;
                    }
                    for (i = 0; i < 8; i++)
                    {
                        binid1[i] = binid1[i] * bin1[i];
                        binid2[i] = binid2[i] * bin2[i];
                        binid3[i] = binid3[i] * bin3[i];
                        binid4[i] = binid4[i] * bin4[i];
                        binbroad1[i] = binid1[i];
                        binbroad2[i] = binid2[i];
                        binbroad3[i] = binid3[i];
                        binbroad4[i] = binid4[i];
                    }
                    for (i = r2; i < 8; i++)
                    {
                        binbroad3[i] = 1;
                    }
                    for (i = 0; i < 8; i++)
                    {
                        binbroad4[i] = 1;
                    }
                    int octmac1 = conversion(bin1);
                    int octmac2 = conversion(bin2);
                    int octmac3 = conversion(bin3);
                    int octmac4 = conversion(bin4);
                    int ip1 = binarioDecimal(octmac1);
                    int ip2 = binarioDecimal(octmac2);
                    int ip3 = binarioDecimal(octmac3);
                    int ip4 = binarioDecimal(octmac4);
                    int oct1 = conversion(binid1);
                    int oct2 = conversion(binid2);
                    int oct3 = conversion(binid3);
                    int oct4 = conversion(binid4);
                    int numid1 = binarioDecimal(oct1);
                    int numid2 = binarioDecimal(oct2);
                    int numid3 = binarioDecimal(oct3);
                    int numid4 = binarioDecimal(oct4);
                    int octbroad1 = conversion(binbroad1);
                    int octbroad2 = conversion(binbroad2);
                    int octbroad3 = conversion(binbroad3);
                    int octbroad4 = conversion(binbroad4);
                    int numbroad1 = binarioDecimal(octbroad1);
                    int numbroad2 = binarioDecimal(octbroad2);
                    int numbroad3 = binarioDecimal(octbroad3);
                    int numbroad4 = binarioDecimal(octbroad4);
                    txtid1.Text = Convert.ToString(numid1);
                    txtid2.Text = Convert.ToString(numid2);
                    txtid3.Text = Convert.ToString(numid3);
                    txtid4.Text = Convert.ToString(numid4);
                    txtr1.Text = Convert.ToString(numid1);
                    txtr2.Text = Convert.ToString(numid2);
                    txtr3.Text = Convert.ToString(numid3);
                    txtr4.Text = Convert.ToString(numid4 + 1);
                    txtr5.Text = Convert.ToString(numbroad1);
                    txtr6.Text = Convert.ToString(numbroad2);
                    txtr7.Text = Convert.ToString(numbroad3);
                    txtr8.Text = Convert.ToString(numbroad4 - 1);
                    txtm1.Text = Convert.ToString(ip1);
                    txtm2.Text = Convert.ToString(ip2);
                    txtm3.Text = Convert.ToString(ip3);
                    txtm4.Text = Convert.ToString(ip4);
                    txtb1.Text = Convert.ToString(numbroad1);
                    txtb2.Text = Convert.ToString(numbroad2);
                    txtb3.Text = Convert.ToString(numbroad3);
                    txtb4.Text = Convert.ToString(numbroad4);
                }
                else
                {
                    if (r == 2 && r2 == 0)
                    {
                        for (i = 0; i < 8; i++)
                        {
                            bin2[i] = 1;
                            bin3[i] = 0;
                            bin4[i] = 0;
                        }
                        for (i = 0; i < 8; i++)
                        {
                            binid1[i] = binid1[i] * bin1[i];
                            binid2[i] = binid2[i] * bin2[i];
                            binid3[i] = binid3[i] * bin3[i];
                            binid4[i] = binid4[i] * bin4[i];
                            binbroad1[i] = binid1[i];
                            binbroad2[i] = binid2[i];
                            binbroad3[i] = binid3[i];
                            binbroad4[i] = binid4[i];
                        }
                        for (i = 0; i < 8; i++)
                        {
                            binbroad3[i] = 1;
                            binbroad4[i] = 1;
                        }
                        int octmac1 = conversion(bin1);
                        int octmac2 = conversion(bin2);
                        int octmac3 = conversion(bin3);
                        int octmac4 = conversion(bin4);
                        int ip1 = binarioDecimal(octmac1);
                        int ip2 = binarioDecimal(octmac2);
                        int ip3 = binarioDecimal(octmac3);
                        int ip4 = binarioDecimal(octmac4);
                        int oct1 = conversion(binid1);
                        int oct2 = conversion(binid2);
                        int oct3 = conversion(binid3);
                        int oct4 = conversion(binid4);
                        int numid1 = binarioDecimal(oct1);
                        int numid2 = binarioDecimal(oct2);
                        int numid3 = binarioDecimal(oct3);
                        int numid4 = binarioDecimal(oct4);
                        int octbroad1 = conversion(binbroad1);
                        int octbroad2 = conversion(binbroad2);
                        int octbroad3 = conversion(binbroad3);
                        int octbroad4 = conversion(binbroad4);
                        int numbroad1 = binarioDecimal(octbroad1);
                        int numbroad2 = binarioDecimal(octbroad2);
                        int numbroad3 = binarioDecimal(octbroad3);
                        int numbroad4 = binarioDecimal(octbroad4);
                        txtid1.Text = Convert.ToString(numid1);
                        txtid2.Text = Convert.ToString(numid2);
                        txtid3.Text = Convert.ToString(numid3);
                        txtid4.Text = Convert.ToString(numid4);
                        txtr1.Text = Convert.ToString(numid1);
                        txtr2.Text = Convert.ToString(numid2);
                        txtr3.Text = Convert.ToString(numid3);
                        txtr4.Text = Convert.ToString(numid4 + 1);
                        txtr5.Text = Convert.ToString(numbroad1);
                        txtr6.Text = Convert.ToString(numbroad2);
                        txtr7.Text = Convert.ToString(numbroad3);
                        txtr8.Text = Convert.ToString(numbroad4 - 1);
                        txtm1.Text = Convert.ToString(ip1);
                        txtm2.Text = Convert.ToString(ip2);
                        txtm3.Text = Convert.ToString(ip3);
                        txtm4.Text = Convert.ToString(ip4);
                        txtb1.Text = Convert.ToString(numbroad1);
                        txtb2.Text = Convert.ToString(numbroad2);
                        txtb3.Text = Convert.ToString(numbroad3);
                        txtb4.Text = Convert.ToString(numbroad4);
                    }
                }
                if (r == 3 && r2 != 0)
                {
                    for (i = 0; i < 8; i++)
                    {
                        bin2[i] = 1;
                        bin3[i] = 1;
                        bin4[i] = 0;
                    }
                    for (i = 0; i < r2; i++)
                    {
                        bin4[i] = 1;
                    }
                    for (i = 0; i < 8; i++)
                    {
                        binid1[i] = binid1[i] * bin1[i];
                        binid2[i] = binid2[i] * bin2[i];
                        binid3[i] = binid3[i] * bin3[i];
                        binid4[i] = binid4[i] * bin4[i];
                        binbroad1[i] = binid1[i];
                        binbroad2[i] = binid2[i];
                        binbroad3[i] = binid3[i];
                        binbroad4[i] = binid4[i];
                    }
                    for (i = r2; i < 8; i++)
                    {
                        binbroad4[i] = 1;
                    }
                    int octmac1 = conversion(bin1);
                    int octmac2 = conversion(bin2);
                    int octmac3 = conversion(bin3);
                    int octmac4 = conversion(bin4);
                    int ip1 = binarioDecimal(octmac1);
                    int ip2 = binarioDecimal(octmac2);
                    int ip3 = binarioDecimal(octmac3);
                    int ip4 = binarioDecimal(octmac4);
                    int oct1 = conversion(binid1);
                    int oct2 = conversion(binid2);
                    int oct3 = conversion(binid3);
                    int oct4 = conversion(binid4);
                    int numid1 = binarioDecimal(oct1);
                    int numid2 = binarioDecimal(oct2);
                    int numid3 = binarioDecimal(oct3);
                    int numid4 = binarioDecimal(oct4);
                    int octbroad1 = conversion(binbroad1);
                    int octbroad2 = conversion(binbroad2);
                    int octbroad3 = conversion(binbroad3);
                    int octbroad4 = conversion(binbroad4);
                    int numbroad1 = binarioDecimal(octbroad1);
                    int numbroad2 = binarioDecimal(octbroad2);
                    int numbroad3 = binarioDecimal(octbroad3);
                    int numbroad4 = binarioDecimal(octbroad4);
                    txtid1.Text = Convert.ToString(numid1);
                    txtid2.Text = Convert.ToString(numid2);
                    txtid3.Text = Convert.ToString(numid3);
                    txtid4.Text = Convert.ToString(numid4);
                    txtr1.Text = Convert.ToString(numid1);
                    txtr2.Text = Convert.ToString(numid2);
                    txtr3.Text = Convert.ToString(numid3);
                    txtr4.Text = Convert.ToString(numid4 + 1);
                    txtr5.Text = Convert.ToString(numbroad1);
                    txtr6.Text = Convert.ToString(numbroad2);
                    txtr7.Text = Convert.ToString(numbroad3);
                    txtr8.Text = Convert.ToString(numbroad4 - 1);
                    txtm1.Text = Convert.ToString(ip1);
                    txtm2.Text = Convert.ToString(ip2);
                    txtm3.Text = Convert.ToString(ip3);
                    txtm4.Text = Convert.ToString(ip4);
                    txtb1.Text = Convert.ToString(numbroad1);
                    txtb2.Text = Convert.ToString(numbroad2);
                    txtb3.Text = Convert.ToString(numbroad3);
                    txtb4.Text = Convert.ToString(numbroad4);
                }
                else
                {
                    if (r == 3 && r2 == 0)
                    {
                        for (i = 0; i < 8; i++)
                        {
                            bin2[i] = 1;
                            bin3[i] = 1;
                            bin4[i] = 0;
                        }
                        for (i = 0; i < 8; i++)
                        {
                            binid1[i] = binid1[i] * bin1[i];
                            binid2[i] = binid2[i] * bin2[i];
                            binid3[i] = binid3[i] * bin3[i];
                            binid4[i] = binid4[i] * bin4[i];
                            binbroad1[i] = binid1[i];
                            binbroad2[i] = binid2[i];
                            binbroad3[i] = binid3[i];
                            binbroad4[i] = binid4[i];
                        }
                        for (i = 0; i < 8; i++)
                        {
                            binbroad4[i] = 1;
                        }
                        int octmac1 = conversion(bin1);
                        int octmac2 = conversion(bin2);
                        int octmac3 = conversion(bin3);
                        int octmac4 = conversion(bin4);
                        int ip1 = binarioDecimal(octmac1);
                        int ip2 = binarioDecimal(octmac2);
                        int ip3 = binarioDecimal(octmac3);
                        int ip4 = binarioDecimal(octmac4);
                        int oct1 = conversion(binid1);
                        int oct2 = conversion(binid2);
                        int oct3 = conversion(binid3);
                        int oct4 = conversion(binid4);
                        int numid1 = binarioDecimal(oct1);
                        int numid2 = binarioDecimal(oct2);
                        int numid3 = binarioDecimal(oct3);
                        int numid4 = binarioDecimal(oct4);
                        int octbroad1 = conversion(binbroad1);
                        int octbroad2 = conversion(binbroad2);
                        int octbroad3 = conversion(binbroad3);
                        int octbroad4 = conversion(binbroad4);
                        int numbroad1 = binarioDecimal(octbroad1);
                        int numbroad2 = binarioDecimal(octbroad2);
                        int numbroad3 = binarioDecimal(octbroad3);
                        int numbroad4 = binarioDecimal(octbroad4);
                        txtid1.Text = Convert.ToString(numid1);
                        txtid2.Text = Convert.ToString(numid2);
                        txtid3.Text = Convert.ToString(numid3);
                        txtid4.Text = Convert.ToString(numid4);
                        txtr1.Text = Convert.ToString(numid1);
                        txtr2.Text = Convert.ToString(numid2);
                        txtr3.Text = Convert.ToString(numid3);
                        txtr4.Text = Convert.ToString(numid4 + 1);
                        txtr5.Text = Convert.ToString(numbroad1);
                        txtr6.Text = Convert.ToString(numbroad2);
                        txtr7.Text = Convert.ToString(numbroad3);
                        txtr8.Text = Convert.ToString(numbroad4 - 1);
                        txtm1.Text = Convert.ToString(ip1);
                        txtm2.Text = Convert.ToString(ip2);
                        txtm3.Text = Convert.ToString(ip3);
                        txtm4.Text = Convert.ToString(ip4);
                        txtb1.Text = Convert.ToString(numbroad1);
                        txtb2.Text = Convert.ToString(numbroad2);
                        txtb3.Text = Convert.ToString(numbroad3);
                        txtb4.Text = Convert.ToString(numbroad4);
                    }

                }
                if (r == 4 && r2 == 0)
                {
                    for (i = 0; i < 8; i++)
                    {
                        bin2[i] = 1;
                        bin3[i] = 1;
                        bin4[i] = 1;
                    }
                    for (i = 0; i < 8; i++)
                    {
                        binid1[i] = binid1[i] * bin1[i];
                        binid2[i] = binid2[i] * bin2[i];
                        binid3[i] = binid3[i] * bin3[i];
                        binid4[i] = binid4[i] * bin4[i];
                        binbroad1[i] = binid1[i];
                        binbroad2[i] = binid2[i];
                        binbroad3[i] = binid3[i];
                        binbroad4[i] = binid4[i];
                    }
                    for (i = r2; i < 8; i++)
                    {
                        binbroad4[i] = 1;
                    }
                    int octmac1 = conversion(bin1);
                    int octmac2 = conversion(bin2);
                    int octmac3 = conversion(bin3);
                    int octmac4 = conversion(bin4);
                    int ip1 = binarioDecimal(octmac1);
                    int ip2 = binarioDecimal(octmac2);
                    int ip3 = binarioDecimal(octmac3);
                    int ip4 = binarioDecimal(octmac4);
                    int oct1 = conversion(binid1);
                    int oct2 = conversion(binid2);
                    int oct3 = conversion(binid3);
                    int oct4 = conversion(binid4);
                    int numid1 = binarioDecimal(oct1);
                    int numid2 = binarioDecimal(oct2);
                    int numid3 = binarioDecimal(oct3);
                    int numid4 = binarioDecimal(oct4);
                    int octbroad1 = conversion(binbroad1);
                    int octbroad2 = conversion(binbroad2);
                    int octbroad3 = conversion(binbroad3);
                    int octbroad4 = conversion(binbroad4);
                    int numbroad1 = binarioDecimal(octbroad1);
                    int numbroad2 = binarioDecimal(octbroad2);
                    int numbroad3 = binarioDecimal(octbroad3);
                    int numbroad4 = binarioDecimal(octbroad4);
                    txtid1.Text = Convert.ToString(numid1);
                    txtid2.Text = Convert.ToString(numid2);
                    txtid3.Text = Convert.ToString(numid3);
                    txtid4.Text = Convert.ToString(numid4);
                    txtr1.Text = Convert.ToString(numid1);
                    txtr2.Text = Convert.ToString(numid2);
                    txtr3.Text = Convert.ToString(numid3);
                    txtr4.Text = Convert.ToString(numid4 + 1);
                    txtr5.Text = Convert.ToString(numbroad1);
                    txtr6.Text = Convert.ToString(numbroad2);
                    txtr7.Text = Convert.ToString(numbroad3);
                    txtr8.Text = Convert.ToString(numbroad4 - 1);
                    txtm1.Text = Convert.ToString(ip1);
                    txtm2.Text = Convert.ToString(ip2);
                    txtm3.Text = Convert.ToString(ip3);
                    txtm4.Text = Convert.ToString(ip4);
                    txtb1.Text = Convert.ToString(numbroad1);
                    txtb2.Text = Convert.ToString(numbroad2);
                    txtb3.Text = Convert.ToString(numbroad3);
                    txtb4.Text = Convert.ToString(numbroad4);
                }




            }
            else
                {
                    lblerror.Text = "Error prefijo, Ip tipo de direccion";
                }
            }
        

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtn.Text = "";
            txtn2.Text = "";
            txtn3.Text = "";
            txtn4.Text = "";
            txtprefijo.Text = "";
            txtid1.Text = "";
            txtid2.Text = "";
            txtid3.Text = "";
            txtid4.Text = "";
            txtsubredes.Text = "";
            txthost.Text = "";
            txtr1.Text = "";
            txtr2.Text = "";
            txtr3.Text = "";
            txtr4.Text = "";
            txtr5.Text = "";
            txtr6.Text = "";
            txtr7.Text = "";
            txtr8.Text = "";
            txtb1.Text = "";
            txtb2.Text = "";
            txtb3.Text = "";
            txtb4.Text = "";
            lblerror.Text = "";
            txtm1.Text = "";
            txtm2.Text = "";
            txtm3.Text = "";
            txtm4.Text = "";

        }

        private void txtn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}