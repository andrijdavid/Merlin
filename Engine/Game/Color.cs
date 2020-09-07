using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game
{
    public class Color
    {
        public static Color SKYBLUE { get { return Raylib_cs.Color.SKYBLUE; } }
        public static Color BROWN { get { return Raylib_cs.Color.BROWN; } }
        public static Color BEIGE { get { return Raylib_cs.Color.BEIGE; } }
        public static Color DARKPURPLE { get { return Raylib_cs.Color.DARKPURPLE; } }
        public static Color VIOLET { get { return Raylib_cs.Color.VIOLET; } }
        public static Color PURPLE { get { return Raylib_cs.Color.BROWN; } }
        public static Color DARKBLUE { get { return Raylib_cs.Color.BROWN; } }
        public static Color BLUE { get { return Raylib_cs.Color.BROWN; } }
        public static Color BLACK { get { return Raylib_cs.Color.BROWN; } }
        public static Color DARKGREEN { get { return Raylib_cs.Color.BROWN; } }
        public static Color LIME { get { return Raylib_cs.Color.BROWN; } }
        public static Color GREEN { get { return Raylib_cs.Color.BROWN; } }
        public static Color MAROON { get { return Raylib_cs.Color.BROWN; } }
        public static Color RED { get { return Raylib_cs.Color.BROWN; } }
        public static Color PINK { get { return Raylib_cs.Color.BROWN; } }
        public static Color ORANGE { get { return Raylib_cs.Color.BROWN; } }
        public static Color GOLD { get { return Raylib_cs.Color.BROWN; } }
        public static Color YELLOW { get { return Raylib_cs.Color.BROWN; } }
        public static Color DARKGRAY { get { return Raylib_cs.Color.BROWN; } }
        public static Color GRAY { get { return Raylib_cs.Color.BROWN; } }
        public static Color LIGHTGRAY { get { return Raylib_cs.Color.BROWN; } }
        public static Color BLANK { get { return Raylib_cs.Color.BROWN; } }
        public static Color MAGENTA { get { return Raylib_cs.Color.BROWN; } }
        public static Color RAYWHITE { get { return Raylib_cs.Color.BROWN; } }
        public static Color DARKBROWN { get { return Raylib_cs.Color.BROWN; } }
        public static Color WHITE { get { return Raylib_cs.Color.BROWN; } }
        public int R { get; private set; }
        public int A { get; private set; }
        public int B { get; private set; }
        public int G { get; private set; }
        public Color(int r, int g, int b) : this(r, g, b, 1)
        {

        }
        public Color(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = 0;
        }

        public static implicit operator Raylib_cs.Color(Color c) => new Raylib_cs.Color(c.R, c.G, c.B, c.A);
        public static implicit operator Color(Raylib_cs.Color c) => new Color(c.r, c.g, c.b, c.a);
    }
}
