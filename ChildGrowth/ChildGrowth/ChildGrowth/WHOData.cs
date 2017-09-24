using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth
{
    class WHOData
    {
        public List<double> ageList = new List<double>(new double[] {0.0, 0.5, 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5, 8.5, 9.5, 10.5, 11.5, 12.5, 13.5, 14.5, 15.5, 16.5, 17.5, 18.5, 19.5, 20.5, 21.5, 22.5, 23.5, 24.5, 25.5, 26.5, 27.5, 28.5, 29.5, 30.5, 31.5, 32.5, 33.5, 34.5, 35.5, 36.0});
        public enum Sex {Male, Female};
        public enum Percentile { P3, P5, P10, P25, P50, P75, P90, P95, P97};
        public Dictionary<Sex, Dictionary<Percentile, List<double>>> weightPercentile;

        public WHOData()
        {
            weightPercentile = WeightData.getWeightData();
        }

        class WeightData
        {
            public static List<double> P3WeightMale = new List<double>(new double[] {2.355450986, 2.7995486410000003, 3.614688072, 4.34234145, 4.992897896000001, 5.575169066, 6.096775274, 6.564430346, 6.984123338, 7.361236116000001, 7.700624405, 8.006677447000001, 8.283364855, 8.534275028, 8.762648582, 8.971407287, 9.163180317, 9.340328068, 9.504964014, 9.658974787, 9.804039109, 9.941644878, 10.07310549, 10.19957488, 10.32206165, 10.4414422, 10.55847309, 10.67380261, 10.78798156, 10.90147346, 11.01466395, 11.12786972, 11.24134752, 11.355298199999998, 11.46987977, 11.58520959, 11.70137143, 11.75978387 });

            public static List<double> P3WeightFemale = new List<double>(new double[] {2.414111983, 2.7569169839999996, 3.402293298, 3.997805608, 4.54738333, 5.054538727, 5.522500226, 5.954272494, 6.352668277, 6.720327734, 7.059731719, 7.373211901, 7.662959063, 7.93103031, 8.179355552, 8.409743555, 8.62388725, 8.82336957, 9.00966812, 9.184160166, 9.348127323, 9.502760074, 9.649162144, 9.788354721000001, 9.921280547, 10.04880788, 10.17173431, 10.29079052, 10.40664383, 10.51990171, 10.63111516, 10.74078194, 10.84934975, 10.95721927, 11.06474677, 11.17224778, 11.27999893, 11.33404488});

            public static Dictionary<Sex, Dictionary<Percentile, List<double>>> getWeightData()
            {
                Dictionary<Sex, Dictionary<Percentile, List<double>>> weightPercentile = new Dictionary<Sex, Dictionary<Percentile, List<double>>>();

                Dictionary<Percentile, List < double >> percentileDictMale = new Dictionary<Percentile, List<double>>();
                Dictionary<Percentile, List<double>> percentileDictFemale = new Dictionary<Percentile, List<double>>();

                percentileDictMale.Add(Percentile.P3,P3WeightMale);
                percentileDictFemale.Add(Percentile.P3, P3WeightFemale);

                weightPercentile.Add(Sex.Male, percentileDictMale);
                weightPercentile.Add(Sex.Female, percentileDictFemale);
                return weightPercentile;
            }
        }
    }   
}
