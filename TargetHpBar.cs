using XIVMicroPaserDalamud.Models;
using Dalamud.Game.ClientState;
using Microsoft.Xna.Framework;
using Dalamud.Game.Chat;
using Dalamud.Game.Chat.SeStringHandling;
using Dalamud.Game.Chat.SeStringHandling.Payloads;
using System;
using System.Linq;
using System.Collections.Generic;

namespace XIVMicroPaserDalamud.TargetHpBar
{
    public class TargetHpBar
    {
        private readonly DalamudPluginInterface pi;
        private readonly TargetInfoModel model;

        public TargetHpBar(DalamudPluginInterface pluginInterface, TargetInfoModel targetInfoModel)
        {
            this.pi = pluginInterface;
            this.model = targetInfoModel;
        }

        public void DrawTargetHPBar()
        {
            var client = pi.ClientState;
            var target = client.Target;
            if (target == null)
                return;

            var width = 200;
            var height = 20;
            var pos = new Vector2(100, 100);

            var hpRatio = model.HpRatio;

            var hpBarWidth = (int)(width * hpRatio);

            // Draw background
            pi.Drawing.DrawRectangle(pos.X, pos.Y, width, height, new Color(0, 0, 0, 128));
            // Draw HP bar
            pi.Drawing.DrawRectangle(pos.X, pos.Y, hpBarWidth, height, new Color(255, 0, 0, 255));
            // Draw HP percentage
            pi.Drawing.DrawText(hpRatio.ToString("P0"), pos.X + width / 2, pos.Y, Color.White, Drawing.TextAlignment.Center);
        }
    }
}
