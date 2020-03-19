using System;
using System.Collections.Generic;
using System.Drawing;
using HeatMap;

namespace ConsoleDebug
{
    class Program
    {
        static MockDatasGen datasGen;
        const int WIDTH = 800;
        const int HEIGHT = 600;
        static void Main(string[] args)
        {
            Example2();
        }

        static void Example1()
        {
            Console.WriteLine("Create some mock datas");
            datasGen = new MockDatasGen(WIDTH, HEIGHT);
            List<DataType> datas = datasGen.CreateMockDatas(100);

            Console.WriteLine("Set datas");
            HeatMapImage heatMapImage = new HeatMapImage(WIDTH, HEIGHT, 200, 50);
            heatMapImage.SetDatas(datas);

            Console.WriteLine("Calculate and generate heatmap");
            Bitmap img = heatMapImage.GetHeatMap();

            img.Save("..\\..\\..\\..\\Images\\heatmap1.png");
        }
        static void Example2()
        {
            Console.WriteLine("Create some mock datas");
            datasGen = new MockDatasGen(WIDTH, HEIGHT);
            HeatMapImage heatMapImage = new HeatMapImage(WIDTH, HEIGHT, 200, 50);

            Console.WriteLine("Start generating data and recording");
            for (int i = 0; i < 200; i++)
            {
                DataType data = datasGen.CreateAData();
                heatMapImage.SetAData(data);

            }

            Console.WriteLine("Calculate and generate heatmap");
            Bitmap img = heatMapImage.GetHeatMap();

            img.Save("..\\..\\..\\..\\Images\\heatmap2.png");
        }
    }
}
