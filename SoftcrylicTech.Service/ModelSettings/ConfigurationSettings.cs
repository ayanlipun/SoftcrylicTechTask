namespace SoftcrylicTech.Service.ModelSettings
{
    public class ConfigurationSettings
    {
        public string FriendlyName { get; set; }
        public string CopyRightText { get; set; }
        public string BuildVersion { get; set; }
    }

    public class VersionInformation
    {
        public string ApplicationName { get; set; }
        public string BuildVersion { get; set; }
        public string Frameworkversion { get; set; }
    }
}
