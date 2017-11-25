using BikeStore.DataAccess;
using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.DataAccess
{
    public class BikeContext
    {
        public IRepository bikeRepository = new BikeRepository();
        private static IList<BikeModel> bikes;

        public static IList<BikeModel> instance()
        {
            if(bikes == null)
            {
                bikes = init();
            }
            return bikes;
        }

        private static IList<BikeModel> init()
        {
            IList<BikeModel> bikes = new List<BikeModel>();
            for (int i = 0; i < 10; i++)
            {
                bikes.Add(BikeModel.build());
            }
            return bikes;
        }
    }

}