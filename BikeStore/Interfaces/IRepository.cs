using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BikeStore
{
    public interface IRepository
    {
        IList<BikeModel> findAll();
        BikeModel findBike(int? bikeId);
        bool save(BikeModel bike);
        IList<BikeModel> update(BikeModel bike);
        bool delete(BikeModel bike);
        IList<BikeModel> search(string bikeId);

    }
}
