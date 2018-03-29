using System;
using System.Collections.Generic;
using System.Linq;
using DeskRandomizerApp;
using Xunit;

namespace DeskRandomizerTests
{
    public class Tests
    {
        [Fact]
        public void CreatePersonListShouldCreateAnArrayWithGivenInput()
        {
            var deskRandomizer = new DeskRandomizer(3);

            Assert.Equal(3, deskRandomizer.FinalArrangement.Length);
        }

        [Fact]
        public void FinalArrangementShouldBePopulated()
        {
            var deskRandomizer = new DeskRandomizer(3);

            foreach (var element in deskRandomizer.FinalArrangement)
            {
                Assert.Equal(-1, element);
            }
        }

        [Fact]
        public void PersonListShouldBeInitialized()
        {
            var deskRandomizer = new DeskRandomizer(3);

            Assert.Equal(3, deskRandomizer.People.Length);
        }

        [Fact]
        public void PersonListShouldBePopulated()
        {
            var deskRandomizer = new DeskRandomizer(4);

            foreach (var person in deskRandomizer.People)
            {
                Assert.True(person > 0);
            }
        }

        [Fact]
        public void PersonListShouldBeUnique()
        {
            var deskRandomizer = new DeskRandomizer(4);

            Assert.Equal(4, deskRandomizer.People.Distinct().Count());
        }

        [Fact]
        public void CannotSetPersonListToInvalidLength()
        {
            var deskRandomizer = new DeskRandomizer(4);
            var testArray = new int[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => deskRandomizer.People = testArray);
        }

        [Fact]
        public void HasPreviousNeighboursReturnsTrueWithPreviousNeighboursOnRight()
        {
            var deskRandomizer = new DeskRandomizer(3);

            var resultHigher = deskRandomizer.HasPreviousNeighbours(1, 3, new List<int> {7, 3, 4}.ToArray());
            var resultLower = deskRandomizer.HasPreviousNeighbours(1, 3, new List<int> {7, 3, 4}.ToArray());

            Assert.True(resultHigher);
            Assert.True(resultLower);
        }

        [Fact]
        public void HasPreviousNeighboursReturnsTrueWithPreviousNeighboursOnLeft()
        {
            var deskRandomizer = new DeskRandomizer(3);

            var resultHigher = deskRandomizer.HasPreviousNeighbours(1, 3, new List<int> {2, 3, 7}.ToArray());
            var resultLower = deskRandomizer.HasPreviousNeighbours(1, 3, new List<int> {2, 3, 7}.ToArray());

            Assert.True(resultHigher);
            Assert.True(resultLower);
        }

        [Fact]
        public void HasPreviousNeighboursReturnsTrueWithPreviousNeighboursWrapped()
        {
            var deskRandomizer = new DeskRandomizer(3);

            var resultLeft = deskRandomizer.HasPreviousNeighbours(0, 2, new List<int> {2, 7, 1}.ToArray());
            var resultRight = deskRandomizer.HasPreviousNeighbours(2, 1, new List<int> {2, 7, 1}.ToArray());

            Assert.True(resultLeft);
            Assert.True(resultRight);
        }

        [Fact]
        public void AllocatePlacesPeopleInFinalAllocation()
        {
            var deskRandomizer = new DeskRandomizer(6);

            deskRandomizer.Allocate(deskRandomizer.People.ToList());

            Assert.Equal(new List<int> {1, 4, 2, 5, 3, 6}.ToArray(), deskRandomizer.FinalArrangement);
        }

        [Fact]
        public void AllocatePlacesPeopleInWithNoPreviousNeighbours()
        {
            var deskRandomizer = new DeskRandomizer(6);

            deskRandomizer.Allocate(deskRandomizer.People.ToList());
            var expected = new List<int> {1, 4, 2, 5, 3, 6}.ToArray();
            Assert.Equal(expected, deskRandomizer.FinalArrangement);
        }

        [Fact]
        public void AllocatePlacesPeopleInWithNoPreviousNeighboursWithShuffle()
        {
            var deskRandomizer = new DeskRandomizer(11);

            deskRandomizer.ShufflePeople();
            deskRandomizer.Allocate(deskRandomizer.People.ToList());

            var passed = true;
            for (var i = 0; i < 11; i++)
            {
                if (deskRandomizer.HasPreviousNeighbours(i, deskRandomizer.FinalArrangement[i], deskRandomizer.FinalArrangement))
                {
                    Assert.Equal(new List<int> {1, 4, 2, 5, 3, 6}.ToArray(), deskRandomizer.BeforePlacement);
                    Assert.False(true);
                }

                ;
            }
        }

        [Fact]
        public void PlacesesLastPerson2()
        {
            var deskRandomizer = new DeskRandomizer(6);

            deskRandomizer.Allocate(new List<int> {4, 3, 6, 5, 1, 2});

            Assert.Equal(new List<int> {2, 6, 3, 5, 1, 4}.ToArray(), deskRandomizer.FinalArrangement);
        }

        [Fact]
        public void PlacesesLastPerson()
        {
            var deskRandomizer = new DeskRandomizer(6);

            deskRandomizer.Allocate(new List<int> {5, 1, 4, 6, 3, -1});

            deskRandomizer.PlaceLastPerson(2);
            Assert.Equal(new List<int> {5, 2, 4, 6, 3, 1}.ToArray(), deskRandomizer.FinalArrangement);
        }

        [Fact]
        public void PlacesesLastPerson3()
        {
            var deskRandomizer = new DeskRandomizer(6);

            deskRandomizer.Allocate(new List<int> {1, 5, 3, 6, 4, -1});

            deskRandomizer.PlaceLastPerson(2);
            Assert.Equal(new List<int> {1, 5, 3, 6, 2, 4}.ToArray(), deskRandomizer.FinalArrangement);
        }
    }
}