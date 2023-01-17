using XIVMicroPaserDalamud.Models;
using XIVMicroPaserDalamud.TargetInfo;
using XIVMicroPaserDalamud.TargetHpBar;
using XIVMicroPaserDalamud.TargetRemainingTime;
using XIVMicroPaserDalamud.TargetHPrDPS;

using Dalamud.Plugin;

namespace XIVMicroPaserDalamud
{
    public class XIVMicroPaserDalamud : IDalamudPlugin
    {
        private readonly DalamudPluginInterface pi;
        private TargetInfo targetInfo;
        private TargetHpBar targetHpBar;
        private TargetRemainingTime targetRemainingTime;
        private TargetHPrDPS targetHPrDPS;

        public XIVMicroPaserDalamud(DalamudPluginInterface pluginInterface)
        {
            this.pi = pluginInterface;
            this.targetInfo = new TargetInfo(pi);
            this.targetHpBar = new TargetHpBar(pi);
            this.targetRemainingTime = new TargetRemainingTime(pi);
            this.targetHPrDPS = new TargetHPrDPS(pi);
        }

        public void Initialize()
        {
            // do something on plugin initialization
        }

        public void Dispose()
        {
            // do something on plugin disposal
        }

        public void Draw()
        {
            targetInfo.RenderTargetInfo();
            targetHpBar.DrawTargetHPBar();
            targetRemainingTime.DrawTargetRemainingTime();
            targetHPrDPS.DrawTargetHPrDPS();
        }
    }
}
