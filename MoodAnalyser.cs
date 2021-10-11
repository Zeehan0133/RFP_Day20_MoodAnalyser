using Mood_Analyser;

using System;
using System.Collections.Generic;
using System.Text;

namespace DAY21_Assignment_MoodAnalyzer
{
    public class MoodAnalyser
    {
        public string message;
        //Default constructor
        public MoodAnalyser() { }
        //Parameterised Constructor
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyser.MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (message.ToUpper().Contains("SAD"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
        }
    }
}
