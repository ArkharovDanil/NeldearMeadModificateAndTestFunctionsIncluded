using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenerateMatrixWithSilvestr;
using NeldearMeadModificateAndTestFunctionsIncluded;
using NeldearMeadModificateAndTestFunctionsIncluded.NeldearMead;



namespace ConsoleLogging
{
    public class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Program p = new Program();
            p.TestWithBounds29();
            p.TestWithoutBounds29();
        }

        public void TestWithBounds29()
        {
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini29.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = solution.GaussSolution;
            double L, L_thres, cR, alpha, beta, gamma;
            L = 2;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;

            double[] x = { 0.08,
                0.09,
                0.06 };

            Console.WriteLine("примерная функция="+ObjectiveFunctions.ObjectiveFunction29(x));

            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction29,
                                     X,
                                     NP,
                                     L,
                                     L_thres,
                                     cR,
                                     alpha,
                                     beta,
                                     gamma,
                                     lowerBounds,
                                     upperBounds);

            bool flag = true;
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                Console.WriteLine("Our answer= " + answer[i] + "; Gauss answer= " + gaussSolution[i]);
            }


            Console.WriteLine(ObjectiveFunctions.ObjectiveFunction29(answer));
            Console.WriteLine(ObjectiveFunctions.ExpectedFunctionValue29());



        }

        public void TestWithoutBounds29()
        {
            Console.WriteLine("Without bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 5;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;
            double[] x = { -0.08,
                -0.09,
                -0.06 };

            Console.WriteLine("примерная функция=" + ObjectiveFunctions.ObjectiveFunction29(x));
            double[] answer = NeldearMeadNewVersion.Optimize(ObjectiveFunctions.ObjectiveFunction29,
                                     X,
                                     NP,
                                     L,
                                     L_thres,
                                     cR,
                                     alpha,
                                     beta,
                                     gamma);


            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini29.txt");
            double[] gaussSolution = solution.GaussSolution;

            bool flag = true;
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                Console.WriteLine("Our answer= " + answer[i] + "; Gauss answer= "+gaussSolution[i]);
            }
                
            
            Console.WriteLine(ObjectiveFunctions.ObjectiveFunction29(answer));
            Console.WriteLine(ObjectiveFunctions.ExpectedFunctionValue29());



        }
    }
}
