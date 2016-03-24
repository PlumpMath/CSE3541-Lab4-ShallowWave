using System;

public class Heights
{
    public Heights()
    {
    }

    public static float[,] Ys_To_Heights(float[] ys)
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

    public static float[] Heights_To_Ys(float[,] heights)
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
