using System.Collections.Generic;

namespace EventManagementSystem
{
    public class Account
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public Dictionary<int, Ticket> TicketsBooked { get; private set; }

        public Account(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
            TicketsBooked = new Dictionary<int, Ticket>();
        }

        public void BookTicket(Ticket ticket)
        {
            if (!TicketsBooked.ContainsKey(ticket.TicketId))
            {
                TicketsBooked.Add(ticket.TicketId, ticket);
            }
        }

        public void CancelTicket(int ticketId)
        {
            if (TicketsBooked.ContainsKey(ticketId))
            {
                TicketsBooked.Remove(ticketId);
            }
        }
    }
}
