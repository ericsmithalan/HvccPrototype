namespace Rooler
{
    public struct IntPoint
    {
        public IntPoint(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public static bool operator ==(IntPoint point1, IntPoint point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        public static bool operator !=(IntPoint point1, IntPoint point2)
        {
            return !(point1 == point2);
        }

        public override bool Equals(object o)
        {
            if (o == null || !(o is IntPoint))
            {
                return false;
            }

            return Equals((IntPoint)o);
        }

        public bool Equals(IntPoint value)
        {
            return X == value.X && Y == value.Y;
        }

        public override int GetHashCode()
        {
            return (X.GetHashCode() ^ Y.GetHashCode());
        }

        public override string ToString()
        {
            return X + "," + Y;
        }
    }
}