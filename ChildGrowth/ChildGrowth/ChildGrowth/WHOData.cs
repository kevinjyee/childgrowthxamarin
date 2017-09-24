﻿using System;
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

            //see scraper.py for autoformatted data cleaner
            public static List<double> P3MaleWeight = new List<double>(new double[] { 2.355450986, 2.799548641, 3.614688072, 4.34234145, 4.992897896, 5.575169066, 6.096775274, 6.564430346, 6.984123338, 7.361236116, 7.700624405, 8.006677447, 8.283364855, 8.534275028, 8.762648582, 8.971407287, 9.163180317, 9.340328068, 9.504964014, 9.658974787, 9.804039109, 9.941644878, 10.07310549, 10.19957488, 10.32206165, 10.4414422, 10.55847309, 10.67380261, 10.78798156, 10.90147346, 11.01466395, 11.12786972, 11.24134752, 11.3552982, 11.46987977, 11.58520959, 11.70137143, 11.75978387 });
            public static List<double> P5MaleWeight = new List<double>(new double[] { 2.52690402, 2.964655655, 3.774848862, 4.503255345, 5.157411653, 5.744751566, 6.272175299, 6.745992665, 7.171952393, 7.555286752, 7.90075516, 8.212683538, 8.494999555, 8.751264252, 8.984701111, 9.198222429, 9.394453831, 9.575756968, 9.744250626, 9.901830339, 10.05018686, 10.19082308, 10.32507004, 10.45410181, 10.57894925, 10.70051298, 10.81957536, 10.93681171, 11.05280067, 11.168034, 11.28292555, 11.3978197, 11.51299966, 11.62869248, 11.74507947, 11.86229971, 11.98045644, 12.03991048 });
            public static List<double> P10MaleWeight = new List<double>(new double[] { 2.773801848, 3.209510017, 4.020561446, 4.754479354, 5.416802856, 6.01371624, 6.551379244, 7.035656404, 7.472021438, 7.865532922, 8.220839211, 8.542195484, 8.833485623, 9.098245709, 9.339687673, 9.560722369, 9.763981751, 9.951839998, 10.12643352, 10.28967982, 10.44329524, 10.58881155, 10.72759156, 10.86084353, 10.98963476, 11.11490406, 11.23747341, 11.35805876, 11.47727994, 11.59566994, 11.7136834, 11.8317045, 11.95005435, 12.06899744, 12.18874835, 12.30947723, 12.43131521, 12.49268178 });
            public static List<double> P25MaleWeight = new List<double>(new double[] { 3.150611082, 3.597395573, 4.428872952, 5.183377547, 5.866806254, 6.484969167, 7.043626918, 7.548345716, 8.004398775, 8.416718775, 8.789881892, 9.128109523, 9.43527941, 9.714941801, 9.970337596, 10.20441778, 10.41986276, 10.61910138, 10.80432929, 10.97752662, 11.14047457, 11.2947714, 11.44184727, 11.58297823, 11.7192993, 11.85181666, 11.98141892, 12.10888759, 12.23490671, 12.36007175, 12.48489772, 12.60982671, 12.73523417, 12.86143776, 12.98869905, 13.11723187, 13.24720657, 13.31277633 });
            public static List<double> P50MaleWeight = new List<double>(new double[] { 3.530203168, 4.003106424, 4.879525083, 5.672888765, 6.391391982, 7.041836432, 7.630425182, 8.162951035, 8.644832479, 9.081119817, 9.476500305, 9.835307701, 10.16153567, 10.45885399, 10.7306256, 10.97992482, 11.20955529, 11.4220677, 11.61977698, 11.80477902, 11.9789663, 12.14404334, 12.30154103, 12.45283028, 12.59913494, 12.74154396, 12.88102276, 13.01842382, 13.1544966, 13.28989667, 13.42519408, 13.56088113, 13.69737858, 13.83504622, 13.97418199, 14.1150324, 14.25779618, 14.32994444 });
            public static List<double> P75MaleWeight = new List<double>(new double[] { 3.879076559, 4.387422565, 5.327327567, 6.175598158, 6.942217106, 7.635323002, 8.262032991, 8.828786159, 9.34149038, 9.805593364, 10.22612395, 10.60772151, 10.9546603, 11.27087147, 11.55996332, 11.82524099, 12.06972515, 12.29616991, 12.50708008, 12.70472779, 12.89116805, 13.06825426, 13.23765258, 13.40085582, 13.55919667, 13.71386029, 13.86589625, 14.0162298, 14.1656725, 14.31493214, 14.46462206, 14.61526973, 14.76732387, 14.9211657, 15.07710916, 15.23541179, 15.3962791, 15.47772447 });
            public static List<double> P90MaleWeight = new List<double>(new double[] { 4.17249339, 4.718161283, 5.728152752, 6.638979132, 7.460702368, 8.202193202, 8.871384112, 9.47546616, 10.02101374, 10.51406421, 10.96017225, 11.36445045, 11.73160184, 12.06594792, 12.37145331, 12.65174864, 12.91015164, 13.14968707, 13.37310558, 13.58290165, 13.78133058, 13.9704249, 14.15200982, 14.3277181, 14.49900418, 14.6671577, 14.83331632, 14.99847794, 15.16351231, 15.32917196, 15.49610261, 15.66485286, 15.83588308, 16.00957526, 16.18623873, 16.36611917, 16.54940494, 16.6423691 });
            public static List<double> P95MaleWeight = new List<double>(new double[] { 4.34029274, 4.910130108, 5.967101615, 6.921119162, 7.781401145, 8.556813353, 9.255614546, 9.885435743, 10.45331433, 10.96573632, 11.42867623, 11.84763282, 12.2276612, 12.57340193, 12.88910809, 13.17867019, 13.44563963, 13.6932508, 13.92444193, 14.14187481, 14.34795358, 14.54484233, 14.73448194, 14.91860604, 15.09875606, 15.27629562, 15.45242405, 15.62818936, 15.80450043, 15.98213866, 16.16176896, 16.34395024, 16.52914562, 16.71773017, 16.91000241, 17.10619066, 17.30646132, 17.40816491 });
            public static List<double> P97MaleWeight = new List<double>(new double[] { 4.446488308, 5.032624982, 6.121929103, 7.106250132, 7.993878049, 8.793443663, 9.51330656, 10.16135019, 10.74492376, 11.27083843, 11.74538465, 12.17435729, 12.56308347, 12.91645043, 13.23893338, 13.53462171, 13.80724431, 14.0601935, 14.29654774, 14.51909298, 14.73034312, 14.93255878, 15.12776542, 15.31777023, 15.50417803, 15.68840631, 15.87169941, 16.05514188, 16.23967114, 16.42608957, 16.61507584, 16.80719582, 17.00291386, 17.2025984, 17.40653835, 17.61494698, 17.8279717, 17.93624653 });

            public static List<double> P3FemaleWeight = new List<double>(new double[] { 2.414111983, 2.756916984, 3.402293298, 3.997805608, 4.54738333, 5.054538727, 5.522500226, 5.954272494, 6.352668277, 6.720327734, 7.059731719, 7.373211901, 7.662959063, 7.93103031, 8.179355552, 8.409743555, 8.62388725, 8.82336957, 9.00966812, 9.184160166, 9.348127323, 9.502760074, 9.649162144, 9.788354721, 9.921280547, 10.04880788, 10.17173431, 10.29079052, 10.40664383, 10.51990171, 10.63111516, 10.74078194, 10.84934975, 10.95721927, 11.06474677, 11.17224778, 11.27999893, 11.33404488 });
            public static List<double> P5FemaleWeight = new List<double>(new double[] { 2.54790518, 2.894442278, 3.547610305, 4.150638506, 4.70712251, 5.220487543, 5.693974176, 6.130641295, 6.533372908, 6.904885578, 7.247735767, 7.564326904, 7.856916169, 8.127621012, 8.378425424, 8.611186014, 8.827637666, 9.029399482, 9.217979979, 9.394782429, 9.561109949, 9.718170424, 9.867081272, 10.00887405, 10.14449891, 10.27482891, 10.40066414, 10.52273581, 10.64171007, 10.7581918, 10.8727282, 10.98581228, 11.09788625, 11.2093447, 11.32053756, 11.43177357, 11.54332263, 11.59928903 });
            public static List<double> P10FemaleWeight = new List<double>(new double[] { 2.747222257, 3.101767067, 3.770157472, 4.387041982, 4.95592631, 5.480295205, 5.963510428, 6.408775097, 6.819122283, 7.197413532, 7.546341788, 7.868436369, 8.166068895, 8.441459662, 8.696684147, 8.933679535, 9.154251142, 9.360078736, 9.55272268, 9.733629905, 9.904139709, 10.06548937, 10.21881956, 10.3651796, 10.50553251, 10.64075987, 10.77166654, 10.89898515, 11.02338047, 11.14545358, 11.26574591, 11.38474303, 11.50287842, 11.62053697, 11.73805834, 11.85574032, 11.9738418, 12.03312087 });
            public static List<double> P25FemaleWeight = new List<double>(new double[] { 3.06486465, 3.437628263, 4.13899376, 4.784820426, 5.379141034, 5.92588831, 6.428828208, 6.891533095, 7.317373091, 7.709516114, 8.070932165, 8.404399764, 8.712513432, 8.997691667, 9.262185089, 9.508084539, 9.737329319, 9.951714686, 10.15289979, 10.34241498, 10.52166904, 10.69195601, 10.85446195, 11.01027128, 11.16037297, 11.30566645, 11.44696728, 11.58501256, 11.72046615, 11.8539236, 11.98591692, 12.11691911, 12.24734843, 12.37757256, 12.50791269, 12.63864672, 12.77001339, 12.83599859 });
            public static List<double> P50FemaleWeight = new List<double>(new double[] { 3.39918645, 3.79752846, 4.544776513, 5.230584214, 5.859960798, 6.437587751, 6.967850457, 7.454854109, 7.902436186, 8.314178377, 8.693418423, 9.043261854, 9.366593571, 9.666089185, 9.944226063, 10.20329397, 10.4454058, 10.67250698, 10.88638558, 11.08868151, 11.28089537, 11.46439708, 11.64043402, 11.81013895, 11.97453748, 12.13455528, 12.2910249, 12.44469237, 12.59622335, 12.74620911, 12.89517218, 13.04357164, 13.19180827, 13.34022934, 13.48913357, 13.63877446, 13.78936547, 13.86507382 });
            public static List<double> P75FemaleWeight = new List<double>(new double[] { 3.717519384, 4.145593668, 4.946765504, 5.680083196, 6.351511983, 6.966523789, 7.53018045, 8.047178246, 8.52187726, 8.958324062, 9.360270982, 9.7311934, 10.07430572, 10.39257636, 10.68874201, 10.96532105, 11.2246268, 11.46877937, 11.69971783, 11.91921144, 12.1288704, 12.3301562, 12.52439148, 12.71276942, 12.89636272, 13.07613212, 13.25293459, 13.42753102, 13.60059358, 13.77271274, 13.94440383, 14.11611337, 14.28822496, 14.46106492, 14.634908, 14.80998135, 14.98647034, 15.07529315 });
            public static List<double> P90FemaleWeight = new List<double>(new double[] { 3.992572231, 4.450125603, 5.305632496, 6.08764077, 6.802769825, 7.45711879, 8.056331004, 8.605635546, 9.109878097, 9.573546299, 10.00079194, 10.3954511, 10.76106284, 11.10088678, 11.4179197, 11.7149113, 11.99437938, 12.258624, 12.50974133, 12.74963667, 12.98003694, 13.20250263, 13.41843913, 13.62910755, 13.8356351, 14.03902484, 14.24016506, 14.43983817, 14.63872906, 14.83743314, 15.03646393, 15.23626013, 15.43719248, 15.63957012, 15.84364677, 16.04962601, 16.25766706, 16.36249956 });
            public static List<double> P95FemaleWeight = new List<double>(new double[] { 4.152636594, 4.628836382, 5.51916925, 6.332837055, 7.076722522, 7.757233948, 8.380329759, 8.951543685, 9.476008728, 9.958479736, 10.40335475, 10.81469528, 11.19624565, 11.5514514, 11.88347697, 12.19522253, 12.48934, 12.76824867, 13.03414978, 13.28904061, 13.53472797, 13.77284102, 14.00484351, 14.23204547, 14.45561433, 14.67658549, 14.89587242, 15.11427618, 15.33249457, 15.55113065, 15.770701, 15.99164336, 16.21432393, 16.43904429, 16.66604772, 16.89552564, 17.12762297, 17.24468787 });
            public static List<double> P97FemaleWeight = new List<double>(new double[] { 4.254922004, 4.743581789, 5.657379108, 6.492574414, 7.256165568, 7.954730061, 8.59441348, 9.180938407, 9.719620693, 10.2153883, 10.67280092, 11.0960696, 11.48907597, 11.85539095, 12.19829279, 12.52078451, 12.82561033, 13.11527219, 13.39204468, 13.65798985, 13.91497124, 14.1646673, 14.40858419, 14.64806798, 14.88431632, 15.11838945, 15.35122083, 15.5836271, 15.8163176, 16.0499034, 16.28490586, 16.52176469, 16.7608456, 17.00244749, 17.24680884, 17.49411514, 17.74450372, 17.87088515 });


            public static Dictionary<Sex, Dictionary<Percentile, List<double>>> getWeightData()
            {
                Dictionary<Sex, Dictionary<Percentile, List<double>>> weightPercentile = new Dictionary<Sex, Dictionary<Percentile, List<double>>>();

                Dictionary<Percentile, List < double >> percentileDictMale = new Dictionary<Percentile, List<double>>();
                Dictionary<Percentile, List<double>> percentileDictFemale = new Dictionary<Percentile, List<double>>();

                percentileDictMale.Add(Percentile.P3,P3MaleWeight);
                percentileDictFemale.Add(Percentile.P3, P3FemaleWeight);

                weightPercentile.Add(Sex.Male, percentileDictMale);
                weightPercentile.Add(Sex.Female, percentileDictFemale);
                return weightPercentile;
            }
        }
    }   
}
