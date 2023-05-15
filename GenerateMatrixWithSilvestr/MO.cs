using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateMatrixWithSilvestr
{
    public static class MO
    {
        public static double ScalarMultiplication(double[] x1, double[] x2)
        {
            int t = x1.Length;
            double scalar = 0;
            for (int i = 0; i < t; i++)
            {
                scalar += x1[i] * x2[i];
            }
            return scalar;
        }
        public static double[] MultiplicateOnVector(double[,] A, double[] x1)
        {
            double[] answer = new double[x1.Length];
            for (int i = 0; i < x1.Length; i++)
            {
                for (int j = 0; j < x1.Length; j++)
                {
                    answer[i] += A[i, j] * x1[j];
                }
            }
            return answer;
        }
        public static double[,] Transpose(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] result = new double[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        // Сумма двух матриц
        public static double[,] Add(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
            {
                throw new ArgumentException("The dimensions of the matrices are not the same.");
            }

            double[,] result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return result;
        }
    }
}
