using System;

namespace PigLatinCaptsone;
internal class Program
{
    static void Main(string[] args)
    {
        // intro message
        Console.WriteLine("Welcome to the Pig Latin Translator!");
        Console.WriteLine();
        // user input
        Console.Write("Enter a line to be translated: ");
        string englishWord = Console.ReadLine().ToLower();
        // vowel checker
        int VowelPosition = GetVowelPosition(englishWord);
        //foreach (char letter in englishWord)
        //{
        //    VowelPosition = VowelPosition + 1;
        //    if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
        //    {
        //        break;
        //    }
        //}
        // conditionals 
        string pigLatinWord = "";
        string beginningLetters = "";
        string afterLetters = "";
        switch (VowelPosition)
        {
            case 0:
                // if a word starts with a vowel, just add “way” onto the ending
                pigLatinWord = englishWord + "way";
                break;
            case 1:
                // if a word starts with a consonant, move all of the consonants that appear before the first vowel
                // to the end of the word, then add “ay” to the end of the word
                beginningLetters = englishWord.Substring(0, 1);
                afterLetters = englishWord.Substring(1);
                pigLatinWord = afterLetters + beginningLetters + "ay";
                break;
            case 2:
                beginningLetters = englishWord.Substring(0, 2);
                afterLetters = englishWord.Substring(2);
                pigLatinWord = afterLetters + beginningLetters + "ay";
                break;
            default:
                pigLatinWord = "Sorry, unable to translate that word.";
                break;
        }
        // displaying translation (output)
        Console.WriteLine("Translation: " + pigLatinWord);
        Console.WriteLine();
    }
    static int GetVowelPosition(string word)
    {
        int VowelPosition = -1;
        foreach (char letter in word)
        {
            VowelPosition = VowelPosition + 1;
            if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
            {
                break;
            }
        }
        return VowelPosition;
    }
}
