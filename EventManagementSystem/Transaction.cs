using System;

namespace EventManagementSystem
{
    public abstract class Transaction
    {
        public DateTime TransactionDateTime { get; set; }
        public string TransactionType { get; set; }

        protected Transaction(DateTime transactionDateTime, string transactionType)
        {
            TransactionDateTime = transactionDateTime;
            TransactionType = transactionType;
        }

        public abstract override string ToString();
    }

    public class AddEventTransaction : Transaction
    {
        public Event Event { get; set; }

        public AddEventTransaction(DateTime transactionDatetime, Event eventObj)
            : base(transactionDatetime, "AddEvent")
        {
            Event = eventObj;
        }

        public override string ToString()
        {
            return $"{TransactionDateTime}: {TransactionType} - EventId: {Event.EventId}, EventName: {Event.Name}";
        }
    }

    public class DeleteEventTransaction : Transaction
    {
        public Event Event { get; set; }

        public DeleteEventTransaction(DateTime transactionDatetime, Event eventObj)
            : base(transactionDatetime, "DeleteEvent")
        {
            Event = eventObj;
        }

        public override string ToString()
        {
            return $"{TransactionDateTime}: {TransactionType} - EventId: {Event.EventId}, EventName: {Event.Name}";
        }
    }

    public class UpdateEventTransaction : Transaction
    {
        public Event Event { get; set; }

        public UpdateEventTransaction(DateTime transactionDatetime, Event eventObj)
            : base(transactionDatetime, "UpdateEvent")
        {
            Event = eventObj;
        }

        public override string ToString()
        {
            return $"{TransactionDateTime}: {TransactionType} - EventId: {Event.EventId}, EventName: {Event.Name}";
        }
    }

    public class BookTicketTransaction : Transaction
    {
        public Ticket Ticket { get; set; }
        public string Username { get; set; }

        public BookTicketTransaction(DateTime transactionDatetime, Ticket ticket, string username)
            : base(transactionDatetime, "BookTicket")
        {
            Ticket = ticket;
            Username = username;
        }

        public override string ToString()
        {
            return $"{TransactionDateTime}: {TransactionType} - TicketId: {Ticket.TicketId}, EventId: {Ticket.EventId}, Username: {Username}, PricePaid: {Ticket.PricePaid}";
        }
    }

    public class CancelTicketTransaction : Transaction
    {
        public Ticket Ticket { get; set; }
        public string Username { get; set; }

        public CancelTicketTransaction(DateTime transactionDatetime, Ticket ticket, string username)
            : base(transactionDatetime, "CancelTicket")
        {
            Ticket = ticket;
            Username = username;
        }

        public override string ToString()
        {
            return $"{TransactionDateTime}: {TransactionType} - TicketId: {Ticket.TicketId}, EventId: {Ticket.EventId}, Username: {Username}";
        }
    }
}
