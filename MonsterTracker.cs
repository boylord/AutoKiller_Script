using StealthAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public class MonsterTracker
    {
        private bool _cancel;
        private readonly Action<string> _messanger;

        public MonsterTracker(Action<string> messanger)
        {
            _messanger = messanger;
        }

        public async void AutoTrack()
        {
            Stealth.Client.SetFindDistance(2);
            while (!_cancel)
            {
                await TrackOnce();
                await Task.Delay(1000);
            }

            _cancel = false;
        }

        private async Task TrackOnce()
        {
            Stealth.Client.FindTypeEx(0xFFFF, 0xFFFF, Stealth.Client.GetGroundID(), false);
            var items = Stealth.Client.GetFindList();

            foreach (var item in items)
            {
                if (!Stealth.Client.IsNPC(item))
                {
                    continue;
                }

                if (Stealth.Client.GetNotoriety(item) > 2)
                {
                    while (Stealth.Client.GetType(item) > 0)
                    {
                        if (Stealth.Client.GetDistance(item) <= 2)
                        {
                            Stealth.Client.Attack(item);
                        }
                        else
                            break;

                        await Task.Delay(1000);
                    }
                }
            }
        }

        public void Cancel()
        {
            _cancel = true;
        }
    }
}
