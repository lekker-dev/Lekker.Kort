using Lekker.Kort.Interface;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Lekker.Kort.Services
{
    public static class LekkerConstants
    {
        private static string[] _items = new string[]
        {
            "braai",
            "bier",
            "brannas",
            "boeries",
            "bosveld",
            "biltong",
            "chops",
            "vuur",
            "musiek",
            "vriende"
        };

        public static string GetLekkerItemForChar(char c)
        {
            return _items[GetNumberForChar(c)];
        }

        private static int GetNumberForChar(char c)
        {
            // https://stackoverflow.com/questions/239103/convert-char-to-int-in-c-sharp
            // This works because each character is internally represented by a number.
            // The characters '0' to '9' are represented by consecutive numbers, so finding the difference between the characters '0' and '2' results in the number 2.
            return c - '0';
        }
    }
}