using StealthAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public class AutoAbilityUser
    {
        private bool _abilityEnabled { get; set; } = false;
        private string _abilityUsedMessage { get; set; }
        private string _abilityImmuneMessage { get; set; }
        private int _manaNeeded { get; set; }
        private Action<string> _messanger;
             
        public AutoAbilityUser(string abilityUsed, string immuneMessage, int manaNeeded, Action<string> messanger)
        {
            _abilityUsedMessage = abilityUsed;
            _abilityImmuneMessage = immuneMessage;
            _manaNeeded = manaNeeded;

            _messanger = messanger;

            
        }


        private bool _cancel { get; set; } = false;
        public void Cancel()
        {
            _cancel = true;
        }

        private CancellationTokenSource ct { get; set; }

        public async void AutoUsePrimaryAbility()
        {
            Stealth.Client.ClilocSpeech += Client_ClilocSpeech;

            while (!_cancel)
            {
                if (Stealth.Client.GetSelfMana() >= _manaNeeded && !_abilityEnabled)
                {
                    _messanger?.Invoke("[Information] Ability enabled");
                    ct = new CancellationTokenSource();

                    _abilityEnabled = true;
                    Stealth.Client.UsePrimaryAbility();
                    try
                    {
                        await Task.Delay(30000, ct.Token);
                    }
                    catch (TaskCanceledException) { }
                }
                await Task.Delay(1000);
            }
            
            Stealth.Client.ClilocSpeech -= Client_ClilocSpeech;
        }

        private void Client_ClilocSpeech(object sender, ClilocSpeechEventArgs e)
        {
            if (e.Text.Contains(_abilityUsedMessage) || e.Text.Contains(_abilityImmuneMessage))
            {
                ct?.Cancel();
                _abilityEnabled = false;
            }
        }
    }
}
