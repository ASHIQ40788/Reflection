using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace MoodAnalyser058Batch
{
    public class Program
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("Running moodAnalyser");
            TestCustomerDetailsUsingReflection();
            Console.ReadKey();
        }
        public static void TestCustomerDetailsUsingReflection()
        {
            Assembly asem = Assembly.LoadFrom(@"C:\Users\Personal\source\repos\EWP\EWP\EWP\bin\Debug\EWP.exe");
            // Assembly asem=Assembly.GetExecutingAssembly();

            //Type is a class where iam storing the types of customer class in the form of array.
            Type[] types = asem.GetTypes();
            //Traversing the data present in the 't' object.
            foreach (Type t in types)
            {
                Console.WriteLine("Available Classes from current assambly" + t.FullName);

            }

            //Type is class where iam creating the object and calling the inbuilt function GetType.
            //created the instance because i want to take the type information of my class.
            Type type = Type.GetType("MoodAnalyser058Batch.Customer");
            //Printing the Full Name.
            Console.WriteLine("FullName" + type.FullName);

            //Printing the Name.
            Console.WriteLine("Name" + type.Name);

            //PropertyInfo is a class where iam storing the properties of customer class in the form of array.
            PropertyInfo[] propertyInfos = type.GetProperties();

            Console.WriteLine("Fetching customer property details");

            //Traversing the data present in the property object.
            foreach (PropertyInfo property in propertyInfos)
            {
                Console.WriteLine("ReturnType" + property.PropertyType + " PropertyName+" + property.Name);

            }
            Console.WriteLine("Fetching customer Method details");

            //storing the number of method in an array which is of MethodInfo Class.
            MethodInfo[] methodInfos = type.GetMethods();
            //Traversing the data present in the method.
            foreach (MethodInfo method in methodInfos)
            {
                Console.WriteLine("ReturnType" + method.DeclaringType + "MethodName" + method.Name);

            }
            // ConstructorInfo is a class where iam storing the constructors of customer class in the form of array.
            ConstructorInfo[] constructors = type.GetConstructors();
            Console.WriteLine("Displaying constructors of customer class");
            //Traversing the data present in the constructor object.
            foreach (ConstructorInfo info in constructors)
            {
                Console.WriteLine(info.Name);
                Console.WriteLine(info.ToString());
            }

        }
    }
}
