using System;
using System.Linq;

namespace EventManagementSystem
{
    public class UserUI
    {
        private EventManager eventManager;
        private AccountManager accountManager;
        private TransactionManager transactionManager;
        private Account currentUser;

        public UserUI()
        {
            eventManager = new EventManager();
            accountManager = new AccountManager();
            transactionManager = new TransactionManager();
        }

        public void Login(string username, string password)
        {
            if (accountManager.Accounts.TryGetValue(username, out var account) && account.Password == password)
            {
                currentUser = account;
            }
            else
            {
                currentUser = null;
            }
        }

        public void Register(string username, string password, bool isAdmin)
        {
            Account newAccount = new Account(username, password, isAdmin);
            accountManager.AddAccount(newAccount);
        }

        public bool IsLoggedIn()
        {
            return currentUser != null;
        }

        public bool IsAdmin()
        {
            return currentUser != null && currentUser.IsAdmin;
        }

        public void Logout()
        {
            currentUser = null;
        }

        public void AdminAddEvent(int eventId, string eventName, int numberOfTickets, double pricePerTicket, DateTime eventDate)
        {
            if (currentUser != null && currentUser.IsAdmin)
            {
                var existingEvent = eventManager.Events.FirstOrDefault(e => e.EventId == eventId);
                if (existingEvent == null)
                {
                    Event newEvent = new Event(eventId, eventName, numberOfTickets, pricePerTicket, eventDate);
                    eventManager.AddEvent(newEvent);
                    transactionManager.RecordAddEvent(newEvent);
                }
                else
                {
                    Console.WriteLine("Event with the same ID already exists.");
                }
            }
            else
            {
                Console.WriteLine("Only admin can add events.");
            }
        }

        public void AdminUpdateEvent(int eventId, string eventName, int numberOfTickets, double pricePerTicket, DateTime eventDate)
        {
            if (currentUser != null && currentUser.IsAdmin)
            {
                eventManager.AdminUpdateEvent(currentUser, eventId, eventName, numberOfTickets, pricePerTicket, eventDate);
            }
        }

        public void AdminDeleteEvent(int eventId)
        {
            if (currentUser != null && currentUser.IsAdmin)
            {
                var eventToDelete = eventManager.Events.FirstOrDefault(e => e.EventId == eventId);
                if (eventToDelete != null && !eventToDelete.HasTicketsBooked())
                {
                    eventManager.RemoveEvent(eventId);
                    transactionManager.RecordDeleteEvent(eventToDelete);
                }
                else if (eventToDelete != null && eventToDelete.HasTicketsBooked())
                {
                    Console.WriteLine("Cannot delete event because tickets have been booked.");
                }
            }
        }

        public void ViewAllEvents()
        {
            var events = eventManager.ListEvents();
            foreach (var eachEvent in events)
            {
                Console.WriteLine($"Event ID: {eachEvent.EventId}, Name: {eachEvent.Name}, Available Tickets: {eachEvent.AvailableTickets.Count}, Date: {eachEvent.DateTime}");
            }
        }

        public void UserBookTicket(int eventId, bool pricePaid, DateTime bookingDate)
        {
            if (currentUser != null)
            {
                var eventDetails = eventManager.Events.FirstOrDefault(e => e.EventId == eventId);
                if (eventDetails != null && eventDetails.AvailableTickets.Count > 0)
                {
                    var ticket = eventDetails.AvailableTickets.First();
                    ticket.SetPricePaid(pricePaid);
                    ticket.SetBookingDate(bookingDate);
                    currentUser.BookTicket(ticket);
                    eventManager.BookTicket(eventId, ticket.TicketId, pricePaid, bookingDate);
                    transactionManager.RecordBookTicket(ticket, currentUser.Username);
                }
                else
                {
                    Console.WriteLine("Event not found or no available tickets.");
                }
            }
            else
            {
                Console.WriteLine("No user is logged in.");
            }
        }

        public void UserCancelTicket(int ticketId)
        {
            if (currentUser != null)
            {
                Console.WriteLine("Current user is logged in.");
                if (currentUser.TicketsBooked.ContainsKey(ticketId))
                {
                    Console.WriteLine("User has this ticket booked.");
                    var ticket = currentUser.TicketsBooked[ticketId];
                    var eventDetails = eventManager.Events.FirstOrDefault(e => e.EventId == ticket.EventId);
                    if (eventDetails != null)
                    {
                        Console.WriteLine("Event found in EventManager.");
                        eventManager.CancelTicket(ticketId);
                        currentUser.CancelTicket(ticketId);
                        transactionManager.RecordCancelTicket(ticket, currentUser.Username);
                        Console.WriteLine("Ticket cancelled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Event not found in EventManager.");
                    }
                }
                else
                {
                    Console.WriteLine("User does not have this ticket booked.");
                }
            }
            else
            {
                Console.WriteLine("No user is logged in.");
            }
        }

        public void ViewMyTickets()
        {
            if (currentUser != null)
            {
                foreach (var ticket in currentUser.TicketsBooked.Values)
                {
                    var eventDetails = eventManager.Events.FirstOrDefault(e => e.EventId == ticket.EventId);
                    if (eventDetails != null)
                    {
                        Console.WriteLine($"Ticket ID: {ticket.TicketId}, Event Name: {eventDetails.Name}, Date: {eventDetails.DateTime}, Price Paid: {ticket.PricePaid}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No user is logged in.");
            }
        }

        public TransactionManager GetTransactionManager()
        {
            return transactionManager;
        }
    }
}
