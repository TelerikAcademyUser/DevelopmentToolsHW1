// <copyright file="Event.cs" company="Telerik Academy">
// Telerik Academy. All rights reserved.
// </copyright>
// <author>Unknown</author>

namespace Events
{
    using System;
    using System.Text;

    /// <summary>
    /// Class implementing an event of some kind including date, title and location.
    /// </summary>
    public class Event : IComparable
    {
        #region Private fields
        
        /// <summary>
        /// Private field to keep the information about the event plus dateTime format.
        /// </summary>
        private readonly string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        
        /// <summary>
        /// Private field to keep the <see cref="Event"/> date and time settings.
        /// </summary>
        private DateTime dateTime;
        
        /// <summary>
        /// Private field to keep the <see cref="Event"/> title.
        /// </summary>
        private string title;
        
        /// <summary>
        /// Private field to keep the <see cref="Event"/> location.
        /// </summary>
        private string location;
        
        #endregion
        
        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="dateTime">The date and time of the event.</param>
        /// <param name="title">The title/name of the event.</param>
        /// <param name="location">The location of the event.</param>
        public Event(DateTime dateTime, string title, string location)
        {
            this.DateTime = dateTime;
            this.Title = title;
            this.Location = location;
        }
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets and privately set the date and time of the event.
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }
            
            private set
            {
                this.dateTime = value;
            }
        }
        
        /// <summary>
        /// Gets and privately set the title of the event.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            
            private set
            {
                this.title = value;
            }
        }
        
        /// <summary>
        /// Gets and privately set the location of the event.
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
            }
            
            private set
            {
                this.location = value;
            }
        }
        
        #endregion
        
        #region Methods
        
        /// <summary>
        /// Compares two events based on location, time or date.
        /// </summary>
        /// <param name="obj">Get another event as an object.</param>
        /// <returns>Returns an integer determined by the conditions.</returns>
        public int CompareTo(object obj)
        {
            Event otherEvent = obj as Event;
            int byDate = this.DateTime.CompareTo(otherEvent.DateTime);
            int byTitle = this.Title.CompareTo(otherEvent.Title);
            int byLocation = this.Location.CompareTo(otherEvent.Location);
            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }
            else
            {
                return byDate;
            }
        }
        
        /// <summary>
        /// Overrides ToString and add the information about the event.
        /// </summary>
        /// <returns>Information about the event as a string.</returns>
        public override string ToString()
        {
            StringBuilder eventAsString = new StringBuilder();
            eventAsString.Append(this.DateTime.ToString(this.dateTimeFormat));
            eventAsString.Append(" | " + this.Title);
            if (!string.IsNullOrEmpty(this.Location))
            {
                eventAsString.Append(" | " + this.Location);
            }
            
            return eventAsString.ToString();
        }
    
        #endregion
    }
}