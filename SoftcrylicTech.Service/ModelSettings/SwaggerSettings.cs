using System.Collections.Generic;

namespace SoftcrylicTech.Service.ModelSettings
{
    public class SwaggerSettings
    {
        public string ContactEmail { get; set; }
        public string LicenseName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionText { get; set; }
        public string SecurityDefinationName { get; set; }
        public string HubClientId { get; set; }
        public IList<Scope> Scopes { get; set; }
    }

    public class Scope
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
