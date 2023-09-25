namespace P01.Stream_Progress
{
    public interface IStream
    {
        int BytesSent { get; }

        int Length { get; }
    }
}