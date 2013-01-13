namespace IPClassLibrary.StaticClasses
{
    using System;

    /// <summary>
    /// Garbage Collector Static Class
    /// </summary>
    public static class GarbageCollector
    {
        /// <summary>
        /// Collects the Garbage from the the Thread it was called from
        /// </summary>
        public static void CollectGarbage()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
