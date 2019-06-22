using System.Collections.Generic;

namespace WASKOTask.DAL
{
    class CarsBuffer
    {
        public List<Car> Cars { get; set; }

        public CarsBuffer()
        {
            Cars = new List<Car>();
        }

        public void AddRecord(Car car)
        {
            Cars.Add(car);
        }

        public bool IsEmpty()
        {
            if (Cars.Count == 0) return true;
            return false;
        }

        public void Clear()
        {
            Cars.Clear();
        }
    }
}
