using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QQ2020
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public String SendRequestByGetMethod(String url, Encoding encoding)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), encoding);
            return sr.ReadToEnd();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            calcWea();
        }

        private void SetGifBackground(string strGif)
        {
            Image gif = Image.FromFile(@strGif);
            System.Drawing.Imaging.FrameDimension fd = new System.Drawing.Imaging.FrameDimension(gif.FrameDimensionsList[0]);
            int count = gif.GetFrameCount(fd);    //获取帧数(gif图片可能包含多帧，其它格式图片一般仅一帧)
            Timer timer1 = new Timer();
            timer1.Interval = 100;
            int i = 0;
            Image bgImg = null;
            timer1.Tick += (s, e) =>
            {
                if (i >= count) { i = 0; }
                gif.SelectActiveFrame(fd, i);
                System.IO.Stream stream = new System.IO.MemoryStream();
                gif.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (bgImg != null) { bgImg.Dispose(); }
                bgImg = Image.FromStream(stream);
                this.BackgroundImage = bgImg;
                i++;
            };
            timer1.Start();
        } // 窗体加载动图的方法

        private void calcWea()
        {
            string request = SendRequestByGetMethod("http://v.juhe.cn/weather/index?format=2&dtype=xml&cityname=成都&key=efc6c4da1fe8094d19be7c59e5706c70", Encoding.UTF8);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(request);
            XmlElement xmlRoot = doc.DocumentElement;
            XmlNode node = xmlRoot.ChildNodes[2];
            XmlNode today = node.ChildNodes[1];
            lblDegree.Text = today.ChildNodes[0].InnerText;
            lblWeather.Text = today.ChildNodes[1].InnerText;
            lblAir.Text = today.ChildNodes[3].InnerText;

            XmlNode future = node.ChildNodes[2];
            XmlNode item = future.ChildNodes[0];
            lblTodayDegree.Text = item.ChildNodes[0].InnerText;
            List<char> list = item.ChildNodes[1].InnerText.ToList<char>();
            if (list.Contains('雨'))
            {
                picTodayWeather.Image = Properties.Resources.yutian;
                SetGifBackground("雨.gif");
            }
            else if (list.Contains('云'))
            {
                picTodayWeather.Image = Properties.Resources.yintian;
                SetGifBackground("云.gif");
            }
            else if (list.Contains('晴'))
            {
                picTodayWeather.Image = Properties.Resources.qingtian;
                SetGifBackground("晴.gif");
            }
            item = future.ChildNodes[1];
            lblTomorrowDegree.Text = item.ChildNodes[0].InnerText;
            list = item.ChildNodes[1].InnerText.ToList<char>();
            if (list.Contains('雨'))
                picTomorrowWeather.Image = Properties.Resources.yutian;
            else if (list.Contains('云'))
                picTomorrowWeather.Image = Properties.Resources.yintian;
            else if (list.Contains('晴'))
                picTomorrowWeather.Image = Properties.Resources.qingtian;

            item = future.ChildNodes[2];
            lblNextTomorrowDegree.Text = item.ChildNodes[0].InnerText;
            list = item.ChildNodes[1].InnerText.ToList<char>();
            if (list.Contains('雨'))
                picNextTomorrow.Image = Properties.Resources.yutian;
            else if (list.Contains('云'))
                picNextTomorrow.Image = Properties.Resources.yintian;
            else if (list.Contains('晴'))
                picNextTomorrow.Image = Properties.Resources.qingtian;
            
        }
    }
}
