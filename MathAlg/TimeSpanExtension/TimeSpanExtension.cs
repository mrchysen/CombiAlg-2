namespace MathAlg2.TimeSpanExtension;

public static class TimeSpanExtension
{
    public static string ToStringCustom(this TimeSpan t)
    {
        int millis = t.Milliseconds;
        int sec = t.Seconds;
        int min = t.Minutes;

        return $"<mm:ss:msms>{min}:{sec}:{millis}";
    }
}
