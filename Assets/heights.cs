using UnityEngine;
using System;

public class Heights
{
    public Heights()
    {
    }

    public static float[,] From_Ys(float[] ys)
    {
        int side = (int)Math.Sqrt((double) ys.Length);
        float[,] heights = new float[side, side];

        int yIndex = 0;

        for(int y = 0; y < side; y++)
        {
            for (int x = 0; x < side; x++) {
                heights[y, x] = ys[yIndex];

                yIndex++;
            }
        }

        return heights;
    }

    public static float[] To_Ys(float[,] heights)
    {
        int length = heights.Length;
        int side = (int)Math.Sqrt((double) length);

        float[] ys = new float[length];

        int yIndex = 0;

        for(int y = 0; y < side; y++)
        {
            for(int x = 0; x < side; x++)
            {
                ys[yIndex] = heights[y, x];

                yIndex++;
            }
        }

        return ys;
    }

    public static float[,] From_Vertices(Vector3[] vs)
    {
        float[] ys = Vertices_To_Ys(vs);
        float[,] heights = From_Ys(ys);

        return heights;
    }

    public static Vector3[] To_Vertex_Ys(float[,] heights, Vector3[] vs)
    {
        float[] ys = To_Ys(heights);
        Vector3[] newVs = Ys_To_Vertex_Ys(ys, vs);

        return newVs;
    }

    public static float[,] New_H(float[,] old_h, float[,] h, float damping, float rate)
    {
        int length = h.Length;
        int side = (int)Math.Sqrt((double) length);
        float[,] new_h = new float[side, side];

        for(int y = 0; y < side; y++)
        {
            int yMinus1 = y - 1 >= 0 ? y - 1 : y;
            int yPlus1 = y + 1 < side ? y + 1 : y;

            for (int x = 0; x < side; x++)
            {
                int xMinus1 = x - 1 >= 0 ? x - 1 : x;
                int xPlus1 = x + 1 < side ? x + 1 : x;

                new_h[y, x] = h[y, x] + (h[y, x] - old_h[y, x]) * damping +
                             (h[yMinus1,x] + h[yPlus1,x] + h[y,xMinus1] + h[y,xPlus1] - 4*h[y,x]) * rate;
            }
        }

        return new_h;
    }

    private static float[] Vertices_To_Ys(Vector3[] vs)
    {
        int length = vs.Length;
        float[] ys = new float[length];

        for(int i = 0; i < length; i++)
        {
            ys[i] = vs[i].y;
        }

        return ys;
    }

    private static Vector3[] Ys_To_Vertex_Ys(float[] ys, Vector3[] vs)
    {
        int length = ys.Length;

        for(int i = 0; i < length; i++)
        {
            vs[i].y = ys[i];

        }

        return vs;
    }

}
