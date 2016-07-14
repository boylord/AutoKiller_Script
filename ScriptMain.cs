using StealthAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public class ScriptMain
    {
        internal bool UseBandages = true;

        private readonly Action<string> _messanger;

        AutoHealer healer;
        AutoAbilityUser abUser;
        private readonly IBuffHandler _bf;
        MonsterTracker monsterTracker;
        AutoLooter looter;
        ICQInformer icqInformer;
        DataContextProvider lootArrayProvider;

        public ScriptMain(Action<string> messanger, IBuffHandler buffHandler)
        {
            _messanger = messanger;
            _bf = buffHandler;
        }

        public void Execute(string ICQUIN, string ICQPassword, string targetUINS, string userInput_LootDataString, int bandagesAlertCount = 100)
        {
            if (!string.IsNullOrEmpty(ICQUIN) &&
                !string.IsNullOrEmpty(ICQPassword) &&
                !string.IsNullOrEmpty(targetUINS))
            {
                uint uin = 0;
                uint.TryParse(ICQUIN.Replace(" ", ""), out uin);

                if (uin > 0)
                {
                    icqInformer = new ICQInformer(_messanger, uin, ICQPassword, targetUINS.Split(','));
                }
            }

            if (UseBandages)
            {
                BandageHealer bh = new BandageHealer(_messanger, icqInformer, bandagesAlertCount);
                healer = new AutoHealer(bh);
                healer.AutoHeal();
            }

            abUser = new AutoAbilityUser("is bleeding", "by the bleed attack", 22, _messanger);
            abUser.AutoUsePrimaryAbility();

            monsterTracker = new MonsterTracker(_messanger);
            monsterTracker.AutoTrack();

            lootArrayProvider = new DataContextProvider(userInput_LootDataString);          
            looter = new AutoLooter(_messanger, lootArrayProvider.OutData);
            looter.AutoLoot();
        }

        public void Stop()
        {
            healer?.Cancel();
            abUser?.Cancel();
            _bf.Cancel();
            monsterTracker?.Cancel();
            looter?.Cancel();
        }
    }
}
