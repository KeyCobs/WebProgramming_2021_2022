using System;

namespace Jacobs_Kevin_3IMS_BackEnd
{
    public class Song
    {
        public int ID { get; private set; }
        public string Title { get; set; }
        //public Artist Artist { get; private set; }
        public int Artist_id { get; set; }
        public string Spotify { get; set; }
        //public int Votes { get; set; }
        //public int Points { get; set; }
    }
}
