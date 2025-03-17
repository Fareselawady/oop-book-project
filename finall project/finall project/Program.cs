using System.Xml.Linq;

namespace finall_project
{
    public delegate void TicketBookingHandler(string message);
    public interface Iticketgooking
    {
        void Bookticket(int ticketId);
        void Cancelticket(int ticketId);
        void Displayavailableticket();
    }
    public class Ticket 
    {
        public Ticket(int id, string name, TicketType type, decimal money)
        {
            this.ticketType = type;
            this.price = money;
            this.Eventname = name;
            this.Bookid = id;
        }
        public override string ToString()
        {
            return $"{Bookid} | {Eventname} | {ticketType} | {price}";
        }
        public int Bookid { get; set; }
        public string Eventname { get; set; }
        public TicketType ticketType { get; set; }
        public decimal price { get; set; }
    }

    public class Ticketbookingmanagment : Iticketgooking
    {
       public List<Ticket> list = new List<Ticket>();
       public event TicketBookingHandler TicketBooked;
        public void Bookticket(int ticketId)
        {

        }

        public void Cancelticket(int ticketId)
        {

        }

        public void Displayavailableticket()
        {

        }

    }
    public enum TicketType
    {
        Regylar,
        VIP,
        Child
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var TBM = new Ticketbookingmanagment();
           TBM.list.Add(new Ticket(1 , "fares" , TicketType.VIP , 300.00m));
           TBM.list.Add(new Ticket(2 , "Elawady" , TicketType.Child , 50.00m));
            TBM.list.Add(new Ticket(3, "Mawlana", TicketType.Regylar, 100.00m));
        }
    }
}
