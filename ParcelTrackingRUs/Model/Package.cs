using MongoDB.Bson.Serialization.Attributes;

namespace ParcelTrackingRUs.Model
{
    public class Package
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastLocationCoords { get; set; }

        public Package(Guid id, string name, string coordinates)
        {
            this.Id = id;
            this.Name = name;
            this.LastLocationCoords = coordinates;
        }
    }
}
