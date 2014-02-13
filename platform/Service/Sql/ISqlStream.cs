namespace platform
{
    public interface ISqlStream
    {
        void _runSelect(ISqlCommand nSqlCommand);

        void _runWhen(ISqlCommand nSqlCommand);
    }
}
