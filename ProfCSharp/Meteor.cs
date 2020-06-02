using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCSharp
{
    class Meteor : BaseObject
    {
        public Meteor(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.Red, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y);
        }
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
            }
        }
    }
}
