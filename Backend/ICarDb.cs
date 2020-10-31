using System.Collections.Generic;
using DataTypes;

namespace Backend
{
    public interface ICarDb
    {
        public byte[] GetCarListJson(int startIndex, int amount);

        public byte[] GetSortedCarsJson(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        public byte[] GetFilteredCarsJson(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        public bool AddCarJson(byte[] car);

        public byte[] GetCarJson(int id);

        public bool DeleteCar(int id);

        public List<int> GetUserAdIds(string username);
    }
}
