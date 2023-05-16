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
            // p.TestWithBounds29();
            // p.TestWithBounds28();
            p.TestWithBounds();
          //  p.TestWithoutBounds29();
        }
        public void TestWithBounds()
        {
            TestWithBounds27();
            TestWithBounds26();
            TestWithBounds25();
            TestWithBounds24();
            TestWithBounds23();

        }
        public void TestWithoutBounds27()
        {
            Console.WriteLine("TestWithoutBounds27");
            Console.WriteLine("Without bounds");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini29.txt");
            double[] gaussSolution = solution.GaussSolution;
            const int NP = 5;
            double[] Vector = new double[NP + 1];
            double[] X = solution.GaussSolution;
            double L, L_thres, cR, alpha, beta, gamma;
            L = 5;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;

            double[] answer = NeldearMeadNewVersion.Optimize(ObjectiveFunctions.ObjectiveFunction27,
                                     X,
                                     NP,
                                     L,
                                     L_thres,
                                     cR,
                                     alpha,
                                     beta,
                                     gamma);


            

            bool flag = true;
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                Console.WriteLine("Our answer= " + answer[i] + "; Gauss answer= " + gaussSolution[i]);
            }


            Console.WriteLine("Our answer= " + ObjectiveFunctions.ObjectiveFunction29(answer));
            Console.WriteLine("expectedAnswer= " + ObjectiveFunctions.ExpectedFunctionValue29());



        }
        public void TestWithBounds27()
        {          
            Console.WriteLine("TestWithBounds27");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini27.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 5;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0,0,0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction27,
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
           
            double our = ObjectiveFunctions.ObjectiveFunction27(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue27();
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            if (miss<10)
            {
                for (int i = 0; i < gaussSolution.Length; i++)
                {
                    Console.WriteLine("miss in coords= " + Math.Abs(answer[i] - gaussSolution[i]));
                }
                Console.WriteLine("Our answer = " + our);
                Console.WriteLine("expectedAnswer = " + expected);

            }
            Console.WriteLine("--------------------------------------------- ");
        }
        public void TestWithBounds26()
        {
            Console.WriteLine("TestWithBounds26");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini26.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 5;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction26,
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

            double our = ObjectiveFunctions.ObjectiveFunction26(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue26();
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            if (miss < 10)
            {
                for (int i = 0; i < gaussSolution.Length; i++)
                {
                    Console.WriteLine("miss in coords= " + Math.Abs(answer[i] - gaussSolution[i]));
                }
                Console.WriteLine("Our answer = " + our);
                Console.WriteLine("expectedAnswer = " + expected);

            }
            Console.WriteLine("--------------------------------------------- ");
        }
        public void TestWithBounds25()
        {
            Console.WriteLine("TestWithBounds25");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini25.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 5;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction25,
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

            double our = ObjectiveFunctions.ObjectiveFunction25(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue25();
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            if (miss < 10)
            {
                for (int i = 0; i < gaussSolution.Length; i++)
                {
                    Console.WriteLine("miss in coords= " + Math.Abs(answer[i] - gaussSolution[i]));
                }
                Console.WriteLine("Our answer = " + our);
                Console.WriteLine("expectedAnswer = " + expected);

            }
            Console.WriteLine("--------------------------------------------- ");
        }
        public void TestWithBounds24()
        {
            Console.WriteLine("TestWithBounds24");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini24.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 5;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction24,
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

            double our = ObjectiveFunctions.ObjectiveFunction24(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue24();
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            if (miss < 10)
            {
                for (int i = 0; i < gaussSolution.Length; i++)
                {
                    Console.WriteLine("miss in coords= " + Math.Abs(answer[i] - gaussSolution[i]));
                }
                Console.WriteLine("Our answer = " + our);
                Console.WriteLine("expectedAnswer = " + expected);

            }
            Console.WriteLine("--------------------------------------------- ");
        }
        public void TestWithBounds23()
        {
            Console.WriteLine("TestWithBounds23");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini23.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 5;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction23,
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

            double our = ObjectiveFunctions.ObjectiveFunction23(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue23();
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            if (miss < 10)
            {
                for (int i = 0; i < gaussSolution.Length; i++)
                {
                    Console.WriteLine("miss in coords= " + Math.Abs(answer[i] - gaussSolution[i]));
                }
                Console.WriteLine("Our answer = " + our);
                Console.WriteLine("expectedAnswer = " + expected);

            }
            Console.WriteLine("--------------------------------------------- ");
        }

        public void TestWithoutBounds29()
        {
            Console.WriteLine("TestWithoutBounds29");
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


            Console.WriteLine("Our answer= " + ObjectiveFunctions.ObjectiveFunction29(answer));
            Console.WriteLine("expectedAnswer= " + ObjectiveFunctions.ExpectedFunctionValue29());



        }
    }
}
