using StealthAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public class BandageHealer : IHealer
    {
        private const ushort __bandageType = 0xE21;
        private CancellationTokenSource _ct;
        private readonly int _maxLife;
        private readonly Action<string> _sendConsoleMessage;
        private readonly uint _backpackId;
        private readonly ICQInformer _icqInformer;
        private readonly int _bandagesLeftIcqInform;

        public BandageHealer(Action<string> sendConsoleMessage, ICQInformer icqInformer, int bandagesLeftICQInform, int maxLife = 0)
        {
            _sendConsoleMessage = sendConsoleMessage;
            _maxLife = (maxLife == 0) ? Stealth.Client.GetSelfMaxLife() : maxLife;
            _backpackId = Stealth.Client.GetBackpackID();
            _icqInformer = icqInformer;
            _bandagesLeftIcqInform = bandagesLeftICQInform;
        }

        public async Task HealOnceAsync()
        {
            if (Stealth.Client.GetDeadStatus())
            {
                return;
            }

            _ct = new CancellationTokenSource();
            if (Stealth.Client.GetSelfLife() < _maxLife)
            {
                _sendConsoleMessage?.Invoke($"[Information] Healing started");
            }else
            {
                //_sendConsoleMessage?.Invoke("No need in heals");
                return;
            }

            Stealth.Client.ClilocSpeech += Client_ClilocSpeech;

            var bandage = Stealth.Client.FindTypeEx(__bandageType, 0xFFFF, _backpackId, true);
            int bandageCount;
            if (bandage > 0)
            {
                bandageCount = Stealth.Client.GetFindQuantity() - 1;
                await Task.Delay(1000);
                Stealth.Client.WaitTargetSelf();
                Stealth.Client.UseObject(bandage);
            }
            else
            {
                //_ct.Dispose();
                _sendConsoleMessage("[Error] No bandages found!");
                return;
            }

            _sendConsoleMessage?.Invoke($"[Information] Bandages left: {bandageCount}");

            if (bandageCount < _bandagesLeftIcqInform)
            {
                _icqInformer?.SendICQMessage($"[Critical] Low resources bandages left: {bandageCount}");
            }

            try
            {
                await Task.Delay(8000, _ct.Token);
            }
            catch (TaskCanceledException)
            {
                //ct.Dispose();
            }
                        
            _sendConsoleMessage?.Invoke("[Information] Healing ended");
        }

        private void Client_ClilocSpeech(object sender, ClilocSpeechEventArgs e)
        {
            if (e.Text.Contains("finish") || e.Text.Contains("being is not damaged") || e.Text.Contains("heal what little damage"))
            {   
                _ct?.Cancel();
            }
        }
    }
}
