using Xunit;

namespace Meltwater_Technical_Exercise
{
    public class DocumentRedactorTests
    {
        [Fact]
        public void TestSanitize_SingleReplacement()
        {
            const string textToSanitize = "This thing is borked.";
            const string valueExpected = "This thing is XXXX.";

            DocumentRedactor myRedactor = new();

            myRedactor.SetItemsToRedact("borked");

            var sanitizedText = myRedactor.Sanitize(textToSanitize,"XXXX");

            Assert.Equal(valueExpected,sanitizedText);
        }

        [Fact]
        public void TestSanitize_MultipleReplacements()
        {
            const string textToSanitize = "This thing is borked. You know it's true.";
            const string valueExpected = "This thing is XXXX. You know it's XXXX.";

            DocumentRedactor myRedactor = new();

            myRedactor.SetItemsToRedact("borked,true");

            var sanitizedText = myRedactor.Sanitize(textToSanitize, "XXXX");

            Assert.Equal(valueExpected, sanitizedText);
        }

        [Fact]
        public void TestOddballItemsString()
        {
            const string textToSanitize = "Everyone likes the Boston Red Sox.";
            const string valueExpected = "Everyone likes the XXXX.";

            DocumentRedactor myRedactor = new();

            myRedactor.SetItemsToRedact("Hello world ?Boston Red Sox?, ?Pepperoni Pizza?, ?Cheese Pizza?, beer ");

            var sanitizedText = myRedactor.Sanitize(textToSanitize, "XXXX");

            Assert.Equal(valueExpected, sanitizedText);
        }

        [Fact]
        public void TestOddballItemsString2()
        {
            const string textToSanitize = "Everyone likes the Boston Red Sox.";
            const string valueExpected = "Everyone likes the XXXX.";

            DocumentRedactor myRedactor = new();

            var crazyText = "Hello world ?Boston Red Sox?, ?Pepperoni Pizza?, ?Cheese Pizza?, beer ";

            myRedactor.SetItemsToRedact(crazyText);

            var sanitizedText = myRedactor.Sanitize(textToSanitize, "XXXX");

            Assert.Equal(valueExpected, sanitizedText);
        }

        [Fact]
        public void TestSpecialCharacters()
        {
            const string textToSanitize = "This 'thing' is borked. !@#$%^&*();:,.<>/?[]{}|=+-_ You know it's true.";
            const string valueExpected = "This 'thing' is XXXX. !@#$%^&*();:,.<>/?[]{}|=+-_ You know it's XXXX.";

            DocumentRedactor myRedactor = new();

            myRedactor.SetItemsToRedact("borked,true");

            var sanitizedText = myRedactor.Sanitize(textToSanitize, "XXXX");

            Assert.Equal(valueExpected, sanitizedText);
        }
    }
}
