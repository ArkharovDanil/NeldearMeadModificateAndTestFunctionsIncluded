using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeldearMeadModificateAndTestFunctionsIncluded.AnotherMethods
{
    public static class Gradient
    {
        public static double[] GradientDescent(Func<double[], double> ObjectiveFunction,
                                        double[] X,
                                        int NP,
                                        double[] lowerBounds,
                                        double[] upperBounds)
        {
            double alpha = 0.01; // коэффициент обучения, можно настроить
            double precision = 0.00001; // точность для остановки алгоритма, можно настроить

            for (int i = 0; i < NP; i++)
            {
                var gradient = ComputeGradient(ObjectiveFunction, X); // градиент вашей функции

                // Обновляем каждый элемент вектора
                for (int j = 0; j < X.Length; j++)
                {
                    X[j] -= alpha * gradient[j]; // делаем шаг градиента
                                                 // Ограничиваем значения в пределах заданных границ
                    if (X[j] < lowerBounds[j]) X[j] = lowerBounds[j];
                    if (X[j] > upperBounds[j]) X[j] = upperBounds[j];
                }

                // Если норма градиента становится меньше заданной точности, останавливаем алгоритм
                if (Norm(gradient) < precision)
                    break;
            }
            return X;
        }

        // Вычисляем градиент с помощью центральной разности
        public static double[] ComputeGradient(Func<double[], double> f, double[] X)
        {
            double[] gradient = new double[X.Length];
            double h = 0.0001; // шаг для численного дифференцирования, можно настроить
            for (int i = 0; i < X.Length; i++)
            {
                double tmp = X[i];

                X[i] = tmp + h;
                double f1 = f(X);

                X[i] = tmp - h;
                double f2 = f(X);

                gradient[i] = (f1 - f2) / (2 * h);
                X[i] = tmp; // восстанавливаем X[i]
            }
            return gradient;
        }

        // Вычисляем норму вектора
        public static double Norm(double[] vector)
        {
            double sum = 0.0;
            for (int i = 0; i < vector.Length; i++)
            {
                sum += vector[i] * vector[i];
            }
            return Math.Sqrt(sum);
        }
    }

}
