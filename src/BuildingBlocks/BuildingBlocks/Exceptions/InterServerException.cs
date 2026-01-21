namespace BuildingBlocks.Exceptions
{
    public class InterServerException : Exception
    {        
        public InterServerException(string message) : base(message) { }
        public InterServerException(string message, string details) : base(message) {
        Details = details;
        }

        public string? Details { get;  }
    }
}
