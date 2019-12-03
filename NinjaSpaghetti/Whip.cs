using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaSpaghetti
{
    class Whip
    {
        private Texture2D m_txr;
        public Rectangle CollisionRect;
        public Whip(Texture2D txr, int xpos, int ypos)
        {
            m_txr = txr;
            CollisionRect = new Rectangle(xpos, ypos, m_txr.Width, m_txr.Height);
        }

        public void UpdateMe()
        {

        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_txr, CollisionRect, Color.White);
        }
    }
}
