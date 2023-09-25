namespace Logger.Layouts
{
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Template => "{0} - {1} - {2}";
    }
}
