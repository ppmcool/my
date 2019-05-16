using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechGigCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            //int value = Convert.ToInt32(Console.ReadLine());
            //// Console.WriteLine(value);
            //List<int> lstPowerOfVideoCard = new List<int>();
            //for (int j = 0; j < value; j++)
            //{
            //    lstPowerOfVideoCard.Add(Convert.ToInt32(Console.ReadLine()));
            //}

            //Console.WriteLine(BestOutputVideo(lstPowerOfVideoCard));

            // ====================================================

            // Question 1 start
            //int numberOfTestCases = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < numberOfTestCases; i++)
            //{
            //    int value = Convert.ToInt32(Console.ReadLine());
            //    // Console.WriteLine(value);
            //    List<int> lstPowerOfVillian = new List<int>();
            //    for (int j = 0; j < value; j++)
            //    {
            //        lstPowerOfVillian.Add(Convert.ToInt32(Console.ReadLine().Split(' ')[j]));
            //    }
            //    List<int> lstPowerOfHeroes = new List<int>();
            //    for (int j = 0; j < value; j++)
            //    {
            //        lstPowerOfHeroes.Add(Convert.ToInt32(Console.ReadLine().Split(' ')[j]));
            //    }

            //    lstPowerOfVillian.Sort();
            //    lstPowerOfHeroes.Sort();
            //    bool result = true;
            //    for (int k = 0; k < lstPowerOfVillian.Count; k++)
            //    {
            //        if (lstPowerOfVillian[k] > lstPowerOfHeroes[k])
            //        {
            //            result = false;
            //            break;
            //        }
            //    }

            //    if (result)
            //    {
            //        Console.Write("WIN");
            //    }
            //    else
            //    {
            //        Console.Write("LOSE");
            //    }
            //}

            // ================================================================================

            // Question 2 end

            //int[] a = { 1, 2, 3, -5, -3, 2, 5 };

            //List<int> l = maxSum1(a);
            //Console.WriteLine(
            //        "indices {" + l.stream().map(String::valueOf).collect(Collectors.joining(", ")) + "}");
            //Console.WriteLine("values  {"
            //        + l.stream().map(i->String.valueOf(a[i])).collect(Collectors.joining(", ")) + "}");


            //int[] arr = new int[]{3, 2, 1, -1 };

            //Console.Write(
            // FindMaxSum(arr, arr.Length));

            //Console.ReadLine();
            NeighborsAndNewYearParty();
        }

        private static void NeighborsAndNewYearParty()
        {
            int numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                int noumberOfHouses = Convert.ToInt32(Console.ReadLine());

                List<int> lstTicketNumbers = new List<int>();
                string[] arr = Console.ReadLine().Split(' ');
                for (int j = 0; j < noumberOfHouses; j++)
                {
                    lstTicketNumbers.Add(Convert.ToInt32(arr[j]));
                }

                // maxSum(lstTicketNumbers.ToArray());    
                maxSumNew(lstTicketNumbers.ToArray());
            }

            Console.ReadLine();
            // const int N = 1e6 + 10;
        }

        public static void maxSumNew(int[] arr)
        {
            int n = arr.Length, max;

            int[] val = new int[n];
            bool[] minus = new bool[n];

            for (int i = 0; i < n; i++)
            {
                val[i] = arr[i];
                if (val[i] < 0)
                {       //just don't take negative elements
                    val[i] = 0;
                    minus[i] = true;
                }
                else minus[i] = false;
            }

            max = 0;
            List<int> lstMaxSum = new List<int>();

            int iteration = (val.Length / 2) + ((val.Length % 2 == 0) ? 0 : 1);

            for (int i = 0; i < iteration; i++)
            {
                int v = val[i];
                if (v == 0)
                    continue;
                List<int> lstMaxS = new List<int>();
                lstMaxS.Add(i);
                int previoudIndex = -1;
                // for (int j = val.Length - 1; j >= iteration; j--)
                for (int j = 0; j < val.Length; j++)
                {

                    if (i == j || i == j - 1 || i == j + 1 || val[j] == 0 || j - 1 == previoudIndex || j + 1 == previoudIndex)
                        continue;

                    v = v + val[j];
                    previoudIndex = j;
                    lstMaxS.Add(j);
                }

                if (v >= max)
                {
                    if (v > max)
                    {
                        lstMaxSum.Clear();
                        for (int k = 0; k < lstMaxS.Count; k++)
                        {
                            lstMaxSum.Add(lstMaxS[k]);
                        }
                    }
                    else
                    {
                        lstMaxSum.Add(-1);
                        for (int k = 0; k < lstMaxS.Count; k++)
                        {
                            lstMaxSum.Add(lstMaxS[k]);
                        }
                    }
                    max = v;
                }
            }

            if (!lstMaxSum.Contains(-1))
            {
                for (int r = 0; r < lstMaxSum.Count; r++)
                {
                    Console.Write(val[lstMaxSum[r]]);
                }
            }
            else
            {
                string number = "";
                int oldNumber = 0;
                for (int r = 0; r < lstMaxSum.Count; r++)
                {
                    if(lstMaxSum[r] == -1)
                    {
                        if(oldNumber != 0)
                        {

                        }
                    }
                    number = Convert.ToString(val[lstMaxSum[r]]);
                }
            }
            Console.WriteLine();

            //dp[0] = val[0];   // there is no elements to take before 1
            //dp[1] = val[1];   //
            //from[0] = -1;
            //from[1] = -1;
            //max = dp[0];
            //max_index = 0;
            //for (int i = 2; i < n; i++)
            //{
            //    dp[i] = val[i] + max;
            //    from[i] = max_index;
            //    if (dp[i - 1] > max && dp[i - 1] > dp[i])
            //    {    //cause for the element i+1 ,the right most element you can take is i-1
            //        max = dp[i - 1];
            //        max_index = i - 1;
            //    }
            //}
            //int cnt = 0;
            //if (dp[n] > max) max_index = n;
            //while (max_index != -1 && cnt == 0)
            //{
            //    if (max_index == 0)
            //        cnt = cnt + 1;
            //    if (!minus[max_index]) Console.WriteLine(val[max_index]);
            //    max_index = from[max_index];
            //}
            //printf("\n");
        }

        static int FindMaxSum(int[] arr, int n)
        {
            int incl = arr[0];
            int excl = 0;
            int excl_new;
            int i;

            for (i = 1; i < n; i++)
            {
                /* current max excluding i */
                excl_new = (incl > excl) ?
                                incl : excl;

                /* current max including i */
                incl = excl + arr[i];
                excl = excl_new;
            }

            /* return max of incl and excl */
            return ((incl > excl) ?
                                incl : excl);
        }

        /** returns a list of indices which contain the elements that make up the max sum */
        public static List<int> maxSum1(int[] arr)
        {
            int priorMaxSum = 0;
            List<int> priorMaxSumList = new List<int>();

            // initial max sum
            int maxSum = arr[0];
            List<int> maxSumList = new List<int>();
            maxSumList.Add(0);

            for (int i = 1; i < arr.Length; i++)
            {
                int currSum;
                List<int> currSumList;
                if (priorMaxSum > 0)
                {
                    // if the prior sum was positive, then continue from it
                    currSum = priorMaxSum + arr[i];
                    currSumList = new List<int>(priorMaxSumList);
                }
                else
                {
                    // if the prior sum was not positive, then throw it out and start new
                    currSum = arr[i];
                    currSumList = new List<int>();
                }
                currSumList.Add(i);

                // update prior max sum and list
                priorMaxSum = maxSum;
                priorMaxSumList = new List<int>(maxSumList);

                if (currSum > maxSum)
                {
                    // update max sum
                    maxSum = currSum;
                    maxSumList = currSumList;
                }
            }
            return maxSumList;
        }

        public static void maxSum(int[] arr)
        {
            int n = arr.Length;

            int[] parent = new int[n];
            parent[0] = -1;

            int lastSum = 0; // last sum encountered
            int lastPos = -1; // position of that last sum
            int currSum = arr[0]; // current sum
            int currPos = 0; // position of the current sum

            List<int> numberConsidered = new List<int>();

            for (int i = 1; i < n; i++)
            {
                parent[i] = lastPos;  // save the last sum's position for this element

                // below this it is mostly similar to what you have done;
                // just keeping track of position too.
                int probableSum = Math.Max(arr[i] + lastSum, arr[i]);
                int tSum = currSum;
                int tPos = currPos;
                if (probableSum > currSum)
                {
                    currSum = probableSum;
                    currPos = i;
                    numberConsidered.Add(arr[i]);
                }
                lastSum = tSum;
                lastPos = tPos;
            }
            Console.WriteLine(currSum); // print sum
                                        // Console.WriteLine(parent.ToString()); // print parent array; for debugging purposes.
                                        // logic to print the elements

            for (int k = 0; k < numberConsidered.Count; k++)
            {
                Console.Write(numberConsidered[k]);
            }

            //int p = parent[n - 1];
            //string finalValue = "";
            //if (arr[n - 1] != -1)
            //{
            //    finalValue = Convert.ToString(arr[n - 1]);
            //}
            //while (p != -1)
            //{
            //    if (arr[p] != -1)
            //    {
            //        finalValue = finalValue + Convert.ToString(arr[p]);
            //    }
            //    p = parent[p];
            //}
            //Console.WriteLine(finalValue);
        }

        private static int BestOutputVideo(List<int> lstPowerOfVideoCard)
        {
            List<int> maxPower = new List<int>();
            for (int k = 0; k < lstPowerOfVideoCard.Count; k++)
            {
                int sumOfPowar = lstPowerOfVideoCard[k];
                int leadingPower = lstPowerOfVideoCard[k];
                for (int j = 0; j < lstPowerOfVideoCard.Count; j++)
                {
                    if (j > k)
                    {
                        if (leadingPower <= lstPowerOfVideoCard[j])
                        {
                            if (lstPowerOfVideoCard[j] % leadingPower == 0)
                            {
                                sumOfPowar = sumOfPowar + lstPowerOfVideoCard[j];
                            }
                            else
                            {
                                sumOfPowar = sumOfPowar + (lstPowerOfVideoCard[j] - (lstPowerOfVideoCard[j] % leadingPower));
                            }
                        }
                    }
                }

                maxPower.Add(sumOfPowar);
            }

            return maxPower.Max();
        }
    }
}
