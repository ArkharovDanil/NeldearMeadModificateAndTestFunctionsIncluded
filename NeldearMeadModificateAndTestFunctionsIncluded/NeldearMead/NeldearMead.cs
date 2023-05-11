using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateMatrixWithSilvestr;

namespace NeldearMeadModificateAndTestFunctionsIncluded.NeldearMead
{
    public class NeldearMead
    {
        Solution solution = new Solution();

        const int Dimension = 2;
        double[,] Nelder_Mid = new double[Dimension, Dimension + 1];
        double[] Vector = new double[Dimension + 1];
        double[] _firstSimplex = new double[Dimension + 1];
        string log = "";
        public void LogThis(string str)
        {
            log += str+"\n";
        }
        public void LogThis(int str)
        {
            log += str.ToString() + "\n";
        }
        public void LogThis(double str)
        {
            log += str.ToString() + "\n";
        }
        public string ShowLog()
        {
            return log;
        }
        public double[] GetFirstSimplex()
        {
            return _firstSimplex;
        }

        private double Function(double[] X, int NP)
        {
            double x1 = X[0];
            double p = 1.0 - x1;
            double p2 = X[1] - x1 * x1;
            return p * p + 100.0 * p2 * p2;
        }

        private void makeSimplex(double[] X, double L, int NP, bool first)
        {
            double qn, q2, r1, r2;
            int i, j;
            qn = Math.Sqrt(1.0 + NP) - 1.0;
            q2 = L / Math.Sqrt(2.0) * (double)NP;
            r1 = q2 * (qn + (double)NP);
            r2 = q2 * qn;
            for (i = 0; i < NP; i++) Nelder_Mid[i, 0] = X[i];
            for (i = 1; i < NP + 1; i++)
                for (j = 0; j < NP; j++)
                    Nelder_Mid[j, i] = X[j] + r2;
            for (i = 1; i < NP + 1; i++) Nelder_Mid[i - 1, i] = Nelder_Mid[i - 1, i] - r2 + r1;
            for (i = 0; i < NP + 1; i++)
            {
                for (j = 0; j < NP; j++) X[j] = Nelder_Mid[j, i];
                Vector[i] = Function(X, NP);
            }
            if (first)
            {
                LogThis("Значения функции в вершинах начального симплекса:");
                for (i = 0; i < NP + 1; i++)
                {
                    _firstSimplex[i] = Vector[i];
                    LogThis(Vector[i]);
                }

            }
        }
        private double[] masscenter(int k, int NP)
        {
            int i, j;
            double s;
            double[] xc = new double[NP];
            for (i = 0; i < NP; i++)
            {
                s = 0;
                for (j = 0; j < NP + 1; j++) s += Nelder_Mid[i, j];
                xc[i] = s;
            }
            for (i = 0; i < NP; i++) xc[i] = (xc[i] - Nelder_Mid[i, k]) / (double)NP;
            return xc;
        }
        private void reflection(int k, double cR, int NP)
        {
            double[] xc = masscenter(k, NP);
            for (int i = 0; i < NP; i++) Nelder_Mid[i, k] = (1.0 + cR) * xc[i] - Nelder_Mid[i, k];
        }
        private void reduction(int k, double gamma, int NP)
        {
            int i, j;
            double[] xk = new double[NP];
            for (i = 0; i < NP; i++) xk[i] = Nelder_Mid[i, k];
            for (j = 0; j < NP; j++)
                for (i = 0; i < NP; i++)
                    Nelder_Mid[i, j] = xk[i] + gamma * (Nelder_Mid[i, j] - xk[i]);
            for (i = 0; i < NP; i++) Nelder_Mid[i, k] = xk[i];
        }
        private void shrinking_expansion(int k, double alpha_beta, int NP)
        {
            double[] xc = masscenter(k, NP);
            for (int i = 0; i < NP; i++)
                Nelder_Mid[i, k] = xc[i] + alpha_beta * (Nelder_Mid[i, k] - xc[i]);
        }
        private double findL(double[] X2, int NP)
        {
            double L = 0;
            for (int i = 0; i < NP; i++) L += X2[i] * X2[i];
            return Math.Sqrt(L);
        }
        private double minval(double[] F, int N1, ref int imi)
        {
            double fmi = double.MaxValue, f;
            for (int i = 0; i < N1; i++)
            {
                f = F[i];
                if (f < fmi)
                {
                    fmi = f;
                    imi = i;
                }
            }
            return fmi;
        }
        private double maxval(double[] F, int N1, ref int ima)
        {
            double fma = double.MinValue, f;
            for (int i = 0; i < N1; i++)
            {
                f = F[i];
                if (f > fma)
                {
                    fma = f;
                    ima = i;
                }
            }
            return fma;
        }
        private void simplexRestore(int NP)
        {
            int i, imi = -1, imi2 = -1;
            double fmi, fmi2 = double.MaxValue, f;
            double[] X = new double[NP], X2 = new double[NP];
            fmi = minval(Vector, NP + 1, ref imi);
            for (i = 0; i < NP + 1; i++)
            {
                f = Vector[i];
                if (f != fmi && f < fmi2)
                {
                    fmi2 = f;
                    imi2 = i;
                }
            }
            for (i = 0; i < NP; i++)
            {
                X[i] = Nelder_Mid[i, imi];
                X2[i] = Nelder_Mid[i, imi] - Nelder_Mid[i, imi2];
            }
            makeSimplex(X, findL(X2, NP), NP, false);
        }
        private bool notStopYet(double L_thres, int NP)
        {
            int i, j, k;
            double[] X = new double[NP], X2 = new double[NP];
            for (i = 0; i < NP; i++)
            {
                for (j = 0; j < NP; j++) X[j] = Nelder_Mid[j, i];
                for (j = i + 1; j < NP + 1; j++)
                {
                    for (k = 0; k < NP; k++) X2[k] = X[k] - Nelder_Mid[k, j];
                    if (findL(X2, NP) > L_thres) return true;
                }
            }
            return false;
        }

        public double[] nelMead(ref double[] X, int NP, double L, double L_thres, double cR, double alpha, double beta, double gamma)
        {
            int i, j2, imi = -1, ima = -1;
            int j = 0, kr = 0, jMx = 10000;
            double[] X2 = new double[NP], X_R = new double[NP];
            double Fmi, Fma, F_R, F_S, F_E;
            const int kr_todo = 60;
            LogThis("Начальная длина ребра = " + L.ToString());
            LogThis("Предельное значение длины ребра  = " + L_thres.ToString());
            LogThis("Коэффициент отражения = " + cR.ToString());
            LogThis("Коэффициент растяжения = " + alpha.ToString());
            LogThis("Коэффициент сжатия = " + beta.ToString());
            LogThis("Коэффициент редукции  = " + gamma.ToString());
            makeSimplex(X, L, NP, true);
            while (notStopYet(L_thres, NP) && j < jMx)
            {
                j++;
                kr++;
                if (kr == kr_todo)
                {
                    kr = 0;
                    simplexRestore(NP);
                }
                Fmi = minval(Vector, NP + 1, ref imi);
                Fma = maxval(Vector, NP + 1, ref ima);
                for (i = 0; i < NP; i++) X[i] = Nelder_Mid[i, ima];
                reflection(ima, cR, NP);
                for (i = 0; i < NP; i++) X_R[i] = Nelder_Mid[i, ima];
                F_R = Function(X_R, NP);
                if (F_R > Fma)
                {
                    shrinking_expansion(ima, beta, NP);
                    for (i = 0; i < NP; i++) X2[i] = Nelder_Mid[i, ima];
                    F_S = Function(X2, NP);
                    if (F_S > Fma)
                    {
                        for (i = 0; i < NP; i++) Nelder_Mid[i, ima] = X[i];
                        reduction(ima, gamma, NP);
                        for (i = 0; i < NP + 1; i++)
                        {
                            if (i == ima) continue;
                            for (j2 = 0; j2 < NP; j2++) X2[j2] = Nelder_Mid[j2, i];

                            Vector[i] = Function(X2, NP);
                        }
                    }
                    else
                        Vector[ima] = F_S;
                }
                else if (F_R < Fmi)
                {
                    shrinking_expansion(ima, alpha, NP);
                    for (j2 = 0; j2 < NP; j2++) X2[j2] = Nelder_Mid[j2, ima];
                    F_E = Function(X2, NP);
                    if (F_E > Fmi)
                    {
                        for (j2 = 0; j2 < NP; j2++) Nelder_Mid[j2, ima] = X_R[j2];
                        Vector[ima] = F_R;
                    }
                    else
                        Vector[ima] = F_E;
                }
                else
                    Vector[ima] = F_R;
            }
            LogThis("Число итераций: " + j.ToString());
            return Vector;
        }
     

    }
    }
