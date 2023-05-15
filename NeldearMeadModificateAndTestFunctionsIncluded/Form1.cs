using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeldearMeadModificateAndTestFunctionsIncluded.NeldearMead;

namespace NeldearMeadModificateAndTestFunctionsIncluded
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public void ShowThis(string str)
        {
            richTextBox1.Text += str+"\n";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            const int Dimension = 3;
            double[] Vector = new double[Dimension + 1];
            NeldearMead.NeldearMead Jedi = new NeldearMead.NeldearMead();
            double[] X = { 0, 0, 0};
            double L, L_thres, cR, alpha, beta, gamma;
            L = 100;
            L_thres = 1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;
            ShowThis("Начальная точка:");
            for (int i = 0; i < Dimension; i++) ShowThis(X[i].ToString());
            Vector = Jedi.nelMead(ref X, Dimension, L, L_thres, cR, alpha, beta, gamma);
            ShowThis(Jedi.ShowLog());
            ShowThis("Результат:");
            ShowThis("Аргументы:");
            for (int i = 0; i < Dimension; i++) ShowThis(X[i].ToString());
            ShowThis("Функция в вершинах симплекса:");
            for (int i = 0; i < Dimension + 1; i++) ShowThis(Vector[i].ToString());
        }
    }
}
