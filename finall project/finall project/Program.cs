using System;
using System.Collections.Generic;

namespace FinalProject
{
    public delegate void TicketBookingHandler(string message);

    public interface ITicketBooking
    {
        void BookTicket(int ticketId);
        void CancelTicket(int ticketId);
        void DisplayAvailableTickets();
    }

    public class Ticket
    {
        public Ticket(int id, string name, TicketType type, decimal price)
        {
            this.TicketType = type;
            this.Price = price;
            this.EventName = name;
            this.BookId = id;
        }

        public override string ToString()
        {
            return $"{BookId} | {EventName} | {TicketType} | {Price} EGP";
        }

        public int BookId { get; set; }
        public string EventName { get; set; }
        public TicketType TicketType { get; set; }
        public decimal Price { get; set; }
    }

    public class TicketBookingManagement : ITicketBooking
    {
        private List<Ticket> tickets = new List<Ticket>();

        public event TicketBookingHandler TicketBooked;

        public void BookTicket(int ticketId)
        {
            var ticket = tickets.Find(t => t.BookId == ticketId);
            if (ticket != null)
            {
                tickets.Remove(ticket);
                TicketBooked?.Invoke($"Ticket {ticketId} booked successfully.");
            }
            else
            {
                Console.WriteLine("Ticket not found.");
            }
        }

        public void CancelTicket(int ticketId)
        {
            Console.WriteLine($"Ticket {ticketId} canceled.");
        }

        public void DisplayAvailableTickets()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets available.");
                return;
            }

            Console.WriteLine("Available Tickets:");
            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket);
            }
        }

        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }
    }

    public enum TicketType
    {
        Regular,
        VIP,
        Child
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var tbm = new TicketBookingManagement();

            // Adding tickets
            tbm.AddTicket(new Ticket(1, "Concert", TicketType.VIP, 300.00m));
            tbm.AddTicket(new Ticket(2, "Movie", TicketType.Child, 50.00m));
            tbm.AddTicket(new Ticket(3, "Theater", TicketType.Regular, 100.00m));

            // Display available tickets
            tbm.DisplayAvailableTickets();

            // Booking a ticket
            tbm.BookTicket(1);

            // Display available tickets after booking
            tbm.DisplayAvailableTickets();
        }
    }
}
