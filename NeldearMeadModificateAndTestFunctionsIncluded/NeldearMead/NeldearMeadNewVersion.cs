using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeldearMeadModificateAndTestFunctionsIncluded.NeldearMead
{
    static public class NeldearMeadNewVersion
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
            double gamma)
        {
            // Создание начального симплекса
            double[][] simplex = new double[NP + 1][];
            simplex[0] = (double[])X.Clone();
            for (int i = 1; i <= NP; i++)
            {
                double[] vertex = (double[])X.Clone();
                vertex[i - 1] += L;
                simplex[i] = vertex;
            }

            while (L > L_thres)
            {
                // Сортировка симплекса по значению целевой функции
                Array.Sort(simplex, (x1, x2) => ObjectiveFunction(x1).CompareTo(ObjectiveFunction(x2)));

                // Отражение
                double[] xReflection = new double[NP];
                for (int i = 0; i < NP; i++)
                {
                    xReflection[i] = simplex[0][i] + cR * (simplex[0][i] - simplex[NP][i]);
                }

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

                        if (ObjectiveFunction(xExpansion) < ObjectiveFunction(simplex[0]))
                        {
                            simplex[NP] = xExpansion;
                        }
                    }
                }
                else
                {
                    // Сжатие
                    double[] xContraction = new double[NP];
                    for (int i = 0; i < NP; i++)
                    {
                        xContraction[i] = simplex[0][i] + beta * (simplex[NP][i] - simplex[0][i]);
                    }

                    if (ObjectiveFunction(xContraction) < ObjectiveFunction(simplex[NP]))
                    {
                        simplex[NP] = xContraction;
                    }
                    else
                    {
                        // Редукция
                        for (int i = 1; i <= NP; i++)
                        {
                            for (int j = 0; j < NP; j++)
                            {
                                simplex[i][j] = simplex[0][j] + gamma * (simplex[i][j] - simplex[0][j]);
                            }
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


        
            return simplex[0];
        }
    }
}
