using System;

namespace Jacobs_Kevin_3IMS_BackEnd
{
    public class Vote
    {
        public int ID { get; private set; }
        public int Song_ID { get; set; }
        public int Points { get; set; }
        public string IncomingPoints { get; set; }
    }
}
