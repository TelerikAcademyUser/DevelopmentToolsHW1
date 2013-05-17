// <copyright file="ManipulateEvents.cs" company="Telerik Academy">
// Telerik Academy. All rights reserved.
// </copyright>
// <author>Unknown</author>

namespace Events
{
    using System;

    /// <summary>
    /// Have all the methods to manipulate the events in way wanted.
    /// </summary>
    public class ManipulateEvents
    {
        #region Readonly Fields
        
        /// <summary>
        /// Created a new <see cref="EventHolder"/>.
        /// </summary>
        private static readonly EventHolder CollectionOfEvents = new EventHolder();
        
        #endregion
        
        #region Methods
        
        /// <summary>
        /// Execute a command by corresponding letter.
        /// </summary>
        /// <param name="command">Input from the user from the console.</param>
        /// <returns>Boolean result</returns>
        public static bool ExecuteNextCommand(string command)
        {
            char commmandChar = command[0];
            bool correctCommandExecuted = true;
            switch (commmandChar)
            {
                case 'A':
                    AddEvent(command);
                    break;
                case 'D':
                    DeleteEvents(command);
                    break;
                case 'L':
                    ListEvents(command);
                    break;
                default:
                    {
                        correctCommandExecuted = false;
                        return correctCommandExecuted;
                    }
            }
            
            return correctCommandExecuted;
        }
        
        /// <summary>
        /// Make a list of all the events to the corresponding command.
        /// </summary>
        /// <param name="command">The user command.</param>
        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);
            CollectionOfEvents.ListEvents(date, count);
        }
        
        /// <summary>
        /// Deletes of all the events to the corresponding command.
        /// </summary>
        /// <param name="command">The user command.</param>
        private static void DeleteEvents(string command)
        {
            string title = command.Substring(
                "DeleteEvents".Length + 1);
            CollectionOfEvents.DeleteEvents(title);
        }
        
        /// <summary>
        /// Adds a new <see cref="Event"/> to the collection.
        /// </summary>
        /// <param name="command">The user command.</param>
        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);
            CollectionOfEvents.AddEvent(date, title, location);
        }
        
        /// <summary>
        /// Process the command and separate the parameters to later use.
        /// </summary>
        /// <param name="commandForExecution">The user command.</param>
        /// <param name="commandType">The command type - (methods from above)</param>
        /// <param name="dateAndTime">Output date and time</param>
        /// <param name="eventTitle">Output the title for an event</param>
        /// <param name="eventLocation">Output the location for an event</param>
        private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
 