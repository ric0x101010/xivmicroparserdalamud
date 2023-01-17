using XIVMicroPaserDalamud.Models;
using Dalamud.Game.ClientState;
using Microsoft.Xna.Framework;
using Dalamud.Game.Chat;
using Dalamud.Game.Chat.SeStringHandling;
using Dalamud.Game.Chat.SeStringHandling.Payloads;
using System;
using System.Linq;
using System.Collections.Generic;

namespace XIVMicroPaserDalamud.TargetHPrDPS
{
    public class TargetHPrDPS
    {
        private readonly DalamudPluginInterface pi;
        private readonly TargetInfoModel model;

        public TargetHPrDPS(DalamudPluginInterface pluginInterface, TargetInfoModel targetInfoModel)
        {
            this.pi = pluginInterface;
            this.model = targetInfoModel;
        }

        public void DrawTargetHPrDPS()
        {
            var client = pi.ClientState;
            var target = client.Target;
            if (target == null)
                return;

            var rDPS = model.Rdps;
            var pos = new Vector2(100, 140);
            pi.Drawing.DrawText("rDPS: "+ rDPS.ToString("0.00"), pos.X, pos.Y, Color.White, Drawing.TextAlignment.Left);
        }
    }
}
