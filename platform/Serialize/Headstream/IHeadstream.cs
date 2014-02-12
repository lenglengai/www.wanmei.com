namespace platform
{
    public interface IHeadstream
    {
        void _headSerialize(ISerialize nSerialize);

        string _streamName();
    }
}
