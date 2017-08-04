using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TestClient
{
    public partial class Form1 : Form
    {
        public const int BUFFERSIZE = 64 * 1024;
        private byte[] buffer = new byte[BUFFERSIZE];

        private List<string> MsgList = new List<string>();
        private delegate void MyDelegate();

        private Socket MySorcket;
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            ConnectServer();
        }

        private void ConnectServer()
        {
            if (MySorcket == null)
            {
                MySorcket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    MySorcket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    if (MySorcket != null)
                    {
                        MySorcket.NoDelay = true;
                        MySorcket.Connect(IPBox.Text, int.Parse(PortBox.Text));

                        if (MySorcket.Connected)
                        {
                            Receive();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace);
                }
            }

            Thread thread = new Thread(MyInvoke);
            thread.Start();
        }
        private void Receive()
        {
            if (MySorcket.Connected)
            {
                MySorcket.BeginReceive(buffer, 0, BUFFERSIZE, 0, new AsyncCallback(ReceiveCallback), null);
            }
        }
        private void ReceiveCallback(IAsyncResult ar)
        {

            int bytesRead = MySorcket.EndReceive(ar);
            if (bytesRead > 0)
            {
                ProcessPacket(buffer, bytesRead);
                Receive();
            }
        }

        private MemoryStream memStream;
        private BinaryReader reader;
        void ProcessPacket(byte[] bytes, int length)
        {
            try
            {
                memStream.Seek(0, SeekOrigin.End);
                memStream.Write(bytes, 0, length);
                memStream.Seek(0, SeekOrigin.Begin);
                while (memStream.Length - memStream.Position >= 2)
                {
                    byte[] lendata = reader.ReadBytes(2);
                    Array.Reverse(lendata);
                    int messageLen = BitConverter.ToUInt16(lendata, 0);
                    if (memStream.Length - memStream.Position >= messageLen - 2)
                    {
                        byte[] data = reader.ReadBytes(messageLen);
                        string target = System.Text.Encoding.UTF8.GetString(data);
                        MsgList.Add(target);
                    }
                    else
                    {
                        memStream.Position = memStream.Position - 2;
                    }
                }
                byte[] leftover = reader.ReadBytes((int)(memStream.Length - memStream.Position)); //将剩余的数据读出来
                memStream.SetLength(0);  //清空缓存
                memStream.Write(leftover, 0, leftover.Length);
            }
            catch (Exception e)
            {
                string error = "ProcessPacket error=" + e.StackTrace;
                MsgList.Add(error);
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SendBox.Text)) return;
            byte[] msgArray = System.Text.Encoding.UTF8.GetBytes(SendBox.Text);
            MySorcket.Send(msgArray);
        }

        private void MyInvoke()
        {
            this.Invoke(new MyDelegate(MessageOprater));
        }

        private void MessageOprater()
        {
            if (MsgList.Count > 0)
            {
                string target = MsgList[0];
                MsgList.RemoveAt(0);
                if (string.IsNullOrEmpty(MsgBox.Text))
                {
                    MsgBox.Text = target;
                }
                else
                {
                    MsgBox.Text += "/n" + target;
                }
            }
        }
    }
}
