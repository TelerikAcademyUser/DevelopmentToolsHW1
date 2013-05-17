// <copyright file="EventHolder.cs" company="Telerik Academy">
// Telerik Academy. All rights reserved.
// </copyright>
// <author>Unknown</author>

namespace Events
{
    using System;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Collection of Event objects.
    /// </summary>
    public class EventHolder
    {
        #region Private fields  
        
        /// <summary>
        /// From the PowerCollections library Dictionary used to store the events by title.
        /// </summary>
        private readonly MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        
        /// <summary>
        /// From the PowerCollections library OrderedBag used to store the events by Date.
        /// </summary>
        private readonly OrderedBag<Event> byDate = new OrderedBag<Event>();
        
        #endregion
        
        #region Methods
        
        /// <summary>
        /// Method to add new <see cref="Event"/> by given parameters
        /// </summary>
        /// <param name="dateTime">The date and time of the event we want to create</param>
        /// <param name="title">The title of the new event </param>
        /// <param name="location">The location of the new event</param>
        public void AddEvent(DateTime dateTime, string title, string location)
        {
            Event newEvent = new Event(dateTime, title, location);
            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(newEvent);
            Messages.EventAdded();
        }
        
        /// <summary>
        /// Method we use to delete an <see cref="Event"/> by its title
        /// </summary>
        /// <param name="titleToDelete">The title of the event to be deleted.</param>
        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.byTitle[title])
            {
                this.byDate.Remove(eventToRemove);
                removed++;
            }
            
            this.byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }
        
        /// <summary>
        /// Method to print all the events by limiting them by dateTime and counter.
        /// </summary>
        /// <param name="date">Given to the event at that date.</param>
        /// <param name="count">Number of the events we want to list.</param>
        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }
                
                Messages.PrintEvent(eventToShow);
                showed++;
            }
            
            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
        
        #endregion
    }
}