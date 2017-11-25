using System;
using BikeStore.Models;
using BikeStore.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore
{
    public class BikeRepository : IRepository
    {
        private static IList<BikeModel> _bikes;

        public BikeRepository()
        {
            if (_bikes == null) _bikes = init();
        }
        private IList<BikeModel> init()
        {
            IList<BikeModel> bikes = new List<BikeModel>();
            for(int i = 0; i < 10; i++)
            {
                bikes.Add(BikeModel.build());
            }
            return bikes;
        }

        public IList<BikeModel> findAll()
        {
            return _bikes;
        }

        public BikeModel findBike(int? bikeId)
        {
            return _bikes.FirstOrDefault(bike => bike.ID == bikeId);
        }

        public bool save(BikeModel bike)
        {
            _bikes.Add(bike);
            return true;
        }

        public IList<BikeModel> update(BikeModel bike)
        {
            foreach(BikeModel bikee in _bikes)
            {
                if(bikee.ID == bike.ID)
                {
                    bikee.ID = bike.ID;
                    bikee.Mark = bike.Mark;
                    bikee.Price = bike.Price;
                    bikee.BikeModelName = bike.BikeModelName;
                    bikee.Type = bike.Type;
                    return _bikes;
                }
            }
            return _bikes;
        }

        public bool delete(BikeModel bike)
        {
            foreach(BikeModel bikee in _bikes)
            {
                if(bike.ID == bikee.ID)
                {
                    _bikes.Remove(bike);
                    return true;
                }
            }
            return false;
        }

        public IList<BikeModel> search(string bikeId)
        {
            throw new NotImplementedException();
        }
    }
}