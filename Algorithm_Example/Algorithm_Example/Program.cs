using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Example
{
    class Program
    {
        public static int nonDivisibleSubset(int k, List<int> s)
        {
            List<int> result = new List<int>();
            List<int> modResult = new List<int>();
            for (int i = 0; i < s.Count; i++)
            {
                int divide = s[i] % k;
                modResult.Add(divide);
            }

            for (int i = 0; i < s.Count; i++)
            {

                List<int> tempResult = new List<int>();
                tempResult.Add(s[i]);
                for (int j = 0; j < s.Count; j++)
                {
                    if (i != j)
                    {
                        int temp1 = modResult[i];
                        int temp2 = modResult[j];
                        int divide = (temp1 + temp2) % k;
                        bool onay = true;
                        if (divide != 0)
                        {
                            foreach (var item in tempResult)
                            {
                                int temp3 = item;
                                if (((temp3 + temp2) % k) == 0)
                                {
                                    onay = false;
                                }
                            }
                            if (onay == true) tempResult.Add(s[j]);
                        }
                    }


                }
                if (tempResult.Count > result.Count)
                {
                    result = tempResult;
                }



            }
           
            return result.Count;
        }

        static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            int result = nonDivisibleSubset(k, s);
            Console.Write(result);
            Console.ReadKey();
        }
    }
}
