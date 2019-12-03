using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaSpaghetti
{
    class Platform : Background
    {
        public Rectangle Surface;

        public Platform(Texture2D txr, int xpos, int ypos) : base (txr, xpos, ypos)
        {
            Surface = new Rectangle(xpos, ypos, txr.Width, txr.Height);
        }
    }
}
