using System.Runtime.InteropServices.ComTypes;

namespace DeskRandomizerApp
{
    public class DeskRandomizer
    {
        public DeskRandomizer(int numberOfPeople)
        {
            Arrangement = new int[numberOfPeople];
        }

        public int[] Arrangement { get; }
    }
}