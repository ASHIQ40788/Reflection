using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MoodAnalyser05Batch;
using System.ComponentModel.DataAnnotations;

namespace MoodAnalyser058Batch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running moodAnalyser");
            TestCustomerDetailsUsingReflection();
       
        }
        public static void TestAuthorModel(Author author)
        {
            ValidationContext context = new ValidationContext(author, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(author, context, validationResults, true);
            if (!valid)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine("{0}", validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Satisfied all the validations");
            }
        }

        public static void TestCustomerDetailsUsingReflection()
        {
            Assembly asem=Assembly.LoadFrom(@"C:\Users\Personal\source\repos\EWP\EWP\EWP\bin\Debug\EWP.exe");
            // Assembly asem=Assembly.GetExecutingAssembly();
            Type[] types = asem.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine("Available Classes from current assambly" + t.FullName);

            }

            Type type = Type.GetType("MoodAnalyser058Batch.Customer");

            Console.WriteLine("FullName" + type.FullName);

            Console.WriteLine("Name" + type.Name);

            PropertyInfo[] propertyInfos = type.GetProperties();

            Console.WriteLine("Fetching customer property details");
            foreach(PropertyInfo property in propertyInfos)
            {
                Console.WriteLine("ReturnType" +property.PropertyType+" PropertyName+" +property.Name);

            }
            Console.WriteLine("Fetching customer Method details");
            MethodInfo[] methodInfos = type.GetMethods();
            foreach (MethodInfo method in methodInfos)
            {
                Console.WriteLine("ReturnType" +method.DeclaringType+ "MethodName" + method.Name);

            }
            ConstructorInfo[] constructors = type.GetConstructors();
            Console.WriteLine("Displaying constructors of customer class");
            foreach (ConstructorInfo info in constructors)
            {
                Console.WriteLine(info.Name);
                Console.WriteLine(info.ToString());
            }

        }
    }
}
