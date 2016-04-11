using System;


namespace Shapes
{
    public interface IPointy
    {
        uint NumberOfPoints();
    }

    public interface IPrintable
    {
        void PrintInfo();
    }

    public interface IMeasurable
    {
        double GetArea();
    }

    public interface IPolygone : IPointy, IMeasurable
    {
        int NumberOfDiagonals { get; }
    }

    public interface IPlottarable
    {
        void Draw();
    }

    public interface IScreenable
    {
        void Draw();
    }
}
