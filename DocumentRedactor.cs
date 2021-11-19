using System;
using System.Linq;

namespace Meltwater_Technical_Exercise
{
    public class DocumentRedactor
    {
        private string[] _itemsToRedact;
        private readonly char[] _charSeparators = new char[] { '\u002C' }; //unicode comma = \u002C

        public void SetItemsToRedact(string inputString)
        {
            _itemsToRedact = RedactorStringCleaner.CleanItems(inputString.Split(_charSeparators, StringSplitOptions.RemoveEmptyEntries));
        }

        public string Sanitize(string textToSanitize, string replacementText)
        {
            return _itemsToRedact.Aggregate(textToSanitize, (current, redactItem) => current.Replace(redactItem, replacementText));
        }
    }
}
