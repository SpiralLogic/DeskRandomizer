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

            Assert.Equal(3, deskRandomizer.Arrangement.Length);
        }
    }
}