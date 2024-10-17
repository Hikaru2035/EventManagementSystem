using System;
using System.Collections.Generic;

namespace EventManagementSystem
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int NumberOfTickets { get; set; }
        public double PricePerTicket { get; set; }
        public DateTime DateTime { get; set; }
        public List<Ticket> AvailableTickets { get; private set; }
        private List<Ticket> bookedTickets;

        public Event(int eventId, string name, int numberOfTickets, double pricePerTicket, DateTime dateTime)
        {
            EventId = eventId;
            Name = name;
            NumberOfTickets = numberOfTickets;
            PricePerTicket = pricePerTicket;
            DateTime = dateTime;
            AvailableTickets = new List<Ticket>();
            bookedTickets = new List<Ticket>();

            for (int i = 0; i < numberOfTickets; i++)
            {
                AvailableTickets.Add(new Ticket(eventId, false, dateTime)); // Assuming false for PricePaid and dateTime as bookingDate for initialization
            }
        }

        public bool HasTicketsBooked()
        {
            return bookedTickets.Count > 0;
        }

        public void BookTicket(Ticket ticket)
        {
            if (AvailableTickets.Contains(ticket))
            {
                AvailableTickets.Remove(ticket);
                bookedTickets.Add(ticket);
            }
        }

        public void CancelTicket(int ticketId)
        {
            var ticket = bookedTickets.Find(t => t.TicketId == ticketId);
            if (ticket != null)
            {
                bookedTickets.Remove(ticket);
                AvailableTickets.Add(ticket);
            }
        }

        public void UpdateAvailableTickets()
        {
            AvailableTickets = new List<Ticket>(NumberOfTickets - bookedTickets.Count);
        }
    }
}
