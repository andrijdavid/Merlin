using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game
{
    public class Message
    {

        private string text;
        private int x;
        private int y;
        private int fontSize;
        private int duration;
        private Color color;

        public Message(String text, int x, int y, int fontSize, Color color)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public Message(String text, int x, int y) : this(text, x, y, 20, Color.WHITE)
        {

        }

        public String GetText()
        {
            return this.text;
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public Color GetColor()
        {
            return this.color;
        }

        public int GetFontSize()
        {
            return fontSize;
        }

        public int RemainingRenderTimes()
        {
            return duration < 0 ? 0 : duration--;
        }
    }
}
