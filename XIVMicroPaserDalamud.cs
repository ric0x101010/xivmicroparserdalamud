using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalamud;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Plugin;
using ImGuiNET;

namespace XIVMicroPaserDalamud {
    public class XIVMicroPaserDalamud : IDalamudPlugin {
        public string Name => "XIVMicroPaserDalamud";
        private DalamudPluginInterface pi;
        private ActData _actData;
        private Config _config;

        public void Initialize(DalamudPluginInterface pluginInterface) {
            this.pi = pluginInterface;
            _config = new Config();
            _actData = new ActData(_config);
            pi.CommandManager.AddHandler("/micro", new MicroCommand(this));
            pi.ClientState.OnChange += HandleClientStateChange;
            pi.UiBuilder.OnBuildUi += RenderUI;
        }

        public void Dispose() {
            pi.UiBuilder.OnBuildUi -= RenderUI;
            pi.ClientState.OnChange -= HandleClientStateChange;
            pi.CommandManager.RemoveHandler("/micro");
        }

        private void HandleClientStateChange(object sender, ClientStateEventArgs e) {
            if (e.NewState != ClientState.Ingame)
                return;

            _actData.Update();
        }

        private void RenderUI() {
            ImGui.Begin("XIV Micro Parser");
            ImGui.Text("Encounter: " + _actData.GetEncounterName());
            ImGui.Text("Encounter HP: " + _actData.GetCurrentEncounterHp());
            ImGui.Text("Group DPS: " + _actData.GetGroupDps());
            ImGui.Text("Group Damage: " + _actData.GetGroupDamage());
            ImGui.Text("Encounter Duration: " + _actData.GetEncounterDuration());
            ImGui.End();
        }

        private class MicroCommand : Command {
            private readonly XIVMicroPaserDalamud _plugin;

            public MicroCommand(XIVMicroPaserDalamud plugin) {
                this._plugin = plugin;
                this.Name = "micro";
                this.Description = "XIV Micro Parser";
            }

            public override void Execute(string command, string[] args) {
                _plugin._config.ShowConfiguration();
            }
        }
    }
}
