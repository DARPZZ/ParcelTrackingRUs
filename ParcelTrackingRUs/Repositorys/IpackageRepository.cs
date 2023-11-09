using ParcelTrackingRUs.Model;

namespace ParcelTrackingRUs.Repositorys
{
    public interface IpackageRepository
    {
        void add(Package std);
        public Package get(Guid id);
        public Package getAll();
    }
}
