using System;
using System.Collections.Generic;
using System.Linq;

namespace DeskRandomizerApp
{
    public class DeskRandomizer
    {
        private readonly int _numberOfPeople;
        private int[] _people;
        public int[] FinalArrangement { get; set; }

        public int[] People
        {
            get => _people;
            set
            {
                if (value.Length != _numberOfPeople)
                    throw new ArgumentOutOfRangeException();
                _people = value;
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
            People = new int[_numberOfPeople];

            for (var i = 0; i < _numberOfPeople; i++)
            {
                People[i] = i + 1;
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

        public bool HasPreviousNeighbours(int position, int person, int[] peopleList)
        {
            return IsPersonWrappedPreviousNeighbour(position, person, peopleList) ||
                   (IsPersonToRightPreviousNeighbour(position, person, peopleList) || IsPersonToLeftPreviousNeighbour(position, person, peopleList));
        }

        private bool IsPersonWrappedPreviousNeighbour(int position, int person, int[] peopleList)
        {
            if (position == 0)
            {
                return peopleList.Last() + 1 == peopleList[0] || peopleList.Last() - 1 == peopleList[0];
            }

            if (position == _numberOfPeople - 1)
            {
                return peopleList.First() + 1 == person || peopleList.First() - 1 == person;
            }

            return false;
        }

        private bool IsPersonToRightPreviousNeighbour(int position, int person, int[] peopleList)
        {
            if (position + 1 >= _numberOfPeople) return false;

            return peopleList[position + 1] + 1 == person || peopleList[position + 1] - 1 == person;
        }

        private bool IsPersonToLeftPreviousNeighbour(int position, int person, int[] peopleList)
        {
            if (position - 1 < 0) return false;

            return peopleList[position - 1] + 1 == person || peopleList[position - 1] - 1 == person;
        }

        public int[] Allocate(List<int> peopleToPlace)
        {
            foreach (var person in peopleToPlace.Take(peopleToPlace.Count - 1))
            {
                PlaceNextPerson(person);
            }

            BeforePlacement = FinalArrangement.ToArray();
            PlaceLastPerson(peopleToPlace.Last());
            return FinalArrangement;
            //      PlaceLastPerson(peopleToPlace.Last());
        }

        public int[] BeforePlacement { get; set; }

        public void PlaceLastPerson(int lastPerson)
        {
            var freePosition = Array.IndexOf(FinalArrangement, -1);

            if (!HasPreviousNeighbours(freePosition, lastPerson, FinalArrangement))
            {
                FinalArrangement[freePosition] = lastPerson;

                return;
            }

            for (var i = 0; i < _numberOfPeople; i++)
            {
                if (i == freePosition) continue;

                var testArrangement = FinalArrangement.ToArray();
                testArrangement[freePosition] = FinalArrangement[i];
                testArrangement[i] = lastPerson;
                
                if (!HasPreviousNeighbours(i, lastPerson, testArrangement) && !HasPreviousNeighbours(freePosition, FinalArrangement[i], testArrangement))
                {
                    FinalArrangement = testArrangement;
                    return;
                }
            }
        }

        private void PlaceNextPerson(int person)
        {
            for (var i = 0; i < _numberOfPeople; i++)
            {
                if (FinalArrangement[i] == -1)
                {
                    if (!HasPreviousNeighbours(i, person, FinalArrangement))
                    {
                        FinalArrangement[i] = person;
                        return;
                    }
                }
            }
        }

        private static Random rng = new Random();

        public void ShufflePeople()
        {
            var list = People.ToList();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            People = list.ToArray();
        }
    }
}