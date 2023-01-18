using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Text;

namespace XIVMicroPaserDalamud {
    public class ActData {
        private readonly Config _config;

        public ActData(Config config) {
            _config = config;
        }

        public void Update() {
            var json = GetActData();
            var encounter = json["currentCombat"];
            var groupDps = json["last30Seconds"]["encdps"];
            var groupDamage = json["last30Seconds"]["damage"];
            var encounterName = encounter["title"];
            var encounterHp = encounter["currentHp"];
            var encounterDuration = encounter["duration"];
            // Handle the encounter data here
        }

        private JObject GetActData() {
            var url = _config.ActUrl;
            var json = new WebClient().DownloadString(url);
            return JsonConvert.DeserializeObject<JObject>(json);
        }
    }
}
