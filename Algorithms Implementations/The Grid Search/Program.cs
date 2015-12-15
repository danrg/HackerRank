// solution for https://www.hackerrank.com/challenges/the-grid-search
using System;
class Solution
{
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            // read input data
            string[] tokens_R = Console.ReadLine().Split(' ');
            int R = Convert.ToInt32(tokens_R[0]);
            int C = Convert.ToInt32(tokens_R[1]);
            string[] G = new string[R];
            for (int G_i = 0; G_i < R; G_i++)
            {
                G[G_i] = Console.ReadLine();
            }
            string[] tokens_r = Console.ReadLine().Split(' ');
            int r = Convert.ToInt32(tokens_r[0]);
            int c = Convert.ToInt32(tokens_r[1]);
            string[] P = new string[r];
            for (int P_i = 0; P_i < r; P_i++)
            {
                P[P_i] = Console.ReadLine();
            }

            // check most items in the big matrix:
            bool isFound = false;
            for (int i = 0; i <= R - r; i++)
            {
                for (int j = 0; j <= C - c; j++)
                {
                    if (ProcessItem(i, j, G, P))
                    {
                        isFound = true;
                    }
                }
            }

            // display result for the current big and small matrices:
            if (isFound)
            {
                Console.Out.WriteLine("YES");
            }
            else
            {
                Console.Out.WriteLine("NO");
            }
        }
    }

    private static bool ProcessItem(int line, int column, string[] bigMatrix, string[] smallMatrix)
    {
        for (int l = line; l < line + smallMatrix.Length; l++)
        {
            for (int c = column; c < column + smallMatrix[l - line].Length; c++)
            {
                if (bigMatrix[l][c] != smallMatrix[l - line][c - column])
                {
                    return false;
                }
            }
        }

        return true;
    }
}