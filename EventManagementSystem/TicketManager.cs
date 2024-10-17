using System.Linq;

namespace EventManagementSystem
{
    public class TicketManager
    {
        private EventManager eventManager;

        public TicketManager(EventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        public bool CanBookTicket(int eventId)
        {
            var eventDetails = eventManager.Events.FirstOrDefault(e => e.EventId == eventId);
            return eventDetails != null && eventDetails.AvailableTickets.Count > 0;
        }

        public bool CanCancelTicket(int ticketId)
        {
            return eventManager.Tickets.Any(t => t.TicketId == ticketId);
        }
    }
}
