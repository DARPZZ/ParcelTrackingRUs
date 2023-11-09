using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParcelTrackingRUs.Model;

namespace ParcelTrackingRUs.Repositorys
{
  
    public class StudentRepository : IpackageRepository
    {
        public StudentRepository(IOptions<RestDatabaseSettings> mongoDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mongoDBSettings.Value.ConnectString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _students = mongoDatabase.GetCollection<Package>(mongoDBSettings.Value.StudentsCollectionName);
        }
        private readonly IMongoCollection<Package> _students;


        public void add(Package std)
        {
            _students.InsertOne(std);
        }

        public Package? get(Guid id)
        {
            return _students.Find(std => std.Id == id).FirstOrDefault();
        }
        public Package? getAll()
        {
            return _students.Find(e => e.Id =
        }

    }
}
