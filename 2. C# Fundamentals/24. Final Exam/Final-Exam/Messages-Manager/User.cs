using System;
using System.Collections.Generic;
using System.Text;

namespace Messages_Manager
{
    class User
    {
        public int SentMessages { get; set; }
        public int ReceivedMessages { get; set; }
        public User(int sentMessages, int receivedMessages)
        {
            this.SentMessages = sentMessages;
            this.ReceivedMessages = receivedMessages;
        }
    }
}
