using System.ComponentModel.Design;

namespace AdventOfCode2021.Models;


//This would have been cleaner as inheritance (three derived types for each line)
internal class Line
{
    public Coordinate StartPoint { get; private set; }
    public Coordinate EndPoint { get; private set; }
    public LineType Type { get; private set; }


    public Line(int x1, int y1, int x2, int y2)
    {
        StartPoint = new Coordinate(x1, y1);
        EndPoint = new Coordinate(x2, y2);

        DetermineLineType();
    }

    private void DetermineLineType()
    {
        if (StartPoint.X != EndPoint.X && StartPoint.Y == EndPoint.Y)
            Type = LineType.Horizontal;
        else if (StartPoint.Y != EndPoint.Y && StartPoint.X == EndPoint.X)
            Type = LineType.Vertical;
        else 
            Type = LineType.Diagonal;
    }

    public IEnumerable<Coordinate> GetAllCoordinates()
    {
        switch (Type)
        {
            case LineType.Horizontal:
            {
                var (startPoint, endPoint) = NormalizeStartAndEndPoint(StartPoint.X, EndPoint.X);

                return Enumerable.Range(startPoint, (endPoint - startPoint + 1))
                    .Select(point => new Coordinate(point, StartPoint.Y));
            }
            case LineType.Vertical:
            {
                var (startPoint, endPoint) = NormalizeStartAndEndPoint(StartPoint.Y, EndPoint.Y);

                return Enumerable.Range(startPoint, (endPoint - startPoint + 1))
                    .Select(point => new Coordinate(StartPoint.X, point));
            }
            case LineType.Diagonal:
            {
                return GetDiagonalPoints();
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerable<Coordinate> GetDiagonalPoints()
    {
        var (startCoord, endCoord) = NormalizeDiagonalCoords(StartPoint, EndPoint);

        if (startCoord.Y < endCoord.Y)
        {
            return PointsForDownhillSlope(startCoord, endCoord);
        }
        else
        {
            return PointsForUphillSlope(startCoord, endCoord);
        }
    }

    private IEnumerable<Coordinate> PointsForDownhillSlope(Coordinate startCoord, Coordinate endCoord)
    {
        var coords = new List<Coordinate>();
        var startPointX = startCoord.X;
        var startPointY = startCoord.Y;
        var endPointX = endCoord.X;
        var endPointY = endCoord.Y;

        while (startPointX <= endPointX && startPointY <= endPointY)
        {
            coords.Add(new Coordinate(startPointX, startPointY));
            startPointX++;
            startPointY++;
        }

        return coords;
    }

    private IEnumerable<Coordinate> PointsForUphillSlope(Coordinate startCoord, Coordinate endCoord)
    {
        var coords = new List<Coordinate>();
        var startPointX = startCoord.X;
        var startPointY = startCoord.Y;
        var endPointX = endCoord.X;
        var endPointY = endCoord.Y;

        while (startPointX <= endPointX && startPointY >= endPointY)
        {
            coords.Add(new Coordinate(startPointX, startPointY));
            startPointX++;
            startPointY--;
        }

        return coords;
    }

    private static (int startPoint, int endPoint) NormalizeStartAndEndPoint(int startOnAxis, int endOnAxis)
    {
        return startOnAxis >= endOnAxis ? (endOnAxis, startOnAxis) : (startOnAxis, endOnAxis);
    }

    private static (Coordinate start, Coordinate endPoint) NormalizeDiagonalCoords(Coordinate startPoint, Coordinate endPoint)
    {
        return startPoint.X > endPoint.X ? (endPoint, startPoint) : (startPoint, endPoint);
    }
}

public enum LineType
{
    Vertical, 
    Horizontal,
    Diagonal
}