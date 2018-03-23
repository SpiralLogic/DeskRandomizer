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

            Assert.Equal(3, deskRandomizer.PersonList.Length);
        }

        [Fact]
        public void PersonListShouldBePopulated()
        {
            var deskRandomizer = new DeskRandomizer(4);

            foreach (var person in deskRandomizer.PersonList)
            {
                Assert.True(person > 0);
            }
        }

        [Fact]
        public void PersonListShouldBeUnique()
        {
            var deskRandomizer = new DeskRandomizer(4);

            Assert.Equal(4, deskRandomizer.PersonList.Distinct().Count());
        }

        [Fact]
        public void CannotSetPersonListToInvalidLength()
        {
            var deskRandomizer = new DeskRandomizer(4);
            var testArray = new int[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => deskRandomizer.PersonList = testArray);
        }
        
        [Fact]
        public void HasPreviousNeighboursReturnsTrueWithPreviousNeighboursOnRight()
        {
            var deskRandomizer = new DeskRandomizer(3);

            deskRandomizer.PersonList = new List<int>{1,3,4}.ToArray();
            var resultHigher = deskRandomizer.HasPreviousNeighbours(1);

            deskRandomizer.PersonList = new List<int>{1,3,2}.ToArray();
            var resultLower = deskRandomizer.HasPreviousNeighbours(1);
            
            Assert.True(resultHigher);
            Assert.True(resultLower);
        }
        [Fact]
        public void HasPreviousNeighboursReturnsTrueWithPreviousNeighboursOnLeft()
        {
            var deskRandomizer = new DeskRandomizer(3);

            deskRandomizer.PersonList = new List<int>{2,3,1}.ToArray();
            var resultHigher = deskRandomizer.HasPreviousNeighbours(1);

            deskRandomizer.PersonList = new List<int>{4,3,1}.ToArray();
            var resultLower = deskRandomizer.HasPreviousNeighbours(1);
            
            Assert.True(resultHigher);
            Assert.True(resultLower);
        }
    }
}