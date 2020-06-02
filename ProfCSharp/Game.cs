using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProfCSharp
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game() { }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            foreach (BaseObject obj in _bkgr) obj.Draw();
            Buffer.Render();
        }
        public static BaseObject[] _objs;
        public static BaseObject[] _bkgr;
        public static void Load()
        {
            _objs = new BaseObject[30];
            _bkgr = new BaseObject[30];
            for (int i = 0; i < _objs.Length / 2; i++)
            {
                _objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            }
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                _objs[i] = new Star(new Point(600, i * 20), new Point(i, 0), new Size(5, 5));
            }
            for (int i = 0; i < _bkgr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    _bkgr[i] = new Comet(new Point(600, i * 20), new Point(i / 2 + 1, 0), new Size(30, 10));
                }
                else
                {
                    _bkgr[i] = new Meteor(new Point(600, i * 20), new Point(i * 2 + 1, 10), new Size(10, 10));
                }
            } 
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (BaseObject obj in _bkgr)
                obj.Update();
        }
    }
}
