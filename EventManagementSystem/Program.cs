using System;

namespace EventManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            UserUI userUI = new UserUI();

            // Admin account setup
            userUI.Register("admin", "admin", true);

            // User registration
            userUI.Register("user1", "password1", false);

            // Login as admin
            userUI.Login("admin", "admin");

            // Admin adds an event
            Console.WriteLine("Admin adds an event:");
            userUI.AdminAddEvent(1, "Music Concert", 100, 50.0, DateTime.Now.AddMonths(1));

            // View all events
            Console.WriteLine("\nViewing all events:");
            userUI.ViewAllEvents();

            // Logout admin
            userUI.Logout();

            // Login as user
            userUI.Login("user1", "password1");

            // User books a ticket
            Console.WriteLine("\nUser books a ticket:");
            userUI.UserBookTicket(1, true, DateTime.Now);

            // View all events after user books a ticket
            Console.WriteLine("\nViewing all events after user books a ticket:");
            userUI.ViewAllEvents();

            // User views their tickets
            Console.WriteLine("\nUser views their tickets:");
            userUI.ViewMyTickets();

            // User cancels a ticket
            Console.WriteLine("\nUser cancels a ticket:");
            userUI.UserCancelTicket(1);

            // View all events after user cancels a ticket
            Console.WriteLine("\nViewing all events after user cancels a ticket:");
            userUI.ViewAllEvents();

            // User views their tickets after canceling
            Console.WriteLine("\nUser views their tickets after canceling:");
            userUI.ViewMyTickets();

            // Logout user
            userUI.Logout();

            // Login as admin
            userUI.Login("admin", "admin");

            // Admin tries to update the event after tickets have been booked
            Console.WriteLine("\nAdmin tries to update the event after tickets have been booked:");
            userUI.AdminUpdateEvent(1, "Second Update Music Concert", 200, 70.0, DateTime.Now.AddMonths(3));

            // View all events after admin tries to update
            Console.WriteLine("\nViewing all events after admin tries to update:");
            userUI.ViewAllEvents();

            // Admin tries to delete the event after tickets have been booked
            Console.WriteLine("\nAdmin tries to delete the event after tickets have been booked:");
            userUI.AdminDeleteEvent(1);

            // View all events after admin tries to delete
            Console.WriteLine("\nViewing all events after admin tries to delete:");
            userUI.ViewAllEvents();

            // Display all transactions
            Console.WriteLine("\nDisplaying all transactions:");
            foreach (var transaction in userUI.GetTransactionManager().GetAllTransactions())
            {
                Console.WriteLine(transaction);
            }

            // Logout admin
            userUI.Logout();
        }
    }
}
