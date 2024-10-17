using System;
using System.Collections.Generic;

namespace EventManagementSystem
{
    public class TransactionManager
    {
        private List<Transaction> transactions;

        public TransactionManager()
        {
            transactions = new List<Transaction>();
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }

        public void RecordAddEvent(Event eventObj)
        {
            transactions.Add(new AddEventTransaction(DateTime.Now, eventObj));
        }

        public void RecordDeleteEvent(Event eventObj)
        {
            transactions.Add(new DeleteEventTransaction(DateTime.Now, eventObj));
        }

        public void RecordUpdateEvent(Event eventObj)
        {
            transactions.Add(new UpdateEventTransaction(DateTime.Now, eventObj));
        }

        public void RecordBookTicket(Ticket ticket, string username)
        {
            transactions.Add(new BookTicketTransaction(DateTime.Now, ticket, username));
        }

        public void RecordCancelTicket(Ticket ticket, string username)
        {
            transactions.Add(new CancelTicketTransaction(DateTime.Now, ticket, username));
        }
    }
}
