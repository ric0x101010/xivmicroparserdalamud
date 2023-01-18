using Dalamud.Game.Command;

namespace XIVMicroPaserDalamud {
    public class Config : Dalamud.Configuration.PluginConfiguration {
        public string ActUrl { get; set; } = "http://localhost:50000/api/encounter";

        [Command("Url")]
        public void SetUrl(string url) {
            this.ActUrl = url;
            this.Save();
        }
    }
}
