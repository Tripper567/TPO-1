using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpo1lab111
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, h, n = 10, res, res2, res1 = 0, resCount;
            double x , eps, an = 0;

            
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                eps = Convert.ToDouble(textBox3.Text);
                int count = GetDecimalDigitsCount(eps);

                if (Math.Abs(a) == b || Math.Abs(eps) > 1)
                { 
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();    
                        MessageBox.Show("Вы ввели парные числа интегрирования или указана неверная точность");
                }

                else
                {
                    richTextBox1.Clear();
                    do
                    {
                        h = (b - Math.Abs(a)) / n;
                        label1.Text = Convert.ToString(Math.Round(h, count));
                        x = a; res = 0;
                        while (x + h <= b)
                        {
                            if (x < 0 || x > 160000)
                            {
                                richTextBox1.AppendText("Число в не ОДЗ" + x + '\n');
                            }
                            else
                            {

                                res += h * Math.Sqrt(400 - Math.Sqrt(x));
                                resCount = h * Math.Sqrt(400 - Math.Sqrt(x));
                                //richTextBox1.AppendText(Convert.ToString(resCount) + '\n'); // вывод иксов 
                                //x += h;
                            }
                            x += h;
                        }
                        res2 = res;
                        n++;

                        an = Math.Abs(res2 - res1);
                        res1 = res;
                    }
                    while (an > eps);
                    double Xg = a;


                    double[] numX = new double[10];
                    double[] numY = new double[10];

                    for (int i = 0; i < 10; i++)
                    {
                        numX[i] = Math.Round(Xg, count);
                        numY[i] = Math.Sqrt(400 - Math.Sqrt(Xg));
                        Xg = Xg + h;
                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series[0].Points.DataBindXY(numX, numY);
                    chart1.Series[0].LegendText = "√(400-√x)";
                    label2.Text = Convert.ToString(Math.Round(res, count) + "   h=" + Math.Round(h, count));
                    chart1.ChartAreas[0].AxisY.Minimum = 5; chart1.ChartAreas[0].AxisY.Maximum = 30;

                }

            }

            catch
            {
                MessageBox.Show("Некоректные данные");
            }





            #region
            //if ((textBox1.Text == "") || (textBox2.Text == "")  || (textBox3.Text == "") || (Convert.ToDouble(textBox1.Text) < 0) || (Convert.ToDouble(textBox1.Text) >100000) || (Convert.ToDouble(textBox2.Text) < 0) || (Convert.ToDouble(textBox2.Text) >100000) || (Convert.ToDouble(textBox3.Text) <0) || (Convert.ToDouble(textBox3.Text) >1) )
            //{
            //    MessageBox.Show("Некоректные данные");
            //}
            //else
            //{
            //    a = Convert.ToDouble(textBox1.Text);
            //    b = Convert.ToDouble(textBox2.Text);
            //    eps = Convert.ToDouble(textBox3.Text);
            //    int count = GetDecimalDigitsCount(eps);

            //    do
            //    {
            //        h = (b - a) / n;
            //        label1.Text = Convert.ToString(Math.Round(h, count));
            //        x = a; res = 0;
            //        while (x + h <= b)
            //        {
            //            res += h * Math.Sqrt(400 - Math.Sqrt(x));
            //            x += h;
            //        }
            //        res2 = res;
            //        n++;

            //        an = Math.Abs(res2 - res1);
            //        res1 = res;
            //    }
            //    while (an > eps);
            //    double Xg = a;


            //    double[] numX = new double[10];
            //    double[] numY = new double[10];

            //    for(int i = 0; i < 10; i++)
            //    {
            //        numX[i] = Math.Round(Xg,count);
            //        numY[i] = Math.Sqrt(400 - Math.Sqrt(Xg));
            //        Xg = Xg + h;
            //    }

            //    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //    chart1.Series[0].Points.DataBindXY(numX, numY);
            //    chart1.Series[0].LegendText = "√(400-√x)";
            //    label2.Text = Convert.ToString(Math.Round(res,count)+ "   h=" + Math.Round(h,count)); 
            //    chart1.ChartAreas[0].AxisY.Minimum = 5; chart1.ChartAreas[0].AxisY.Maximum = 30;

            //}
            #endregion





        }
        static int GetDecimalDigitsCount(double number)
        {
            string str = number.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return str.Contains(".") ? str.Remove(0, Math.Truncate(number).ToString().Length + 1).Length : 0;
        }

        private void chart1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
