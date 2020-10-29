using System.Collections.Generic;
using DataTypes;

namespace Backend
{
    public interface ICarDb
    {
        public byte[] GetCarList(int startIndex, int amount);

        public byte[] SortBy(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        public byte[] Filter(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        public bool AddCar(byte[] car);

        public byte[] GetCar(int id);

        public bool DeleteCar(int id);

        public List<int> GetUserAdIds(string username);
    }
}
