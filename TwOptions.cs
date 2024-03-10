
namespace TrayWeather2
{
    internal class TwOptions
    {
        public string? key { get; set; }
        public string? q { get; set; }
        public string? rph { get; set; }

        public TwOptions()
        {
            key = String.Empty;
            q = String.Empty;
            rph = String.Empty;
        }

        public void SetAll(string k, string qq, string r)
        {
            key = k;
            q = qq;
            rph = r;
        }
    }
}
