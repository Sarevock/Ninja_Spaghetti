using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaSpaghetti
{
    class Background
    {
        private Vector2 m_position;
        private Texture2D m_txr;

        public Background(Texture2D txr, int xpos, int ypos)
        {
            m_txr = txr;
            m_position = new Vector2(xpos, ypos);
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_txr, m_position, Color.White);
        }
    }
}
