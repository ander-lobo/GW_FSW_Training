namespace Gcsb.Connect.Training.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string businessMessage)
            : base(businessMessage)
        {

        }
    }
}
