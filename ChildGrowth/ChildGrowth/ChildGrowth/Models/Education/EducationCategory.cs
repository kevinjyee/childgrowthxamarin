using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Education
{
    public enum EducationCategory
    {
        BEHAVIOR,
        LEARNING,
        SAFETY,
        PLAY,
        TOILET_TRAINING,
        DISEASES,
        DOCTOR_VISITS,
        YEAR01,
        YEAR12,
        YEAR23
    }

    public enum EducationYear01Category
    {
        Y1GENERAL,
        Y1BREASTFEEDING,
        Y1FEEDINGNUTRITION,
        Y1SLEEP,
        Y1TEETHING,
        Y1BATHINGSKINCARE,
        Y1DIAPERSCLOTHING,
        Y1MILESTONES
    }
    public enum EducationYear12Category
    {
        Y2GENERAL,
        Y2FEEDINGNUTRITION,
        Y2MILESTONES
    }
    public enum EducationYear23Category
    {
        Y3GENERAL,
        Y3MILESTONES,
        Y3BEHAVIOR
    }
}
