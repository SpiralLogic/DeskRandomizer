namespace DeskRandomizerApp
{
    public class DeskRandomizer
    {
        private int _numberOfPeople;
        public int[] FinalArrangement { get; private set; }
        public int[] PersonList { get; private set; }

        public DeskRandomizer(int numberOfPeople)
        {
            _numberOfPeople = numberOfPeople;
            
            InitializePersonList();

            InitializeFinalArrangement();
        }

        private void InitializePersonList()
        {
            PersonList = new int[_numberOfPeople];

            for (var i = 0; i < _numberOfPeople; i++)
            {
                PersonList[i] = i + 1;
            }
        }

        private void InitializeFinalArrangement()
        {
            FinalArrangement = new int[_numberOfPeople];

            for (var i = 0; i < _numberOfPeople; i++)
            {
                FinalArrangement[i] = -1;
            }
        }

    }
}