using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GenerateMatrixWithSilvestr
{
    public partial class Form1 : Form
    {
        Solution thisSolution = new Solution();
        Random random = new Random();
        int maxForRandom = 9;
        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            textBox2.Text = "9";
            textBox3.Text = "iniFiles\\ini12.txt";
        }
        private void InitializeMaxForRandom()
        {
            maxForRandom = Convert.ToInt32(textBox2.Text);
        }
     
        public void InitializeComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InitializeMaxForRandom();
            GenerateMatrix(Convert.ToInt32(comboBox1.Text));
        }
        public void ShowMatrix(double[,] Matrix, int n)
        {
            textBox1.Text = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    textBox1.Text += Matrix[i, j].ToString() + " ";
                }
                textBox1.Text += Environment.NewLine;
            }
        }
        public void ShowMatrix(double[] Matrix, int n,string name)
        {
            textBox1.Text +=name+ Environment.NewLine;

            for (int i = 0; i < n; i++)
            {
                textBox1.Text += Matrix[i].ToString() + " ";
                textBox1.Text += Environment.NewLine;
            }
        }
        public void ShowIsPositivelyDefined(bool flag)
        {
            if (flag)
            {
                label3.BackColor = Color.Green;
                label3.Text = "Матрица положительно определена";
            }
            else
            {
                label3.BackColor = Color.Red;
                label3.Text = "Матрица не положительно определена";
            }
        }
        public void ShowSolution(Solution solution)
        {
            ShowMatrix(solution.Matrix, solution.Dimension);
            ShowIsPositivelyDefined(IsSilvestr(solution.Matrix, solution.Dimension));
            ShowMatrix(solution.BVector, solution.Dimension,"BVector");
            ShowMatrix(solution.GaussSolution, solution.Dimension, "Gauss");
            ShowMatrix(solution.Determinants, solution.Dimension, "Determinants");

        }
        public void ShowAll(double[,] Matrix, int n)
        {
            ShowMatrix(Matrix, n);
            ShowIsPositivelyDefined(IsSilvestr(Matrix, n));
            double[] x=Gauss(Matrix,n);
            ShowMatrix(x, n,"Gauss");
            thisSolution.GaussSolution = x;
            thisSolution.Matrix = Matrix;
            thisSolution.Save("iniFiles5\\ini");
        }
        public void GenerateMatrix(int n)
        {
            thisSolution.Dimension = n;
            double[,] Matrix = new double[n, n];
            switch (n)
            {
                case 1:
                    { 
                        Matrix= GenerateSymmetricMatrixA1WithZeros();
                        ShowAll(Matrix, n);

                    }
        break;
                case 2:
                    {
                        Matrix = GenerateSymmetricMatrixA2WithZeros();
                        ShowAll(Matrix, n);
                    }
        break;
                case 3:
                    {
                        Matrix = GenerateSymmetricMatrixA3WithZeros();
                        ShowAll(Matrix, n);
                    }
                    break;
                case 4:
                    {
                        Matrix = GenerateSymmetricMatrixA4WithZeros();
                        ShowAll(Matrix, n);
                    }
                    break;
                case 5:
                    { 
                        Matrix = GenerateSymmetricMatrixA5WithZeros();
                        ShowAll(Matrix, n);
                    }
                    break;

                default:
                    {

                    }
        break;
            }

        }
        public double[,] GenerateSymmetricMatrixA1()
        {
            double[,] MatrixA = new double[1, 1];

            for (int i = 0; i < 1; i++)
            {
                for (int j = i; j < 1; j++)
                {
                    double randomValue = GenerateRandomInt();
                    MatrixA[i, j] = randomValue;

                    if (i != j)
                    {
                        MatrixA[j, i] = randomValue;
                    }
                }
            }

            return MatrixA;
        }
        public double[,] GenerateSymmetricMatrixA1WithZeros()
        {
            double[,] MatrixA = GenerateSymmetricMatrixA1();
            return MatrixA;
        }
        public double[,] GenerateSymmetricMatrixA2()
        {
            double[,] MatrixA = new double[2, 2];

            for (int i = 0; i < 2; i++)
            {
                for (int j = i; j < 2; j++)
                {
                    double randomValue = GenerateRandomInt();
                    MatrixA[i, j] = randomValue;

                    if (i != j)
                    {
                        MatrixA[j, i] = randomValue;
                    }
                }
            }

            return MatrixA;
        }
        public double[,] GenerateSymmetricMatrixA2WithZeros()
        {
            double[,] MatrixA = GenerateSymmetricMatrixA2();
            return MatrixA;
        }
        public double[,] GenerateSymmetricMatrixA3()
        {
            double[,] MatrixA = new double[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = i; j < 3; j++)
                {
                    double randomValue = GenerateRandomInt();
                    MatrixA[i, j] = randomValue;

                    if (i != j)
                    {
                        MatrixA[j, i] = randomValue;
                    }
                }
            }

            return MatrixA;
        }
        public double[,] GenerateSymmetricMatrixA3WithZeros()
        {
            double[,] MatrixA = GenerateSymmetricMatrixA3();

            // Задаем позиции, где нужно добавить нули
            int[,] zeroPositions = {
                                   {0, 2}
                                   };

            // Добавляем нули на указанные позиции
            for (int i = 0; i < zeroPositions.GetLength(0); i++)
            {
                int row = zeroPositions[i, 0];
                int col = zeroPositions[i, 1];
                MatrixA[row, col] = 0;
                MatrixA[col, row] = 0;
            }

            return MatrixA;
        }
        public double[,] GenerateSymmetricMatrixA4()
        {
            double[,] MatrixA = new double[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = i; j < 4; j++)
                {
                    double randomValue = GenerateRandomInt();
                    MatrixA[i, j] = randomValue;

                    if (i != j)
                    {
                        MatrixA[j, i] = randomValue;
                    }
                }
            }

            return MatrixA;
        }
        public double[,] GenerateSymmetricMatrixA4WithZeros()
        {
            double[,] MatrixA = GenerateSymmetricMatrixA4();

            // Задаем позиции, где нужно добавить нули
            int[,] zeroPositions = {
                                   {0, 2}, {1, 3}
                                   };

            // Добавляем нули на указанные позиции
            for (int i = 0; i < zeroPositions.GetLength(0); i++)
            {
                int row = zeroPositions[i, 0];
                int col = zeroPositions[i, 1];
                MatrixA[row, col] = 0;
                MatrixA[col, row] = 0;
            }

            return MatrixA;
        }

        public double[,] GenerateSymmetricMatrixA5()
        {
            double[,] MatrixA = new double[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = i; j < 5; j++)
                {
                    double randomValue = GenerateRandomInt();
                    MatrixA[i, j] = randomValue;

                    if (i != j)
                    {
                        MatrixA[j, i] = randomValue;
                    }
                }
            }

            return MatrixA;
        }
        public double[,] GenerateSymmetricMatrixA5WithZeros()
        {
            double[,] MatrixA = GenerateSymmetricMatrixA5();

            // Задаем позиции, где нужно добавить нули
            int[,] zeroPositions = {
                                   {0, 2}, {1, 3}, {1, 4}, {2, 4}
                                   };

            // Добавляем нули на указанные позиции
            for (int i = 0; i < zeroPositions.GetLength(0); i++)
            {
                int row = zeroPositions[i, 0];
                int col = zeroPositions[i, 1];
                MatrixA[row, col] = 0;
                MatrixA[col, row] = 0;
            }

            return MatrixA;
        }
        public bool IsSilvestr(double[,]Matrix,int n)
        {
            switch(n)
            {
                case 1:
                    {
                        return IsSilvestrA1(Matrix, n);
                    }
                    break;
                case 2:
                    {
                        return IsSilvestrA2(Matrix, n);
                    }
                    break;
                case 3:
                    {
                        return IsSilvestrA3(Matrix, n);
                    }
                    break;
                case 4:
                    {
                        return IsSilvestrA4(Matrix, n);
                    }
                    break;
                case 5:
                    {
                        return IsSilvestrA5(Matrix, n);
                        
                    }
                    break;

                default:
                    {

                    }
                    break;
            }
            return true;
        }
        public bool IsPositiveDeterminant1(double[,] Matrix)
        {
            bool flag = false;
            double determinant = Matrix[0, 0];
            label9.Text=determinant.ToString();
            thisSolution.Determinants[0] = determinant;
            if (
                determinant > 0
                ) 
                flag = true;
            return flag;
        }
        public bool IsPositiveDeterminant2(double[,] Matrix)
        {
            bool flag = false;
            double determinant = Matrix[0, 0] * Matrix[1, 1] -
                Matrix[0, 1] * Matrix[1, 0];
            thisSolution.Determinants[1] = determinant;
            label10.Text = determinant.ToString();
            if (
                determinant > 0
                )
                flag = true;
            return flag;
        }
        public bool IsPositiveDeterminant3(double[,] Matrix)
        {
            bool flag = false;
            double determinant = Matrix[0, 0] * Matrix[1, 1] * Matrix[2, 2]
                            + Matrix[0, 1] * Matrix[1, 2] * Matrix[2, 0]
                            + Matrix[0, 2] * Matrix[1, 0] * Matrix[2, 1]
                            - Matrix[0, 2] * Matrix[1, 1] * Matrix[2, 0]
                            - Matrix[0, 0] * Matrix[1, 2] * Matrix[2, 1]
                            - Matrix[0, 1] * Matrix[1, 0] * Matrix[2, 2];
            thisSolution.Determinants[2] = determinant;
            label11.Text = determinant.ToString();
            if (
                determinant>0
                ) 
                flag = true;
            return flag;
        }
        public bool IsPositiveDeterminant4(double[,] Matrix)
        {
            bool flag = false;
            double determinant = Matrix[0, 0] * Matrix[1, 1] * Matrix[2, 2] * Matrix[3, 3]
                             - Matrix[0, 0] * Matrix[1, 1] * Matrix[2, 3] * Matrix[3, 2]
                             - Matrix[0, 0] * Matrix[1, 2] * Matrix[2, 1] * Matrix[3, 3]
                             + Matrix[0, 0] * Matrix[1, 2] * Matrix[2, 3] * Matrix[3, 1]
                             + Matrix[0, 0] * Matrix[1, 3] * Matrix[2, 1] * Matrix[3, 2]
                             - Matrix[0, 0] * Matrix[1, 3] * Matrix[2, 2] * Matrix[3, 1]
                             - Matrix[0, 1] * Matrix[1, 0] * Matrix[2, 2] * Matrix[3, 3]
                             + Matrix[0, 1] * Matrix[1, 0] * Matrix[2, 3] * Matrix[3, 2]
                             + Matrix[0, 1] * Matrix[1, 2] * Matrix[2, 0] * Matrix[3, 3]
                             - Matrix[0, 1] * Matrix[1, 2] * Matrix[2, 3] * Matrix[3, 0]
                             - Matrix[0, 1] * Matrix[1, 3] * Matrix[2, 0] * Matrix[3, 2]
                             + Matrix[0, 1] * Matrix[1, 3] * Matrix[2, 2] * Matrix[3, 0]
                             + Matrix[0, 2] * Matrix[1, 0] * Matrix[2, 1] * Matrix[3, 3]
                             - Matrix[0, 2] * Matrix[1, 0] * Matrix[2, 3] * Matrix[3, 1]
                             - Matrix[0, 2] * Matrix[1, 1] * Matrix[2, 0] * Matrix[3, 3]
                             + Matrix[0, 2] * Matrix[1, 1] * Matrix[2, 3] * Matrix[3, 0]
                             + Matrix[0, 2] * Matrix[1, 3] * Matrix[2, 0] * Matrix[3, 1]
                             - Matrix[0, 2] * Matrix[1, 3] * Matrix[2, 1] * Matrix[3, 0]
                             - Matrix[0, 3] * Matrix[1, 0] * Matrix[2, 1] * Matrix[3, 2]
                             + Matrix[0, 3] * Matrix[1, 0] * Matrix[2, 2] * Matrix[3, 1]
                             + Matrix[0, 3] * Matrix[1, 1] * Matrix[2, 0] * Matrix[3, 2]
                             - Matrix[0, 3] * Matrix[1, 1] * Matrix[2, 2] * Matrix[3, 0]
                             - Matrix[0, 3] * Matrix[1, 2] * Matrix[2, 0] * Matrix[3, 1]
                             + Matrix[0, 3] * Matrix[1, 2] * Matrix[2, 1] * Matrix[3, 0];
            thisSolution.Determinants[3] = determinant;
            label12.Text = determinant.ToString();
            if (
                determinant > 0
                )
                flag = true;
            return flag;
        }
        public bool IsPositiveDeterminant(double[,] Matrix)
        {
            bool flag = false;
            int n = Matrix.GetLength(0);
            double determinant = 0;

            if (n == 1)
            {
                determinant = Matrix[0, 0];
                thisSolution.Determinants[0]=determinant;
                label9.Text = determinant.ToString();
            }
            else if (n == 2)
            {
                determinant = Matrix[0, 0] * Matrix[1, 1] - Matrix[0, 1] * Matrix[1, 0];
                thisSolution.Determinants[1] = determinant;
                label10.Text = determinant.ToString();
            }
            else if (n == 3)
            {
                determinant = Matrix[0, 0] * Matrix[1, 1] * Matrix[2, 2]
                            + Matrix[0, 1] * Matrix[1, 2] * Matrix[2, 0]
                            + Matrix[0, 2] * Matrix[1, 0] * Matrix[2, 1]
                            - Matrix[0, 2] * Matrix[1, 1] * Matrix[2, 0]
                            - Matrix[0, 0] * Matrix[1, 2] * Matrix[2, 1]
                            - Matrix[0, 1] * Matrix[1, 0] * Matrix[2, 2];
                thisSolution.Determinants[2] = determinant;
                label11.Text = determinant.ToString();
            }
            else if (n == 4)
            {
                determinant = Matrix[0, 0] * Matrix[1, 1] * Matrix[2, 2] * Matrix[3, 3]
                            - Matrix[0, 0] * Matrix[1, 1] * Matrix[2, 3] * Matrix[3, 2]
                            - Matrix[0, 0] * Matrix[1, 2] * Matrix[2, 1] * Matrix[3, 3]
                            + Matrix[0, 0] * Matrix[1, 2] * Matrix[2, 3] * Matrix[3, 1]
                            + Matrix[0, 0] * Matrix[1, 3] * Matrix[2, 1] * Matrix[3, 2]
                            - Matrix[0, 0] * Matrix[1, 3] * Matrix[2, 2] * Matrix[3, 1]
                            - Matrix[0, 1] * Matrix[1, 0] * Matrix[2, 2] * Matrix[3, 3]
                            + Matrix[0, 1] * Matrix[1, 0] * Matrix[2, 3] * Matrix[3, 2]
                            + Matrix[0, 1] * Matrix[1, 2] * Matrix[2, 0] * Matrix[3, 3]
                            - Matrix[0, 1] * Matrix[1, 2] * Matrix[2, 3] * Matrix[3, 0]
                            - Matrix[0, 1] * Matrix[1, 3] * Matrix[2, 0] * Matrix[3, 2]
                            + Matrix[0, 1] * Matrix[1, 3] * Matrix[2, 2] * Matrix[3, 0]
                            + Matrix[0, 2] * Matrix[1, 0] * Matrix[2, 1] * Matrix[3, 3]
                            - Matrix[0, 2] * Matrix[1, 0] * Matrix[2, 3] * Matrix[3, 1]
                            - Matrix[0, 2] * Matrix[1, 1] * Matrix[2, 0] * Matrix[3, 3]
                            + Matrix[0, 2] * Matrix[1, 1] * Matrix[2, 3] * Matrix[3, 0]
                            + Matrix[0, 2] * Matrix[1, 3] * Matrix[2, 0] * Matrix[3, 1]
                            - Matrix[0, 2] * Matrix[1, 3] * Matrix[2, 1] * Matrix[3, 0]
                            - Matrix[0, 3] * Matrix[1, 0] * Matrix[2, 1] * Matrix[3, 2]
                            + Matrix[0, 3] * Matrix[1, 0] * Matrix[2, 2] * Matrix[3, 1]
                            + Matrix[0, 3] * Matrix[1, 1] * Matrix[2, 0] * Matrix[3, 2]
                            - Matrix[0, 3] * Matrix[1, 1] * Matrix[2, 2] * Matrix[3, 0]
                            - Matrix[0, 3] * Matrix[1, 2] * Matrix[2, 0] * Matrix[3, 1]
                            + Matrix[0, 3] * Matrix[1, 2] * Matrix[2, 1] * Matrix[3, 0];
                thisSolution.Determinants[3] = determinant;
                label12.Text = determinant.ToString();
            }
            else if (n == 5)
            {
                double[,] subMatrix = new double[4, 4];
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        subMatrix[i, j] = Matrix[i + 1, j + 1];

                for (int k = 0; k < 5; k++)
                {
                    double tmpDeterminant = Matrix[0, k] * MO.CalculateDeterminant4(subMatrix);
                    determinant += (k % 2 == 0 ? 1 : -1) * tmpDeterminant;

                    if (k < 4)
                    {
                        for (int i = 0; i < 4; i++)
                            subMatrix[i, k] = Matrix[i + 1, k];
                    }
                }
                thisSolution.Determinants[4] = determinant;
                label13.Text = determinant.ToString();
            }
            
            if (determinant > 0)
                    flag = true;

                return flag;

            }

        public bool IsPositiveDeterminant5(double[,] Matrix)
        {
            bool flag = false;
            double determinant = 0;

            double[,] subMatrix = new double[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    subMatrix[i, j] = Matrix[i + 1, j + 1];

            for (int k = 0; k < 5; k++)
            {
                double tmpDeterminant = Matrix[0, k] * MO.CalculateDeterminant4(subMatrix);
                determinant += (k % 2 == 0 ? 1 : -1) * tmpDeterminant;

                if (k < 4)
                {
                    for (int i = 0; i < 4; i++)
                        subMatrix[i, k] = Matrix[i + 1, k];
                }
            }
            thisSolution.Determinants[4] = determinant;
            label13.Text = determinant.ToString();

            if (
                determinant > 0
                )
                flag = true;
            return flag;
        }
        public bool IsSilvestrA1(double[,] Matrix, int n)
        {
            bool flag = true;
            if (!IsPositiveDeterminant1(Matrix)) flag = false;
            return flag;
        }
        public bool IsSilvestrA2(double[,] Matrix, int n)
        {
            bool flag = true;
            if (!IsPositiveDeterminant1(Matrix)) flag = false;
            if (!IsPositiveDeterminant2(Matrix)) flag = false;
            return flag;
        }
        public bool IsSilvestrA3(double[,] Matrix, int n)
        {
            bool flag = true;
            if (!IsPositiveDeterminant1(Matrix)) flag = false;
            if (!IsPositiveDeterminant2(Matrix)) flag = false;
            if (!IsPositiveDeterminant3(Matrix)) flag = false;
            return flag;
        }
        public bool IsSilvestrA4(double[,] Matrix, int n)
        {
            bool flag = true;
            if (!IsPositiveDeterminant1(Matrix)) flag = false;
            if (!IsPositiveDeterminant2(Matrix)) flag = false;
            if (!IsPositiveDeterminant3(Matrix)) flag = false;
            if (!IsPositiveDeterminant4(Matrix)) flag = false;
            return flag;
        }
        public bool IsSilvestrA5(double[,] Matrix,int n)
        {
            bool flag = true;
            if (!IsPositiveDeterminant1(Matrix)) flag = false;
            if (!IsPositiveDeterminant2(Matrix)) flag = false;
            if (!IsPositiveDeterminant3(Matrix)) flag = false;
            if (!IsPositiveDeterminant4(Matrix)) flag = false;
            if (!IsPositiveDeterminant5(Matrix)) flag = false;
            return flag;
        }
        public double GenerateRandomInt()
        {
            double t = random.Next(maxForRandom * 2) - maxForRandom;
            if (t == 0) return t+1;
            return t;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializeMaxForRandom();
            GeneratePositivelyDefinedMatrix(Convert.ToInt32(comboBox1.Text));
        }     
        public void GeneratePositivelyDefinedMatrix(int n)
        {
            thisSolution.Dimension = n;
            double[,] Matrix = new double[n, n];
            switch (n)
            {
                case 1:
                    {
                        Matrix = GenerateSymmetricMatrixA1WithZeros();
                        while (!IsSilvestr(Matrix, n))
                        {
                            Matrix = GenerateSymmetricMatrixA1WithZeros();
                        }
                        ShowAll(Matrix, n);

                    }
                    break;
                case 2:
                    {
                        Matrix = GenerateSymmetricMatrixA2WithZeros();
                        while (!IsSilvestr(Matrix, n))
                        {
                            Matrix = GenerateSymmetricMatrixA2WithZeros();
                        }
                        ShowAll(Matrix, n);
                    }
                    break;
                case 3:
                    {
                        Matrix = GenerateSymmetricMatrixA3WithZeros();
                        while (!IsSilvestr(Matrix, n))
                        {
                            Matrix = GenerateSymmetricMatrixA3WithZeros();
                        }
                        ShowAll(Matrix, n);
                    }
                    break;
                case 4:
                    {
                        Matrix = GenerateSymmetricMatrixA4WithZeros();
                        while (!IsSilvestr(Matrix, n))
                        {
                            Matrix = GenerateSymmetricMatrixA4WithZeros();
                        }
                        ShowAll(Matrix, n);
                    }
                    break;
                case 5:
                    {
                        Matrix = GenerateSymmetricMatrixA5WithZeros();
                        while (!IsSilvestr(Matrix, n))
                        {
                            Matrix = GenerateSymmetricMatrixA5WithZeros();
                        }
                        ShowAll(Matrix, n);
                    }
                    break;

                default:
                    {

                    }
                    break;
            }

        }
        double[] Gauss(double[,] matrix, int n)
          {
            double[,] UsMatrix = new double[n, n];
            double[,] FreeCopy = new double[n, 1];
            double[] bVector = new double[n];
            if (thisSolution.BVector is null)
            {
                for (int i = 0; i < n; i++)
                {
                    FreeCopy[i, 0] = GenerateRandomInt();
                }
                for (int i = 0; i < n; i++)
                {
                    bVector[i] = FreeCopy[i, 0];
                }
                thisSolution.BVector = bVector;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    FreeCopy[i, 0] = thisSolution.BVector[i];
                }
                for (int i = 0; i < n; i++)
                {
                    bVector[i] = FreeCopy[i, 0];
                }
            }
           
            ShowMatrix(bVector, n,"bVector");
            UsMatrix = (double[,])matrix.Clone();   //копирование матрицы
            double[,] UsMatrix2 = new double[n, n];
            UsMatrix2=MO.Inverse(UsMatrix);
            double[] x = MO.MultiplicateOnVector(UsMatrix2,bVector);
            for (int i = 0; i < n; i++)
            {
                x[i] = -1*x[i];
            }
            //for (int i = 0; i < n - 1; i++)
            //{       //приведение к верхнему треугольному виду
            //    for (int j = i + 1; j < n; j++)
            //    {
            //        double koef = UsMatrix[j, i] / UsMatrix[i, i];
            //        for (int k = i; k < n; k++)
            //        {
            //            UsMatrix[j, k] -= UsMatrix[i, k] * koef;
            //        }
            //        FreeCopy[j, 0] -= FreeCopy[i, 0] * koef;        //изменение вектора свободных членов
            //    }
            //}
            //int count = 1;
            //double[] x = new double[n];
            //x[0] = FreeCopy[n - 1, 0] / UsMatrix[n - 1, n - 1];
            //for (int i = 1, k = n - 2; i < n && k >= 0; i++, k--)
            //{       //обртаный ход
            //    for (int j = n - 1; j != k; j--, count++)
            //    {
            //        x[i] = (FreeCopy[k, 0] + UsMatrix[k, j] * (-1) * x[i - count]) / UsMatrix[k, k];
            //    }
            //    count = 1;
            //}
            
            return x;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Solution solve = new Solution();
                thisSolution=solve.LoadSolutionFromFile(textBox3.Text);
                ShowSolution(thisSolution);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Solution solve = new Solution();
            thisSolution = solve.LoadSolutionFromFile(textBox3.Text);
            textBox4.Text = thisSolution.GetFunction(thisSolution.GaussSolution).ToString() + Environment.NewLine; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            thisSolution.GaussSolution = Gauss(thisSolution.Matrix, thisSolution.Dimension);
            thisSolution.Save("iniFiles1\\ini");
        }
    }
}
