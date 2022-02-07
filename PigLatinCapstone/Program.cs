using System;

namespace PigLatinCaptsone;

internal class Program
{
    static void Main(string[] args)
    {
        bool runProgram = true;
        while (runProgram)
        {
            // intro message
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine();
            // user input
            Console.Write("Enter a line to be translated: ");
            string englishInput = Console.ReadLine().ToLower();
            // displaying translation (output)
            string pigLatinOutput = TranslateLine(englishInput);
            Console.WriteLine();
            Console.WriteLine("Translation: " + pigLatinOutput);
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Would you like to translate again? y/n");
                string loopChoice = Console.ReadLine().ToLower();   
                if (loopChoice == "y")
                {
                    runProgram = true;
                    break;
                }
                else if (loopChoice == "n")
                {
                    runProgram= false;
                    break;
                }
            }
        }
    }

    /// <summary> Gets first vowel index in word/line </summary>
    /// <returns> -1 if not found </returns>
    static int GetVowelPosition(string word)
    {
        int VowelPosition = -1;
        foreach (char letter in word)
        {
            VowelPosition = VowelPosition + 1;
            if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
            {
                return VowelPosition;
            }
            //if (VowelPosition > word.Length)
            //{
            //    return -1;
            //}
        }
        return VowelPosition;
    }

    /// <summary>  will translate the english word into pig latin. </summary>
    /// <param name="englishWord"></param>
    /// <returns></returns>
    static string TranslateWord(string englishWord)
    {
        string pigLatinWord = "";
        string beginningLetters = "";
        string afterLetters = "";
        int VowelPosition = GetVowelPosition(englishWord);
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
            case 3:
                beginningLetters = englishWord.Substring(0, 3);
                afterLetters = englishWord.Substring(3);
                pigLatinWord = afterLetters + beginningLetters + "ay";
                break;
            default:
                pigLatinWord = englishWord;
                Console.WriteLine("\tUnable to translate " + englishWord);
                break;
        }
        return pigLatinWord;
    }

    /// <summary> Translates english line into pig latin </summary>
    /// <param name="english"></param>
    /// <returns></returns>
    static string TranslateLine(string englishLine)
    {
        string translation = "";
        string input = englishLine;
        string[] tempInput = input.Split(' ');

        if (ContainsSymbols(englishLine) || ContainsNumbers(englishLine))
        {
            return "Inncorrect Input";
        }

        for (int i = 0; i < tempInput.Length; i++)
        {
            translation = translation + TranslateWord(tempInput[i]) + " ";
        }
        return translation;
    }

    /// <summary> checks word/line for symbols </summary>
    static bool ContainsSymbols(string englishLine)
    {
        for(int i = 0; i < englishLine.Length; i++)
        {
            if(englishLine.Substring(i,1) == "@" || englishLine.Substring(i, 1) == "#" || englishLine.Substring(i, 1) == "*" || englishLine.Substring(i, 1) == "%" || englishLine.Substring(i, 1) == "&")
            {
                return true;
            }
        }
        return false;
    }

    static bool ContainsNumbers(string englishLine)
    {
        return englishLine.Any(char.IsDigit);
    }

    /// <summary> tests code </summary>
    static void Test()
    {
        Console.WriteLine(GetVowelPosition("poops"));
        Console.WriteLine("2: " + GetVowelPosition("PPO"));
        Console.WriteLine("3: " + GetVowelPosition("PPPO"));
        Console.WriteLine("4: " + GetVowelPosition("PPPPO"));
        Console.WriteLine("-1: " + GetVowelPosition("P"));
        Console.WriteLine("7: " + GetVowelPosition("PPPPPPPO"));
    }


}


