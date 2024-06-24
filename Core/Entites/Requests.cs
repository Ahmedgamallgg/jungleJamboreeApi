using Core.Entites;

namespace Core.Entites
{
    public enum RequestType
    {
        Pending,
        Approved,
        Reject
    }
    public class Requests : BaseEntity
    {
        public int Id { get; set; }

        public RequestType Type { get; set; } = RequestType.Pending;

        public ICollection<TripsEvents> TripsEvents { get; set; }
        public ICollection<NewStaff> NewStaff { get; set; }
    }
}
