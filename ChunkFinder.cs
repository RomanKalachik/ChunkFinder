using System;
using System.Collections.Generic;
using System.Text;

namespace ChunkFinder
{
    public struct Chunk
    {
        public int StartOffset { get; set; }

        public int EndOffset { get; set; }

        public int ID { get; set; }

        public static Chunk Empty { get { return new Chunk() { ID = -1 }; } }
        public override string ToString() {
            return string.Format("ID {0}, StartOffset {1}, EndOffset {2}", ID, StartOffset, EndOffset);
        }
    }

    public class ChunkFinder
    {
        public static void PreprocessChunks(List<Chunk> chunks)
        {
            chunks.Sort(
                (c1, c2) =>
                {
                    return c1.StartOffset.CompareTo(c2.StartOffset);
                });
        }

        /// <summary>
        /// returns a chunk with startoffset closest to a offset specified in parameters
        /// </summary>
        /// <param name="chunks" sorted chunks list></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static Chunk BinarySearch(List<Chunk> chunks, int offset, out int iterationsCount)
        {
            int leftStartIndex, leftEndIndex;
            int rightStartIndex, rightEndIndex;
            int watchdog = chunks.Count;
            int iterationsConunter = 0;
            leftStartIndex = 0;
            leftEndIndex = chunks.Count / 2;
            rightStartIndex = leftEndIndex + 1;
            rightEndIndex = chunks.Count - 1;
            try {
                do {
                    iterationsConunter++;
                    if(chunks[leftStartIndex].StartOffset > chunks[rightStartIndex].StartOffset)
                        throw new ArgumentException("chunks not sorted!");
                    if(chunks[leftStartIndex].StartOffset <= offset && chunks[leftEndIndex].StartOffset >= offset) {
                        //divide left
                        int count = leftEndIndex - leftStartIndex;
                        if(count <= 0 || chunks[leftStartIndex].StartOffset == offset)
                            return chunks[leftStartIndex];
                        leftEndIndex = leftStartIndex + count / 2;
                        rightStartIndex = leftEndIndex + 1;
                        rightEndIndex = leftStartIndex + count;
                    } else {
                        //divide right
                        int count = rightEndIndex - rightStartIndex;
                        if(count <= 0 || chunks[rightStartIndex].StartOffset == offset)
                            return chunks[rightStartIndex];
                        leftStartIndex = rightStartIndex;
                        leftEndIndex = leftStartIndex + count / 2;
                        rightStartIndex = leftEndIndex + 1;
                        rightEndIndex = leftStartIndex + count;
                    }
                }
                while (watchdog-- > 0);
                throw new Exception("unknown error");
            } finally {
                iterationsCount = iterationsConunter;
            }
        }
        /// <summary>
        /// returns a chunk with startoffset closest to a offset specified in parameters
        /// </summary>
        /// <param name="chunks" sorted chunks list></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static Chunk BinarySearchImproved(List<Chunk> chunks, int offset, out int iterationsCount) {
            int leftStartIndex, leftEndIndex;
            int rightStartIndex, rightEndIndex;
            int watchdog = chunks.Count;
            int iterationsConunter = 0;
            leftStartIndex = 0;
            leftEndIndex = chunks.Count / 3;
            rightStartIndex = leftEndIndex + 1;
            rightEndIndex = chunks.Count - 1;
            try {
                do {
                    iterationsConunter++;
                    if (chunks[leftStartIndex].StartOffset > chunks[rightStartIndex].StartOffset)
                        throw new ArgumentException("chunks not sorted!");
                    if (chunks[leftStartIndex].StartOffset <= offset && chunks[leftEndIndex].StartOffset >= offset) {
                        //divide left
                        int count = leftEndIndex - leftStartIndex;
                        if (count <= 0 || chunks[leftStartIndex].StartOffset == offset)
                            return chunks[leftStartIndex];
                        leftEndIndex = leftStartIndex + count / 3; ///!! 
                        rightStartIndex = leftEndIndex + 1;
                        rightEndIndex = leftStartIndex + count;
                    } else {
                        //divide right
                        int count = rightEndIndex - rightStartIndex;
                        if (count <= 0 || chunks[rightStartIndex].StartOffset == offset)
                            return chunks[rightStartIndex];
                        leftStartIndex = rightStartIndex;
                        leftEndIndex = leftStartIndex + count / 3; ///!!
                        rightStartIndex = leftEndIndex + 1;
                        rightEndIndex = leftStartIndex + count;
                    }
                }
                while (watchdog-- > 0);
                throw new Exception("unknown error");
            } finally {
                iterationsCount = iterationsConunter;
            }
        }
    }
}
