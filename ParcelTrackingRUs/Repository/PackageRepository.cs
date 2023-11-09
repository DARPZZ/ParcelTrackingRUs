using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParcelTrackingRUs.Model;

namespace ParcelTrackingRUs.Repository
{
  
    public class PackageRepository : IPackageRepository
    {
        public PackageRepository(IOptions<RestDatabaseSettings> mongoDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mongoDBSettings.Value.ConnectString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _students = mongoDatabase.GetCollection<Package>(mongoDBSettings.Value.StudentsCollectionName);
        }
        private readonly IMongoCollection<Package> _students;


        public void Add(Package std)
        {
            _students.InsertOne(std);
        }

        public Package? Get(Guid id)
        {
            return _students.Find(std => std.Id == id).FirstOrDefault();
        }
		public List<Package> GetAll()
		{
			return _students.Find(_ => true).ToList();
		}

	}
}
