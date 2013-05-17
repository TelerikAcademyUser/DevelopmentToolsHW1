// <copyright file="Program.cs" company="Telerik Academy">
// Telerik Academy. All rights reserved.
// </copyright>
// <author>Unknown</author>

namespace Events
{
    using System;

    /// <summary>
    /// Main program with only Main method to execute the commands
    /// </summary>
    public class Program
    {
        #region Main Method
        
        /// <summary>
        /// Main where we execute commands connected to the events and print the log of messages
        /// </summary>
        public static void Main()
        {
            string command = null;
            do
            {
                command = Console.ReadLine();
            }
            while (ManipulateEvents.ExecuteNextCommand(command));
            
            Console.WriteLine(Messages.OutputString);
        }
    
        #endregion
    }
}