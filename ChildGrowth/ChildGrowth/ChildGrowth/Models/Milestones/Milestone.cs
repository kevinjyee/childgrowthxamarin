using SQLiteNetExtensions.Attributes;
using SQLite.Net.Attributes;
using ChildGrowth.Models.MediaUtil;

namespace ChildGrowth.Models.Milestones
{
    [Table("Milestone")]
    public class Milestone
    {
        [PrimaryKey]
        public int ID { get; set; }

        // MilestoneDueDate is in units of months.
        [Indexed]
        public int MilestoneDueDate { get; set; }

        [Indexed]
        public string Category { get; set; }

        
        public string Media { get;  set; }

        // Not sure if I should make _title or equivalents for the rest of the string members.
        public string Title { get; set; }

        public string QuestionText { get; set; }

        public string HelpfulText { get; set; }

        [TextBlob("MediaBlobbed")]
        public string _media { get; set; }
        public string MediaBlobbed { get; set; }

        private Milestone(int id, int milestoneDueDate, MilestoneCategory category, string title, string questionText, string helpfulText, string media)
        {
            this.ID = id;
            this.MilestoneDueDate = milestoneDueDate;
            this.Category = category.ToString();
            this.Title = title;
            this.QuestionText = questionText;
            this.HelpfulText = helpfulText;
            this.Media = media;
        }

        public Milestone()
        {

        }

        /**
         * Builder class for Milestones objects. Use this to avoid annoying constructors with a bunch of parameters.
         * 
         */
        public class MilestoneBuilder
        {
            private int _id;
            private int _milestoneDueDate;
            private MilestoneCategory _category;
            private string _title;
            private string _questionText;
            private string _helpfulText;
            private string _media;

            public MilestoneBuilder()
            {

            }

            public Milestone Build()
            {
                return new Milestone(_id, _milestoneDueDate, _category, _title, _questionText, _helpfulText, _media);
            }

            public MilestoneBuilder WithID(int id)
            {
                this._id = id;
                return this;
            }

            public MilestoneBuilder WithMilestoneDueDate(int milestoneDueDate)
            {
                this._milestoneDueDate = milestoneDueDate;
                return this;
            }

            public MilestoneBuilder WithCategory(MilestoneCategory category)
            {
                this._category = category;
                return this;
            }

            public MilestoneBuilder WithTitle(string title)
            {
                this._title = title;
                return this;
            }
            
            public MilestoneBuilder WithQuestionText(string questionText)
            {
                this._questionText = questionText;
                return this;
            }

            public MilestoneBuilder WithHelpfulText(string helpfulText)
            {
                this._helpfulText = helpfulText;
                return this;
            }

            public MilestoneBuilder WithMedia(string media)
            {
                this._media = media;
                return this;
            }
        }
    }
}
