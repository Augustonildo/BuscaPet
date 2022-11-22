using System.Runtime.Serialization;

namespace BuscaPet.Exceptions
{
    [Serializable]
    public class InvalidRegistryException : Exception
    {
        public InvalidRegistryException()
        {
        }

        public InvalidRegistryException(string message)
            : base(message)
        {
        }

        public InvalidRegistryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected InvalidRegistryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
