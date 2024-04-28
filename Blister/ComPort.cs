using Blister.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;

namespace Blister
{
    public partial class ComPort : Form
    {
        private Thread threadModbusManager = null; // Thread for managing tcp ip connection with tcp ip server.
        public AyarForm AyarFrm;
        public Sifre SifreFrm;
        private DateTime lastDateTime = DateTime.Now;

        private string customMessageBoxTitle;
        string logDosyaPath = "";
        string[] cozunurluk = new string[2];

        bool connectionModbusState = true;
        byte[] serial1ByteArray = new byte[8];
        byte[] arrayRx1 = new byte[256];
        int counterRxByte1 = 0;

        int productCounter = 0;
        public int yetki;

        public ComPort()
        {
            this.AyarFrm = new AyarForm();
            this.AyarFrm.MainFrm = this;
            this.SifreFrm = new Sifre();
            this.SifreFrm.MainFrm = this;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.customMessageBoxTitle = Ayarlar.Default.projectName;
            this.projectNameTxt.Text = customMessageBoxTitle;
            this.Text = customMessageBoxTitle;

            foreach (string portName in SerialPort.GetPortNames())
            {
                this.AyarFrm.SerialPort1Com.Items.Add((object)portName);
            }

            this.logDosyaPath = Ayarlar.Default.txtLogDosya;
            this.serialPort1.PortName = Ayarlar.Default.SerialPort1Com;
            this.serialPort1.BaudRate = Ayarlar.Default.SerialPort1Baud;
            this.serialPort1.DataBits = Ayarlar.Default.SerialPort1dataBits;
            this.serialPort1.StopBits = Ayarlar.Default.SerialPort1stopBit;
            this.serialPort1.Parity = Ayarlar.Default.SerialPort1Parity;
            this.serialPort1.ReceivedBytesThreshold = 1;
           
            this.timerAdmin.Interval = Ayarlar.Default.timerAdmin;  //Ayarlar Süresi İçin
            this.loopTimer.Interval = 1000;    //loop Süresi İçin

            this.yetki = 0;
            this.yetkidegistir();
            
             if (Ayarlar.Default.chBoxSerial1)
             {
                 try
                 {
                     this.serialPort1.DtrEnable = true;
                     this.serialPort1.Open();
                     lblStatusCom1.Text = "ON";
                     lblStatusCom1.BackColor = Color.Green;
                 }
                 catch (Exception ex)
                 {
                     int num2 = (int)MessageBox.Show("Com1 Port Hatası: " + ex.ToString());
                     lblStatusCom1.Text = "OFF";
                     lblStatusCom1.BackColor = Color.Red;
                 }
             }
            Connection();
        }

        //DataAvailable //Gerek Yok

        public bool Connected
        {
            get
            {
                if (connectionModbusState)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Connection()
        {
            try
            {
                if (connectionModbusState)
                {
                    loopTimer.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return true;
        }

        public bool notConnection()
        {
            try
            {
                this.serialPort1.Close();
                //?  njCompolet1.WriteVariable("connectionStart", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return true;
        }

        public void loopTimer_Tick(object sender, EventArgs e)
        {
            threadModbusManager = new Thread(threadModbusManagerFunction);
            threadModbusManager.Start();
        }

        private void threadModbusManagerFunction()
        {
            if (threadModbusManager != null)
            {
                if (connectionModbusState)
                {
                    try
                    {
                    }
                    catch
                    {
                        ConsoleAppendLine("Thread Fonksiyonu İçinde ReadData Hatası", Color.Red);
                    }
                }
                else
                {
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            setProduction(int.Parse(comboBoxSelectedProductCode.Text), int.Parse(textBoxSelectedProductAmount.Text));
        }

        public void setProduction(int productCode, int amount)
        {
            if (connectionModbusState)
            {
                try
                {
                   serialWriteByte1(1, productCode, amount);   //Üretim Kodu, ve Miktarı
                }
                catch (Exception ex)
                {
                    ConsoleAppendLine("Hata Oluştu", Color.Red);
                    CustomMessageBox.ShowMessage("Hata Oluştu", Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
                }
            }
            else
            {
                ConsoleAppendLine("ModBus Bağlantısı Yok", Color.Red);
                CustomMessageBox.ShowMessage("ModBus Bağlantısı Yok", Ayarlar.Default.projectName, MessageBoxButtons.OK, CustomMessageBoxIcon.Error, Color.Red);
            }
        }

        // public void startProduction()  //Gerek Yok
        // public void stopProduction()   //Gerek Yok
        //public void Stop()   //Gerek Yok
        //ReadData()  //Gerek Yok
        //ReadResult()   //Gerek Yok
        //ReadDataAvailable()  //Gerek Yok
        //ReadProductionMonitorData()  //Gerek Yok
        //GetData()  //Gerek Yok
        //public void SetBarcode(string Barcode) //Gerek Yok

        private void serialWriteByte1(byte addr, int value1, int value2)
        {
            dataConvertProductCode(value1);
            dataConvertAmount(value2);
            serial1ByteArray[0] = 1;
            serial1ByteArray[1] = 0;
            serialPort1.Write(serial1ByteArray, 0, 8);
          for(int i = 0; i< 8; i++)
          {
            ConsoleAppendLine("" + Convert.ToByte(serial1ByteArray[i]), Color.Green);
          }
            
            ConsoleAppendLine("COM1'den gitti.", Color.Blue);
        }

        public void dataConvertProductCode(int value)
        {
            byte data2 = (byte)(value >> 16);
            serial1ByteArray[7] = data2;
            int sayi16 = (int)(value - data2 * 256 * 256);
            byte data3 = (byte)(sayi16 >> 8);
            serial1ByteArray[6] = data3;
            int sayi8 = (int)(sayi16 - data3 * 256);
            byte data4 = (byte)(sayi8);
            serial1ByteArray[5] = data4;
            //  textBoxSelectedProductAmount.Text = Convert.ToString(data1 * 256 * 256 * 256 + data2 * 256 * 256 + data3 * 256 + data4);
        }
        public void dataConvertAmount(int value)
        {
            byte data3 = (byte)(value >> 8);
            serial1ByteArray[4] = data3;
            int sayi8 = (int)(value - data3 * 256);
            byte data4 = (byte)(sayi8);
            serial1ByteArray[3] = data4;
            //  textBoxSelectedProductAmount.Text = Convert.ToString(data1 * 256 * 256 * 256 + data2 * 256 * 256 + data3 * 256 + data4);
        }
        /*byte data1 = (byte)(value >> 24);
            serial1ByteArray[7] = data1;
            int sayi24 = (int)(value - data1 * 256 * 256 * 256);
            byte data2 = (byte)(value >> 16);
            serial1ByteArray[6] = data2;
            int sayi16 = (int)(sayi24 - data2 * 256 * 256);
            byte data3 = (byte)(sayi16 >> 8);
            serial1ByteArray[5] = data3;
            int sayi8 = (int)(sayi16 - data3 * 256);
            byte data4 = (byte)(sayi8);
            serial1ByteArray[4] = data4;*/

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (serialPort1.BytesToRead > 0)
            {
                arrayRx1[counterRxByte1] = Convert.ToByte(serialPort1.ReadByte());
                counterRxByte1++;
                Thread.Sleep(100);
            }
            this.Invoke(new EventHandler(ShowData1));
        }

        private void ShowData1(object sender, EventArgs e)
        {
            for (int i = 0; i < counterRxByte1; i++)
            {
                ConsoleAppend("' " + Convert.ToByte(arrayRx1[i]) + "' ", Color.Green);
            }
            ConsoleAppendLine("COM1'den geldi.", Color.Green);
            ConsoleNewLine();

            justFeedbackCheck();
        }

        private void justFeedbackCheck()
        {
            if (arrayRx1[0] == 2 && arrayRx1[2] == 1)  //sayac++
            {
                productCounter++;
                txProductedAmount.Text = Convert.ToString(productCounter);
                Thread.Sleep(1000);
                serial1ByteArray[2] = 1;
                setProduction(int.Parse(comboBoxSelectedProductCode.Text), int.Parse(textBoxSelectedProductAmount.Text));
            }
           else if (arrayRx1[0] == 2 && arrayRx1[2] == 2)  //sayac+2
            {
                productCounter = productCounter + 2;
                txProductedAmount.Text = Convert.ToString(productCounter);
                Thread.Sleep(1000);
                serial1ByteArray[2] = 1;
                setProduction(int.Parse(comboBoxSelectedProductCode.Text), int.Parse(textBoxSelectedProductAmount.Text));
            }
            else if (arrayRx1[0] == 2 && arrayRx1[2] == 0)  //sayac++
            {
                Thread.Sleep(1000);
                serial1ByteArray[2] = 0;
                setProduction(int.Parse(comboBoxSelectedProductCode.Text), int.Parse(textBoxSelectedProductAmount.Text));
            }

            if (arrayRx1[0] == 2 && arrayRx1[1] == 0)  //Makine Çalışmıyor
            {
                textBoxStatus.Text = "Makine Çalışmıyor";
                textBoxStatus.BackColor = Color.Red;
            }
            else if (arrayRx1[0] == 2 && arrayRx1[1] == 1)  //Üretim Devam Ediyor
            {
                textBoxStatus.Text = "Üretim Devam Ediyor";
                textBoxStatus.BackColor = Color.Green;
            }
            else if (arrayRx1[0] == 2 && arrayRx1[1] == 2)  //Üretim Durdu
            {
                textBoxStatus.Text = "Üretim Durdu";
                textBoxStatus.BackColor = Color.Yellow;
            }
            else if (arrayRx1[0] == 2 && arrayRx1[1] == 3) //Üretim Bitti
            {
                textBoxStatus.Text = "Üretim Bitti";
                textBoxStatus.BackColor = Color.Red;
                productCounter = 0;
                txProductedAmount.Text = Convert.ToString(productCounter);
            }
            serialBufferClear();
        }

        private void serialBufferClear()
        {
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            for (int i = 0; i <= counterRxByte1; i++)
            {
                arrayRx1[i] = 0x0;
            }
            counterRxByte1 = 0;
        }

        /*******************************************************************************************/
        private void rtbConsole_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            rtb.SelectionStart = rtb.Text.Length;
            rtb.ScrollToCaret();
        }

        private void ConsoleAppend(string text, Color color)
        {
            if (rtbConsole.InvokeRequired)
            {
                rtbConsole.Invoke(new Action(delegate ()
                {
                    rtbConsole.Select(rtbConsole.TextLength, 0);
                    rtbConsole.SelectionColor = color;
                    rtbConsole.AppendText(text);  
                    rtbConsole.Select(rtbConsole.TextLength, 0);
                    rtbConsole.SelectionColor = Color.White;
                }));
            }
            else
            {
                rtbConsole.Select(rtbConsole.TextLength, 0);
                rtbConsole.SelectionColor = color;
                rtbConsole.AppendText(text);
                rtbConsole.Select(rtbConsole.TextLength, 0);
                rtbConsole.SelectionColor = Color.White;
            }
        }

        /*Kullanıcı Arayüzüne Yazı Yazılır*/
        private void ConsoleAppendLine(string text, Color color)
        {
            if (rtbConsole.InvokeRequired)
            {
                rtbConsole.Invoke(new Action(delegate ()
                {
                    rtbConsole.Select(rtbConsole.TextLength, 0);
                    rtbConsole.SelectionColor = color;
                    rtbConsole.AppendText(text + Environment.NewLine); 
                    rtbConsole.Select(rtbConsole.TextLength, 0);
                    rtbConsole.SelectionColor = Color.White;
                }));
            }
            else
            {
                rtbConsole.Select(rtbConsole.TextLength, 0);
                rtbConsole.SelectionColor = color;
                rtbConsole.AppendText(text + Environment.NewLine);
                rtbConsole.Select(rtbConsole.TextLength, 0);
                rtbConsole.SelectionColor = Color.White;
            }
        }

        /*Kullanıcı Arayüzünde Bir Satır Boşluk Bırakılır*/
        private void ConsoleNewLine()
        {
            if (rtbConsole.InvokeRequired)
            {
                rtbConsole.Invoke(new Action(delegate ()
                {
                    rtbConsole.AppendText(Environment.NewLine);
                }));
            }
            else
            {
                rtbConsole.AppendText(Environment.NewLine);
            }
        }

        private void ConsoleClean()
        {
            if (rtbConsole.InvokeRequired)
            {
                rtbConsole.Invoke(new Action(delegate ()
                {
                    rtbConsole.Text = "";
                    rtbConsole.Select(rtbConsole.TextLength, 0);
                    rtbConsole.SelectionColor = Color.White;
                }));
            }
            else
            {
                rtbConsole.Text = "";
                rtbConsole.Select(rtbConsole.TextLength, 0);
                rtbConsole.SelectionColor = Color.White;
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
            int num = (int)this.AyarFrm.ShowDialog();
        }

        public void yetkidegistir()
        {
            if (this.yetki == 0)
            {
                this.btnCikis.Enabled = false;
                this.btnAyar.Enabled = false;
                this.btnCikis.BackColor = Color.Beige;
                this.btnAyar.BackColor = Color.Beige;
            }
            if (this.yetki == 1)
            {
                this.btnCikis.Enabled = true;
                this.btnAyar.Enabled = true;
                this.btnCikis.BackColor = Color.Red;
                this.btnAyar.BackColor = Color.Red;
                timerAdmin.Start();
            }
            if (this.yetki == 2)
            {
                this.btnCikis.Enabled = true;
                this.btnCikis.BackColor = Color.Red;
                this.btnAyar.BackColor = Color.Beige;
                timerAdmin.Start();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.L)
                return;
            if (this.yetki != 0)
            {
                timerAdmin.Stop();
                this.yetki = 0;
                this.yetkidegistir();
            }
            else
            {
                int num = (int)this.SifreFrm.ShowDialog();
                textBox1.Clear();
            }
        }

        private void timerAdmin_Tick_1(object sender, EventArgs e)
        {
            timerAdmin.Stop();
            this.yetki = 0;
            this.yetkidegistir();
        }

        private void comboBoxSelectedProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxSelectedProductCode.Text == "10000000")
            {
                textBoxSelectedProductAmount.Text = "10";
            }
            else if (comboBoxSelectedProductCode.Text == "10000001")
            {
                textBoxSelectedProductAmount.Text = "20";
            }
            else if (comboBoxSelectedProductCode.Text == "10000002")
            {
                textBoxSelectedProductAmount.Text = "30";
            }
            else if (comboBoxSelectedProductCode.Text == "10000003")
            {
                textBoxSelectedProductAmount.Text = "40";
            }
            else if (comboBoxSelectedProductCode.Text == "10000004")
            {
                textBoxSelectedProductAmount.Text = "50";
            }
            else if (comboBoxSelectedProductCode.Text == "10000005")
            {
                textBoxSelectedProductAmount.Text = "60";
            }
            else if (comboBoxSelectedProductCode.Text == "10000006")
            {
                textBoxSelectedProductAmount.Text = "70";
            }
            else if (comboBoxSelectedProductCode.Text == "10000007")
            {
                textBoxSelectedProductAmount.Text = "80";
            }
            else if (comboBoxSelectedProductCode.Text == "10000008")
            {
                textBoxSelectedProductAmount.Text = "90";
            }
            else if (comboBoxSelectedProductCode.Text == "10000009")
            {
                textBoxSelectedProductAmount.Text = "100";
            }
        }
    }
}

