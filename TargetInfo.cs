using XIVMicroPaserDalamud.Models;
using Dalamud.Game.ClientState;
using System;
using Microsoft.AspNetCore.Mvc.Razor;
using System.IO;

namespace XIVMicroPaserDalamud.TargetInfo
{
    public class TargetInfo
    {
        private readonly DalamudPluginInterface pi;
        private TargetInfoModel model;

        public TargetInfo(DalamudPluginInterface pluginInterface)
        {
            this.pi = pluginInterface;
            this.model = new TargetInfoModel();
        }

        public void RenderTargetInfo()
        {
            var client = pi.ClientState;
            var target = client.Target;
            if (target == null)
                return;

            model.HpRatio = target.HpRatio;
            model.Rdps = target.Rdps;
            model.RemainingTime = target.RemainingTime;

            var engine = pi.Razor;
            var template = File.ReadAllText("TargetInfo.cshtml");
            var result = engine.RunCompile(template, "templateKey", typeof(TargetInfoModel), model);
            // do something with the result, such as displaying it on the screen
        }
    }
}
