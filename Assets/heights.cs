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
}
