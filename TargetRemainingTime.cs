using XIVMicroPaserDalamud.Models;
using Dalamud.Game.ClientState;
using Microsoft.Xna.Framework;
using Dalamud.Game.Chat;
using Dalamud.Game.Chat.SeStringHandling;
using Dalamud.Game.Chat.SeStringHandling.Payloads;
using System;
using System.Linq;
using System.Collections.Generic;

namespace XIVMicroPaserDalamud.TargetRemainingTime
{
    public class TargetRemainingTime
    {
        private readonly DalamudPluginInterface pi;
        private readonly TargetInfoModel model;

        public TargetRemainingTime(DalamudPluginInterface pluginInterface, TargetInfoModel targetInfoModel)
        {
            this.pi = pluginInterface;
            this.model = targetInfoModel;
        }

        public void DrawTargetRemainingTime()
        {
            var client = pi.ClientState;
            var target = client.Target;
            if (target == null)
                return;

            var remainingTime = model.RemainingTime;
            var pos = new Vector2(100, 120);
            pi.Drawing.DrawText(remainingTime, pos.X, pos.Y, Color.White, Drawing.TextAlignment.Left);
        }
    }
}
