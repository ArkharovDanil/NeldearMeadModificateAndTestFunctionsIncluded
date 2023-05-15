using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeldearMeadModificateAndTestFunctionsIncluded.NeldearMead
{
    public class NeldearMeadNewVersionWithBounds
    {
        public static double[] Optimize(
            Func<double[], double> ObjectiveFunction,
            double[] X,
            int NP,
            double L,
            double L_thres,
            double cR,
            double alpha,
            double beta,
            double gamma,
            double[] lowerBounds,
            double[] upperBounds)
        {
            // Создание начального симплекса с учетом границ
            double[][] simplex = new double[NP + 1][];
            simplex[0] = (double[])X.Clone();
            for (int i = 1; i <= NP; i++)
            {
                double[] vertex = (double[])X.Clone();
                vertex[i - 1] = Math.Min(Math.Max(vertex[i - 1] + L, lowerBounds[i - 1]), upperBounds[i - 1]);
                simplex[i] = vertex;
            }

            // Вспомогательная функция для проверки границ
            double[] CheckBounds(double[] x)
            {
                double[] boundedX = new double[NP];
                for (int i = 0; i < NP; i++)
                {
                    boundedX[i] = Math.Min(Math.Max(x[i], lowerBounds[i]), upperBounds[i]);
                }
                return boundedX;
            }

            while (L > L_thres)
            {
                Array.Sort(simplex, (x1, x2) => ObjectiveFunction(x1).CompareTo(ObjectiveFunction(x2)));

                // Отражение с проверкой границ
                double[] xReflection = new double[NP];
                for (int i = 0; i < NP; i++)
                {
                    xReflection[i] = simplex[0][i] + cR * (simplex[0][i] - simplex[NP][i]);
                }
                xReflection = CheckBounds(xReflection);


                if (ObjectiveFunction(xReflection) < ObjectiveFunction(simplex[NP - 1]))
                {
                    simplex[NP] = xReflection;

                    if (ObjectiveFunction(xReflection) < ObjectiveFunction(simplex[0]))
                    {
                        // Расширение
                        double[] xExpansion = new double[NP];

                        for (int i = 0; i < NP; i++)
                        {
                            xExpansion[i] = simplex[0][i] + alpha * (xReflection[i] - simplex[0][i]);
                        }
                        xExpansion = CheckBounds(xExpansion);

                        if (ObjectiveFunction(xExpansion) < ObjectiveFunction(simplex[0]))
                        {
                            simplex[NP] = xExpansion;
                        }
                    }
                }
                else
                {
                    // Сжатие с проверкой границ
                    double[] xContraction = new double[NP];
                    for (int i = 0; i < NP; i++)
                    {
                        xContraction[i] = simplex[0][i] + beta * (simplex[NP][i] - simplex[0][i]);
                    }
                    xContraction = CheckBounds(xContraction);
                    if (ObjectiveFunction(xContraction) < ObjectiveFunction(simplex[NP]))
                    {
                        simplex[NP] = xContraction;
                    }
                    else
                    {
                        // Редукция с проверкой границ
                        for (int i = 1; i <= NP; i++)
                        {
                            for (int j = 0; j < NP; j++)
                            {
                                simplex[i][j] = simplex[0][j] + gamma * (simplex[i][j] - simplex[0][j]);
                            }
                            simplex[i] = CheckBounds(simplex[i]);
                        }

                    }
                }
                   
                // Вычисление максимальной длины ребра
                L = 0.0;
                for (int i = 1; i <= NP; i++)
                {
                    double edgeLength = 0.0;
                    for (int j = 0; j < NP; j++)
                    {
                        edgeLength += Math.Pow(simplex[i][j] - simplex[0][j], 2);
                    }
                    edgeLength = Math.Sqrt(edgeLength);
                    L = Math.Max(L, edgeLength);
                }
            }

            // Возвращаем вершину симплекса с наименьшим значением целевой функции
            return simplex[0];
        }
    }
}
