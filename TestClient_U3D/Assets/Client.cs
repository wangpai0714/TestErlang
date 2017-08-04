using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.IO;
using System;

public class Client : MonoBehaviour
{

    public InputField IPText;
    public InputField PortText;
    public Button ConnectBtn;

    public InputField SendContent;
    public Button SendBtn;

    public InputField MsgBox;

    private Socket _Socket;
    public const int BUFFERSIZE = 64 * 1024;
    private byte[] buffer = new byte[BUFFERSIZE];

    private List<string> MsgList = new List<string>();

    // Use this for initialization
    void Start()
    {
        MsgBox.interactable = false;
        StartCoroutine(PaulTimer());
        ConnectBtn.onClick.AddListener(delegate () { ClickConnect(); });
        SendBtn.onClick.AddListener(delegate () { ClickSend(); });
        memStream = new MemoryStream();
        reader = new BinaryReader(memStream);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ClickConnect()
    {
        ConnectServer();
        ConnectBtn.interactable = false;
    }

    void ClickSend()
    {
        if (string.IsNullOrEmpty(SendContent.text))
        {
            MsgList.Add("不能发空消息！");
            return;
        }
        byte[] msgArray = System.Text.Encoding.UTF8.GetBytes(SendContent.text);
        _Socket.Send(msgArray);
    }

    private void ConnectServer()
    {
        if (_Socket == null)
        {
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (_Socket != null)
                {
                    _Socket.NoDelay = true;
                    _Socket.Connect(IPText.text, int.Parse(PortText.text));

                    if (_Socket.Connected)
                    {
                        Receive();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.StackTrace);
            }
        }
    }
    private void Receive()
    {
        if (_Socket.Connected)
        {
            _Socket.BeginReceive(buffer, 0, BUFFERSIZE, 0, new AsyncCallback(ReceiveCallback), null);
        }
    }
    private void ReceiveCallback(IAsyncResult ar)
    {

        int bytesRead = _Socket.EndReceive(ar);
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
            string error = "ProcessPacket error=" + e.StackTrace + "/t info=" + e.Message;
            MsgList.Add(error);
        }
    }

    private IEnumerator PaulTimer()
    {
        while (true)
        {
            if (MsgList.Count > 0)
            {
                string target = MsgList[0];
                MsgList.RemoveAt(0);
                if (string.IsNullOrEmpty(MsgBox.text))
                {
                    MsgBox.text = target;
                }
                else
                {
                    MsgBox.text += "\n" + target;
                }
            }
            yield return null;
        }
        yield return null;
    }
}
