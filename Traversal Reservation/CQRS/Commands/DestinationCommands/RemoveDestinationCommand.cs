namespace Traversal_Reservation.CQRS.Commands.DestinationCommands
{
    public class RemoveDestinationCommand
    {
        public RemoveDestinationCommand(int ID)
        {
            this.ID = ID;
        }

        public int ID { get; set; }
    }
}
