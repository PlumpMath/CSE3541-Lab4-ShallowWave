using System;
using UnityEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShallowWaveTests
{
    [TestClass]
    public class HeightsTests
    {
        [TestMethod]
        public void FromYsTests()
        {
            float[] ys = new float[9] {1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f};
            float[,] expectedHeights = new float[,] { { 1.0f, 2.0f, 3.0f }, 
                                                      { 4.0f, 5.0f, 6.0f }, 
                                                      { 7.0f, 8.0f, 9.0f } };

            float[,] actualHeights = Heights.From_Ys(ys);

            CollectionAssert.AreEqual(expectedHeights, actualHeights);
        }

        [TestMethod]
        public void ToYsTests()
        {
            float[] expectedYs = new float[9] {1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f};

            float[,] heights = new float[,] { { 1.0f, 2.0f, 3.0f }, 
                                              { 4.0f, 5.0f, 6.0f }, 
                                              { 7.0f, 8.0f, 9.0f } };

            float[] actualYs = Heights.To_Ys(heights);

            CollectionAssert.AreEqual(expectedYs, actualYs);
        }

        [TestMethod]
        public void FromVerticesTests()
        {
            Vector3[] vertices = new Vector3[] { new Vector3(0.0f, 0.0f, 0.0f),
                                                 new Vector3(0.0f, 1.0f, 0.0f),
                                                 new Vector3(0.0f, 2.0f, 0.0f),
                                                 new Vector3(0.0f, 3.0f, 0.0f) };

            float[,] expectedHeights = { { 0.0f, 1.0f },
                                         { 2.0f, 3.0f } };

            float[,] actualHeights = Heights.From_Vertices(vertices);

            CollectionAssert.AreEqual(expectedHeights, actualHeights);
        }


        [TestMethod]
        public void ToVertexYsTests()
        {
            Vector3[] vertices = new Vector3[] { new Vector3(0.0f, 0.0f, 0.0f),
                                                 new Vector3(0.0f, 0.0f, 0.0f),
                                                 new Vector3(0.0f, 0.0f, 0.0f),
                                                 new Vector3(0.0f, 0.0f, 0.0f) };

            float[,] heights = { { 0.0f, 1.0f },
                                 { 2.0f, 3.0f } };

            Vector3[] expectedVs = new Vector3[] { new Vector3(0.0f, 0.0f, 0.0f),
                                                   new Vector3(0.0f, 1.0f, 0.0f),
                                                   new Vector3(0.0f, 2.0f, 0.0f),
                                                   new Vector3(0.0f, 3.0f, 0.0f) };

            Vector3[] actualVs = Heights.To_Vertex_Ys(heights, vertices);

            CollectionAssert.AreEqual(expectedVs, actualVs);
        }
    }
}
