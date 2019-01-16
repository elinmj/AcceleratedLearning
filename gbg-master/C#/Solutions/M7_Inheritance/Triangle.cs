
namespace M7_Inheritance
{
    public class Triangle : Shape
    {
        double _baselength;
        double _height;

        public Triangle(double baselength, double height)
        {
            _baselength = baselength;
            _height = height;
        }

        public override string ToString()
        {
            return $"I'm a triangle with baselength={_baselength} and height={_height}";
        }

        public override double CalculateArea()
        {
            return _baselength * _height / 2;
        }
    }
}
