using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaSpaghetti
{
    class Food
    {

        Texture2D m_txr;
        public Rectangle m_rect;

        public Vector2 m_position;
        Vector2 m_velocity;

        //Feet Rectangle
        private const int FOOTMARGIN = 3;
        private Rectangle m_feetPos;

        public Food(Texture2D txr, Random RNG, int MaxX,int minSpeed, int maxSpeed)
        {

            m_txr = txr;
            m_position = new Vector2(RNG.Next(0, MaxX), 120);
            m_rect = new Rectangle((int)m_position.X, (int)m_position.Y, txr.Width, txr.Height);

            m_velocity = new Vector2(RNG.Next(minSpeed, maxSpeed), 0);

            //Feet Rect
            m_feetPos = new Rectangle(m_rect.X + FOOTMARGIN, m_rect.Y + m_rect.Height - 2, m_rect.Width - (FOOTMARGIN * 2), 2);
        }
    
        public void UpdateMe(Rectangle screenSize, float gravity, int ground, List<Platform> platforms)
        {
            //Movement
            m_position = m_position + m_velocity;

            if (m_velocity.X == 0)
            {
                m_velocity.X = 1;
            }

            //Handle Enemies Wrap
            if (m_position.X + m_rect.Width < 0)
                m_position.X = screenSize.Width - 1;
            if (m_position.X > screenSize.Width)
                m_position.X = 1 - m_rect.Width;

            //Gravity
            if (m_rect.Bottom < ground)
            {
                if (m_velocity.Y < gravity * 15)
                    m_velocity.Y += gravity;
                for (int i = 0; i < platforms.Count; i++)
                    if (platforms[i].Surface.Intersects(m_feetPos))
                    {
                        if (m_velocity.Y > 0)
                        {
                            m_velocity.Y = 0;
                            m_position.Y = platforms[i].Surface.Top - m_rect.Height + 1;
                        }
                    }
            }
            else
            {
                m_velocity.Y = 0;
                m_position.Y = ground - m_rect.Height;
            }
            //Rect update position
            m_position += m_velocity;
            m_rect.X = (int)m_position.X;
            m_rect.Y = (int)m_position.Y;

            //Feet Rect position
            m_feetPos.X = m_rect.X + FOOTMARGIN;
            m_feetPos.Y = m_rect.Y + m_rect.Height - 2;
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_txr, m_rect, Color.White);
        }
    }
}
