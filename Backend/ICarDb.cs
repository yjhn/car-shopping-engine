using System.Collections.Generic;
using DataTypes;

namespace Backend
{
    public interface ICarDb
    {
        public byte[] GetCarList(int startIndex, int amount);

        public byte[] SortBy(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount, List<Car> carListToSort = null);

        public byte[] Filter(CarFilters filters, SortingCriteria sortBy, bool sortAsceding, int startIndex, int amount);

        public bool AddCar(byte[] car);

        public byte[] GetCar(uint id);

        public bool DeleteCar(uint id);

        public List<uint> GetUserAdIds(string username);
    }
}
