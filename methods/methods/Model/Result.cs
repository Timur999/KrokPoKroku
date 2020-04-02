namespace methods.Model
{
    static class Result
    {
        static public Status Status;
        static public Status Success = Status.Success;
        static public void SetStatus(Status status)
        {
            Status = status;
        }
    }

    public enum Status
    {
        Success,
        Error
    }
}