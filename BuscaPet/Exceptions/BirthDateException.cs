using System.Runtime.Serialization;

namespace BuscaPet.Exceptions
{
    [Serializable]
    public class BirthDateException : Exception
    {
        public BirthDateException()
        {
        }

        public BirthDateException(string message)
            : base(message)
        {
        }

        public BirthDateException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected BirthDateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
