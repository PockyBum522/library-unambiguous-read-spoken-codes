﻿using System;
using JetBrains.Annotations;


namespace EasyCodes
{
    [PublicAPI]
    public static class Generator
    {
        // Valid characters should be unambiguous when spoken AND read
        private static string ValidLetters => "ACDFGHJKLPQRTUVWXYZ";
        private static string ValidNumbers => "24679";
        private static string ValidSymbols => "~@#%^&*";
        
        public static string GetCode(int length = 6, CharacterSets characterSet = CharacterSets.LettersAndNumbers)
        {
            var fullCharacterSet = BuildFullCharacterSet(characterSet);

            var rand = new Random();

            var returnCode = "";
            
            for (var i = 0; i < length; i++)
            {
                var randomIndex = rand.Next(fullCharacterSet.Length);

                returnCode += fullCharacterSet[randomIndex];
            }

            return returnCode;
        }

        public static string SplitCode(string code, int splitEveryChars = 4, string splitString = " ")
        {
            if (code.Length <= splitEveryChars)
                return code;

            var i = splitEveryChars;
            
            while (i < code.Length)
            {
                code = code.Insert(i, splitString);

                i += splitEveryChars + splitString.Length;
            }

            return code;
        }
        
        private static string BuildFullCharacterSet(CharacterSets characterSet)
        {
            if (characterSet == CharacterSets.LettersOnly)
            {
                return ValidLetters;
            }

            if (characterSet == CharacterSets.LettersAndNumbers)
            {
                return ValidLetters + ValidNumbers;
            }

            if (characterSet == CharacterSets.LettersNumbersAndSymbols)
            {
                return ValidLetters + ValidNumbers + ValidSymbols;
            }

            throw new Exception();
        }
    }
}