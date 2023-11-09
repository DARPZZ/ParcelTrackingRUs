using ParcelTrackingRUs.Model;

namespace ParcelTrackingRUs.Repository
{
    public interface IPackageRepository
    {
        void Add(Package std);
        public Package Get(Guid id);
        public List<Package> GetAll();
    }
}
