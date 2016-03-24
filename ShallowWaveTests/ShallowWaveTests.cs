using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShallowWaveTests
{
    [TestClass]
    public class HeightsTests
    {
        [TestMethod]
        public void CopyYsToHeightsTests()
        {
            float[] ys = new float[9] {1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f};
            float[,] expectedHeights = new float[,] { { 1.0f, 2.0f, 3.0f }, 
                                                      { 4.0f, 5.0f, 6.0f }, 
                                                      { 7.0f, 8.0f, 9.0f } };

            float[,] actualHeights = Heights.From_Ys(ys);

            CollectionAssert.AreEqual(expectedHeights, actualHeights);
        }

        [TestMethod]
        public void CopyHeightsToYsTests()
        {
            float[] expectedYs = new float[9] {1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f};

            float[,] heights = new float[,] { { 1.0f, 2.0f, 3.0f }, 
                                              { 4.0f, 5.0f, 6.0f }, 
                                              { 7.0f, 8.0f, 9.0f } };

            float[] actualYs = Heights.To_Ys(heights);

            CollectionAssert.AreEqual(expectedYs, actualYs);
        }
    }
}
