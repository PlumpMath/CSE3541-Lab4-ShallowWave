using System;

public class Heights
{
    public Heights()
    {
    }

    public static float[,] CopyYsToHeights(float[] ys)
    {
        int side = (int)Math.Log((double) ys.Length);
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
}
