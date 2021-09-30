using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MoodAnalyser058Batch
{

    /// UC4-is to create object by using reflector and use default constructor
    /// <summary>
    /// Creating MoodAnalyserFactory class
    /// </summary>
    public class MoodAnalyserFactory
    {

       
        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <param name="className">Name of the class</param>
        /// <param name="constructor">The constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyser058Batch.CustomMoodAnalyserException ">
        /// class not found
        /// constructor not found
        /// </exception>
        public Object CreateMoodAnalyserObject(string className, string constructor)
        {
            //MoodAnalyserBatch058Batch.MoodAnalyse
            string pattern = "." + constructor + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }

                catch (Exception ex)
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "class not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "constructor not found");
            }
        }

        /// <summary>
        /// UC5- Creating parameterized constructor.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructor"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public object CreateMoodAnalyserParameterizedObject(string className, string constructor, string message)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    if (type.Name.Equals(constructor))
                    {
                        ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                        var obj = constructorInfo.Invoke(new object[] { message });
                        return obj;
                    }
                    else
                        throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "constructor is not found");
                }
                else
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "className is not found");

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// UC6-Reflection to invoke Method.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                MethodInfo methodInfo = type.GetMethod(methodName);
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object moodAnalyserObject = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserForTVSBatch.MoodAnalyser", "MoodAnalyser", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();

            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "method not found");
            }
        }
        /// <summary>
        /// UC7-Sets the field
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        /// <exception cref ="MoodAnalyser058Batch.CustomMoodAnalyserException")
        /// Message should not be null
        /// or
        /// FieldName should not be null
        /// </exception>
        /// <exception cref="System.Exception"></exception>
        public string SetField(string msg, string fieldName)
        {
            try
            {
                MoodAnalyserFactory fac = new MoodAnalyserFactory();
                MoodAnalyser obj = (MoodAnalyser)fac.CreateMoodAnalyserObject("MoodAnalyser058Batch.MoodAnalyser", "MoodAnalyser");
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (field != null)
                {
                    if (msg == null)
                    {
                        throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NUll_MESSAGE, "Message should not be null");
                    }
                    field.SetValue(obj, msg);
                    return obj.message;
                }
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.FIELD_NULL, "FieldName should not be null");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        
    }
}



                
