// <copyright file="Messages.cs" company="Telerik Academy">
// Telerik Academy. All rights reserved.
// </copyright>
// <author>Unknown</author>

namespace Events
{
    using System.Text;

    /// <summary>
    /// Creates and manipulates log of messages for the events kept in String Builder
    /// and returned as a string with property
    /// </summary>
    public class Messages
    {
        #region ReadOnly Fields
        
        /// <summary>
        /// The place to store the information about the message log for <see cref="Event"/>
        /// </summary>
        private static readonly StringBuilder Output = new StringBuilder();
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets the String Builder as a string but can't be use to set a value.
        /// </summary>
        public static string OutputString
        {
            get
            {
                return Output.ToString();
            }
        }
        
        #endregion
        
        #region Methods
        
        /// <summary>
        /// Append to a new line that a new <see cref="Event"/> has been added.
        /// </summary>
        public static void EventAdded()
        {
            Output.Append("Event added").AppendLine();
        }
        
        /// <summary>
        /// Append to a new line that an <see cref="Event"/> has been deleted or call another function.
        /// </summary>
        /// <param name="numberOfEvents">Number of events that has been deleted.</param>
        public static void EventDeleted(int numberOfEvents)
        {
            if (numberOfEvents == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} events deleted", numberOfEvents).AppendLine();
            }
        }
        
        /// <summary>
        /// Appends to a new line that no matching events has been found.
        /// </summary>
        public static void NoEventsFound()
        {
            Output.Append("No events found").AppendLine();
        }
        
        /// <summary>
        /// If there is a valid event print it to a new line.
        /// </summary>
        /// <param name="eventToPrint">An event given to check.</param>
        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint).AppendLine();
            }
        }
    
        #endregion
    }
}