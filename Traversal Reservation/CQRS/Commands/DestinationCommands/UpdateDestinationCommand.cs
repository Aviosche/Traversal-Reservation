namespace Traversal_Reservation.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int ID { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string DayNight { get; set; }
    }
}
