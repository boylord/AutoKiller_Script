using StealthAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public class ICQInformer
    {
        private readonly string _ICQPassword;
        private readonly uint _ICQUIN;
        private readonly Action<string> _messanger;

        public ICQInformer(Action<string> messanger, uint ICQUIN, string ICQPassword, IEnumerable<string> targets)
        {
            _messanger = messanger;
            _ICQUIN = ICQUIN;
            _ICQPassword = ICQPassword;

            _targets = new List<uint>();
            foreach(var target in targets)
            {
                uint id = 0;
                uint.TryParse(target, out id);
                if (id > 0)
                    _targets.Add(id);
            }
            
            Stealth.Client.ICQDisconnect += Client_ICQDisconnect;
            Stealth.Client.ICQError += Client_ICQError;
            Stealth.Client.ICQIncomingText += Client_ICQIncomingText;
        }

        private void Client_ICQIncomingText(object sender, ICQIncomingTextEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_ICQError(object sender, ICQErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_ICQDisconnect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_ICQConnect(object sender, EventArgs e)
        {
            ct.Cancel();
        }

        CancellationTokenSource ct;
        private readonly List<uint> _targets;

        public async void SendICQMessage(string message)
        {
            if(!Stealth.Client.ICQ_GetConnectedStatus())
            {
                Stealth.Client.ICQConnect += Client_ICQConnect;
                ct = new CancellationTokenSource();

                Stealth.Client.ICQ_Connect(_ICQUIN, _ICQPassword);
                try
                {
                    await Task.Delay(20000, ct.Token);
                }
                catch (TaskCanceledException) {
                    _messanger?.Invoke("[Information] ICQ Connected");
                }
                Stealth.Client.ICQConnect -= Client_ICQConnect;
            }

            if (Stealth.Client.ICQ_GetConnectedStatus())
            {
                foreach (var target in _targets)
                {
                    Stealth.Client.ICQ_SendText(target, message);
                    await Task.Delay(1000);
                }
            }else
            {
                _messanger?.Invoke("[Error] ICQ failed to connect!");
            }
        }



    }
}
