using System;

namespace CoreAlgos
{
    /// <summary>
    ///   Functions for computing Fibonacci number.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The Nth Fibonacci <c>F_N</c> is defined as <c>F_{N-1} + F_{N-2}</c> with base cases
    ///     of <c>F_0 = 0</c> and <c>F_1 = 1</c>.
    ///   </para>
    /// </remarks>
    public static class FibonacciNumbers
    {
        /// <summary>
        ///   Compute the nth Fibonacci number in a naive way.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(2^n)</c> and the space complexity is <c>O(n)</c>, as this
        ///     computes the nth number via a direct translation of the formula into code.
        ///     Technically this is a doubly exponential algorithm, as the storage space to
        ///     represent <c>n</c> is just <c>q=log(n)</c> bits, making it <c>O(2^2^q)</c>.
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

        /// <summary>
        ///   Compute the nth Fibonacci number in a fast way, based on Dynamic Programming.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(n)</c> and the space complexity is <c>O(1)</c>. Technically,
        ///     this is an exponential algorithm, as the storage space to represent <c>n</c> is just
        ///     <c>q=log(n)</c> bits, making it <c>O(2^q)</c>. This is a classic simple DP algorithm,
        ///     where we build up the nth number incrementally. We can also discard everything past
        ///     the last two values, so the space is constant.
        ///   </para>
        /// </remarks>
        public static long DPSum(long n)
        {
            if (n < 0)
                throw new ArgumentException("Expected a positive number");

            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            long Fn = 1;
            long Fnm1 = 0;

            for (long i = 1; i < n; i++)
            {
                long Fnp1 = Fn + Fnm1;
                Fnm1 = Fn;
                Fn = Fnp1;
            }

            return Fn;
        }
    }
}
