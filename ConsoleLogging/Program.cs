﻿using System;
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
        private List<(int, double)> Combine = new List<(int, double)>();
        int current = 0;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Program p = new Program();
           // p.ForDiplomaThirdDimension();
          //  p.ForDiplomaFourthDimension();
           // p.ForDiplomaFifthDimension();
            p.ForDiplomaThirdDimensionFiveFunctions();
            //p.ForDiploma4();
            //p.ForDiploma5();
            //p.ForDiploma12();
            //p.ForDiploma14();
            //p.ForDiploma25();
            //p.ForDiploma26();
            // p.TestWithBounds29();
            // p.TestWithBounds28();
           // p.TestWithBounds3Dimension();
        //    p.TestWithBounds4Dimension();
          //  p.TestWithBounds5Dimension();

            int Good = 0;
            int Best = 0;
            int Worst = 0;
            int Better = 0;
            int Betterest = 0;
            int b = 1;
            foreach (var t in p.Combine)
            {
                Console.WriteLine();
                Console.Write(b+" = "+t.Item2);
                b++;
                if (t.Item2 < 0.01)
                {
                    Betterest++;
                    Console.Write(" betterest");
                }
                else
                {
                    if (t.Item2 < 0.1)
                    {
                        Better++;
                        Console.Write(" better");
                     }
                    else
                    {
                        if (t.Item2 < 0.1 * t.Item1)
                        {
                            Best++;
                            Console.Write(" best");
                        }
                        else
                        {
                            if (t.Item2 < 0.1 * t.Item1 * t.Item1)
                            {
                                Good++;
                                Console.Write(" Good");
                            }
                            else
                            {
                                Worst++;
                                Console.Write(" worst");
                            }
                        }
                    }
                }


              
               
                
                

            }
            Console.WriteLine();
            Console.WriteLine("Betterest= " + Betterest);
            Console.WriteLine("Better= " + Better);
            Console.WriteLine("Best= " + Best);
            Console.WriteLine("Good= " + Good);
            Console.WriteLine("Worst= " + Worst);
        }
        public double[] CloseTo(double[] x)
        {
            double[] answer=new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                Random rand = new Random();
                int t = rand.Next(4);
                if (t % 2 == 0)
                {
                    answer[i] = x[i] + t;
                }
                else
                {
                    answer[i] = x[i] - t;
                }
                
            }
            return answer;
        }
        public int WhichEstimate(double t)
        {
            Console.WriteLine("Estimate= " + t);
            if (t < 0.01)
            {
                Console.WriteLine("Best");
                return 0;
            }
            if (t < 0.1)
            {
                Console.WriteLine("Good");
                return 0;
            }
            if (t < 1)
            {
                Console.WriteLine("Not Good");
                return 0;
            }
            if (t < 10)
            {
                Console.WriteLine("Not Good");
                return 0;
            }
            Console.WriteLine("Bad");
            return -1;

        }
        public void MethodMethod(double[] expected, double[] solved)
        {
            double estimate = Estimation(expected, solved);
            Combine.Add((expected.Length, estimate));
            current++;
        }
        public double Estimation(double[] expected, double[] solved)
        {
            double SumDiff = 0;
            double estimation=0;
           
            for (int i=0; i < solved.Length; i++)
            {
                SumDiff+=Math.Abs(Math.Pow(solved[i]-expected[i],1));
            }
            //double pow = Math.Pow(6-expected.Length,-1);
            //estimation =Math.Pow(SumDiff,pow);
            estimation = SumDiff/solved.Length;
            return estimation;
            
        }
        public double FunctionThirdDimension(double[] x)
        {
            double first = ObjectiveFunctions.ObjectiveFunction4(x);
            double second = ObjectiveFunctions.ObjectiveFunction5(x);
            if (first > second) 
                return second;
            return first;

        }
        public double FunctionThirdDimensionFiveFunctions(double[] x)
        {
            double[] solutions=new double[5];
            List<double> f=new List<double>();
            f.Add(ObjectiveFunctions.ObjectiveFunction1(x));
            f.Add(ObjectiveFunctions.ObjectiveFunction2(x));
            f.Add(ObjectiveFunctions.ObjectiveFunction3(x));
            f.Add(ObjectiveFunctions.ObjectiveFunction4(x));
            f.Add(ObjectiveFunctions.ObjectiveFunction5(x));
            double answer = f.Min();
            return answer;
        }
        public double FunctionFourthDimension(double[] x)
        {
            double first = ObjectiveFunctions.ObjectiveFunction12(x);
            double second = ObjectiveFunctions.ObjectiveFunction14(x);
            if (first > second)
                return second;
            return first;

        }
        public double FunctionFifthDimension(double[] x)
        {
            double first = ObjectiveFunctions.ObjectiveFunction25(x);
            double second = ObjectiveFunctions.ObjectiveFunction26(x);
            if (first > second)
                return second;
            return first;

        }
        public void ForDiplomaThirdDimensionFiveFunctions()
        {
            Console.WriteLine("TestWithBoundsThirdDimension");
            Solution solution1 = new Solution();
            Solution solution2 = new Solution();
            Solution solution3 = new Solution();
            Solution solution4 = new Solution();
            Solution solution5 = new Solution();
            solution1 = solution1.LoadSolutionFromFile("C:\\iniFiles\\ini1.txt");
            solution2 = solution2.LoadSolutionFromFile("C:\\iniFiles\\ini2.txt");
            solution3 = solution3.LoadSolutionFromFile("C:\\iniFiles\\ini3.txt");
            solution4 = solution4.LoadSolutionFromFile("C:\\iniFiles\\ini4.txt");
            solution5 = solution5.LoadSolutionFromFile("C:\\iniFiles\\ini5.txt");
            double[] gaussSolution1 = solution1.GaussSolution;
            double[] gaussSolution2 = solution2.GaussSolution;
            double[] gaussSolution3 = solution3.GaussSolution;
            double[] gaussSolution4 = solution4.GaussSolution;
            double[] gaussSolution5 = solution5.GaussSolution;
            double[] lowerBounds = solution1.LowerBound(1000);
            double[] upperBounds = solution1.UpperBound(1000);
            Console.WriteLine("With bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = CloseTo(gaussSolution2);
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(FunctionThirdDimensionFiveFunctions,
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

            double our = FunctionThirdDimensionFiveFunctions(answer);
            double expected1 = FunctionThirdDimensionFiveFunctions(gaussSolution1);
            double expected2 = FunctionThirdDimensionFiveFunctions(gaussSolution2);
            double expected3 = FunctionThirdDimensionFiveFunctions(gaussSolution3);
            double expected4 = FunctionThirdDimensionFiveFunctions(gaussSolution4);
            double expected5 = FunctionThirdDimensionFiveFunctions(gaussSolution5);
            Console.WriteLine("Оценка относительно первого решения= " + Estimation(gaussSolution1, answer));
            Console.WriteLine("Оценка относительно второго решения= " + Estimation(gaussSolution2, answer));
            Console.WriteLine("Оценка относительно третьего решения= " + Estimation(gaussSolution3, answer));
            Console.WriteLine("Оценка относительно четвёртого решения= " + Estimation(gaussSolution4, answer));
            Console.WriteLine("Оценка относительно пятого решения= " + Estimation(gaussSolution5, answer));
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer1 = " + expected1);
            Console.WriteLine("expectedAnswer2 = " + expected2);
            Console.WriteLine("expectedAnswer3 = " + expected3);
            Console.WriteLine("expectedAnswer4 = " + expected4);
            Console.WriteLine("expectedAnswer5 = " + expected5);

            Console.WriteLine("--------------------------------------------- ");
        }
        public void ForDiplomaThirdDimension()
        {
            Console.WriteLine("TestWithBoundsThirdDimension");
            Solution solution = new Solution();
            Solution solution1 = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini4.txt");
            solution1= solution1.LoadSolutionFromFile("C:\\iniFiles\\ini5.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(1000);
            double[] upperBounds = solution.UpperBound(1000);
            Console.WriteLine("With bounds");
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = { 0,0,0};
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(FunctionThirdDimension,
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

            double our = FunctionThirdDimension(answer);
            double expected = FunctionThirdDimension(gaussSolution);
            double expected2 = FunctionThirdDimension(solution1.GaussSolution);
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
            //    Console.WriteLine("x[" + i + "] = " + answer[i] + " G1solution= "+gaussSolution[i]+" Разница="+Math.Abs(answer[i]-gaussSolution[i])+" G2solution= "+solution1.GaussSolution[i]+" Разница= "+ Math.Abs(answer[i] - solution1.GaussSolution[i]));
            }
            Console.WriteLine("Оценка относительно первого решения= "+Estimation(gaussSolution,answer));
            Console.WriteLine("Оценка относительно второго решения= " + Estimation(solution1.GaussSolution, answer));

            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer1 = " + expected);
            Console.WriteLine("expectedAnswer2 = " + expected2);

            Console.WriteLine("--------------------------------------------- ");

                    }
        public void ForDiplomaFourthDimension()
        {
            Console.WriteLine("TestWithBoundsFourthDimension");
            Solution solution = new Solution();
            Solution solution1 = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini12.txt");
            solution1 = solution1.LoadSolutionFromFile("C:\\iniFiles\\ini14.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] gaussSolution1 = solution1.GaussSolution;
            double[] lowerBounds = solution.LowerBound(1000);
            double[] upperBounds = solution.UpperBound(1000);
            Console.WriteLine("With bounds");
            const int NP = 4;
            double[] Vector = new double[NP + 1];
            double[] X = { gaussSolution1[0]-1, gaussSolution1[1] - 2, gaussSolution1[2] - 2, gaussSolution1[3] - 1 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 10;
            L_thres = 0.1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(FunctionFourthDimension,
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

            double our = FunctionFourthDimension(answer);
            double expected = FunctionFourthDimension(gaussSolution);
            double expected2 = FunctionFourthDimension(solution1.GaussSolution);
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
                //Console.WriteLine("x[" + i + "] = " + answer[i]);
            }
            Console.WriteLine("Оценка относительно первого решения= " + Estimation(gaussSolution, answer));
            Console.WriteLine("Оценка относительно второго решения= " + Estimation(solution1.GaussSolution, answer));
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer1 = " + expected);
            Console.WriteLine("expectedAnswer2 = " + expected2);

            Console.WriteLine("--------------------------------------------- ");

        }
        public void ForDiplomaFifthDimension()
        {
            Console.WriteLine("TestWithBoundsFifthDimension");
            Solution solution = new Solution();
            Solution solution1 = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini25.txt");
            solution1 = solution1.LoadSolutionFromFile("C:\\iniFiles\\ini26.txt");
            double[] gaussSolution = solution.GaussSolution;
            double[] lowerBounds = solution.LowerBound(1000);
            double[] upperBounds = solution.UpperBound(1000);
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


            double[] answer = NeldearMeadNewVersionWithBounds.Optimize(FunctionFifthDimension,
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

            double our = FunctionFifthDimension(answer);
            double expected = FunctionFifthDimension(gaussSolution);
            double expected2 = FunctionFifthDimension(solution1.GaussSolution);
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
               // Console.WriteLine("x[" + i + "] = " + answer[i]);
            }
            Console.WriteLine("Оценка относительно первого решения= " + Estimation(gaussSolution, answer));
            Console.WriteLine("Оценка относительно второго решения= " + Estimation(solution1.GaussSolution, answer));
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer1 = " + expected);
            Console.WriteLine("expectedAnswer2 = " + expected2);

            Console.WriteLine("--------------------------------------------- ");

        }
        public void ForDiploma4()
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
            for (int i = 0; i < gaussSolution.Length; i++)
            {
               // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
                Console.WriteLine("x[" + i + "] = " + answer[i]);
            }
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer = " + expected);
            Console.WriteLine("--------------------------------------------- ");

        }
        public void ForDiploma5()
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
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
                Console.WriteLine("x[" + i + "] = " + answer[i]);
            }
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer = " + expected);
            Console.WriteLine("--------------------------------------------- ");

        }
        public void ForDiploma12()
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
            double[] X = { 0, 0, 0 ,0};
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
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
                Console.WriteLine("x[" + i + "] = " + answer[i]);
            }
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer = " + expected);
            Console.WriteLine("--------------------------------------------- ");

        }
        public void ForDiploma14()
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
            double[] X = { 0, 0, 0 ,0};
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
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
                Console.WriteLine("x[" + i + "] = " + answer[i]);
            }
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer = " + expected);
            Console.WriteLine("--------------------------------------------- ");

        }
        public void ForDiploma25()
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
            double[] X = { 0, 0, 0 ,0,0};
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
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
                Console.WriteLine("x[" + i + "] = " + answer[i]);
            }
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer = " + expected);
            Console.WriteLine("--------------------------------------------- ");

        }
        public void ForDiploma26()
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
            double[] X = { 0, 0, 0 ,0,0};
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
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                // Console.WriteLine("Gauss solution "+i+" "+ gaussSolution[i]);
                Console.WriteLine("x[" + i + "] = " + answer[i]);
            }
            double miss = Math.Abs(our - expected);
            Console.WriteLine("miss= " + miss);
            Console.WriteLine("Our answer = " + our);
            Console.WriteLine("expectedAnswer = " + expected);
            Console.WriteLine("--------------------------------------------- ");

        }
        public void TestWithBounds5Dimension()
        {
            TestWithBounds30();//16
            TestWithBounds29();//17
            TestWithBounds28();//18
            TestWithBounds27();//19
            TestWithBounds26();//20
            TestWithBounds25();//21
            TestWithBounds24();//22
            TestWithBounds23();//23
            TestWithBounds21();//24
            TestWithBounds20();//25
            TestWithBounds19();//26
            TestWithBounds18();//27
            TestWithBounds17();//28
            TestWithBounds16();//29
        }
        public void TestWithBounds4Dimension()
        {
            TestWithBounds15();//6
            TestWithBounds14();//7
            TestWithBounds13();//8
            TestWithBounds12();//9
            TestWithBounds11();//10
            TestWithBounds10();//11
            TestWithBounds9();//12
            TestWithBounds8();//13
            TestWithBounds7();//14
            TestWithBounds6();//15
        }
        public void TestWithBounds3Dimension()
        {
            TestWithBounds5();//1
            TestWithBounds4();//2
            TestWithBounds3();//3
            TestWithBounds2();//4
            TestWithBounds1();//5

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

            double expected = FunctionFourthDimension(gaussSolution);
            Console.WriteLine("Оценка относительно первого решения= " + Estimation(gaussSolution, answer));


            bool flag = true;
            for (int i = 0; i < gaussSolution.Length; i++)
            {
                Console.WriteLine("Our answer= " + answer[i] + "; Gauss answer= " + gaussSolution[i]);
            }


            Console.WriteLine("Our answer= " + ObjectiveFunctions.ObjectiveFunction29(answer));
            Console.WriteLine("expectedAnswer= " + ObjectiveFunctions.ExpectedFunctionValue29());
            WhichEstimate(Estimation(gaussSolution, answer));
            MethodMethod(gaussSolution, answer);


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
            double[] X = CloseTo(gaussSolution);
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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            double[] X = CloseTo(gaussSolution);
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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            double[] X = CloseTo(gaussSolution);
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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));
            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));
            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);

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
            WhichEstimate(Estimation(gaussSolution, answer));

            MethodMethod(gaussSolution, answer);




        }
    }
}
