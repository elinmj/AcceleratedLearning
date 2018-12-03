using System;
using System.Collections.Generic;
using System.Text;

namespace Module6_2
{
    class Cube
    {
        public int height { get; set; }
        public int width { get; set; }
        public int depth { get; set; }
        public string color { get; set; }
        public string material { get; set; }

        public Cube(int h, int w, int d, string c, string m)
        {
            height = h;
            width = w;
            depth = d;
            color = c;
            material = m;
        }

        //public void WriteVolume()
        //{
        //    int volume = height * width * depth;
        //    Console.WriteLine($"The volume of the cube is {volume}");
        //}

        public int CalculateVolume()
        {
            int volume = height * width * depth;
            return volume;
        }

        public int CalculateArea()
        {
            int area = (2 * height * width) + (2 * width * depth) + (2 * height * depth);
            return area;
        }

        public string CubeColor()
        {
            return color;
        }

        public string CubeMaterial() 
        {
            return material;
        }
    }
}
