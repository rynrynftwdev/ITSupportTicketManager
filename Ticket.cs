using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support_Ticket_Manager
{
    public class Ticket
    {
        //Class variables
        private string _id = "";
        private string _description = "";
        private string _priority = "Low";
        private string _status = "Open";

        //Make two arrays for allowed values for status and priority
        public static readonly string[] AllowedPriorities = { "Low", "Medium", "High" };
        public static readonly string[] AllowedStatuses = { "Open", "In Progress", "Closed" };

        //Getter / Setter method for each variable
        public string Id
        {
            get => _id;
            set => _id = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Id cannot be empty.")
                : value.Trim();
        }

        public string Description
        {
            get => _description;
            set => _description = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Description cannot be empty.")
                : value.Trim();
        }

        public string Priority
        {
            get => _priority;
            set
            {
                var v = (value ?? "").Trim();
                if (Array.IndexOf(AllowedPriorities, v) < 0)
                    throw new ArgumentException($"Priority must be one of: {string.Join(", ", AllowedPriorities)}");
                _priority = v;
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                var v = (value ?? "").Trim();
                if (Array.IndexOf(AllowedStatuses, v) < 0)
                    throw new ArgumentException($"Status must be one of: {string.Join(", ", AllowedStatuses)}");
                _status = v;
            }
        }

        public DateTime DateCreated { get; private set; } = DateTime.UtcNow;

        //Constructors
        //Default constructor
        public Ticket() { }


        public Ticket(string id, string description, string priority, string status) 
        {
            Id = id;
            Description = description;
            Priority = priority;
            Status = status;
            DateCreated = DateTime.UtcNow;
        }

        //Processing Methods
        public void CloseTicket() => Status = "Closed";
        public void ReopenTicket() => Status = "Open";


        public string GetSummary() =>
            $"[{Id}] ({Priority}) \"{Description}\" | Status: {Status} | Created (UTC): {DateCreated:yyyy-MM-dd HH:mm}";

    }
}
