using System;
using System.Collections.Generic;
using System.Threading;

namespace Backround_Cycler.Core
{
    /// <summary>
    /// EXPERMENTAL
    /// </summary>
    [Obsolete]
    static class HandleThreads
    {
        private static Dictionary<string, Thread> threads = new Dictionary<string, Thread> ();
        
        public static void StartOneThread ( string threadName, ThreadStart start )
        {
            if (threads.ContainsKey ( threadName ))
            {
                if (threads[threadName] == null)
                {
                    threads[threadName] = new Thread ( start );
                    threads[threadName].Name = threadName;
                    threads[threadName].IsBackground = true;
                    threads[threadName].Start ();
                }
                else if (threads[threadName].ThreadState == ThreadState.Unstarted)
                {
                    threads[threadName].Start ();
                }
                else if (threads[threadName].ThreadState == ThreadState.Stopped)
                {
                    threads[threadName] = null;

                    threads[threadName] = new Thread ( start );
                    threads[threadName].Name = threadName;
                    threads[threadName].IsBackground = true;
                    threads[threadName].Start ();
                }
            }
            else
            {
                threads.Add ( threadName, new Thread ( start ) );
                threads[threadName].Name = threadName;
                threads[threadName].IsBackground = true;
                threads[threadName].Start ();
            }
        }

        /// <summary>
        /// Not yet Inplemented
        /// </summary>
        /// <param name="threadName"></param>
        /// <param name="start"></param>
        public static void StartThread ( string threadName, ThreadStart start )
        {
			StartOneThread (threadName, start);
        }

        public static void StopAllThreads ()
        {
            foreach (KeyValuePair<string,Thread> key in threads)
            {
                if (key.Value.ThreadState != ThreadState.Stopped)
                {
                    key.Value.Abort ();
                }
            }
        }
    }
}
