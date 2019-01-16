namespace M6_Classes
{
    public class Triangle
    {
        double _x;
        double _y;
        double _baselength;
        double _height;

        public Triangle(double x, double y, double baselength, double height)
        {
            _x = x;
            _y = y;
            _baselength = baselength;
            _height = height;
        }

        public override string ToString()
        {
            return $"I'm a triangle with x={_x}, y={_y}, baselength={_baselength} and height={_height}";
        }
    }
}
