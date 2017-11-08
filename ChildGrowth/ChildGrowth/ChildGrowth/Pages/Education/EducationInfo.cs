using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Education
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EducationInfo : ContentPage
    {
        public static List<Article> EduArticles = new List<Article>();

        Label CategoryTitle = new Label();


        ListView educationList = new ListView
        {
            RowHeight = 60
        };
        public EducationInfo(String type)
        {
            var layout = new StackLayout();

            EducationRepository(type);
            CategoryTitle.Text = type;
            educationList.ItemsSource = EduArticles;
            educationList.ItemTemplate = new DataTemplate(typeof(EducationCell));
            educationList.BackgroundColor = Color.Transparent;
            educationList.SeparatorColor = Color.Aqua;

            educationList.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };


            educationList.ItemTapped += (Sender, Event) =>
                    {

                        var A = (Article)Event.Item;

                        Device.OpenUri(new Uri(A.URL));

                    };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 10, 0, 10),
                Children = {
                          CategoryTitle,
                          educationList
                        }
            };

        }
        void EducationRepository(String type)
        {

            EduArticles.Add(new Article { Category = "Behavior", Title = "Are Time-Outs Helpful or Harmful to Young Children?", URL = "https://www.zerotothree.org/resources/324-are-time-outs-helpful-or-harmful-to-young-children" });
            EduArticles.Add(new Article { Category = "Behavior", Title = "Helping Young Children Channel Their Aggression", URL = "https://www.zerotothree.org/resources/12-helping-young-children-channel-their-aggression" });
            EduArticles.Add(new Article { Category = "Behavior", Title = "Coping with Defiance: Birth to Three Years", URL = "https://www.zerotothree.org/resources/199-coping-with-defiance-birth-to-three-years" });
            EduArticles.Add(new Article { Category = "Behavior", Title = "Coping With Aggression and Teaching Self-Control", URL = "https://www.zerotothree.org/resources/233-coping-with-aggression-and-teaching-self-control" });
            EduArticles.Add(new Article { Category = "Behavior", Title = "Positive Parenting Approaches", URL = "https://www.zerotothree.org/parenting/positive-parenting-approaches" });
            EduArticles.Add(new Article { Category = "Behavior", Title = "How to Ease Your Child's Separation Anxiety", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Soothing-Your-Childs-Separation-Anxiety.aspx" });
            EduArticles.Add(new Article { Category = "Behavior", Title = "Nightmares and Night Terrors in Preschoolers", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Nightmares-and-Night-Terrors.aspx" });
            EduArticles.Add(new Article { Category = "Behavior", Title = "Gender Identity Development in Children", URL = "https://www.healthychildren.org/English/ages-stages/gradeschool/Pages/Gender-Identity-and-Gender-Confusion-In-Children.aspx" });
            EduArticles.Add(new Article { Category = "Behavior", Title = "How to Shape & Manage Your Young Child's Behavior", URL = "https://www.healthychildren.org/English/family-life/family-dynamics/communication-discipline/Pages/How-to-Shape-Manage-Young-Child-Behavior.aspx" });
            EduArticles.Add(new Article { Category = "Learning", Title = "Learning to Write and Draw", URL = "https://www.zerotothree.org/resources/305-learning-to-write-and-draw" });
            EduArticles.Add(new Article { Category = "Learning", Title = "How to Introduce Toddlers and Babies to Books", URL = "https://www.zerotothree.org/resources/304-how-to-introduce-toddlers-and-babies-to-books" });
            EduArticles.Add(new Article { Category = "Learning", Title = "Learning to Read the World: Literacy in the First 3 Years", URL = "https://www.zerotothree.org/resources/1103-learning-to-read-the-world-literacy-in-the-first-3-years" });
            EduArticles.Add(new Article { Category = "Learning", Title = "How to Support Your Child's Communication Skills", URL = "https://www.zerotothree.org/resources/302-how-to-support-your-child-s-communication-skills" });
            EduArticles.Add(new Article { Category = "Learning", Title = "It Takes Two: The Roots of Language Learning", URL = "https://www.zerotothree.org/resources/298-it-takes-two-the-roots-of-language-learning" });
            EduArticles.Add(new Article { Category = "Learning", Title = "Tips on Learning to Talk", URL = "https://www.zerotothree.org/resources/301-tips-on-learning-to-talk" });
            EduArticles.Add(new Article { Category = "Learning", Title = "Helping Your Child Learn to Read", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Helping-Your-Child-Learn-to-Read.aspx" });
            EduArticles.Add(new Article { Category = "Learning", Title = "How to Share Books with 2 and 3 Year Olds", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/How-to-Share-Books-with-2-and-3-Year-Olds.aspx" });
            EduArticles.Add(new Article { Category = "Learning", Title = "Reinforcing Language Skills for Our Youngest Learners", URL = "https://families.naeyc.org/reinforcing-language-skills-our-youngest-learners" });

            EduArticles.Add(new Article { Category = "Safety", Title = "Tips to Prevent Poisonings", URL = "https://www.cdc.gov/homeandrecreationalsafety/poisoning/preventiontips.htm" });
            EduArticles.Add(new Article { Category = "Safety", Title = "Child Safety: Car seats", URL = "https://www.cdc.gov/vitalsigns/childpassengersafety/infographic.html#seats" });
            EduArticles.Add(new Article { Category = "Safety", Title = "Safety for Your Child: 1 to 2 Years", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Language-Delay.aspx" });
            EduArticles.Add(new Article { Category = "Safety", Title = "Safety for Your Child: 2 to 4 Years", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Safety-for-Your-Child-2-to-4-Years.aspx" });
            EduArticles.Add(new Article { Category = "Safety", Title = "What to Know about Child Abuse", URL = "https://www.healthychildren.org/English/safety-prevention/at-home/Pages/What-to-Know-about-Child-Abuse.aspx" });

            EduArticles.Add(new Article { Category = "Play", Title = "Tips on Playing with Babies and Toddlers", URL = "https://www.zerotothree.org/resources/1081-tips-on-playing-with-babies-and-toddlers" });
            EduArticles.Add(new Article { Category = "Play", Title = "Driven to Discover: How Thinking Skills Develop Through Everyday Play and Exploration", URL = "https://www.zerotothree.org/resources/200-driven-to-discover-how-thinking-skills-develop-through-everyday-play-and-exploration" });
            EduArticles.Add(new Article { Category = "Play", Title = "Power of Play: Building Skills and Having Fun", URL = "https://www.zerotothree.org/resources/158-power-of-play-building-skills-and-having-fun" });
            EduArticles.Add(new Article { Category = "Play", Title = "Young Children Learn A Lot When They Play", URL = "https://www.healthychildren.org/English/ages-stages/toddler/fitness/Pages/Young-Children-Learn-A-Lot-When-They-Play.aspx" });
            EduArticles.Add(new Article { Category = "Play", Title = "10 Things Every Parent Should Know about Play", URL = "https://families.naeyc.org/learning-and-development/child-development/10-things-every-parent-should-know-about-play" });
            EduArticles.Add(new Article { Category = "Play", Title = "Five Essentials to Meaningful Play", URL = "https://families.naeyc.org/five-essentials-meaningful-play" });
            EduArticles.Add(new Article { Category = "Toilet", Title = "Bedwetting", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/Bedwetting.aspx" });
            EduArticles.Add(new Article { Category = "Toilet", Title = "Creating a Toilet Training Plan", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/Creating-a-Toilet-Training-Plan.aspx" });
            EduArticles.Add(new Article { Category = "Toilet", Title = "How to Tell When Your Child is Ready", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/How-to-Tell-When-Your-Child-is-Ready.aspx" });
            EduArticles.Add(new Article { Category = "Toilet", Title = "Praise and Reward Your Child's Success", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/Praise-and-Reward-Your-Childs-Success.aspx" });
            EduArticles.Add(new Article { Category = "Toilet", Title = "Toilet Training Children with Special Needs", URL = "https://www.healthychildren.org/English/ages-stages/toddler/toilet-training/Pages/Toilet-Training-Children-with-Special-Needs.aspx" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Common Cold and Runny Nose", URL = "https://www.cdc.gov/getsmart/community/for-patients/common-illnesses/colds.html" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Down Syndrome", URL = "https://www.cdc.gov/ncbddd/birthdefects/downsyndrome.html" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Hearing Loss", URL = "https://www.cdc.gov/ncbddd/hearingloss/index.html" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Hand Foot and Mouth Disease", URL = "https://www.cdc.gov/hand-foot-mouth/index.html" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Pink Eye", URL = "https://www.cdc.gov/conjunctivitis/" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Intellectual Disability", URL = "https://www.cdc.gov/ncbddd/actearly/pdf/parents_pdfs/intellectualdisability.pdf" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Cancer", URL = "https://www.cdc.gov/cancer/" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Sinus Infection", URL = "https://www.cdc.gov/getsmart/community/for-patients/common-illnesses/sinus-infection.html" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Vision Loss", URL = "https://www.cdc.gov/ncbddd/actearly/pdf/parents_pdfs/visionlossfactsheet.pdf" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Sore Throat", URL = "https://www.cdc.gov/getsmart/community/for-patients/common-illnesses/sore-throat.html" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Autism Screening", URL = "https://www.cdc.gov/ncbddd/autism/screening.html" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Autism Facts", URL = "https://www.cdc.gov/ncbddd/autism/facts.html" });
            EduArticles.Add(new Article { Category = "Diseases", Title = "Diabetes", URL = "https://www.cdc.gov/diabetes/basics/prediabetes.html" });
            EduArticles.Add(new Article { Category = "Doctor", Title = "How to Talk to Your Doctor", URL = "https://www.cdc.gov/ncbddd/actearly/pdf/help_pdfs/CDC_TalkToDoctor.pdf" });

            EduArticles.RemoveAll(p => p.Category != type);
        }
    }

}

