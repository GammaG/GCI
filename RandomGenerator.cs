using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCI
{


    class RandomGenerator
    {

       
        public List<int> generateRandomIntList(int listSize)
        {
            List<int> list = new List<int>();

            Random random = new Random();

           while(list.Count <= listSize)
            {
                int next = random.Next(20 + listSize);
                if (!list.Contains(next))
                {
                    list.Add(next);
                }
             
            }

            return list;

        }


    }
}
