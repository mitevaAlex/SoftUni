using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            Music music = new Music("Ariana Grande", "Thank u, next", 5000, 250);
            File file = new File("random file", 700, 640);

            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(music);
            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());

            streamProgressInfo = new StreamProgressInfo(file);
            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
        }
    }
}
