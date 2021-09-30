using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser058Batch
{
    /// <summary>
    /// Creating customer class
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        /// The identifier.
        public int Id
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        /// <summary>
        /// Initializes the new instance of the <see cref="cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            this.Id = -1;
            this.Name = null;
        }
        public Customer(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }


        //Prints the Identifier.
        public void PrintId()
        {
            Console.WriteLine("Id is {0}" + this.Id);
        }
        public void PrintName()
        {
            Console.WriteLine("Name is {0}" + this.Name);        

        }
    }
}
