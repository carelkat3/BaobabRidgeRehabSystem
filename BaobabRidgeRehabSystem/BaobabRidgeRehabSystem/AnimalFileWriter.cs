using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BaobabRidgeRehabSystem
{
    // Rewrites the whole animals.txt (used by Update and Delete). Like WriteData, it does not
    // catch IOException or UnauthorizedAccessException: the calling form catches them.
    internal static class AnimalFileWriter
    {
        // UTF-8 without a byte-order mark, as required by Section 5.1.
        private static readonly Encoding FileEncoding = new UTF8Encoding(false);

        // Overwrites animals.txt with one line per animal, in list order.
        public static void SaveAll(string filePath, List<Animal> animals)
        {
            File.WriteAllLines(filePath, animals.Select(WriteData.FormatLine), FileEncoding);
        }
    }
}