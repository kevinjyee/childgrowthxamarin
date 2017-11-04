using ChildGrowth.Models.MediaUtil;
using ChildGrowth.Models.Milestones;
using ChildGrowth.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChildGrowth.Models.Milestones.Milestone;

namespace ChildGrowth.Pages.Milestones
{
    public class MilestonesInfoRepository
    {
        private ObservableCollection<MilestonesInfo> milestonesInfo;

        public ObservableCollection<MilestonesInfo> MilestonesInfo
        {
            get { return milestonesInfo; }
            set { this.milestonesInfo = value; }
        }

        public MilestonesInfoRepository()
        {
            GenerateBookInfo();
        }

        internal void GenerateBookInfo()
        {
            milestonesInfo = new ObservableCollection<MilestonesInfo>();
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Social and Emotional", CategoryDescription = "Begins to smile at people" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Social and Emotional", CategoryDescription = "Can briefly calm herself (may bring hands to mouth and suck on hand)" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Social and Emotional", CategoryDescription = "Tries to look at parent" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Language and Communication", CategoryDescription = "Coos, makes gurgling sounds" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Language and Communication", CategoryDescription = "Turns head toward sounds" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Cognitive", CategoryDescription = "Pays attention to faces" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Cognitive", CategoryDescription = "Begins to follow things with eyes and recognize people at a distance" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Cognitive", CategoryDescription = "Begins to act bored (cries, fussy) if activity doesn’t change" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Movement/Physical Development", CategoryDescription = "Can hold head up and begins to push up when lying on tummy" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Movement/Physical Development", CategoryDescription = "Makes smoother movements with arms and legs" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Social and Emotional", CategoryDescription = "Smiles spontaneously, especially at people" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Social and Emotional", CategoryDescription = "Likes to play with people and might cry when playing stops" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Social and Emotional", CategoryDescription = "Copies some movements and facial expressions, like smiling or frowning" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Language and Communication", CategoryDescription = "Begins to babble" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Language and Communication", CategoryDescription = "Babbles with expression and copies sounds he hears" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Language and Communication", CategoryDescription = "Cries in different ways to show hunger, pain, or being tired" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Lets you know if he is happy or sad" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Responds to affection" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Reaches for toy with one hand" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Uses hands and eyes together, such as seeing a toy and reaching for it" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Follows moving things with eyes from side to side" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Watches faces closely" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Recognizes familiar people and things at a distance" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "Holds head steady, unsupported" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "Pushes down on legs when feet are on a hard surface" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "May be able to roll over from tummy to back" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "Can hold a toy and shake it and swing at dangling toys" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "Brings hands to mouth" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "When lying on stomach, pushes up to elbows" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Social and Emotional", CategoryDescription = "Knows familiar faces and begins to know if someone is a stranger" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Social and Emotional", CategoryDescription = "Likes to play with others, especially parents" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Social and Emotional", CategoryDescription = "Responds to other people’s emotions and often seems happy" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Social and Emotional", CategoryDescription = "Likes to look at self in a mirror" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Responds to sounds by making sounds" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Strings vowels together when babbling (“ah,” “eh,” “oh”) and likes taking turns with parent while making sounds" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Responds to own name" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Makes sounds to show joy and displeasure" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Begins to say consonant sounds (jabbering with “m,” “b”)" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Cognitive", CategoryDescription = "Looks around at things nearby" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Cognitive", CategoryDescription = "Brings things to mouth" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Cognitive", CategoryDescription = "Shows curiosity about things and tries to get things that are out of reach" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Cognitive", CategoryDescription = "Begins to pass things from one hand to the other" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Movement/Physical Development", CategoryDescription = "Rolls over in both directions (front to back, back to front)" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Movement/Physical Development", CategoryDescription = "Begins to sit without support" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Movement/Physical Development", CategoryDescription = "When standing, supports weight on legs and might bounce" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Movement/Physical Development", CategoryDescription = "Rocks back and forth, sometimes crawling backward before moving forward" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Social and Emotional", CategoryDescription = "May be afraid of strangers" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Social and Emotional", CategoryDescription = "May be clingy with familiar adults" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Social and Emotional", CategoryDescription = "Has favorite toys" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Language and Communication", CategoryDescription = "Understands “no”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Language and Communication", CategoryDescription = "Makes a lot of different sounds like “mamamama” and “bababababa”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Language and Communication", CategoryDescription = "Copies sounds and gestures of others" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Language and Communication", CategoryDescription = "Uses fingers to point at things" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Watches the path of something as it falls" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Looks for things she sees you hide" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Plays peek-a-boo" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Puts things in his mouth" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Moves things smoothly from one hand to the other" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Picks up things like cereal o’s between thumb and index finger" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Stands, holding on" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Can get into sitting position" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Sits without support" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Pulls to stand" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Crawls" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Is shy or nervous with strangers" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Cries when mom or dad leaves" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Has favorite things and people" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Shows fear in some situations" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Hands you a book when he wants to hear a story" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Repeats sounds or actions to get attention" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Puts out arm or leg to help with dressing" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Plays games such as “peek-a-boo” and “pat-a-cake”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Responds to simple spoken requests" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Uses simple gestures, like shaking head “no” or waving “bye-bye”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Makes sounds with changes in tone (sounds more like speech)" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Says “mama” and “dada” and exclamations like “uh-oh!”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Tries to say words you say" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Explores things in different ways, like shaking, banging, throwing" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Finds hidden things easily" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Looks at the right picture or thing when it’s named" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Copies gestures" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Starts to use things correctly; for example, drinks from a cup, brushes hair" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Bangs two things together" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Puts things in a container, takes things out of a container" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Lets things go without help" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Pokes with index (pointer) finger" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Follows simple directions like “pick up the toy”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Movement/Physical Development", CategoryDescription = "Gets to a sitting position without help" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Movement/Physical Development", CategoryDescription = "Pulls up to stand, walks holding on to furniture (“cruising”)" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Movement/Physical Development", CategoryDescription = "May take a few steps without holding on" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Movement/Physical Development", CategoryDescription = "May stand alone" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Likes to hand things to others as play" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "May have temper tantrums" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "May be afraid of strangers" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Shows affection to familiar people" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Plays simple pretend, such as feeding a doll" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "May cling to caregivers in new situations" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Points to show others something interesting" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Explores alone but with parent close by" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Language and Communication", CategoryDescription = "Says several single words" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Language and Communication", CategoryDescription = "Says and shakes head “no”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Language and Communication", CategoryDescription = "Points to show someone what he wants" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Knows what ordinary things are for; for example, telephone, brush, spoon" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Points to get the attention of others" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Shows interest in a doll or stuffed animal by pretending to feed" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Points to one body part" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Scribbles on his own" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Can follow 1-step verbal commands without any gestures; for example, sits when you say “sit down”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Walks alone" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "May walk up steps and run" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Pulls toys while walking" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Can help undress herself" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Drinks from a cup" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Eats with a spoon" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Copies others, especially adults and older children" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Gets excited when with other children" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Shows more and more independence" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Shows defiant behavior (doing what he has been told not to)" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Plays mainly beside other children, but is beginning to include other children, such as in chase games" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Points to things or pictures when they are named" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Knows names of familiar people and body parts" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Says sentences with 2 to 4 words" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Follows simple instructions" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Repeats words overheard in conversation" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Points to things in a book" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Finds things even when hidden under two or three covers" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Begins to sort shapes and colors" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Completes sentences and rhymes in familiar books" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Plays simple make-believe games" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Builds towers of 4 or more blocks" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Might use one hand more than the other" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Follows two-step instructions such as “Pick up your shoes and put them in the closet.”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Names items in a picture book such as a cat, bird, or dog" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Stands on tiptoe" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Kicks a ball" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Begins to run" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Climbs onto and down from furniture without help" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Walks up and down stairs holding on" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Throws ball overhand" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Makes or copies straight lines and circles" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Copies adults and friends" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Shows affection for friends without prompting" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Takes turns in games" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Shows concern for crying friend" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Understands the idea of “mine” and “his” or “hers”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Shows a wide range of emotions" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Separates easily from mom and dad" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "May get upset with major changes in routine" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Dresses and undresses self" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Follows instructions with 2 or 3 steps" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Can name most familiar things" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Understands words like “in,” “on,” and “under”" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Says first name, age, and sex" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Names a friend" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Says words like “I,” “me,” “we,” and “you” and some plurals (cars, dogs, cats)" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Talks well enough for strangers to understand most of the time" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Carries on a conversation using 2 to 3 sentences" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Can work toys with buttons, levers, and moving parts" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Plays make-believe with dolls, animals, and people" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Does puzzles with 3 or 4 pieces" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Understands what “two” means" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Copies a circle with pencil or crayon" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Turns book pages one at a time" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Builds towers of more than 6 blocks" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Screws and unscrews jar lids or turns door handle" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Movement/Physical Development", CategoryDescription = "Climbs well" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Movement/Physical Development", CategoryDescription = "Runs easily" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Movement/Physical Development", CategoryDescription = "Pedals a tricycle (3-wheel bike)" });
            milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Movement/Physical Development", CategoryDescription = "Walks up and down stairs, one foot on each step" });
            Boolean test = GenerateMilestones().Result;
        }

        async Task<Boolean> GenerateMilestones()
        {
            MilestoneDatabaseAccess milestonesDatabaseAccess = new MilestoneDatabaseAccess();
            await milestonesDatabaseAccess.InitializeAsync();
            List<Milestone> milestones = new List<Milestone>();
            int milestoneID = 0;
            foreach (MilestonesInfo milestoneInfo in milestonesInfo)
            {
                MilestoneBuilder builder = new MilestoneBuilder();
                builder.WithID(milestoneID).WithCategory(milestoneInfo.CategoryName).WithMilestoneDueDate(milestoneInfo.MonthDue)
                    .WithTitle(milestoneInfo.CategoryDescription).WithMedia(new Media(PLACEHOLDER_TEXT))
                    .WithHelpfulText(PLACEHOLDER_TEXT).WithQuestionText(PLACEHOLDER_TEXT);
                milestones.Add(builder.Build());
            }
            await milestonesDatabaseAccess.SaveAllMilestonesAsync(milestones);
            return true;
        }

        private readonly string PLACEHOLDER_TEXT = "Placeholder_Text_Please_Replace";
    }
}
