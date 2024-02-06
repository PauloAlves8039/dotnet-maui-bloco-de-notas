namespace BlocoDeNotas.App.Models
{
    public class About
    {
        public string Title{ get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string MoreInfoUrl { get; set; }

        public About()
        {
            Title = AppInfo.Name;
            Version = AppInfo.VersionString;
            Description = "Este app tem como objetivo simular um bloco de notas no qual você ]" +
                          "poderá anotar tudo o que quiser.";
            MoreInfoUrl = "https://github.com/PauloAlves8039";
        }
    }
}
