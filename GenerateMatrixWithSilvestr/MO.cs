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
        public static double CalculateDeterminant4(double[,] Matrix)
        {
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
            return determinant;
        }
        public static double[,] Inverse(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n, n];
            double[,] augmentedMatrix = new double[n, 2 * n];

            // Создание расширенной матрицы [A|I]
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    augmentedMatrix[i, j] = matrix[i, j];
                    augmentedMatrix[i, j + n] = (i == j) ? 1 : 0;
                }
            }

            // Приведение к ступенчатому виду
            for (int i = 0; i < n; i++)
            {
                // Поиск максимального элемента в столбце
                double maxElement = Math.Abs(augmentedMatrix[i, i]);
                int maxRowIndex = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(augmentedMatrix[k, i]) > maxElement)
                    {
                        maxElement = Math.Abs(augmentedMatrix[k, i]);
                        maxRowIndex = k;
                    }
                }

                // Проверка на вырожденность
                if (maxElement == 0)
                {
                    throw new InvalidOperationException("The matrix is singular and cannot be inverted.");
                }

                // Обмен текущей строки и строки с максимальным элементом
                for (int k = i; k < 2 * n; k++)
                {
                    double temp = augmentedMatrix[maxRowIndex, k];
                    augmentedMatrix[maxRowIndex, k] = augmentedMatrix[i, k];
                    augmentedMatrix[i, k] = temp;
                }

                // Нормализация строки
                double pivot = augmentedMatrix[i, i];
                for (int k = i; k < 2 * n; k++)
                {
                    augmentedMatrix[i, k] /= pivot;
                }

                // Обнуление элементов ниже главной диагонали
                for (int j = i + 1; j < n; j++)
                {
                    double factor = augmentedMatrix[j, i];
                    for (int k = i; k < 2 * n; k++)
                    {
                        augmentedMatrix[j, k] -= factor * augmentedMatrix[i, k];
                    }
                }
            }

            // Обратный проход
            for (int i = n - 1; i >= 0; i--)
            {
                // Обнуление элементов выше главной диагонали
                for (int j = i - 1; j >= 0; j--)
                {
                    double factor = augmentedMatrix[j, i];
                    for (int k = i; k < 2 * n; k++)
                    {
                        augmentedMatrix[j, k] -= factor * augmentedMatrix[i, k];
                    }
                }
            }    // Копирование обратной матрицы из расширенной матрицы
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = augmentedMatrix[i, j + n];
                }
            }

            return result;
        }

    }
}
