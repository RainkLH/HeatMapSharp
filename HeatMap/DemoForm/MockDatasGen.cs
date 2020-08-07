

using System;
using System.Collections.Generic;
using HeatMap;
using NumSharp;

namespace ConsoleDebug
{
    class MockDatasGen
    {
        private DataType tPt;
        private int W;
        private int H;

        public MockDatasGen(int w, int h)
        {
            W = w;
            H = h;
            tPt = new DataType() { X = -1, Y = -1, Weight = -1};
        }

        public List<DataType> CreateMockDatas(int nums)
        {
            List<DataType> datas = new List<DataType>();
            for (int i = 0; i < nums; i++)
            {
                if (tPt.X > 0 && tPt.Y > 0 && tPt.Weight > 0)
                {
                    double c = np.random.rand();
                    int x = 0, y = 0;
                    if (c < 0.85)
                    {
                        int l = np.random.randint(1, 50);
                        double d = 2 * np.random.rand() * np.pi;
                        x = (int)(l * Math.Cos(d));
                        y = (int)(l * Math.Sin(d));
                        x = tPt.X + x < 0 ? 0 - x : x;
                        y = tPt.Y + y < 0 ? 0 - y : y;
                        x = tPt.X + x >= W ? 0 - x : x;
                        y = tPt.Y + y >= H ? 0 - y : y;
                        tPt.X = tPt.X + x;
                        tPt.Y = tPt.Y + y;
                        tPt.Weight = np.random.rand() * 10;
                        DataType data = new DataType() { X = tPt.X, Y = tPt.Y, Weight = tPt.Weight };
                        datas.Add(data);
                    }
                    else
                    {
                        tPt.X = np.random.randint(1, W);
                        tPt.Y = np.random.randint(1, H);
                        tPt.Weight = np.random.rand() * 10;
                        DataType data = new DataType() { X = tPt.X, Y = tPt.Y, Weight = tPt.Weight };
                        datas.Add(data);
                    }
                }
                else
                {
                    tPt.X = np.random.randint(1, W);
                    tPt.Y = np.random.randint(1, H);
                    tPt.Weight = np.random.rand() * 10;
                    DataType data = new DataType() { X = tPt.X, Y = tPt.Y, Weight = tPt.Weight };
                    datas.Add(data);
                }
            }
            return datas;
        }

        public DataType CreateAData()
        {
            if (tPt.X > 0 && tPt.Y > 0 && tPt.Weight > 0)
            {
                double c = np.random.rand();
                int x = 0, y = 0;
                if (c < 0.85)
                {
                    int l = np.random.randint(1, 50);
                    double d = 2 * np.random.rand() * np.pi;
                    x = (int)(l * Math.Cos(d));
                    y = (int)(l * Math.Sin(d));
                    x = tPt.X + x < 0 ? 0 - x : x;
                    y = tPt.Y + y < 0 ? 0 - y : y;
                    x = tPt.X + x >= W ? 0 - x : x;
                    y = tPt.Y + y >= H ? 0 - y : y;
                    tPt.X = tPt.X + x;
                    tPt.Y = tPt.Y + y;
                    tPt.Weight = np.random.rand() * 10;
                    return tPt;
                }
                else
                {
                    tPt.X = np.random.randint(1, W);
                    tPt.Y = np.random.randint(1, H);
                    tPt.Weight = np.random.rand() * 10;
                    return tPt;
                }
            }
            else
            {
                tPt.X = np.random.randint(1, W);
                tPt.Y = np.random.randint(1, H);
                tPt.Weight = np.random.rand() * 10;
                return tPt;
            }
            
        }
    }
}
