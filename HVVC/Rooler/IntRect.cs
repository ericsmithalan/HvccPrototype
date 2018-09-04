using System;

namespace Rooler
{
    public struct IntRect
    {
        public IntRect(int left, int top, int width, int height) : this()
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public static bool operator ==(IntRect a, IntRect b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(IntRect a, IntRect b)
        {
            return !a.Equals(b);
        }

        public int Height { get; set; }

        public bool IsEmpty
        {
            get
            {
                return Left == 0 && Top == 0 && Width == 0 && Height == 0;
            }
        }

        public int Width { get; set; }

        public int Left { get; set; }
        public int Top { get; set; }

        public IntPoint TopLeft
        {
            get { return new IntPoint(Left, Top); }
        }

        public IntPoint BottomRight
        {
            get { return new IntPoint(Right, Bottom); }
        }

        public int Right
        {
            get { return Left + Width; }
        }

        public int Bottom
        {
            get { return Top + Height; }
        }

        public bool Equals(IntRect value)
        {
            return Left == value.Left && Width == value.Width && Top == value.Top && Height == value.Height;
        }

        public override bool Equals(object o)
        {
            if (o == null || !(o is IntRect))
            {
                return false;
            }

            return Equals((IntRect)o);
        }

        public override int GetHashCode()
        {
            if (IsEmpty)
            {
                return 0;
            }

            return (((Left.GetHashCode() ^ Top.GetHashCode()) ^ Width.GetHashCode()) ^ Height.GetHashCode());
        }

        public override string ToString()
        {
            return Left + "," + Top + "," + Width + "," + Height;
        }

        public void Union(IntRect rect)
        {
            if (IsEmpty)
            {
                this = rect;
            }
            else if (!rect.IsEmpty)
            {
                int left = Math.Min(Left, rect.Left);
                int top = Math.Min(Top, rect.Top);

                int right = Math.Max(Right, rect.Right);
                Width = Math.Max(right - left, 0);

                int bottom = Math.Max(Bottom, rect.Bottom);
                Height = Math.Max(bottom - top, 0);

                Left = left;
                Top = top;
            }
        }

        public static IntRect Empty
        {
            get { return new IntRect(); }
        }
    }
}