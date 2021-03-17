using System;
using System.Collections.Generic;
using System.Text;

namespace ChunkFinder
{
    public class ChunkFinderTests
    {
        public List<Chunk> GenerateChunksSimple(int count) {
            List<Chunk> chunks = new List<Chunk>();
            for (int i = 0; i < count; i++)
                chunks.Add(new Chunk() { StartOffset = i * 2, EndOffset = i * 2, ID = i });
            return chunks;
        }
        public void SimpleTest() {
            List<Chunk> chunks = new List<Chunk>() { 
                new Chunk() { StartOffset = 1, EndOffset = 2, ID = 1 },
                new Chunk() { StartOffset = 3, EndOffset = 5, ID = 2 },
                new Chunk() { StartOffset = 6, EndOffset = 8, ID = 3 },
                new Chunk() { StartOffset = 9, EndOffset = 12, ID = 4 },
                new Chunk() { StartOffset = 15, EndOffset = 18, ID = 5 },
            };
            int iterationsCount = 0;
            int targetOffset = 3;
            var resutChunk = ChunkFinder.BinarySearch(chunks, targetOffset, out iterationsCount);
            Console.WriteLine("looking for chunk with a startoffset {0} in a list of {1} chunks", targetOffset, chunks.Count);
            Console.WriteLine("result:{0}", resutChunk.ToString());
            Console.WriteLine("found in {0} iterations", iterationsCount);
        }
        public void SimpleTest1M() {
            int count = 1000000;
            List<Chunk> chunks = GenerateChunksSimple(count);
            int iterationsCount = 0;
            int targetOffset = 1000;
            var resutChunk = ChunkFinder.BinarySearch(chunks, targetOffset, out iterationsCount);
            Console.WriteLine("looking for chunk with a startoffset {0} in a list of {1} chunks", targetOffset, count);
            Console.WriteLine("result:{0}", resutChunk.ToString());
            Console.WriteLine("found in {0} iterations", iterationsCount);
        }
        public void SimpleTest1MEndList() {
            int count = 1000000;
            List<Chunk> chunks = GenerateChunksSimple(count);
            int iterationsCount = 0;
            int targetOffset = 1000000 * 2;
            var resutChunk = ChunkFinder.BinarySearch(chunks, targetOffset, out iterationsCount);
            Console.WriteLine("looking for chunk with a startoffset {0} in a list of {1} chunks", targetOffset, count);
            Console.WriteLine("result:{0}", resutChunk.ToString());
            Console.WriteLine("found in {0} iterations", iterationsCount);
        }
        public void Improved1M() {
            int count = 1000000;
            List<Chunk> chunks = GenerateChunksSimple(count);
            int iterationsCount = 0;
            int targetOffset = 1000;
            var resutChunk = ChunkFinder.BinarySearchImproved(chunks, targetOffset, out iterationsCount);
            Console.WriteLine("looking for chunk with a startoffset {0} in a list of {1} chunks", targetOffset, count);
            Console.WriteLine("result:{0}", resutChunk.ToString());
            Console.WriteLine("found in {0} iterations", iterationsCount);
        }
        public void Improved1MEndList() {
            int count = 1000000;
            List<Chunk> chunks = GenerateChunksSimple(count);
            int iterationsCount = 0;
            int targetOffset = 1000000*2;
            var resutChunk = ChunkFinder.BinarySearchImproved(chunks, targetOffset, out iterationsCount);
            Console.WriteLine("looking for chunk with a startoffset {0} in a list of {1} chunks", targetOffset, count);
            Console.WriteLine("result:{0}", resutChunk.ToString());
            Console.WriteLine("found in {0} iterations", iterationsCount);
        }
    }
}
