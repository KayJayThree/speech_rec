using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
//using System.Speech.Synthesis.Ins4talledVoice;


namespace speech_rec
{
    public partial class Form1 : Form
    {

        //SpeechSynthesizer speaker = new SpeechSynthesizer();
        //bool flag = false;

        public Form1()
        {
            InitializeComponent();

            //MessageBox.Show(reader.GetInstalledVoices().ToList().ToString());
            
            //////////////////////////////////////////
            //below fills Listbox Voice with available voices
            //List<string> MyVoice = new List<string>();
            //cbVoice.Items.AddRange(MyVoice.ToArray());
            //cbVoice.DataSource = MyVoice;
            foreach (InstalledVoice reader in reader.GetInstalledVoices())
            {
                cbVoice.Items.Add(reader.VoiceInfo.Name);
                
            }


        }

        SpeechSynthesizer reader = new SpeechSynthesizer();
        
  
        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                //added next line to get voice  09/10/2016  12:10am
                
                reader.SelectVoice(cbVoice.Text);
                reader.SpeakAsync(richTextBox1.Text);
                
            }
            else
            {
                MessageBox.Show("Please enter some text!");
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
                }
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(reader != null)
            {
                reader.Dispose();
            }
        }
        
        private void cbVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (InstalledVoice reader in reader.GetInstalledVoices())
            //{
            //    cbVoice.Items.Add(reader.VoiceInfo.Name);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
