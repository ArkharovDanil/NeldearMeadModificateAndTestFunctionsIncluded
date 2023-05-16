using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenerateMatrixWithSilvestr;
using NeldearMeadModificateAndTestFunctionsIncluded;

namespace NeldearMidModificateTEST
{
    /// <summary>
    /// Класс, тестирующий работу класса Solution
    /// </summary>
    [TestClass]
    public class UnitTestSolution
    {
        /// <summary>
        /// Метод, тестирующий работу метода GaussSolution класса Solution
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolution()
        {
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini2.txt");
            double[] expectedValues = new double[] { -12.7272727272727,
                                                     -4.36363636363636,
                                                     0.0909090909090908 };
            bool flag = true;
            for (int i = 0; i < expectedValues.Length; i++)
            {
                if (expectedValues[i] != solution.GaussSolution[i])
                {
                    flag = false;
                }
            }
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Метод, тестирующий работу метода BVector класса Solution
        /// </summary>
        [TestMethod]
        public void TestMethodBVector()
        {
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini2.txt");
            double[] expectedValues = new double[] { 4,5,4};
            bool flag = true;
            for (int i = 0; i < expectedValues.Length; i++)
            {
                if (expectedValues[i] != solution.BVector[i])
                {
                    flag = false;
                }
            }
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Метод, тестирующий работу метода Determinants класса Solution
        /// </summary>
        [TestMethod]
        public void TestMethodDeterminants()
        {
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini2.txt");
            double[] expectedValues = new double[] {1,3,11};
            bool flag = true;
            for (int i = 0; i < expectedValues.Length; i++)
            {
                if (expectedValues[i] != solution.Determinants[i])
                {
                    flag = false;
                }
            }
            Assert.IsTrue(flag);
        }

    }
}