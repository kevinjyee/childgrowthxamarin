using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildGrowth.Models.Education;

namespace ChildGrowth.Pages.Education
{
    public class EducationInfoRepository
    {
        private ObservableCollection<Models.Education.Article> educationInfo;

        public ObservableCollection<Models.Education.Article> EducationInfo
        {
            get { return educationInfo; }
            set { this.educationInfo= value; }
        }

        public EducationInfoRepository(string topic)
        {
            // if settings = english:
            // else, settings = spanish:
            if (topic.Equals(Models.Education.EducationCategory.BEHAVIOR))
            {
                BehaviorGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.LEARNING))
            {
                LearningGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.SAFETY))
            {
                SafetyGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.PLAY))
            {
                PlayGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.TOILET_TRAINING))
            {
                ToiletTrainingGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.DISEASES))
            {
                DiseasesGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.DOCTOR_VISITS))
            {
                DoctorVisitsGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.YEAR01))
            {
                Year01GenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.YEAR12))
            {
                Year12GenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationCategory.YEAR23))
            {
                Year23GenerateBookInfo();
            }
        }
        internal void BehaviorGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void LearningGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void SafetyGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.SAFETY.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void PlayGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.PLAY.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void ToiletTrainingGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.TOILET_TRAINING.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void DiseasesGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void DoctorVisitsGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DOCTOR_VISITS.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void Year01GenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.YEAR01.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void Year12GenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.YEAR12.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }
        internal void Year23GenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.YEAR23.ToString(), Title = "social and emotional", URL = "begins to smile at people" });
        }

    }
}
