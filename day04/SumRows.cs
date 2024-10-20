
// mutlitply two matrix could be solved using dynamic programming
// https://www.geeksforgeeks.org/matrix-chain-multiplication-dp-8/
// but it's a bonus so not mandatory
class SumRows
{
    public static void ProgramLoop()
    {
        Console.WriteLine("enter rows");
        int r = int.Parse(Console.ReadLine());
        Console.WriteLine("enter cols");
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine("enter array inputs");
        int[,] a = new int[r, c];
        int[] rowSum = new int[r];
        for (int i = 0; i < r; i++)
        {
            int curSum = 0;
            for (int j = 0; j < c; j++)
            {
                Console.WriteLine("enter number");
                int x = int.Parse(Console.ReadLine());
                curSum += x;
                a[i, j] = x;
            }
            rowSum[i] = curSum;
        }

        Console.WriteLine("row sum: ");
        foreach (var item in rowSum)
        {
            Console.WriteLine($"{item}");
        }
    }
}