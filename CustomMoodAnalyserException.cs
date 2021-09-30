using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser058Batch
{
    public class CustomMoodAnalyserException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            NULL_TYPE_EXCEPTION,
            EMPTY_TYPE_EXCEPTION,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND,
            NO_SUCH_METHOD,
            NUll_MESSAGE,
            FIELD_NULL

        }
        public CustomMoodAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;

        }
    }
}