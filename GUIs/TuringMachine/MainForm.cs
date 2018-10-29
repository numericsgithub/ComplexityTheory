using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    public partial class MainForm : Form
    {
        TuringMachine machine;
        int counter = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void tbMoveFun_TextChanged(object sender, EventArgs e)
        {
            //Compile();
        }

        private string history = "";

        private void Compile()
        {
            history = "";
            counter = 0;
            lStepCount.Text = "Steps: 0";
            List<MoveFunktion> funktions;
            Band inputBand;
            try
            {
                funktions = TuringParser.ParseMoveFunctions(tbMoveFun.Text).ToList();
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message + "\r\n\r\n" + ex.StackTrace;
                return;
            }
            try
            {
                inputBand = TuringParser.ReadBaender(tbInputBand.Text)[0];
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message + "\r\n\r\n" + ex.StackTrace;
                return;
            }
            tbError.Text = "No Compile Errors";
            List<Band> baender = new List<Band>();
            baender.Add(inputBand);
            for (int i = 0; i < numBaender.Value; i++)
            {
                baender.Add(new Band());
            }
            machine = new TuringMachine(baender, funktions);
            DumpMachine();
        }

        private void DumpMachine()
        {
            if(machine != null)
            {
                rtCurBaenders.Clear();
                foreach (var item in machine.Baender)
                {
                    int len = rtCurBaenders.Text.Length;
                    rtCurBaenders.AppendText(item.ToString() + " [" + item.Index + "] = " + item.Current + "\r\n");
                    rtCurBaenders.Select(len + 1 + 2 * item.Index, 1);
                    rtCurBaenders.SelectionColor = Color.Red;
                    rtCurBaenders.Select();
                }
                rtCurBaenders.Select(0,0);
                rtCurBaenders.HideSelection = true;
                tbCurState.Text = machine.CurrentState;
                tbCurZeichen.Text = machine.CurrentChars.GetString();
            }
        }

        string lastfilename = "";

        private void GoToLine(int number)
        {
            number++;
            int position = 0;
            for (int i = 0; i < number - 1; i++)
            {
                position += this.tbMoveFun.Lines[i].Length + 2;
            }
            this.tbMoveFun.Select(position, this.tbMoveFun.Lines[number - 1].Length);
            this.tbMoveFun.ScrollToCaret();
            this.tbMoveFun.Select();
        }

        private void bStep_Click(object sender, EventArgs e)
        {
            lastfilename = "lolTOURINGBILD" + new Random().Next() + ".jpg";
            try
            {
                MoveFunktion moveFunktion = machine.PerformStep(true, (int)numImageSize.Value, lastfilename);
                if (moveFunktion == null)
                    return;
                GoToLine(moveFunktion.TB_INFO);
                pbCurState.Image = Image.FromFile(lastfilename);
                lStepCount.Text = "Steps: "+(++counter);
                history += "Step "+counter+": " + machine.CurrentChars.GetString() + " " + moveFunktion;
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message + "\r\n\r\n" + ex.StackTrace;
                return;
            }
            DumpMachine();
        }

        private void bFull_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                for (; i < numSteps.Value; i++)
                {
                    MoveFunktion moveFunktion = machine.PerformStep();
                    if (moveFunktion == null)
                    {
                        string lauf = "";
                        foreach (var item in machine.Functions)
                        {
                            lauf += item.COUNTER + "   " + item + "\r\n";
                        }
                        break;
                    }
                    moveFunktion.COUNTER++;
                    lStepCount.Text = "Steps: "+(++counter);
                    //history += "Schritt " + counter + ": Leseköpfe" + machine.CurrentChars.GetString() + " " + moveFunktion + "\r\n";
                    //foreach (var item in machine.Baender)
                    //{
                    //    history += "\t" + item.List.GetString().Replace("(","{").Replace(")","}")+"\r\n";
                    //}
                    //history += "\r\n";
                }
            }
            catch (Exception ex)
            {
                tbError.Text = "After the " + (i+1) + " Step: \r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace;
            }
            DumpMachine();
        }

        private void numBaender_ValueChanged(object sender, EventArgs e)
        {
            Compile();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Compile();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in System.IO.Directory.GetFiles(Environment.CurrentDirectory))
            {
                if(item.Contains("lolTOURINGBILD") && item.EndsWith(".jpg"))
                    try
                    {
                        System.IO.File.Delete(item);
                    }catch { }
            }
        }

        private int BackupNum = new Random().Next();

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.WriteAllText("HolyBackup"+ BackupNum + ".txt", tbMoveFun.Text);
            }
            catch
            {

            }
        }

        private void bCompile_Click(object sender, EventArgs e)
        {
            Compile();
        }

        private void pbCurState_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(pbCurState.ImageLocation);
            }
            catch { }
        }
    }
}
