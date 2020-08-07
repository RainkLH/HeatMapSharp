using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleDebug;
using HeatMap;

namespace DemoForm
{
    public partial class Form1 : Form
    {
        static MockDatasGen datasGen;

        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = 500;
            TextExample(500);
        }

        private void TextExample(int count)
        {
            var sw = new Stopwatch();
            sw.Start();
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;
            pictureBox1.Image = Example1(w, h, count);
            sw.Stop();
            label1.Text = $@"TotalSeconds{sw.Elapsed.TotalSeconds}";
            textBox1.Text += $@"Total {count}, TotalSeconds{sw.Elapsed.TotalSeconds}";
            textBox1.Text += Environment.NewLine;
        }
        private void TextExample2(int count)
        {
            var sw = new Stopwatch();
            sw.Start();
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;
            pictureBox1.Image = Example2(w, h, count);
            sw.Stop();
            label1.Text = $@"TotalSeconds{sw.Elapsed.TotalSeconds}\n";
            textBox1.Text +=  $@"Total {count}, TotalSeconds{sw.Elapsed.TotalSeconds}";
            textBox1.Text += Environment.NewLine;
        }

         Bitmap Example1(int width,int height,int count)
        {
            datasGen = new MockDatasGen(width, height);
            List<DataType> datas = datasGen.CreateMockDatas(count);
            HeatMapImage heatMapImage = new HeatMapImage(width, height, 200, 50);
            var sw = new Stopwatch();
            sw.Start();
            heatMapImage.SetDatas(datas);
            sw.Stop();
            textBox1.Text +=  $@"Set Data, TotalSeconds{sw.Elapsed.TotalSeconds}";
            textBox1.Text += Environment.NewLine;
            return heatMapImage.GetHeatMap();
        }
         Bitmap Example2(int width, int height,int count)
        {
            datasGen = new MockDatasGen(width, height);
            HeatMapImage heatMapImage = new HeatMapImage(width, height, 200, 50);
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                DataType data = datasGen.CreateAData();
                heatMapImage.SetAData(data);
            }
            sw.Stop();
            textBox1.Text += $@"Set Data, TotalSeconds{sw.Elapsed.TotalSeconds}";
            textBox1.Text += Environment.NewLine;
            return  heatMapImage.GetHeatMap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var count = (int) numericUpDown1.Value;
            TextExample(count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var count = (int)numericUpDown1.Value;
            TextExample2(count);
        }
    }
}
