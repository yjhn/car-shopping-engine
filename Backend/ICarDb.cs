using System.Collections.Generic;
using DataTypes;

namespace Backend
{
    public interface ICarDb
    {
        public byte[] GetCarList(int resultAmount = 50);

        public byte[] SortBy(SortingCriteria sortBy, int resultAmount = 50, List<Car> carListToSort = null);

        public byte[] Filter(CarFilters filters, SortingCriteria sortBy = SortingCriteria.UploadDate, int resultAmount = 50);

        public bool AddCar(byte[] car);

        public byte[] GetCar(uint id);

        public bool DeleteCar(uint id);

        public List<uint> GetUserAdIds(string username);
    }
}
