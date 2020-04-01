using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payoff_Table
{
    class Program
    {
        static int s;
        static int n;
        static int[] arr;
        static int j;
        static int h, max, min = 0, maxi = 0, mini;

        static void Main(string[] args)
        {

            Console.WriteLine("Enter the number of Decision Alternative");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of State of nature");
            s = int.Parse(Console.ReadLine());

            Console.WriteLine("You are ....");

        Try1:
            Console.WriteLine("1 : Optimistic      2 : Conservative      3 : Regret");
            int are = int.Parse(Console.ReadLine());

            if (are > 3 || are < 1)
            {
                Console.WriteLine();
                Console.WriteLine("In Valid Try again");
                goto Try1;
            }

            Console.WriteLine("You Want ...");

        Try2:
            Console.WriteLine("1 : Profit      2 : Costs");

            int want = int.Parse(Console.ReadLine());
            if (want > 2 || want < 1)
            {
                Console.WriteLine();
                Console.WriteLine("In Valid Try again");
                goto Try2;
            }

            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("Enter the element");
            arr = new int[(s * n)];
            for (h = 0; h < s * n; h++)
            {
                Console.Write("Enter value[{0}] = ",h);
                arr[h] = int.Parse(Console.ReadLine());
                Console.Clear();
                Board();
            }
            switch (want)
            {
                case 1: //Profit
                    if (are == 1) //Optimistic
                    {
                        MaxMam();
                        Console.WriteLine("Optimistic (Maximax) = " + maxi);
                    }

                    if (are == 2) //Conservative
                    {
                        profitconservative();
                        Console.WriteLine("Optimistic (MaxMin) = " + maxi);
                    }
                    if (are == 3)//regret
                    {
                        regret();
                        costconservative();
                        Console.WriteLine("Regret = " + mini);

                    }
                    break;
                case 2: //Costs
                    if (are == 1) //Optimistic
                    {
                        MinMam();
                        Console.WriteLine("Optimistic (Minmini) = " + mini);

                    }
                    if (are == 2) //Conservative
                    {
                        costconservative();
                        Console.WriteLine("Optimistic (Minimax) = " + mini);
                    }
                    if (are == 3)//regret
                    {
                        regret();
                        costconservative();
                        Console.WriteLine("Regret = " + mini);

                    }

                    break;

            }
            Console.ReadKey();

        }
        static void MaxMam()
        {
            for (int fin = 0; fin < n * s; fin += s)
            {
                max = arr[fin];
                for (int get = fin; get < (fin + s); get++)
                {
                    if (arr[get] > max)
                    {
                        max = arr[get];
                    }
                    if (max > maxi)
                    {
                        maxi = max;
                    }
                }
            }
        }
        static void MinMam()
        {
            mini = arr[0];

            for (int fin = 0; fin < n * s; fin += s)
            {
                min = arr[fin];

                for (int get = fin; get < (fin + s); get++)
                {
                    if (arr[get] < min)
                    {
                        min = arr[get];
                    }
                }
                if (min < mini)
                {
                    mini = min;
                }
            }
        }
        static void costconservative()
        {

            for (int fin = 0; fin < n * s; fin += s)
            {
                max = arr[fin];
                for (int get = fin; get < (fin + s); get++)
                {
                    if (arr[get] > max)
                    {
                        max = arr[get];
                    }
                    if (fin == 0)
                    { mini = max; }
                }
                if (max < mini)
                {
                    mini = max;
                }
            }
        }
        static void profitconservative()
        {
            for (int fin = 0; fin < n * s; fin += s)
            {
                min = arr[fin];
                for (int get = fin; get < (fin + s); get++)
                {
                    if (arr[get] < min)
                    {
                        min = arr[get];
                    }
                    if (fin == 0)
                    { maxi = min; }
                }
                if (maxi < min)
                {
                    maxi = min;
                }
            }
        }
        static void regret()
        {
            int[] Arr = new int[n * s];

            for (int i = 0; i < s; i++)
            {
                for (int j = i; j <= (s * n) - 1; j += s)
                {
                    int items = 0;
                    for (int z = i; z <= (n * s - n) + i; z += s)
                    {
                        items += n;
                        int supArryItem = arr[j] - arr[z];
                        int CurrentItem = Arr[z] == null ? 0 : Arr[z];

                        // Here we compare the value in the new matrix with the subtraction result, 
                        // so that no subtraction product enters into the new matrix.

                        if (supArryItem < 0 || CurrentItem > supArryItem)
                            break;
                        else
                        {
                            Arr[z] = supArryItem;
                        }
                    }
                }
            }

            Arr.CopyTo(arr, 0);
        }
        static void Board()
        {
            for (int i = 1; i <= s; i++)
            {
                Console.Write("X" + i + "\t");
            }
            Console.WriteLine();
            int x = 0;
            for (j = 0; j < n * s; j++)
            {
                Console.Write(arr[j] + "\t");

                if (x + 1 == s)
                {
                    Console.WriteLine();
                    x = 0;
                }
                else
                {
                    x++;
                }
                //for (int spa = 1; spa <= j; spa++)
                //{
                //    if (j == (spa * s ))
                //    {
                //        Console.WriteLine();
                //    }
                //}

            }
        }
    }
}
