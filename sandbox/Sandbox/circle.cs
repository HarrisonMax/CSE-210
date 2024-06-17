class Circle
{
    private double _radius;
    public Circle(double radius = 0.0)
    {
        _radius = radius;
    }
    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}