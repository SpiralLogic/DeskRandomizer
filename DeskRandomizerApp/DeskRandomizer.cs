using System;
using System.Linq;

namespace DeskRandomizerApp
{
    public class DeskRandomizer
    {
        private readonly int _numberOfPeople;
        private int[] _personList;
        public int[] FinalArrangement { get; private set; }

        public int[] PersonList
        {
            get => _personList;
            set
            {
                if (value.Length != _numberOfPeople)
                    throw new ArgumentOutOfRangeException();
                _personList = value;
            }
        }

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

        public bool HasPreviousNeighbours(int i)
        {
            return IsPersonWrappedPreviousNeighbour(i) || IsPersonToRightPreviousNeighbour(i) || IsPersonToLeftPreviousNeighbour(i);
        }

        private bool IsPersonWrappedPreviousNeighbour(int i)
        {
            if (i == 0)
            {
                return PersonList.Last() + 1 == PersonList[0] || PersonList.Last() - 1 == PersonList[0];
            }

            if (i == _numberOfPeople - 1)
            {
                return PersonList.First() + 1 == PersonList[i] || PersonList.First() - 1 == PersonList[i];
            }

            return false;
        }

        private bool IsPersonToRightPreviousNeighbour(int i)
        {
            return PersonList[i + 1] + 1 == PersonList[i] || PersonList[i + 1] - 1 == PersonList[i];
        }

        private bool IsPersonToLeftPreviousNeighbour(int i)
        {
            return PersonList[i - 1] + 1 == PersonList[i] || PersonList[i - 1] - 1 == PersonList[i];
        }
    }
}