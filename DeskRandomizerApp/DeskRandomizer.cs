namespace DeskRandomizerApp
{
    public class DeskRandomizer
    {
        public int[] FinalArrangement { get; private set; }
        
        public DeskRandomizer(int numberOfPeople)
        {
            InitializeFinalArrangement(numberOfPeople);
        }

        private void InitializeFinalArrangement(int numberOfPeople)
        {
            FinalArrangement = new int[numberOfPeople];

            for (var i = 0; i < numberOfPeople; i++)
            {
                FinalArrangement[i] = -1;
            }
        }

    }
}