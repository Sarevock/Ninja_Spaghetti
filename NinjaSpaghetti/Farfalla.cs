using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaSpaghetti
{
    class Farfalla
    {
        private Texture2D m_txr;
        public Rectangle CollisionRect;

        public Vector2 m_farfallaPos;
        public float m_speed;



        public Farfalla(Texture2D txr, int xpos, int ypos, float speed)
        {
            m_txr = txr;

            m_farfallaPos = new Vector2(xpos, ypos);
            CollisionRect = new Rectangle((int) m_farfallaPos.X,(int) m_farfallaPos.Y, m_txr.Width, m_txr.Height);
            m_speed = speed;
            
        }

        public void UpdateMe()
        {
            m_farfallaPos.X = m_farfallaPos.X + m_speed;

            CollisionRect.X = (int) m_farfallaPos.X;
            CollisionRect.Y = (int) m_farfallaPos.Y;
        }
        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_txr, m_farfallaPos, Color.White);
        }
    }
}
