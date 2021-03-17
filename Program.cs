using System;

namespace ChunkFinder {
    class Program {
        static void Main(string[] args) {
            var cft = new ChunkFinderTests();
            cft.SimpleTest();
            cft.SimpleTest1M();
            cft.SimpleTest1MEndList();
            //
            cft.Improved1M();
            cft.Improved1MEndList();

            Console.ReadKey();
        }
    }
}
