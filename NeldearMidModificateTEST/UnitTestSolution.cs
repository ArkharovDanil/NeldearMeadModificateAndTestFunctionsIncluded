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
            double[] expectedValues = new double[] { -1.6141975308642,
                                         -6.29938271604938,
                                         -1.16654641654642,
                                         -6.36363636363637,
                                         -2.67849794238683 };
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
            double[] expectedValues = new double[] { -8, -5, -4, 2, -7 };
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
            double[] expectedValues = new double[] {6,11,77,1337,868};
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