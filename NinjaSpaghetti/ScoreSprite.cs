﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaSpaghetti
{
    class ScoreSprite : Background
    {
        public Rectangle Surface;

        public ScoreSprite(Texture2D txr, int xpos, int ypos) : base(txr, xpos, ypos)
        {
            Surface = new Rectangle(xpos, ypos, txr.Width, txr.Height);
        }
    }
}
