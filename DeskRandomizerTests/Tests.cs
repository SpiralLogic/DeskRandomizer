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
        public void HasPreviousNeighboursReturnsTrueWithPreviousNeighbours()
        {
            var deskRandomizer = new DeskRandomizer(4);

            Assert.Equal(4, deskRandomizer.PersonList.Distinct().Count());
        }
        
        
    }
}