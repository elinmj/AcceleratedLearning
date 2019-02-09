
namespace M6_Classes
{
    public class Rectangle
    {
        double _height;
        double _width;
        double _x;
        double _y;

        public Rectangle(double x, double y, double height, double width)
        {
            _x = x;
            _y = y;
            _height = height;
            _width = width;
        }

        public override string ToString()
        {
            return $"I'm a rectangle with x={_x}, y={_y}, height={_height} and width={_width}";
        }
    }
}
