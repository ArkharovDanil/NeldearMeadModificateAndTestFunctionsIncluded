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
    public class Solution
    {
        int _dimension;
        double[,] _matrix;
        double[] _bVector;
        double[] _gauss;
        string[] _info = new string[5];
        double[] _determinants;
        public Solution()
        {

        }
        public int Dimension
        {
            get { return _dimension; }
            set { _dimension = value; _determinants = new double[_dimension]; }
        }
        public double[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
        public double[] BVector
        {
            get { return _bVector; }
            set { _bVector = value; }
        }
        public double[] GaussSolution
        {
            get { return _gauss; }
            set { _gauss = value; }
        }
        public double[] Determinants
        {
            get { return _determinants; }
            set { _determinants = value; }
        }
        private double ScalarMultiplication(double[] x1,double[] x2)
        {
            int t = x1.Length;
            double scalar = 0;
            for (int i=0;i<t;i++)
            {
                scalar+=x1[i]*x2[i];
            }
            return scalar;
        }
        private double[] MultiplicateOnVector(double[,]A,double[] x1)
        {
            double[] answer = new double[x1.Length];
            for (int i=0;i<x1.Length;i++)
            {
                for (int j=0;j<x1.Length;j++)
                {
                    answer[i] += A[i, j]*x1[j];
                }
            }
            return answer;
        }
        public double GetFunction(double[] x)
        {
            double function = 0;
            function+= 0.5*ScalarMultiplication(MultiplicateOnVector(_matrix,x),x) + ScalarMultiplication(_bVector, x);
            return function;
        }
        public Solution LoadSolutionFromFile(string path)
        {
            try
            {
                string text;
                string[] separateText;
               // string path = "iniFiles\\ini9.txt";
                using (StreamReader reader = new StreamReader(path))
                {
                    text = reader.ReadToEnd();
                }
                separateText = text.Split('\n');
                separateText = DeleteLastSymbolsExceptLastWord(separateText);
                int t = WhereFirstNull(separateText);
                return AnalyzeString(separateText);
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
        private string DimensionToString()
        {
            string dimension = "Dimension \n" + _dimension.ToString();

            return dimension;
        }
        private Solution AnalyzeString(string[] stringToAnalyze)
        {
            Solution answer = new Solution();
            int dimension = Convert.ToInt32(stringToAnalyze[1]);
            string[] MatrixString = new string[dimension];
            double[,] MatrixDouble = new double[dimension, dimension];
            double[] bVector = new double[dimension];
            double[] gauss = new double[dimension];
            double[] determinants = new double[dimension];
            if (dimension == 0)
            {

            }

            if (dimension == 1)
            {
                for (int i = 0; i < dimension; i++)
                {
                    string currentString = stringToAnalyze[i + 3];
                    double[] currentDouble = stringToArrayDouble(currentString, dimension);
                    for (int j = 0; j < dimension; j++)
                    {
                        MatrixDouble[i, j] = currentDouble[j];
                    }
                }
                for (int i = 0; i < dimension; i++)
                {
                    bVector[i] = Convert.ToDouble(stringToAnalyze[i + 6]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    gauss[i] = Convert.ToDouble(stringToAnalyze[i + 9]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    determinants[i] = Convert.ToDouble(stringToAnalyze[i * 2 + 13]);
                }
            }

            if (dimension == 2)
            {
                for (int i = 0; i < dimension; i++)
                {
                    string currentString = stringToAnalyze[i + 3];
                    double[] currentDouble = stringToArrayDouble(currentString, dimension);
                    for (int j = 0; j < dimension; j++)
                    {
                        MatrixDouble[i, j] = currentDouble[j];
                    }
                }
                for (int i = 0; i < dimension; i++)
                {
                    bVector[i] = Convert.ToDouble(stringToAnalyze[i + 7]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    gauss[i] = Convert.ToDouble(stringToAnalyze[i + 11]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    determinants[i] = Convert.ToDouble(stringToAnalyze[i * 2 + 16]);
                }
            }

            if (dimension == 3)
            {
                for (int i = 0; i < dimension; i++)
                {
                    string currentString = stringToAnalyze[i + 3];
                    double[] currentDouble = stringToArrayDouble(currentString, dimension);
                    for (int j = 0; j < dimension; j++)
                    {
                        MatrixDouble[i, j] = currentDouble[j];
                    }
                }
                for (int i = 0; i < dimension; i++)
                {
                    bVector[i] = Convert.ToDouble(stringToAnalyze[i + 8]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    gauss[i] = Convert.ToDouble(stringToAnalyze[i + 13]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    determinants[i] = Convert.ToDouble(stringToAnalyze[i * 2 + 19]);
                }
            }

            if (dimension == 4)
            {
                for (int i = 0; i < dimension; i++)
                {
                    string currentString = stringToAnalyze[i + 3];
                    double[] currentDouble = stringToArrayDouble(currentString, dimension);
                    for (int j = 0; j < dimension; j++)
                    {
                        MatrixDouble[i, j] = currentDouble[j];
                    }
                }
                for (int i = 0; i < dimension; i++)
                {
                    bVector[i] = Convert.ToDouble(stringToAnalyze[i + 9]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    gauss[i] = Convert.ToDouble(stringToAnalyze[i + 15]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    determinants[i] = Convert.ToDouble(stringToAnalyze[i * 2 + 22]);
                }
            }

            if (dimension == 5)
            {
                for (int i = 0; i < dimension; i++)
                {
                    string currentString = stringToAnalyze[i + 3];
                    double[] currentDouble = stringToArrayDouble(currentString, dimension);
                    for (int j = 0; j < dimension; j++)
                    {
                        MatrixDouble[i, j] = currentDouble[j];
                    }
                }
                for (int i = 0; i < dimension; i++)
                {
                    bVector[i] = Convert.ToDouble(stringToAnalyze[i + 10]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    gauss[i] = Convert.ToDouble(stringToAnalyze[i + 17]);
                }
                for (int i = 0; i < dimension; i++)
                {
                    determinants[i] = Convert.ToDouble(stringToAnalyze[i * 2 + 25]);
                }
            }
            answer.Dimension = dimension;
            answer.Matrix = MatrixDouble;
            answer.Determinants = determinants;
            answer.BVector = bVector;
            answer.GaussSolution = gauss;
            return answer;

        }





        private double[] stringToArrayDouble(string str, int dimension)
        {
            string[] separateString;
            double[] doubleArray = new double[dimension];
            separateString = str.Split(' ');
            int count = 0;
            foreach (string s in separateString)
            {
                doubleArray[count] = Convert.ToDouble(s);
                count++;
            }
            return doubleArray;

        }
        private string MatrixToString()
        {
            string matrix = "Matrix ";
            for (int i = 0; i < _dimension; i++)
            {
                matrix += "\n";
                for (int j = 0; j < _dimension; j++)
                {
                    matrix += _matrix[i, j].ToString() + " ";
                }
            }
            matrix += "\n";
            return matrix;
        }
        private string GaussSolutionToString()
        {
            string gaussSolutionToString = "Gauss \n";
            for (int i = 0; i < _dimension; i++)
            {
                gaussSolutionToString += _gauss[i].ToString() + " \n";
            }
            return gaussSolutionToString;
        }
        private string BVectorString()
        {
            string BVectorToString = "BVector \n";
            for (int i = 0; i < _dimension; i++)
            {
                BVectorToString += _bVector[i].ToString() + " \n";
            }
            return BVectorToString;
        }
        private string DeterminantsToString()
        {
            string determinantsToString = "Determinants \n";
            for (int i = 0; i < _dimension; i++)
            {
                determinantsToString += "det(" + (i + 1).ToString() + ") = " + " \n" + _determinants[i].ToString() + " \n";
            }
            return determinantsToString;

        }
        private void UpdateInfo()
        {
            _info[0] = DimensionToString();
            _info[1] = MatrixToString();
            _info[2] = BVectorString();
            _info[3] = GaussSolutionToString();
            _info[4] = DeterminantsToString();
        }
        public int WhereFirstNull(string[] text)
        {
            int t = 0;
            foreach (string str in text)
            {
                if (str == "")
                {
                    return t;
                }
                t++;
            }
            return t;
        }
        public string[] DeleteLastSymbolsExceptLastWord(string[] str)
        {
            string[] _str = str;
            for (int i = 0; i < _str.Count() - 1; i++)
            {
                _str[i] = _str[i].Remove(_str[i].Length - 1);
            }
            return _str;
        }
        public void Save(string path)
        {
            string ending = ".txt";
            int counter = 1;
            UpdateInfo();
            FileInfo fileInf = new FileInfo(path + ending);
            if (fileInf.Exists)
            {
                while (fileInf.Exists)
                {
                    counter++;
                    fileInf = new FileInfo(path + counter.ToString() + ending);
                }
            }
            else
            {
                fileInf.Create();
            }


            StreamWriter wr = new StreamWriter(path + counter.ToString() + ending, true);
            foreach (string str in _info)
            {
                wr.WriteLine(str);
            }

            wr.Close();
        }
    }
}
