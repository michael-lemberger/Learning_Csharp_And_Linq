using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examProject
{
    public class Vaggie
    {
        public string name { get; set; }
        public string color { get; set; }
        public int amount { get; set; }
        public static List<Vaggie> getVaggies()
        {
            List<Vaggie> vaggies = new List<Vaggie>
            {
                new Vaggie {name = "carrot", color = "orange", amount = 150 },
                new Vaggie {name = "tomato", color = "red", amount = 200 },
                new Vaggie {name = "apple", color = "green", amount = 180 },
                new Vaggie {name = "pumpkin", color = "orange", amount = 20 },
                new Vaggie {name = "cucumber", color = "green", amount = 300 },
                new Vaggie {name = "peppers", color = "red", amount = 75 },
                new Vaggie {name = "lettuce", color = "green", amount = 55 }

            };

            return vaggies;
        }
    }

    

}
