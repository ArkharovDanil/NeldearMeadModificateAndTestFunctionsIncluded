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
            p.TestWithBounds3Dimension();
            p.TestWithBounds4Dimension();
            p.TestWithBounds5Dimension();
            //  p.TestWithoutBounds29();
        }
        public void TestWithBounds5Dimension()
        {
            TestWithBounds30();
            TestWithBounds29();
            TestWithBounds28();
            TestWithBounds27();
            TestWithBounds26();
            TestWithBounds25();
            TestWithBounds24();
            TestWithBounds23();
            TestWithBounds21();
            TestWithBounds20();
            //TestWithBounds19();
            TestWithBounds18();
            TestWithBounds17();
            TestWithBounds16();
        }
        public void TestWithBounds4Dimension()
        {
            TestWithBounds15();
            TestWithBounds14();
            TestWithBounds13();
            TestWithBounds12();
            TestWithBounds11();
            //TestWithBounds10();
            TestWithBounds9();
            TestWithBounds8();
            TestWithBounds7();
            TestWithBounds6();
        }
        public void TestWithBounds3Dimension()
        {
            TestWithBounds5();
            TestWithBounds4();
            TestWithBounds3();
            TestWithBounds2();
            TestWithBounds1();

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
        public void TestWithBounds30()
        {
            Console.WriteLine("TestWithBounds30");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini30.txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction30,
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

            double our = ObjectiveFunctions.ObjectiveFunction30(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue30();
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
        public void TestWithBounds29()
        {
            Console.WriteLine("TestWithBounds29");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini29.txt");
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

            double our = ObjectiveFunctions.ObjectiveFunction29(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue29();
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
        public void TestWithBounds28()
        {
            Console.WriteLine("TestWithBounds28");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini28.txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction28,
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

            double our = ObjectiveFunctions.ObjectiveFunction28(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue28();
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
        public void TestWithBounds22()
        {
            Console.WriteLine("TestWithBounds22");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini22txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction22,
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

            double our = ObjectiveFunctions.ObjectiveFunction22(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue22();
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
        public void TestWithBounds21()
        {
            Console.WriteLine("TestWithBounds21");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini21.txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction21,
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

            double our = ObjectiveFunctions.ObjectiveFunction21(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue21();
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
        public void TestWithBounds20()
        {
            Console.WriteLine("TestWithBounds20");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini20.txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction20,
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

            double our = ObjectiveFunctions.ObjectiveFunction20(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue20();
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
        public void TestWithBounds19()
        {
            Console.WriteLine("TestWithBounds19");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini19.txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction19,
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

            double our = ObjectiveFunctions.ObjectiveFunction19(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue19();
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
        public void TestWithBounds18()
        {
            Console.WriteLine("TestWithBounds18");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini18.txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction18,
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

            double our = ObjectiveFunctions.ObjectiveFunction18(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue18();
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
        public void TestWithBounds17()
        {
            Console.WriteLine("TestWithBounds17");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini17.txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction17,
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

            double our = ObjectiveFunctions.ObjectiveFunction17(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue17();
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
        public void TestWithBounds16()
        {
            Console.WriteLine("TestWithBounds16");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini16.txt");
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction16,
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

            double our = ObjectiveFunctions.ObjectiveFunction16(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue16();
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
        public void TestWithBounds15()
        {
            Console.WriteLine("TestWithBounds15");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini15.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction15,
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

            double our = ObjectiveFunctions.ObjectiveFunction15(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue15();
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
        public void TestWithBounds14()
        {
            Console.WriteLine("TestWithBounds14");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini14.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction14,
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

            double our = ObjectiveFunctions.ObjectiveFunction14(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue14();
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
        public void TestWithBounds13()
        {
            Console.WriteLine("TestWithBounds13");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini13.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction13,
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

            double our = ObjectiveFunctions.ObjectiveFunction13(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue13();
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
        public void TestWithBounds12()
        {
            Console.WriteLine("TestWithBounds12");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini12.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction12,
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

            double our = ObjectiveFunctions.ObjectiveFunction12(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue12();
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
        public void TestWithBounds11()
        {
            Console.WriteLine("TestWithBounds11");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini11.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction11,
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

            double our = ObjectiveFunctions.ObjectiveFunction11(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue11();
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
        public void TestWithBounds10()
        {
            Console.WriteLine("TestWithBounds10");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini10.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 100;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction10,
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

            double our = ObjectiveFunctions.ObjectiveFunction10(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue10();
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
        public void TestWithBounds9()
        {
            Console.WriteLine("TestWithBounds9");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini9.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction9,
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

            double our = ObjectiveFunctions.ObjectiveFunction9(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue9();
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
        public void TestWithBounds8()
        {
            Console.WriteLine("TestWithBounds8");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini8.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction8,
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

            double our = ObjectiveFunctions.ObjectiveFunction8(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue8();
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
        public void TestWithBounds7()
        {
            Console.WriteLine("TestWithBounds7");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini7.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction7,
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

            double our = ObjectiveFunctions.ObjectiveFunction7(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue7();
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
        public void TestWithBounds6()
        {
            Console.WriteLine("TestWithBounds6");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini6.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction6,
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

            double our = ObjectiveFunctions.ObjectiveFunction6(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue6();
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
        public void TestWithBounds5()
        {
            Console.WriteLine("TestWithBounds5");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini5.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction5,
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

            double our = ObjectiveFunctions.ObjectiveFunction5(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue5();
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
        public void TestWithBounds4()
        {
            Console.WriteLine("TestWithBounds4");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini4.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction4,
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

            double our = ObjectiveFunctions.ObjectiveFunction4(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue4();
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
        public void TestWithBounds3()
        {
            Console.WriteLine("TestWithBounds3");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini3.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction3,
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

            double our = ObjectiveFunctions.ObjectiveFunction3(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue3();
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
        public void TestWithBounds2()
        {
            Console.WriteLine("TestWithBounds2");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini2.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction2,
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

            double our = ObjectiveFunctions.ObjectiveFunction2(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue2();
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
            Console.WriteLine("---------------------------------------------");
        }
        public void TestWithBounds1()
        {
            Console.WriteLine("TestWithBounds1");
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini1.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(10);
            double[] upperBounds = solution.UpperBound(10);
            Console.WriteLine("With bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(ObjectiveFunctions.ObjectiveFunction1,
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

            double our = ObjectiveFunctions.ObjectiveFunction1(answer);
            double expected = ObjectiveFunctions.ExpectedFunctionValue1();
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
