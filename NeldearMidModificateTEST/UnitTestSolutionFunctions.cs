using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenerateMatrixWithSilvestr;
using NeldearMeadModificateAndTestFunctionsIncluded;

namespace NeldearMidModificateTEST
{
    /// <summary>
    /// Класс, тестирующий работу класса Solution на функциях
    /// </summary>
    [TestClass]
    public class UnitTestSolutionFunctions
    {
        /// <summary>
        /// Метод, тестирующий работу метода GaussSolution класса Solution для размерности 3
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolution1()
        {
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini29.txt");
            double functionValue = solution.GetFunction(solution.GaussSolution);
            bool flag = true;
            double expectedFunctionValue = 2.4712;
            System.Console.WriteLine(functionValue);
            System.Console.WriteLine(expectedFunctionValue);
            if (System.Math.Abs(expectedFunctionValue - functionValue) > 0.001)              
                flag = false;             
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Метод, тестирующий работу метода GaussSolution класса Solution для размерности 4
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolution2()
        {
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini24.txt");
            double functionValue = solution.GetFunction(solution.GaussSolution);
            bool flag = true;
            double expectedFunctionValue = 1526;
            System.Console.WriteLine(functionValue);
            System.Console.WriteLine(expectedFunctionValue);
            if (System.Math.Abs(expectedFunctionValue - functionValue) > 1)
                flag = false;
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Метод, тестирующий работу метода GaussSolution класса Solution для размерности 5
        /// </summary>
        [TestMethod]
        public void TestMethodGaussSolution3()
        {
            Solution solution = new Solution();
            solution = solution.LoadSolutionFromFile("C:\\iniFiles\\ini12.txt");
            double functionValue = solution.GetFunction(solution.GaussSolution);
            bool flag = true;
            double expectedFunctionValue = 39.21;
            System.Console.WriteLine(functionValue);
            System.Console.WriteLine(expectedFunctionValue);
            if (System.Math.Abs(expectedFunctionValue - functionValue) > 100)
                flag = false;
            Assert.IsTrue(flag);
        }
    }
}