using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKiller_Script
{
    public partial class Shell : UserControl
    {
        private readonly Action<string> _messanger;
        public Shell(Action<string> messanger)
        {
            InitializeComponent();
            _messanger = messanger;
        }

        private ScriptMain script
        {
            get; set;
        }

        IBuffHandler _buffHandler;
        private void Shell_Load(object sender, EventArgs e)
        {
            _buffHandler = new BuffHandler(_messanger);
            script = new ScriptMain(_messanger, _buffHandler);

            Buffs_comboBox.Items.Add("none");

            foreach(var item in BuffContextProvider.Buffs)
            {
                Buffs_comboBox.Items.Add(item.Title);
            }

            Buffs_comboBox.SelectedText = BuffContextProvider.Buffs.FirstOrDefault().Title;
            Buffs_comboBox.SelectedIndex = 0;
        }

        private bool _uiLocker = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_uiLocker)
            {
                button1.Enabled = false;
                _uiLocker = true;

                script.UseBandages = UseBandages_checkBox.Checked;
                script.Execute(ICQUIN_textBox.Text, ICQPassword_textBox.Text, TargetUINS_textBox.Text, LootDataString_textBox.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            script.Stop();
            button1.Enabled = true;
            _uiLocker = false;
        }
        
        private void BuffDivineFury_button_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;

            if (s.BackColor != Color.Brown)
            {
                s.BackColor = Color.Brown;
                _buffHandler.AddBuffToQueue(BuffContextProvider.Buffs.FirstOrDefault(b => b.Title == s.Text));
            }
            else
            {
                _buffHandler.RemoveBuffFromQueue(BuffContextProvider.Buffs.FirstOrDefault(b => b.Title == s.Text));
                s.BackColor = Color.FromArgb(255,240,240,240);
            }
        }

        private void BuffCancelAllbutton_Click(object sender, EventArgs e)
        {
            _buffHandler.Cancel();

            BuffConsecrate_button.BackColor = Color.FromArgb(255, 240, 240, 240);
            BuffDivineFury_button.BackColor = Color.FromArgb(255, 240, 240, 240);
            BuffEnemyOfOne_button.BackColor = Color.FromArgb(255, 240, 240, 240);
        }
    }
}
