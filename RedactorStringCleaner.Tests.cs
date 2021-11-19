using Xunit;

namespace Meltwater_Technical_Exercise
{
    public class RedactorStringCleanerTests
    {

        [Fact]
        public void TestCleanItems_ExactMatch()
        {
            var dirtyItems = new [] { "happy", "sad" };
            var valueExpected = new [] { "happy", "sad" };

            var cleanItems = RedactorStringCleaner.CleanItems(dirtyItems);

            Assert.Equal(valueExpected, cleanItems);
        }

        [Fact]
        public void TestCleanItems_LeftRightApostrophes()
        {
            var dirtyItems = new[] { "happy ", "‘Cheese Pizza’" };
            var valueExpected = new[] { "happy", "Cheese Pizza" };

            var cleanItems = RedactorStringCleaner.CleanItems(dirtyItems);

            Assert.Equal(valueExpected, cleanItems);
        }

        [Fact]
        public void TestCleanItems_LeftRightQuotation()
        {
            var dirtyItems = new[] { "happy ", "“Boston Red Sox”" };
            var valueExpected = new[] { "happy", "Boston Red Sox" };

            var cleanItems = RedactorStringCleaner.CleanItems(dirtyItems);

            Assert.Equal(valueExpected, cleanItems);
        }

    }
}
