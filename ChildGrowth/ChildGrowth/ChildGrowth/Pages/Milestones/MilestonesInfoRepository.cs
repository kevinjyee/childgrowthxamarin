﻿using ChildGrowth.Models;
using ChildGrowth.Models.MediaUtil;
using ChildGrowth.Models.Milestones;
using ChildGrowth.Models.Settings;
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
            ContextDatabaseAccess currentContext = new ContextDatabaseAccess();
            currentContext.InitializeSync();
            Context currSettings = currentContext.GetContextSync();
            Child currChild = currSettings.GetSelectedChild();
            currentContext.CloseSyncConnection();

            if(currChild == null)
            {
                return;
            }

            Dictionary<MilestoneCategory,List<MilestoneWithResponse>> milestonesDict = currChild.GetMilestoneHistory();
            foreach(MilestoneCategory key in milestonesDict.Keys)
            {
                List<MilestoneWithResponse> responseList;
                milestonesDict.TryGetValue(key, out responseList);
                foreach(MilestoneWithResponse item in responseList)
                {
                    Milestone m = item.Milestone;
                    milestonesInfo.Add(new MilestonesInfo { ID = m.ID,
                                                            MonthDue = m.MilestoneDueDate,
                                                            CategoryName = MilestoneCategoryStringConverter.GetStringForCategoryString(m.Category),
                                                            CategoryDescription = m.QuestionText,
                                                            ImageURL = m.Media,
                                                            Answer = item.Answer});
                }
            }
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Social and Emotional", CategoryDescription = "Begins to smile at people", ImageURL = "http://phil.cdc.gov/PHIL_Images/20651/20651_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Social and Emotional", CategoryDescription = "Can briefly calm herself (may bring hands to mouth and suck on hand)", ImageURL = "http://phil.cdc.gov/PHIL_Images/20653/20653_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Social and Emotional", CategoryDescription = "Tries to look at parent", ImageURL = "http://phil.cdc.gov/PHIL_Images/20654/20654_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Language and Communication", CategoryDescription = "Coos, makes gurgling sounds", ImageURL = "https://i.ytimg.com/vi/ktGf_CSVCVk/hqdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Language and Communication", CategoryDescription = "Turns head toward sounds", ImageURL = "https://i.ytimg.com/vi/7LNUNCfvwKk/hqdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Cognitive", CategoryDescription = "Pays attention to faces", ImageURL = "http://phil.cdc.gov/PHIL_Images/20655/20655_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Cognitive", CategoryDescription = "Begins to follow things with eyes and recognize people at a distance", ImageURL = "http://phil.cdc.gov/PHIL_Images/20656/20656_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Cognitive", CategoryDescription = "Begins to act bored (cries, fussy) if activity doesn’t change", ImageURL = "https://i.ytimg.com/vi/HJS68Ls9rB8/hqdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Movement/Physical Development", CategoryDescription = "Can hold head up and begins to push up when lying on tummy", ImageURL = "http://phil.cdc.gov/PHIL_Images/20659/20659_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 2, CategoryName = "Movement/Physical Development", CategoryDescription = "Makes smoother movements with arms and legs", ImageURL = "http://phil.cdc.gov/PHIL_Images/20660/20660_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Social and Emotional", CategoryDescription = "Smiles spontaneously, especially at people", ImageURL = "http://phil.cdc.gov/PHIL_Images/20660/20660_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Social and Emotional", CategoryDescription = "Likes to play with people and might cry when playing stops", ImageURL = "https://i.ytimg.com/vi/oZavlDUOhXg/hqdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Social and Emotional", CategoryDescription = "Copies some movements and facial expressions, like smiling or frowning", ImageURL = "https://i.ytimg.com/vi/StmNaT9vD90/hqdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Language and Communication", CategoryDescription = "Begins to babble", ImageURL = "https://i.ytimg.com/vi/i8Iuo_fTyv0/hqdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Language and Communication", CategoryDescription = "Babbles with expression and copies sounds he hears", ImageURL = "https://i.ytimg.com/vi/5JObUQDR4Gg/hqdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Language and Communication", CategoryDescription = "Cries in different ways to show hunger, pain, or being tired", ImageURL = "http://img.youtube.com/vi/oZavlDUOhXg/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Lets you know if he is happy or sad", ImageURL = "http://phil.cdc.gov/PHIL_Images/20661/20661_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Responds to affection", ImageURL = "http://img.youtube.com/vi/UBndd-Coq60/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Reaches for toy with one hand", ImageURL = "http://phil.cdc.gov/PHIL_Images/20663/20663_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Uses hands and eyes together, such as seeing a toy and reaching for it", ImageURL = "http://phil.cdc.gov/PHIL_Images/20674/20674_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Follows moving things with eyes from side to side", ImageURL = "http://phil.cdc.gov/PHIL_Images/20672/20672_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Watches faces closely", ImageURL = "http://phil.cdc.gov/PHIL_Images/20664/20664_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Cognitive", CategoryDescription = "Recognizes familiar people and things at a distance", ImageURL = "http://img.youtube.com/vi/qVDBiDWGmi0/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "Holds head steady, unsupported", ImageURL = "http://phil.cdc.gov/PHIL_Images/20665/20665_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "Pushes down on legs when feet are on a hard surface", ImageURL = "http://phil.cdc.gov/PHIL_Images/20671/20671_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "May be able to roll over from tummy to back", ImageURL = "http://phil.cdc.gov/PHIL_Images/20668/20668_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "Can hold a toy and shake it and swing at dangling toys", ImageURL = "http://phil.cdc.gov/PHIL_Images/20666/20666_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "Brings hands to mouth", ImageURL = "http://img.youtube.com/vi/MoD-xOT9ExI/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 4, CategoryName = "Movement/Physical Development", CategoryDescription = "When lying on stomach, pushes up to elbows", ImageURL = "http://phil.cdc.gov/PHIL_Images/20667/20667_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Social and Emotional", CategoryDescription = "Knows familiar faces and begins to know if someone is a stranger", ImageURL = "http://phil.cdc.gov/PHIL_Images/20676/20676_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Social and Emotional", CategoryDescription = "Likes to play with others, especially parents", ImageURL = "http://phil.cdc.gov/PHIL_Images/20677/20677_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Social and Emotional", CategoryDescription = "Responds to other people’s emotions and often seems happy", ImageURL = "http://img.youtube.com/vi/_ewfCVshil0/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Social and Emotional", CategoryDescription = "Likes to look at self in a mirror", ImageURL = "http://phil.cdc.gov/PHIL_Images/20678/20678_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Responds to sounds by making sounds", ImageURL = "http://img.youtube.com/vi/TkFgYc303f0/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Strings vowels together when babbling (“ah,” “eh,” “oh”) and likes taking turns with parent while making sounds", ImageURL = "http://img.youtube.com/vi/-RCSbpez9EU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Responds to own name", ImageURL = "http://img.youtube.com/vi/H5yukc5becc/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Makes sounds to show joy and displeasure", ImageURL = "http://img.youtube.com/vi/XvDXOc4YH8c/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Language and Communication", CategoryDescription = "Begins to say consonant sounds (jabbering with “m,” “b”)", ImageURL = "http://img.youtube.com/vi/hmQUUDYUeFE/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Cognitive", CategoryDescription = "Looks around at things nearby", ImageURL = "http://img.youtube.com/vi/1MFgx-pr8hs/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Cognitive", CategoryDescription = "Brings things to mouth", ImageURL = "http://phil.cdc.gov/PHIL_Images/20679/20679_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Cognitive", CategoryDescription = "Shows curiosity about things and tries to get things that are out of reach", ImageURL = "http://phil.cdc.gov/PHIL_Images/20680/20680_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Cognitive", CategoryDescription = "Begins to pass things from one hand to the other", ImageURL = "http://phil.cdc.gov/PHIL_Images/20681/20681_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Movement/Physical Development", CategoryDescription = "Rolls over in both directions (front to back, back to front)", ImageURL = "http://img.youtube.com/vi/KybaUJNhmpo/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Movement/Physical Development", CategoryDescription = "Begins to sit without support", ImageURL = "http://phil.cdc.gov/PHIL_Images/20682/20682_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Movement/Physical Development", CategoryDescription = "When standing, supports weight on legs and might bounce", ImageURL = "http://img.youtube.com/vi/Y3EySKt7BmU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 6, CategoryName = "Movement/Physical Development", CategoryDescription = "Rocks back and forth, sometimes crawling backward before moving forward", ImageURL = "http://img.youtube.com/vi/gnwtliGFY5s/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Social and Emotional", CategoryDescription = "May be afraid of strangers", ImageURL = "http://img.youtube.com/vi/Puel3D6fMEA/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Social and Emotional", CategoryDescription = "May be clingy with familiar adults", ImageURL = "http://img.youtube.com/vi/2ANlZWF8a1k/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Social and Emotional", CategoryDescription = "Has favorite toys", ImageURL = "http://img.youtube.com/vi/0SeOY0q8Ii0/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Language and Communication", CategoryDescription = "Understands “no”", ImageURL = "http://img.youtube.com/vi/OxzBuPAwt2E/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Language and Communication", CategoryDescription = "Makes a lot of different sounds like “mamamama” and “bababababa”", ImageURL = "http://img.youtube.com/vi/JbwH30VV5VI/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Language and Communication", CategoryDescription = "Copies sounds and gestures of others", ImageURL = "http://phil.cdc.gov/PHIL_Images/20683/20683_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Language and Communication", CategoryDescription = "Uses fingers to point at things", ImageURL = "http://phil.cdc.gov/PHIL_Images/20685/20685_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Watches the path of something as it falls", ImageURL = "http://img.youtube.com/vi/UGJuozLLX9s/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Looks for things she sees you hide", ImageURL = "http://phil.cdc.gov/PHIL_Images/20686/20686_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Plays peek-a-boo", ImageURL = "http://img.youtube.com/vi/cQJPM8gW8oU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Puts things in his mouth", ImageURL = "http://phil.cdc.gov/PHIL_Images/20689/20689_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Moves things smoothly from one hand to the other", ImageURL = "http://phil.cdc.gov/PHIL_Images/20690/20690_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Cognitive", CategoryDescription = "Picks up things like cereal o’s between thumb and index finger", ImageURL = "http://phil.cdc.gov/PHIL_Images/20694/20694_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Stands, holding on", ImageURL = "http://phil.cdc.gov/PHIL_Images/20695/20695_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Can get into sitting position", ImageURL = "http://img.youtube.com/vi/6QFwdkuYxdU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Sits without support", ImageURL = "http://phil.cdc.gov/PHIL_Images/20696/20696_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Pulls to stand", ImageURL = "http://phil.cdc.gov/PHIL_Images/20697/20697_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 9, CategoryName = "Movement/Physical Development", CategoryDescription = "Crawls", ImageURL = "http://img.youtube.com/vi/YlVDkF9WXLs/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Is shy or nervous with strangers", ImageURL = "http://img.youtube.com/vi/rkC2Wf4A_nw/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Cries when mom or dad leaves", ImageURL = "http://img.youtube.com/vi/p86vpbe6cOE/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Has favorite things and people", ImageURL = "http://phil.cdc.gov/PHIL_Images/20700/20700_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Shows fear in some situations", ImageURL = "http://img.youtube.com/vi/0h1OoeVTHJw/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Hands you a book when he wants to hear a story", ImageURL = "http://phil.cdc.gov/PHIL_Images/20703/20703_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Repeats sounds or actions to get attention", ImageURL = "http://img.youtube.com/vi/HV-SB7iYQtM/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Puts out arm or leg to help with dressing", ImageURL = "http://phil.cdc.gov/PHIL_Images/20704/20704_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Social and Emotional", CategoryDescription = "Plays games such as “peek-a-boo” and “pat-a-cake”", ImageURL = "http://phil.cdc.gov/PHIL_Images/20705/20705_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Responds to simple spoken requests", ImageURL = "http://img.youtube.com/vi/tzjCTwrlEqI/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Uses simple gestures, like shaking head “no” or waving “bye-bye”", ImageURL = "http://img.youtube.com/vi/h1xwTJNV0rA/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Makes sounds with changes in tone (sounds more like speech)", ImageURL = "http://img.youtube.com/vi/5eceKJPl8UU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Says “mama” and “dada” and exclamations like “uh-oh!”", ImageURL = "http://img.youtube.com/vi/JiGnOH1GTdM/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Language and Communication", CategoryDescription = "Tries to say words you say", ImageURL = "http://img.youtube.com/vi/ANzafxAxLW0/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Explores things in different ways, like shaking, banging, throwing", ImageURL = "http://img.youtube.com/vi/pMVinh7qvT8/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Finds hidden things easily", ImageURL = "http://phil.cdc.gov/PHIL_Images/20707/20707_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Looks at the right picture or thing when it’s named", ImageURL = "http://img.youtube.com/vi/rQ6RuauvK3Y/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Copies gestures", ImageURL = "http://phil.cdc.gov/PHIL_Images/20710/20710_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Starts to use things correctly; for example, drinks from a cup, brushes hair", ImageURL = "http://img.youtube.com/vi/9nyrA0e9BGE/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Bangs two things together", ImageURL = "http://img.youtube.com/vi/UVoVM0k065Q/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Puts things in a container, takes things out of a container", ImageURL = "http://img.youtube.com/vi/gHYUR7nI8mI/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Lets things go without help", ImageURL = "http://img.youtube.com/vi/33E6N81FKDk/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Pokes with index (pointer) finger", ImageURL = "http://phil.cdc.gov/PHIL_Images/20711/20711_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Cognitive", CategoryDescription = "Follows simple directions like “pick up the toy”", ImageURL = "http://img.youtube.com/vi/pFy0ZT7aLjk/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Movement/Physical Development", CategoryDescription = "Gets to a sitting position without help", ImageURL = "http://phil.cdc.gov/PHIL_Images/20713/20713_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Movement/Physical Development", CategoryDescription = "Pulls up to stand, walks holding on to furniture (“cruising”)", ImageURL = "http://img.youtube.com/vi/fDgMPUtm1os/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Movement/Physical Development", CategoryDescription = "May take a few steps without holding on", ImageURL = "http://img.youtube.com/vi/hrTXjv3TjX4/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 12, CategoryName = "Movement/Physical Development", CategoryDescription = "May stand alone", ImageURL = "http://phil.cdc.gov/PHIL_Images/20716/20716_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Likes to hand things to others as play", ImageURL = "http://phil.cdc.gov/PHIL_Images/20717/20717_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "May have temper tantrums", ImageURL = "http://img.youtube.com/vi/iSKMkHKhocQ/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "May be afraid of strangers", ImageURL = "http://img.youtube.com/vi/0bUa6AvfaeQ/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Shows affection to familiar people", ImageURL = "http://phil.cdc.gov/PHIL_Images/20721/20721_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Plays simple pretend, such as feeding a doll", ImageURL = "http://img.youtube.com/vi/6kszHh5F4fU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "May cling to caregivers in new situations", ImageURL = "http://phil.cdc.gov/PHIL_Images/20718/20718_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Points to show others something interesting", ImageURL = "http://phil.cdc.gov/PHIL_Images/20719/20719_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Social and Emotional", CategoryDescription = "Explores alone but with parent close by", ImageURL = "http://phil.cdc.gov/PHIL_Images/20720/20720_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Language and Communication", CategoryDescription = "Says several single words", ImageURL = "http://img.youtube.com/vi/AMxgyI4EdSM/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Language and Communication", CategoryDescription = "Says and shakes head “no”", ImageURL = "http://img.youtube.com/vi/az4jhcbsDms/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Language and Communication", CategoryDescription = "Points to show someone what he wants", ImageURL = "http://img.youtube.com/vi/nmkZphuIzvk/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Knows what ordinary things are for; for example, telephone, brush, spoon", ImageURL = "http://phil.cdc.gov/PHIL_Images/20722/20722_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Points to get the attention of others", ImageURL = "http://phil.cdc.gov/PHIL_Images/20723/20723_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Shows interest in a doll or stuffed animal by pretending to feed", ImageURL = "http://phil.cdc.gov/PHIL_Images/20724/20724_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Points to one body part", ImageURL = "http://img.youtube.com/vi/RSynaBnWz4k/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Scribbles on his own", ImageURL = "http://phil.cdc.gov/PHIL_Images/20725/20725_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Cognitive", CategoryDescription = "Can follow 1-step verbal commands without any gestures; for example, sits when you say “sit down”", ImageURL = "http://img.youtube.com/vi/kL4-4Ls0W7Q/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Walks alone", ImageURL = "http://img.youtube.com/vi/JaOUmM5ItYU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "May walk up steps and run", ImageURL = "http://img.youtube.com/vi/pJ6lJT0OakY/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Pulls toys while walking", ImageURL = "http://img.youtube.com/vi/E5zpJPaxm18/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Can help undress himself/herself", ImageURL = "http://img.youtube.com/vi/6D4MyzTdyTE/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Drinks from a cup", ImageURL = "http://phil.cdc.gov/PHIL_Images/20727/20727_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 18, CategoryName = "Movement/Physical Development", CategoryDescription = "Eats with a spoon", ImageURL = "http://phil.cdc.gov/PHIL_Images/20726/20726_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Copies others, especially adults and older children", ImageURL = "http://phil.cdc.gov/PHIL_Images/20728/20728_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Gets excited when with other children", ImageURL = "nan" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Shows more and more independence", ImageURL = "http://phil.cdc.gov/PHIL_Images/20729/20729_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Shows defiant behavior (doing what he has been told not to)", ImageURL = "http://img.youtube.com/vi/HaXnKsnlohk/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Social and Emotional", CategoryDescription = "Plays mainly beside other children, but is beginning to include other children, such as in chase games", ImageURL = "http://img.youtube.com/vi/aau2i8hIQaY/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Points to things or pictures when they are named", ImageURL = "http://img.youtube.com/vi/o9vfRS7x53c/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Knows names of familiar people and body parts", ImageURL = "http://img.youtube.com/vi/o-icLJC6tHc/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Says sentences with 2 to 4 words", ImageURL = "http://img.youtube.com/vi/rIdCA-imsZU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Follows simple instructions", ImageURL = "http://img.youtube.com/vi/enEGavf5Cn8/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Repeats words overheard in conversation", ImageURL = "http://img.youtube.com/vi/7WoNafM_RIk/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Language and Communication", CategoryDescription = "Points to things in a book", ImageURL = "http://phil.cdc.gov/PHIL_Images/20730/20730_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Finds things even when hidden under two or three covers", ImageURL = "http://phil.cdc.gov/PHIL_Images/20731/20731_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Begins to sort shapes and colors", ImageURL = "http://phil.cdc.gov/PHIL_Images/20733/20733_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Completes sentences and rhymes in familiar books", ImageURL = "http://img.youtube.com/vi/e_X8gip0ikQ/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Plays simple make-believe games", ImageURL = "http://phil.cdc.gov/PHIL_Images/20734/20734_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Builds towers of 4 or more blocks", ImageURL = "http://phil.cdc.gov/PHIL_Images/20735/20735_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Might use one hand more than the other", ImageURL = "http://img.youtube.com/vi/RIUgcQSHAVc/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Follows two-step instructions such as “Pick up your shoes and put them in the closet.”", ImageURL = "http://img.youtube.com/vi/tySEn371aZM/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Cognitive", CategoryDescription = "Names items in a picture book such as a cat, bird, or dog", ImageURL = "http://img.youtube.com/vi/HFg1eSu_KTk/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Stands on tiptoe", ImageURL = "http://phil.cdc.gov/PHIL_Images/20736/20736_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Kicks a ball", ImageURL = "http://phil.cdc.gov/PHIL_Images/20737/20737_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Begins to run", ImageURL = "http://img.youtube.com/vi/6vnTQD0qqGU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Climbs onto and down from furniture without help", ImageURL = "http://phil.cdc.gov/PHIL_Images/20738/20738_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Walks up and down stairs holding on", ImageURL = "http://phil.cdc.gov/PHIL_Images/20739/20739_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Throws ball overhand", ImageURL = "http://phil.cdc.gov/PHIL_Images/20741/20741_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 24, CategoryName = "Movement/Physical Development", CategoryDescription = "Makes or copies straight lines and circles", ImageURL = "http://img.youtube.com/vi/6XV8xXdy0lg/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Copies adults and friends", ImageURL = "http://phil.cdc.gov/PHIL_Images/20743/20743_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Shows affection for friends without prompting", ImageURL = "nan" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Takes turns in games", ImageURL = "http://img.youtube.com/vi/c9KtszF2_oc/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Shows concern for crying friend", ImageURL = "http://phil.cdc.gov/PHIL_Images/20747/20747_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Understands the idea of “mine” and “his” or “hers”", ImageURL = "http://img.youtube.com/vi/Om-zZvqXPlY/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Shows a wide range of emotions", ImageURL = "http://phil.cdc.gov/PHIL_Images/20746/20746_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Separates easily from mom and dad", ImageURL = "http://phil.cdc.gov/PHIL_Images/20751/20751_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "May get upset with major changes in routine", ImageURL = "nan" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Social and Emotional", CategoryDescription = "Dresses and undresses self", ImageURL = "http://phil.cdc.gov/PHIL_Images/20752/20752_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Follows instructions with 2 or 3 steps", ImageURL = "http://img.youtube.com/vi/-d6rgPOGnSQ/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Can name most familiar things", ImageURL = "http://img.youtube.com/vi/LY8Ot4DJjpU/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Understands words like “in,” “on,” and “under”", ImageURL = "http://img.youtube.com/vi/xIqVMimUWN0/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Says first name, age, and sex", ImageURL = "#VALUE!" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Names a friend", ImageURL = "http://img.youtube.com/vi/ogqu1lRL4j8/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Says words like “I,” “me,” “we,” and “you” and some plurals (cars, dogs, cats)", ImageURL = "http://img.youtube.com/vi/T4tybEWGaIg/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Talks well enough for strangers to understand most of the time", ImageURL = "http://img.youtube.com/vi/k0Hu0FOe5Pc/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Language and Communication", CategoryDescription = "Carries on a conversation using 2 to 3 sentences", ImageURL = "http://img.youtube.com/vi/dlFBFObuVlM/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Can work toys with buttons, levers, and moving parts", ImageURL = "http://phil.cdc.gov/PHIL_Images/20760/20760_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Plays make-believe with dolls, animals, and people", ImageURL = "http://phil.cdc.gov/PHIL_Images/20754/20754_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Does puzzles with 3 or 4 pieces", ImageURL = "http://phil.cdc.gov/PHIL_Images/20755/20755_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Understands what “two” means", ImageURL = "http://img.youtube.com/vi/BUDDlzpgYc0/maxresdefault.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Copies a circle with pencil or crayon", ImageURL = "http://phil.cdc.gov/PHIL_Images/20756/20756_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Turns book pages one at a time", ImageURL = "http://phil.cdc.gov/PHIL_Images/20757/20757_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Builds towers of more than 6 blocks", ImageURL = "http://phil.cdc.gov/PHIL_Images/20758/20758_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Cognitive", CategoryDescription = "Screws and unscrews jar lids or turns door handle", ImageURL = "http://phil.cdc.gov/PHIL_Images/20759/20759_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Movement/Physical Development", CategoryDescription = "Climbs well", ImageURL = "http://phil.cdc.gov/PHIL_Images/20911/20911_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Movement/Physical Development", CategoryDescription = "Runs easily", ImageURL = "http://phil.cdc.gov/PHIL_Images/20762/20762_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Movement/Physical Development", CategoryDescription = "Pedals a tricycle (3-wheel bike)", ImageURL = "http://phil.cdc.gov/PHIL_Images/20761/20761_lores.jpg" });
            //milestonesInfo.Add(new MilestonesInfo { MonthDue = 36, CategoryName = "Movement/Physical Development", CategoryDescription = "Walks up and down stairs, one foot on each step", ImageURL = "http://phil.cdc.gov/PHIL_Images/20763/20763_lores.jpg" });
        }

        private readonly string PLACEHOLDER_TEXT = "Placeholder_Text_Please_Replace";
    }
}
