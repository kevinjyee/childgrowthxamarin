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
            set { this.educationInfo = value; }
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
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else if (topic.Equals(Models.Education.EducationYear01Category.Y1GENERAL))
            {
                Y1GeneralGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear01Category.Y1BREASTFEEDING))
            {
                Y1BreastfeedingGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear01Category.Y1FEEDINGNUTRITION))
            {
                Y1FeedingNutritionGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear01Category.Y1SLEEP))
            {
                Y1SleepGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear01Category.Y1TEETHING))
            {
                Y1TeethingGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear01Category.Y1BATHINGSKINCARE))
            {
                Y1BathingSkincareGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear01Category.Y1DIAPERSCLOTHING))
            {
                Y1DiapersClothingGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear01Category.Y1MILESTONES))
            {
                Y1MilestonesGenerateBookInfo();
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else if (topic.Equals(Models.Education.EducationYear12Category.Y2GENERAL))
            {
                Y2GeneralGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION))
            {
                Y2FeedingNutritionGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear12Category.Y2MILESTONES))
            {
                Y2MilestonesGenerateBookInfo();
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else if (topic.Equals(Models.Education.EducationYear23Category.Y3GENERAL))
            {
                Y3GeneralGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear23Category.Y3MILESTONES))
            {
                Y3MilestonesGenerateBookInfo();
            }
            else if (topic.Equals(Models.Education.EducationYear23Category.Y3BEHAVIOR))
            {
                Y3BehaviorGenerateBookInfo();
            }
        }
        internal void BehaviorGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Are Time-Outs Helpful or Harmful to Young Children?", URL = "https://www.zerotothree.org/resources/324-are-time-outs-helpful-or-harmful-to-young-children" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Helping Young Children Channel Their Aggression", URL = "https://www.zerotothree.org/resources/12-helping-young-children-channel-their-aggression" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Coping with Defiance: Birth to Three Years", URL = "https://www.zerotothree.org/resources/199-coping-with-defiance-birth-to-three-years" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Coping With Aggression and Teaching Self-Control", URL = "https://www.zerotothree.org/resources/233-coping-with-aggression-and-teaching-self-control" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Positive Parenting Approaches", URL = "https://www.zerotothree.org/parenting/positive-parenting-approaches" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "How to Ease Your Child's Separation Anxiety", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Soothing-Your-Childs-Separation-Anxiety.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Nightmares and Night Terrors in Preschoolers", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Nightmares-and-Night-Terrors.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Gender Identity Development in Children", URL = "https://www.healthychildren.org/English/ages-stages/gradeschool/Pages/Gender-Identity-and-Gender-Confusion-In-Children.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "How to Shape & Manage Your Young Child's Behavior", URL = "https://www.healthychildren.org/English/family-life/family-dynamics/communication-discipline/Pages/How-to-Shape-Manage-Young-Child-Behavior.aspx" }); }
        internal void LearningGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "Learning to Write and Draw", URL = "https://www.zerotothree.org/resources/305-learning-to-write-and-draw" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "How to Introduce Toddlers and Babies to Books", URL = "https://www.zerotothree.org/resources/304-how-to-introduce-toddlers-and-babies-to-books" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "Learning to Read the World: Literacy in the First 3 Years", URL = "https://www.zerotothree.org/resources/1103-learning-to-read-the-world-literacy-in-the-first-3-years" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "How to Support Your Child's Communication Skills", URL = "https://www.zerotothree.org/resources/302-how-to-support-your-child-s-communication-skills" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "It Takes Two: The Roots of Language Learning", URL = "https://www.zerotothree.org/resources/298-it-takes-two-the-roots-of-language-learning" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "Tips on Learning to Talk", URL = "https://www.zerotothree.org/resources/301-tips-on-learning-to-talk" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "Helping Your Child Learn to Read", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Helping-Your-Child-Learn-to-Read.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "How to Share Books with 2 and 3 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/How-to-Share-Books-with-2-and-3-Year-Olds.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.LEARNING.ToString(), Title = "Reinforcing Language Skills for Our Youngest Learners", URL = "https://families.naeyc.org/reinforcing-language-skills-our-youngest-learners" });
        }
        internal void SafetyGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.SAFETY.ToString(), Title = "Tips to Prevent Poisonings", URL = "https://www.cdc.gov/homeandrecreationalsafety/poisoning/preventiontips.htm" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.SAFETY.ToString(), Title = "Child Safety: Car seats", URL = "https://www.cdc.gov/vitalsigns/childpassengersafety/infographic.html#seats" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.SAFETY.ToString(), Title = "Safety for Your Child: 1 to 2 Years", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Language-Delay.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.SAFETY.ToString(), Title = "Safety for Your Child: 2 to 4 Years", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Safety-for-Your-Child-2-to-4-Years.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.SAFETY.ToString(), Title = "What to Know about Child Abuse", URL = "https://www.healthychildren.org/English/safety-prevention/at-home/Pages/What-to-Know-about-Child-Abuse.aspx" });
        }
        internal void PlayGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.PLAY.ToString(), Title = "Tips on Playing with Babies and Toddlers", URL = "https://www.zerotothree.org/resources/1081-tips-on-playing-with-babies-and-toddlers" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.PLAY.ToString(), Title = "Driven to Discover: How Thinking Skills Develop Through Everyday Play and Exploration", URL = "https://www.zerotothree.org/resources/200-driven-to-discover-how-thinking-skills-develop-through-everyday-play-and-exploration" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.PLAY.ToString(), Title = "Power of Play: Building Skills and Having Fun", URL = "https://www.zerotothree.org/resources/158-power-of-play-building-skills-and-having-fun" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.PLAY.ToString(), Title = "Young Children Learn A Lot When They Play", URL = "https://www.healthychildren.org/English/ages-stages/toddler/fitness/Pages/Young-Children-Learn-A-Lot-When-They-Play.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.PLAY.ToString(), Title = "10 Things Every Parent Should Know about Play", URL = "https://families.naeyc.org/learning-and-development/child-development/10-things-every-parent-should-know-about-play" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.PLAY.ToString(), Title = "Five Essentials to Meaningful Play", URL = "https://families.naeyc.org/five-essentials-meaningful-play" });
        }
        internal void ToiletTrainingGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.TOILET_TRAINING.ToString(), Title = "Bedwetting", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/Bedwetting.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.TOILET_TRAINING.ToString(), Title = "Creating a Toilet Training Plan", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/Creating-a-Toilet-Training-Plan.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.TOILET_TRAINING.ToString(), Title = "How to Tell When Your Child is Ready", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/How-to-Tell-When-Your-Child-is-Ready.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.TOILET_TRAINING.ToString(), Title = "Praise and Reward Your Child's Success", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/Praise-and-Reward-Your-Childs-Success.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.TOILET_TRAINING.ToString(), Title = "Toilet Training Children with Special Needs", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/Toilet-Training-Children-with-Special-Needs.aspx" });
        }
        internal void DiseasesGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Common Cold and Runny Nose", URL = "https://www.cdc.gov/getsmart/community/for-patients/common-illnesses/colds.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Down Syndrome", URL = "https://www.cdc.gov/ncbddd/birthdefects/downsyndrome.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Hearing Loss", URL = "https://www.cdc.gov/ncbddd/hearingloss/index.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Hand Foot and Mouth Disease", URL = "https://www.cdc.gov/hand-foot-mouth/index.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Pink Eye", URL = "https://www.cdc.gov/conjunctivitis/" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Intellectual Disability", URL = "https://www.cdc.gov/ncbddd/actearly/pdf/parents_pdfs/intellectualdisability.pdf" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Cancer", URL = "https://www.cdc.gov/cancer/" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Sinus Infection", URL = "https://www.cdc.gov/getsmart/community/for-patients/common-illnesses/sinus-infection.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Vision Loss", URL = "https://www.cdc.gov/ncbddd/actearly/pdf/parents_pdfs/visionlossfactsheet.pdf" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Sore Throat", URL = "https://www.cdc.gov/getsmart/community/for-patients/common-illnesses/sore-throat.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Autism Screening", URL = "https://www.cdc.gov/ncbddd/autism/screening.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Autism Facts", URL = "https://www.cdc.gov/ncbddd/autism/facts.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DISEASES.ToString(), Title = "Diabetes", URL = "https://www.cdc.gov/diabetes/basics/prediabetes.html" });
        }
        internal void DoctorVisitsGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.DOCTOR_VISITS.ToString(), Title = "How to Talk to Your Doctor", URL = "https://www.cdc.gov/ncbddd/actearly/pdf/help_pdfs/CDC_TalkToDoctor.pdf" });
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void Y1GeneralGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1GENERAL.ToString(), Title = "Positive Parenting Tips", URL = "https://www.cdc.gov/ncbddd/childdevelopment/positiveparenting/infants.html" });
        }
        internal void Y1BreastfeedingGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BREASTFEEDING.ToString(), Title = "How to Keep Your Breast Pump Kit Clean: The Essentials", URL = "https://www.cdc.gov/healthywater/hygiene/healthychildcare/infantfeeding/breastpump.html" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BREASTFEEDING.ToString(), Title = "Proper Handling and Storage of Human Milk", URL = "https://www.cdc.gov/breastfeeding/recommendations/handling_breastmilk.htm" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BREASTFEEDING.ToString(), Title = "Birth Control and Breastfeeding", URL = "https://www.healthychildren.org/English/ages-stages/baby/breastfeeding/Pages/Birth-Control-and-Breastfeeding.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BREASTFEEDING.ToString(), Title = "A Breastfeeding Checklist: Are You Nursing Correctly?", URL = "https://www.healthychildren.org/English/ages-stages/baby/breastfeeding/Pages/A-Breastfeeding-Checklist-Are-You-Nursing-Correctly.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BREASTFEEDING.ToString(), Title = "Breastfeeding Benefits Your Baby's Immune System", URL = "https://www.healthychildren.org/English/ages-stages/baby/breastfeeding/Pages/Breastfeeding-Benefits-Your-Babys-Immune-System.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BREASTFEEDING.ToString(), Title = "Breastfeeding Positions", URL = "https://www.healthychildren.org/English/ages-stages/baby/breastfeeding/Pages/Breastfeeding-Positions.aspx" });
        }
        internal void Y1FeedingNutritionGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1FEEDINGNUTRITION.ToString(), Title = "Starting Solid Foods", URL = "https://www.healthychildren.org/English/ages-stages/baby/feeding-nutrition/Pages/Switching-To-Solid-Foods.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1FEEDINGNUTRITION.ToString(), Title = "Bottle Feeding Basics", URL = "https://www.healthychildren.org/English/ages-stages/baby/feeding-nutrition/Pages/Bottle-Feeding-How-Its-Done.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1FEEDINGNUTRITION.ToString(), Title = "Burping, Hiccups, and Spitting Up", URL = "https://www.healthychildren.org/English/ages-stages/baby/feeding-nutrition/Pages/Burping-Hiccups-and-Spitting-Up.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1FEEDINGNUTRITION.ToString(), Title = "Choosing a Formula", URL = "https://www.healthychildren.org/English/ages-stages/baby/feeding-nutrition/Pages/Choosing-a-Formula.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1FEEDINGNUTRITION.ToString(), Title = "Food Allergy Reactions", URL = "https://www.healthychildren.org/English/ages-stages/baby/feeding-nutrition/Pages/Food-Allergy-Reactions.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1FEEDINGNUTRITION.ToString(), Title = "How Often and How Much Should Your Baby Eat?", URL = "https://www.healthychildren.org/English/ages-stages/baby/feeding-nutrition/Pages/How-Often-and-How-Much-Should-Your-Baby-Eat.aspx" });
        }
        internal void Y1SleepGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1SLEEP.ToString(), Title = "Back to Sleep, Tummy to Play", URL = "https://www.healthychildren.org/English/ages-stages/baby/sleep/Pages/Back-to-Sleep-Tummy-to-Play.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1SLEEP.ToString(), Title = "Stages of Newborn Sleep", URL = "https://www.healthychildren.org/english/ages-stages/baby/sleep/pages/phases-of-sleep.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1SLEEP.ToString(), Title = "Getting Your Baby to Sleep", URL = "https://www.healthychildren.org/English/ages-stages/baby/sleep/Pages/Getting-Your-Baby-to-Sleep.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1SLEEP.ToString(), Title = "How to Keep Your Sleeping Baby Safe: AAP Policy Explained", URL = "https://www.healthychildren.org/English/ages-stages/baby/sleep/Pages/A-Parents-Guide-to-Safe-Sleep.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1SLEEP.ToString(), Title = "New Crib Standards: What Parents Need to Know", URL = "https://www.healthychildren.org/English/ages-stages/baby/sleep/Pages/New-Crib-Standards-What-Parents-Need-to-Know.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1SLEEP.ToString(), Title = "Reduce the Risk of SIDS & Suffocation", URL = "https://www.healthychildren.org/English/ages-stages/baby/sleep/Pages/Preventing-SIDS.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1SLEEP.ToString(), Title = "Sleep Apnea Detection", URL = "https://www.healthychildren.org/English/ages-stages/baby/sleep/Pages/Sleep-Apnea-Detection.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1SLEEP.ToString(), Title = "Sleeping Through the Night", URL = "https://www.healthychildren.org/English/ages-stages/baby/sleep/Pages/Sleeping-Through-the-Night.aspx" });
        }
        internal void Y1TeethingGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1TEETHING.ToString(), Title = "Drooling and Your Baby", URL = "https://www.healthychildren.org/English/ages-stages/baby/teething-tooth-care/Pages/Drooling-and-Your-Baby.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1TEETHING.ToString(), Title = "How to Help Teething Symptoms without Medications", URL = "https://www.healthychildren.org/English/ages-stages/baby/teething-tooth-care/Pages/How-to-Help-Teething-Symptoms-without-Medications.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1TEETHING.ToString(), Title = "How to Prevent Tooth Decay in Your Baby", URL = "https://www.healthychildren.org/English/ages-stages/baby/teething-tooth-care/Pages/How-to-Prevent-Tooth-Decay-in-Your-Baby.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1TEETHING.ToString(), Title = "Teething Pain", URL = "https://www.healthychildren.org/English/ages-stages/baby/teething-tooth-care/Pages/Teething-Pain.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1TEETHING.ToString(), Title = "Baby's First Tooth: 7 Facts Parents Should Know", URL = "https://www.healthychildren.org/English/ages-stages/baby/teething-tooth-care/Pages/Babys-First-Tooth-Facts-Parents-Should-Know.aspx" });
        }
        internal void Y1BathingSkincareGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BATHINGSKINCARE.ToString(), Title = "Bathing Your Newborn", URL = "https://www.healthychildren.org/English/ages-stages/baby/bathing-skin-care/Pages/Bathing-Your-Newborn.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BATHINGSKINCARE.ToString(), Title = "Heat Rash", URL = "https://www.healthychildren.org/English/ages-stages/baby/bathing-skin-care/Pages/Heat-Rash.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BATHINGSKINCARE.ToString(), Title = "How to Care for Your Baby's Penis", URL = "https://www.healthychildren.org/English/ages-stages/baby/bathing-skin-care/Pages/Caring-For-Your-Sons-Penis.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BATHINGSKINCARE.ToString(), Title = "Nail Care: Fingers and Toes", URL = "https://www.healthychildren.org/English/ages-stages/baby/bathing-skin-care/Pages/Nail-Care-Fingers-and-Toes.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BATHINGSKINCARE.ToString(), Title = "Baby Sunburn Prevention", URL = "https://www.healthychildren.org/English/ages-stages/baby/bathing-skin-care/Pages/Baby-Sunburn-Prevention.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1BATHINGSKINCARE.ToString(), Title = "To Bathe or Not to Bathe", URL = "https://www.healthychildren.org/English/ages-stages/baby/bathing-skin-care/Pages/To-Bathe-or-Not-to-Bathe.aspx" });
        }
        internal void Y1DiapersClothingGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1DIAPERSCLOTHING.ToString(), Title = "Buying Diapers", URL = "https://www.healthychildren.org/English/ages-stages/baby/diapers-clothing/Pages/Buying-Diapers.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1DIAPERSCLOTHING.ToString(), Title = "Changing Diapers", URL = "https://www.healthychildren.org/English/ages-stages/baby/diapers-clothing/Pages/Changing-Diapers.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1DIAPERSCLOTHING.ToString(), Title = "Diaper Rash", URL = "https://www.healthychildren.org/English/ages-stages/baby/diapers-clothing/Pages/Diaper-Rash.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1DIAPERSCLOTHING.ToString(), Title = "Diarrhea in Babies", URL = "https://www.healthychildren.org/English/ages-stages/baby/diapers-clothing/Pages/Diarrhea-in-Babies.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1DIAPERSCLOTHING.ToString(), Title = "Tips for Dressing Your Baby", URL = "https://www.healthychildren.org/English/ages-stages/baby/diapers-clothing/Pages/Dressing-Your-Newborn.aspx" });
        }
        internal void Y1MilestonesGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1MILESTONES.ToString(), Title = "Emotional Development: 1 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Emotional-Development-1-Year-Olds.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1MILESTONES.ToString(), Title = "Cognitive Development: One-Year-Old", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Cognitive-Development-One-Year-Old.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1MILESTONES.ToString(), Title = "Hand and Finger Skills: 1 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Hand-and-Finger-Skills-1-Year-Olds.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1MILESTONES.ToString(), Title = "Social Development: 1 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Social-Development-1-Year-Olds.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1MILESTONES.ToString(), Title = "Physical Appearance and Growth: Your 1 Year Old", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Physical-Appearance-and-Growth-Your-1-Year-Old.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1MILESTONES.ToString(), Title = "Language Development: 1 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Language-Development-1-Year-Olds.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationyYear01Category.Y1MILESTONES.ToString(), Title = "How to Raise Concerns about a Child’s Speech and Language Development: Do's and Don'ts", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/How-to-Raise-Concerns-about-Childs-Speech-Language-Development.aspx" });
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void Y2GeneralGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2GENERAL.ToString(), Title = "Positive Parenting Tips", URL = "https://www.cdc.gov/ncbddd/childdevelopment/positiveparenting/toddlers.html" });
        }
        internal void Y2FeedingNutritionGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION.ToString(), Title = "Feeding & Nutrition Tips: Your 1-Year-Old", URL = "https://www.healthychildren.org/English/ages-stages/toddler/nutrition/Pages/Feeding-and-Nutrition-Your-One-Year-Old.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION.ToString(), Title = "Feeding & Nutrition Tips: Your 2-Year-Old", URL = "https://www.healthychildren.org/English/ages-stages/toddler/nutrition/Pages/Feeding-and-Nutrition-Your-Two-Year-Old.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION.ToString(), Title = "Sample Menu for a Two-Year-Old", URL = "https://www.healthychildren.org/English/ages-stages/toddler/nutrition/Pages/Sample-One-Day-Menu-for-a-Two-Year-Old.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION.ToString(), Title = "Preschoolers’ Diets Shouldn’t Be Fat-Free: Here’s Why", URL = "https://www.healthychildren.org/English/ages-stages/preschool/nutrition-fitness/Pages/Reducing-Dietary-Fat-for-Preschoolers.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION.ToString(), Title = "Picky Eaters", URL = "https://www.healthychildren.org/English/ages-stages/toddler/nutrition/Pages/Picky-Eaters.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION.ToString(), Title = "Selecting Snacks for Toddlers", URL = "https://www.healthychildren.org/English/ages-stages/toddler/nutrition/Pages/Selecting-Snacks-for-Toddlers.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION.ToString(), Title = "Winning the Food Fights", URL = "https://www.healthychildren.org/English/ages-stages/toddler/nutrition/Pages/Winning-the-Food-Fights.aspx" });
        }
        internal void Y2MilestonesGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2MILESTONES.ToString(), Title = "Cognitive Development: Two-Year-Old", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Cognitive-Development-Two-Year-Old.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2MILESTONES.ToString(), Title = "Emotional Development: 2 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Emotional-Development-2-Year-Olds.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2MILESTONES.ToString(), Title = "Hand and Finger Skills: 2 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Hand-and-Finger-Skills-2-Year-Olds.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2MILESTONES.ToString(), Title = "Social Development: 2 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Social-Development-2-Year-Olds.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2MILESTONES.ToString(), Title = "Physical Appearance and Growth: Your 2 Year Old", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Physical-Appearance-and-Growth-Your-2-Year-Od.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear12Category.Y2MILESTONES.ToString(), Title = "Language Development: 2 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Language-Development-2-Year-Olds.aspx" });
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void Y3GeneralGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear23Category.GENERAL.ToString(), Title = "Positive Parenting Tips", URL = "https://www.cdc.gov/ncbddd/childdevelopment/positiveparenting/toddlers2.html" });
        }
        internal void Y3MilestonesGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear23Category.MILESTONES.ToString(), Title = "Hand and Finger Skills of Your Preschooler", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Hand-and-Finger-Skills-of-Your-Preschooler.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear23Category.MILESTONES.ToString(), Title = "Movement Milestones in Preschoolers", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Movement-Milestones-in-Preschoolers.aspx" });
        }
        internal void Y3BehaviorGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear23Category.BEHAVIOR.ToString(), Title = "15 Tips to Survive the Terrible 3's", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Tips-to-Survive-the-Terrible-3s.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationYear23Category.BEHAVIOR.ToString(), Title = "Sexual Behaviors in Young Children: What’s Normal, What’s Not?", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Sexual-Behaviors-Young-Children.aspx" });
        }
    }

}
