using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCI
{

    class ListModel
    {
        private static ListModel listModel;
        private Dictionary<int, long> problemSizeAndAverageMap;
        private List<long> times;

        private ListModel()
        {
            times = new List<long>();
            problemSizeAndAverageMap = new Dictionary<int, long>();
        }

        public static ListModel getInstance()
        {
            if (listModel == null)
            {
                listModel = new ListModel();
            }
            return listModel;
        }

        public void addTime(long time)
        {
            times.Add(time);
        }

        public void addAverageAndProblemsizeToMap(int ProblemSize)
        {
            long sum = 0;
            foreach (long l in times)
            {
                sum += l;
            }

            problemSizeAndAverageMap[ProblemSize] = sum/times.Count;
        }

        public Dictionary<int, long> getProblemSizeMap()
        {
            return problemSizeAndAverageMap;
        }

    }
}
