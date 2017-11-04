using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models.MediaUtil
{
    public class Media
    {

        public Media()
        {

        }

        public Media(string mediaURL, MediaType mediaType)
        {
            this._mediaURL = mediaURL;
            this._mediaType = mediaType;
        }

        public Media(string mediaURL)
        {
            this._mediaURL = mediaURL;
            this._mediaType = MediaType.IMAGE;
        }

        public string _mediaURL { get; set; }
        public string MediaURL { get { return _mediaURL; } set { this._mediaURL = value; } }

        public MediaType _mediaType { get; set; }
        public MediaType MediaType { get { return _mediaType; } set { this._mediaType = value; } }

    }
}
