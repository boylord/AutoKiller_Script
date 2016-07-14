using StealthAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public class AutoLooter
    {
        private readonly Action<string> _messanger;
        private bool _cancel;
        
        private IList<ushort> LootTypes { get; set; }
        private IList<string> LootTooltipValues { get; set; }

        public AutoLooter(Action<string> messanger, IEnumerable<object> lootTypes)
        {
            _messanger = messanger;

            LootTypes = new List<ushort>();
            LootTooltipValues = new List<string>();

            foreach (var type in lootTypes)
            {
                if (type is ushort)
                    LootTypes.Add((ushort)type);
                else if (type is string)
                    LootTooltipValues.Add(type.ToString());
                else
                    _messanger?.Invoke($"Couldn't resolve loot type {type.ToString()}, ignoring.");
            }

            Stealth.Client.ItemInfo += Client_ItemInfo;
            //Stealth.Client.DrawContainer += Client_DrawContainer;

            lootingQueue = new List<uint>();
            _backpackId = Stealth.Client.GetBackpackID();
        }

        private async void Client_DrawContainer(object sender, DrawContainerEventArgs e)
        {
            if(e.ModelGump == 9)
            {
                await Loot(e.ContainerId);
            }
        }

        private List<uint> lootingQueue { get; set; }

        private void Client_ItemInfo(object sender, ItemEventArgs e)
        {
            if(Stealth.Client.GetType(e.ItemId) == 0x2006 && Stealth.Client.GetDistance(e.ItemId) <= 2 && !lootingQueue.Contains(e.ItemId))
            {
                lootingQueue.Add(e.ItemId);
            }
        }

        public async void AutoLoot()
        {
            Stealth.Client.AddItemToContainer += Client_AddItemToContainer;
            while (!_cancel)
            {
                if(lootingQueue.Count > 0)
                {
                    foreach(var item in lootingQueue.ToList())
                    {
                        Stealth.Client.UseObject(item);
                        await Task.Delay(1000);
                        await Loot(item);
                    }
                }

                await Task.Delay(1000);
            }

            _cancel = false;
            Stealth.Client.AddItemToContainer -= Client_AddItemToContainer;
        }

        public void Cancel()
        {
            _cancel = true;
        }

        private uint _currMovingItem = 0;
        CancellationTokenSource ct;
        private readonly uint _backpackId;

        private async Task Loot(uint corpseId)
        {
            Stealth.Client.FindTypeEx(0xFFFF, 0xFFFF, corpseId, true);
            var itemsFound = Stealth.Client.GetFindList();

            foreach(var item in itemsFound)
            {
                bool transfer = false;
                if (LootTypes.Contains(Stealth.Client.GetType(item)))
                {
                    transfer = true;
                }

                if (!transfer)
                {
                    var tooltip = Stealth.Client.GetTooltip(item);
                    foreach(var tooltipValue in LootTooltipValues)
                    {
                        if (tooltip.ToLower().Contains(tooltipValue.ToLower()))
                        {
                            transfer = true;
                            break;
                        }
                    }
                }

                if(transfer)
                {
                    ct = new CancellationTokenSource();
                    _currMovingItem = item;
                    await Task.Delay(1000);

                    Stealth.Client.MoveItem(item, 0, _backpackId, 0, 0, 0);
                    try
                    {
                        await Task.Delay(5000, ct.Token);
                    }
                    catch (TaskCanceledException) { }
                }
            }

            //foreach (var type in LootTypes)
            //{
            //    Stealth.Client.FindTypeEx(type, 0xFFFF, corpseId, true);
            //    var itemsFound = Stealth.Client.GetFindList();

            //    foreach(var item in itemsFound)
            //    {
            //        ct = new CancellationTokenSource();
            //        _currMovingItem = item;
            //        await Task.Delay(1000);
            //        Stealth.Client.MoveItem(item, 0, _backpackId, 0,0,0);

            //        try
            //        {
            //            await Task.Delay(5000, ct.Token);
            //        }
            //        catch (TaskCanceledException){}
            //    }
            //}

            lootingQueue.Remove(corpseId);

        }

        private void Client_AddItemToContainer(object sender, AddItemToContainerEventArgs e)
        {
            if(_currMovingItem == e.ItemId)
            {
                ct.Cancel();
            }
        }
    }
}
