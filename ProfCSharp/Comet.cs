using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCSharp
{
    class Comet : BaseObject
    {
        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.Blue, Pos.X, Pos.Y + (Size.Height / 2), Pos.X + Size.Width, Pos.Y);
            Game.Buffer.Graphics.DrawLine(Pens.Blue, Pos.X, Pos.Y - (Size.Height / 2), Pos.X + Size.Width, Pos.Y);
            Game.Buffer.Graphics.DrawLine(Pens.Blue, Pos.X, Pos.Y + (Size.Height / 2), Pos.X, Pos.Y - (Size.Height / 2));
        }
        public override void Update()
        {
            Pos.X -= Dir.X;
            Pos.Y -= Dir.Y;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
            }
            if (Pos.Y < 0)
            {
                Pos.Y = Game.Height + Size.Height;
            }
        }
    }
}
