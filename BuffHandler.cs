using AutoKiller_Script;
using StealthAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public struct BuffItem
    {
        public string Title;
        public ushort AttributeID;
        public int ManaNeeded;

        public BuffItem(string title, ushort attributeID, int manaNeeded)
        {
            Title = title;
            AttributeID = attributeID;
            ManaNeeded = manaNeeded;
        }
    }

    public static class BuffContextProvider
    {
        public static List<BuffItem> Buffs = new List<BuffItem>()
        {
            new BuffItem("Enemy of One", 1011, 17),
            new BuffItem("Divine Fury", 1010, 13),
            new BuffItem("Consecrate Weapon", 1082, 9)
    };
}

    public interface IBuffHandler
    {
        void AddBuffToQueue(BuffItem item);
        void RemoveBuffFromQueue(BuffItem item);

        void Cancel();
    }

    public class BuffHandler : IBuffHandler
    {
        private readonly Action<string> _messanger;
        private List<ushort> _buffIds;

        public BuffHandler(Action<string> messanger)
        {
            _messanger = messanger;
            _buffIds = new List<ushort>();
            AutoBuffSelf();
        }

        private bool _cancel { get; set; } = false;

        public void Cancel()
        {
            _cancel = true;
            _buffIds.Clear();
        }

        public async void AutoBuffSelf()
        {
            await BuffingInfiniteLoop();
        }

        private async Task BuffingInfiniteLoop()
        {
            _cancel = false;
            while (true)
            {
                if (_buffIds.Count > 0)
                {
                    var buffs = _buffIds.ToList();

                    foreach (var buff in buffs)
                    {
                        var tmpBuff = Stealth.Client.GetBuffBarInfo().FirstOrDefault(s => s.Attribute_ID == buff);
                        if (tmpBuff == null)
                        {
                            if (BuffContextProvider.Buffs.Find(s => s.AttributeID == buff).ManaNeeded <= Stealth.Client.GetSelfMana())
                            {
                                Stealth.Client.CastSpell(BuffContextProvider.Buffs.Find(s => s.AttributeID == buff).Title);
                                await Task.Delay(3000);
                            }
                        }
                    }
                }
                await Task.Delay(1000);
            }
        }

        public void AddBuffToQueue(BuffItem item)
        {   
            _buffIds.Add(item.AttributeID);
        }

        public void RemoveBuffFromQueue(BuffItem item)
        {   
            _buffIds.Remove(item.AttributeID);
        }
    }
}

