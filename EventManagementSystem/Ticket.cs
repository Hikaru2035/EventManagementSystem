using System;

namespace EventManagementSystem
{
    public class Ticket
    {
        private static int nextTicketId = 1;

        public int EventId { get; private set; }
        public int TicketId { get; private set; }
        public bool PricePaid { get; private set; }
        public DateTime BookingDate { get; private set; }

        public Ticket(int eventId, bool pricePaid, DateTime bookingDate)
        {
            EventId = eventId;
            TicketId = nextTicketId++;
            PricePaid = pricePaid;
            BookingDate = bookingDate;
        }

        public void SetPricePaid(bool pricePaid)
        {
            PricePaid = pricePaid;
        }

        public void SetBookingDate(DateTime bookingDate)
        {
            BookingDate = bookingDate;
        }
    }
}
