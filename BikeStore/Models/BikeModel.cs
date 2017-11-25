using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BikeStore.Models
{
    public class BikeModel
    {
        private static Random random = new Random();

        public static string[] arr = { "Sportive", "Mountain" };
        public int ID { get; set; }

        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("Модель")]
        public string BikeModelName { get; set; }

        [DisplayName("Марка")]
        public string Mark { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public static BikeModel build()
        {
            int type = random.Next(0, 2);
            int index = random.Next(0, 1000);
            return new BikeModel()
            {
                ID = index,
                BikeModelName = "BikeModel_" + index,
                Mark = "Mark_" + index,
                Price = 100 * index,
                Type = arr[type]
            };
        }

    }
}