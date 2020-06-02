using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProfCSharp
{
    class Program
    {
        static void Main()
        {
            Form form = new Form
            {
                Width = 800,
                Height = 600
            };
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
