using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public interface ICarDb
    {
        public byte[] GetCarList(int resultAmount = 50);

        public byte[] SortBy(SortingCriteria sortBy, int resultAmount = 50);

        public byte[] Filter(CarFilters filters);

        public bool AddCar(byte[] car);

        public byte[] GetCar(int id);

        public bool DeleteCar(int id);

        public List<int> GetUserAdIds(string username);
    }
}
