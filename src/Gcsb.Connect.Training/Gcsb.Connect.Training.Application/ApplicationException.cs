namespace Gcsb.Connect.Training.Application
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string businessMessage)
            : base(businessMessage) 
        { 
        }
    }
}
