/*
 * Taken from code samples for , Parallel Programming with Microsoft .NET
 *  http://msdn.microsoft.com/en-us/library/ff963553.aspx
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace MpdBaileyTechnology.Shared.Utils
{
    public static class Timing
    {
        /// <summary>
        /// TimeSpan pretty printer
        /// </summary>
        /// <param name="ts">The TimeSpan to format</param>
        /// <returns>A formatted string</returns>
        public static string FormattedTime(TimeSpan ts)
        {
            return String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
        }

        /// <summary>
        /// Executes a function and prints timing results
        /// </summary>
        /// <param name="test">Function to time</param>
        /// <param name="label">Label used in the console output</param>
        public static void TimedAction(Action test, string label)
        {
            Console.WriteLine("Starting {0}", label);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            test();

            stopWatch.Stop();
            TimeSpan seqT = stopWatch.Elapsed;
            Console.WriteLine("{0}: {1}", label, FormattedTime(seqT));
            Console.WriteLine();
        }

        /// <summary>
        /// Executes a function and prints timing results
        /// </summary>
        /// <typeparam name="T">Return type of the function</typeparam>
        /// <param name="test">The timed function that returns a value</param>
        /// <param name="label">Label used in the console output</param>
        public static void TimedRun<T>(Func<T> test, string label)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = test();

            stopWatch.Stop();
            TimeSpan seqT = stopWatch.Elapsed;
            Console.WriteLine("{0} (result={1}): {2}", label, result.ToString(), FormattedTime(seqT));
        }
        /// <summary>
        /// Simulates a CPU-intensive operation on a single core. The operation will use approximately 100% of a
        /// single CPU for a specified duration.
        /// </summary>
        /// <param name="seconds">The approximate duration of the operation in seconds</param>
        /// <returns>true if operation completed normally; false if the user canceled the operation</returns>
        public static bool DoCpuIntensiveOperation(double seconds)
        {
            return DoCpuIntensiveOperation(seconds, CancellationToken.None, false);
        }

        /// <summary>
        /// Simulates a CPU-intensive operation on a single core. The operation will use approximately 100% of a
        /// single CPU for a specified duration.
        /// </summary>
        /// <param name="seconds">The approximate duration of the operation in seconds</param>
        /// <param name="token">A token that may signal a request to cancel the operation.</param>
        /// <param name="throwOnCancel">true if an execption should be thrown in response to a cancellation request.</param>
        /// <returns>true if operation completed normally; false if the user canceled the operation</returns>
        public static bool DoCpuIntensiveOperation(double seconds, CancellationToken token, bool throwOnCancel = false)
        {
            if (token.IsCancellationRequested)
            {
                if (throwOnCancel)
                    token.ThrowIfCancellationRequested();
                return false;
            }

            long ms = (long)(seconds * 1000);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long checkInterval = Math.Min(20000000, (long)(20000000 * seconds));

            // loop to simulate a computationally intensive operation
            int i = 0;
            while (true)
            {
                i += 1;

                // periodically check to see if the user has requested cancellation 
                // or if the time limit has passed
                if (seconds == 0.0d || i % checkInterval == 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        if (throwOnCancel) token.ThrowIfCancellationRequested();
                        return false;
                    }

                    if (sw.ElapsedMilliseconds > ms)
                        return true;
                }
            }
        }

        // vary to simulate I/O jitter
        readonly static int[] SleepTimeouts = new int[] { 65, 165, 110, 110, 185, 160, 40, 125, 275, 110, 80,
            190, 70, 165, 80, 50, 45, 155, 100, 215, 85, 115, 180, 195, 135, 265, 120, 60, 130, 115, 200, 105, 310,
            100, 100, 135, 140, 235, 205, 10, 95, 175, 170, 90, 145, 230, 365, 340, 160, 190, 95, 125, 240, 145,
            75, 105, 155, 125, 70, 325, 300, 175, 155, 185, 255, 210, 130, 120, 55, 225, 120, 65, 400, 290, 205,
            90, 250, 245, 145, 85, 140, 195, 215, 220, 130, 60, 140, 150, 90, 35, 230,
            180, 200, 165, 170, 75, 280, 150, 260, 105
        };

        /// <summary>
        /// Simulates an I/O-intensive operation on a single core. The operation will use only a small percent of a
        /// single CPU's cycles; however, it will block for the specified number of seconds.
        /// </summary>
        /// <param name="seconds">The approximate duration of the operation in seconds</param>
        /// <param name="token">A token that may signal a request to cancel the operation.</param>
        /// <param name="throwOnCancel">true if an execption should be thrown in response to a cancellation request.</param>
        /// <returns>true if operation completed normally; false if the user canceled the operation</returns>
        public static bool DoIoIntensiveOperation(double seconds, CancellationToken token, bool throwOnCancel = false)
        {
            if (token.IsCancellationRequested)
            {
                if (throwOnCancel)
                    token.ThrowIfCancellationRequested();
                return false;
            }
            int ms = (int)(seconds * 1000);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int timeoutCount = SleepTimeouts.Length;

            // loop to simulate i/o intensive operation
            int i = (Math.Abs(sw.GetHashCode()) % timeoutCount);
            while (true)
            {
                int timeout = SleepTimeouts[i];
                i += 1;
                i = i % timeoutCount;

                // simulate i/o latency
                Thread.Sleep(timeout);

                // Has the user requested cancellation? 
                if (token.IsCancellationRequested)
                {
                    if (throwOnCancel) token.ThrowIfCancellationRequested();
                    return false;
                }

                // Is the computation finished?
                if (sw.ElapsedMilliseconds > ms)
                    return true;
            }
        }

    }
}
