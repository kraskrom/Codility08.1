/*
An array A consisting of N integers is given. The dominator of array A is the value that occurs in more than half of the elements of A.

For example, consider array A such that

 A[0] = 3    A[1] = 4    A[2] =  3
 A[3] = 2    A[4] = 3    A[5] = -1
 A[6] = 3    A[7] = 3
The dominator of A is 3 because it occurs in 5 out of 8 elements of A (namely in those with indices 0, 2, 4, 6 and 7) and 5 is more than a half of 8.

Write a function

class Solution { public int solution(int[] A); }

that, given an array A consisting of N integers, returns index of any element of array A in which the dominator of A occurs. The function should return −1 if array A does not have a dominator.

For example, given array A such that

 A[0] = 3    A[1] = 4    A[2] =  3
 A[3] = 2    A[4] = 3    A[5] = -1
 A[6] = 3    A[7] = 3
the function may return 0, 2, 4, 6 or 7, as explained above.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [0..100,000];
each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].
*/

using System;
using System.Collections.Generic;

namespace Codility08._1
{
    class Solution
    {
        public int solution(int[] A)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (stack.Count > 0)
                {
                    int s = stack.Peek();
                    if (s != A[i])
                        stack.Pop();
                    else
                        stack.Push(A[i]);
                }
                else
                    stack.Push(A[i]);
            }
            if (stack.Count == 0)
                return -1;
            int st = stack.Peek();
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == st)
                {
                    count++;
                    if (count > A.Length / 2)
                        return i;
                }
            }
            return -1;
        }
    }

    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            //int[] A = { 3, 4, 4, 2, 3, -1, 3, 3 };
            //int[] A = { 1, 2, 1 };
            int[] A = new int[21];
            for (int i = 0; i < 10; i++)
                A[i] = 1;
            for (int i = 10; i < 21; i++)
                A[i] = 2;
            int s = sol.solution(A);
            Console.WriteLine("Solution: " + s);
            //Console.WriteLine("Solution: " + string.Join(", ", s));
        }
    }
}
