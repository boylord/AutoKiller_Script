using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public class AutoHealer
    {
        private readonly IHealer _healer;

        private bool _cancel = false;

        public AutoHealer(IHealer healer)
        {
            _healer = healer;            
        }

        public void Cancel()
        {
            _cancel = true;
        }

        public async void AutoHeal()
        {
            while (!_cancel)
            {
                await _healer.HealOnceAsync();
                await Task.Delay(1000);
            }
            _cancel = false;
        }

    }
}
