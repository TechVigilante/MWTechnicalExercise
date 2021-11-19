using System.Collections.Generic;
using System.Linq;

namespace Meltwater_Technical_Exercise
{
    public class RedactorStringCleaner
    {
        public static string[] CleanItems(string[] dirtyItems)
        {
            List<string> cleanedItems = new();

            //unicode chars for: space, apostrophe, left apostrophe, right apostrophe, quotation mark, left quotation mark, and right quotation mark
            char[] charsToTrim = { '\u0022', '\u0020', '\u0027', '\u2018', '\u2019', '\u201C', '\u201D', '\u003F' };

            foreach (var itemsToAdd in from item in dirtyItems
                                       let itemToClean = item.Trim(trimChars: charsToTrim)
                                       let itemsToAdd = SplitOnPhrases(itemToClean)
                                       select itemsToAdd)
            {
                cleanedItems.AddRange(from phrase in itemsToAdd
                                      select phrase);
            }

            return cleanedItems.ToArray();
        }

        private static string[] SplitOnPhrases(string itemToSplit)
        {
            //unicode chars for: apostrophe, left apostrophe, right apostrophe, quotation mark, left quotation mark, and right quotation mark
            char[] charsToSplitOn = { '\u0022', '\u0027', '\u2018', '\u2019', '\u201C', '\u201D', '\u003F' };

            List<string> returnItems = new();
            var splitFlag = false;

            foreach (var newItems in from charValue in charsToSplitOn
                                     where itemToSplit.Contains(charValue)
                                     let newItems = itemToSplit.Split(charValue)
                                     select newItems)
            {
                returnItems.AddRange(from newItem in newItems
                                     select newItem.Trim(charsToSplitOn).Trim());
                splitFlag = true;
            }

            if (!splitFlag)
            {
                returnItems.Add(itemToSplit);
            }

            return returnItems.ToArray();
        }
    }
}