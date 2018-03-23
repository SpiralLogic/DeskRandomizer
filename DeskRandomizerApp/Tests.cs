using Xunit;

namespace DeskRandomizerApp
{
    public class Tests
    {
        [Fact]
        public void CreatePersonListShouldCreateAnArrayWithGivenInput()
        {
            var deskRandomizer = new DeskRandomizerApp(3);

            Assert.Equal(3, deskRandomizer.Arrangement.Length);
        }
    }
}