using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public enum MessagesTypes
    {
        Error,
        Info,
        Success
    }

    public class BaseMessanger
    {
        private readonly List<Action<string>> _senderAction;

        public BaseMessanger(List<Action<string>> senderActions)
        {
            _senderAction = senderActions;
        }

        public void SendInfoMessage(string message)
        {

        }

        
    }
}
