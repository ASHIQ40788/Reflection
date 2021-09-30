using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser058Batch
{
    /// <summary>
    /// Analyzing user mood based on happy or sad word.
    /// </summary>
   public class MoodAnalyser
    {
        //Iam in Happy mood
        public string message;
        public MoodAnalyser()
        {
            Console.WriteLine("Default constructor");
        }

        public MoodAnalyser(string message)
        {

            this.message = message;
        }

        //create Analyse method for analyser mood of the user
        public string AnalyseMood()
        {
            try
            {

                if (message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.EMPTY_TYPE_EXCEPTION, "message should not be empty");
                }
                else if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else if (message.ToLower().Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "there is no happy or sad exist in the given message";
                }
            }
            catch (NullReferenceException ex)
            {
                //return "happy";
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NULL_TYPE_EXCEPTION, "message should not be null");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}