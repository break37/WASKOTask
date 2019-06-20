using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASKOTask.DAL
{
    class CarsBuffer
    {
        public List<Car> Cars { get; set; }

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
