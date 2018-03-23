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
        public void ArrangementShouldBePopulated()
        {
            var deskRandomizer = new DeskRandomizer(3);

            foreach (var element in deskRandomizer.FinalArrangement)
            {
                Assert.Equal(-1, element);
            }
        }
    }
}