using System;

namespace CoreAlgos
{
    /// <summary>
    ///   Functions for computing Fibonacci number.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The Nth Fibonacci <c>F_N</c> is defined as <c>F_{N-1} + F_{N-2}</c> with base cases of <c>F_0 = 0</c> and <c>F_1 = 1</c>.
    ///   </para>
    /// </remarks>
    public static class FibonacciNumbers
    {
        /// <summary>
        ///   Compute the nth Fibonacci number in a naive way.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(2^n)</c> and the space complexity is <c>O(n)</c>.
        ///   </para>
        /// </remarks>
        /// <param name="n">Which Fibonacci number to generate</param>
        /// <returns>The nth Fibonacci number</returns>
        public static long Naive(long n)
        {
            if (n < 0)
                throw new ArgumentException("Expected a positive number");

            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return Naive(n - 1) + Naive(n - 2);
        }
    }
}
