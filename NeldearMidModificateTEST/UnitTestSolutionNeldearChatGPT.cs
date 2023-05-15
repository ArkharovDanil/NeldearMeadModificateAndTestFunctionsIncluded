using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenerateMatrixWithSilvestr;
using NeldearMeadModificateAndTestFunctionsIncluded.NeldearMead;

namespace NeldearMidModificateTEST
{
    /// <summary>
    /// Класс, тестирующий работу класса Solution на функциях
    /// </summary>
    [TestClass]
    public class UnitTestSolutionNeldearNewVersion
    {


        /// <summary>
        /// Тест метод для 29 функции
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolutionNewMethodFunc29()
        {
            const int NP = 3;
            double[] Vector = new double[NP + 1];
            double[] X = { 0, 0, 0 };
            double L, L_thres, cR, alpha, beta, gamma;
            L = 5;
            L_thres = 1;
            cR = 1.0;
            alpha = 2.0;
            beta = 0.5;
            gamma = 0.5;

            double[] answer = NeldearMeadNewVersion.Optimize(ObjectiveFunctions.ObjectiveFunction29,
                                     X,
                                     NP,
                                     L,
                                     L_thres,
                                     cR,
                                     alpha,
                                     beta,
                                     gamma);



            bool flag = true;
            if (System.Math.Abs(ObjectiveFunctions.ObjectiveFunction29(answer) - ObjectiveFunctions.ExpectedFunctionValue29()) < 5)
            {

            }
            else
            {
                flag = false;
            }

            Assert.IsTrue(flag);
        }
        /// <summary>
        /// Тест метод для 27 функции
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolutionNewMethodFunc27()
        {
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
            if (System.Math.Abs(ObjectiveFunctions.ObjectiveFunction27(answer) - ObjectiveFunctions.ExpectedFunctionValue27()) < 5)
            {

            }
            else
            {
                flag = false;
            }

            Assert.IsTrue(flag);
        }
        /// <summary>
        /// Тест метод для 28 функции
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolutionNewMethodFunc28()
        {
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

            double[] answer = NeldearMeadNewVersion.Optimize(ObjectiveFunctions.ObjectiveFunction28,
                                     X,
                                     NP,
                                     L,
                                     L_thres,
                                     cR,
                                     alpha,
                                     beta,
                                     gamma);



            bool flag = true;
            if (System.Math.Abs(ObjectiveFunctions.ObjectiveFunction28(answer) - ObjectiveFunctions.ExpectedFunctionValue28()) < 5)
            {

            }
            else
            {
                flag = false;
            }

            Assert.IsTrue(flag);
        }
        /// <summary>
        /// Тест метод для 30 функции
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolutionNewMethodFunc30()
        {
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

            double[] answer = NeldearMeadNewVersion.Optimize(ObjectiveFunctions.ObjectiveFunction30,
                                     X,
                                     NP,
                                     L,
                                     L_thres,
                                     cR,
                                     alpha,
                                     beta,
                                     gamma);



            bool flag = true;
            if (System.Math.Abs(ObjectiveFunctions.ObjectiveFunction30(answer) - ObjectiveFunctions.ExpectedFunctionValue30()) < 5)
            {

            }
            else
            {
                flag = false;
            }

            Assert.IsTrue(flag);
        }
        /// <summary>
        /// Тест метод для 30 функции
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolutionNewMethodFunc31()
        {
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

            double[] answer = NeldearMeadNewVersion.Optimize(ObjectiveFunctions.ObjectiveFunction31,
                                     X,
                                     NP,
                                     L,
                                     L_thres,
                                     cR,
                                     alpha,
                                     beta,
                                     gamma);



            bool flag = true;
            if (System.Math.Abs(ObjectiveFunctions.ObjectiveFunction31(answer) - ObjectiveFunctions.ExpectedFunctionValue31()) < 5)
            {

            }
            else
            {
                flag = false;
            }

            Assert.IsTrue(flag);
        }
    }
}