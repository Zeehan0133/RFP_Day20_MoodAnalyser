using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
    public class MoodAnalyserCustomException : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            NO_SUCH_METHOD,
            NO_SUCH_CLASS
        }
        private readonly ExceptionType type;
        public MoodAnalyserCustomException(ExceptionType Type, String message) : base(message)
        {
            this.type = Type;
        }
    }
}
