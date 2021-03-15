using System;

namespace WebAPI.Services.Exceptions
{
    public class TopicNotFoundException : Exception
    {
        public TopicNotFoundException() 
            : base()
        {
        }

        public TopicNotFoundException(string message)
            : base(message)
        {
        }
    }
}