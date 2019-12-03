using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NinjaSpaghetti
{
    //All possible Char State
    public enum AnimState
    {
        WalkingRight,
        WalkingLeft,
        AirborneRight,
        AirborneLeft,
        FacingRight,
        FacingLeft,
        SpaghettiWhipRight,
        SpaghettiWhipLeft,
        FarfallaThrowRight,
        FarfallaThrowLeft,
    }

    class NinjaSpaghetti
    {
        //Animstate Variable
        public AnimState m_currentState;
        //Image
        private Texture2D m_StandingSprite;
        private Texture2D m_runningSprite;
        private Texture2D m_jumpingSprite;
        private Texture2D m_whipSprite;
        private Texture2D m_farfallaSprite;
        //Whole Rectangle
        public Rectangle CollisionRect;
        //Initial Position
        private Vector2 m_position;
        //Movement
        private float m_WalkSpeed;
        private Vector2 m_velocity;
        //Feet Rectangle
        private const int FOOTMARGIN = 3;
        private Rectangle m_feetPos;
        //Stanza Segreta
        bool m_stanzaSegreta;

        /*Whip Rectangle
        public Rectangle Whip_CollisonRect;
        private const int WHIPEXTEND = 10;
        private Rectangle m_whipPos;

        /*Animation
        private Rectangle m_animCell;
        private float m_frameTimer;
        private float m_fps;
        */

        public NinjaSpaghetti(Texture2D standSprite, Texture2D runningSprite, Texture2D jumpingSprite, Texture2D whipSprite, Texture2D farfallaSprite, int xpos, int ypos)
        {
            //Intial State
            m_currentState = AnimState.FacingRight;
            //Sprite
            m_StandingSprite = standSprite;
            m_runningSprite = runningSprite;
            m_jumpingSprite = jumpingSprite;
            m_whipSprite = whipSprite;
            m_farfallaSprite = farfallaSprite;
            //Whole Rectangle
            CollisionRect = new Rectangle(xpos, ypos, standSprite.Width, standSprite.Height);
            //Initial Position
            m_position = new Vector2(xpos, ypos);
            //Feet Rect
            m_feetPos = new Rectangle(CollisionRect.X + FOOTMARGIN, CollisionRect.Y + CollisionRect.Height - 2, CollisionRect.Width - (FOOTMARGIN * 2), 2);
            //Movement and Gravity
            m_WalkSpeed = 3f;
            m_velocity = Vector2.Zero;
         
            //AnimationConstructor
            /*Animation
            m_animCell = new Rectangle(0, 0, standSprite.Width, standSprite.Height);
            m_frameTimer = 1;
            m_fps = 1;
            */
            /*Whip Rect
            m_whipPos = new Rectangle(CollisionRect.X + WHIPEXTEND, CollisionRect.Y + CollisionRect.Height - 2, CollisionRect.Width - (FOOTMARGIN * 2), 2);
            */
        }

        public void UpdateMe(GamePadState currPad, GamePadState oldPad, Rectangle screenSize, float gravity, int ground, List<Platform> platforms, bool stanzaSegreta, SoundEffect jump)
        {
            //Stanza Segreta
            m_stanzaSegreta = stanzaSegreta;
            //Handle Player Movement
            m_velocity.X = 0;
            if (currPad.DPad.Right == ButtonState.Pressed)
            {
                m_velocity.X = m_WalkSpeed;
                if (m_velocity.Y != 0)
                    m_currentState = AnimState.AirborneRight;
                else
                    m_currentState = AnimState.WalkingRight;
            }
            else if (currPad.DPad.Left == ButtonState.Pressed)
            {
                m_velocity.X -= m_WalkSpeed;
                if (m_velocity.Y != 0)
                    m_currentState = AnimState.AirborneLeft;
                else
                    m_currentState = AnimState.WalkingLeft;
            }
            else if ((m_currentState == AnimState.WalkingLeft) || (m_currentState == AnimState.AirborneLeft))
                m_currentState = AnimState.FacingLeft;
            else if ((m_currentState == AnimState.WalkingRight) || (m_currentState == AnimState.AirborneRight))
                m_currentState = AnimState.FacingRight;

            //CollisionRect Position Update
            m_position += m_velocity;
            CollisionRect.X = (int)m_position.X;
            CollisionRect.Y = (int)m_position.Y;

            //Handle Char Wrap
            if (stanzaSegreta == false)
            {
                if (m_position.X + CollisionRect.Width < 0)
                    m_position.X = screenSize.Width - 1;
                if (m_position.X > screenSize.Width)
                    m_position.X = 1 - CollisionRect.Width;
            }
            if (stanzaSegreta == true)
            {
                if (m_position.X + CollisionRect.Width < -80)
                    m_position.X = screenSize.Width - 1;
                if (m_position.X > screenSize.Width)
                    m_position.X = 1 - CollisionRect.Width;
            }

            //Gravity
            if (CollisionRect.Bottom < ground)
            {
                if (m_velocity.Y < gravity * 15)
                    m_velocity.Y += gravity;
                if(m_position.Y == 0)
                {
                    m_velocity.Y += gravity;
                }
                for (int i = 0; i < platforms.Count; i++)
                    if (platforms[i].Surface.Intersects(m_feetPos))
                    {
                        if (m_velocity.Y > 0)
                        {
                            m_velocity.Y = 0;
                            m_position.Y = platforms[i].Surface.Top - CollisionRect.Height + 1;
                        }
                    }
            }
            else
            {
                m_velocity.Y = 0;
                m_position.Y = ground - CollisionRect.Height;
            }

            //Feet Rect position
            m_feetPos.X = CollisionRect.X + FOOTMARGIN;
            m_feetPos.Y = CollisionRect.Y + CollisionRect.Height - 2;

            //Handle Player Jump
            if ((currPad.Buttons.A == ButtonState.Pressed) && (oldPad.Buttons.A == ButtonState.Released) && (m_velocity.Y == 0) && (CollisionRect.Y > 150))
            {
                jump.Play();
                m_velocity.Y -= 10;
            }
        }
        public void DrawMe(SpriteBatch sb, GameTime gt)
        {
            //Sprite Drawing for each AnimState
            switch (m_currentState)
            {
                case AnimState.WalkingRight:
                    sb.Draw(m_runningSprite, m_position, null, Color.White);
                    break;
                case AnimState.WalkingLeft:
                    sb.Draw(m_runningSprite, m_position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    break;
                case AnimState.FacingRight:
                    sb.Draw(m_StandingSprite, m_position, null, Color.White);
                    break;
                case AnimState.FacingLeft:
                    sb.Draw(m_StandingSprite, m_position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    break;
                case AnimState.AirborneRight:
                    sb.Draw(m_jumpingSprite, m_position, null, Color.White);
                    break;
                case AnimState.AirborneLeft:
                    sb.Draw(m_jumpingSprite, m_position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    break;
                case AnimState.SpaghettiWhipRight:
                    sb.Draw(m_whipSprite, m_position, null, Color.White);
                    break;
                case AnimState.SpaghettiWhipLeft:
                    sb.Draw(m_whipSprite, m_position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    break;
                case AnimState.FarfallaThrowRight:
                    sb.Draw(m_farfallaSprite, m_position, null, Color.White);
                    break;
                case AnimState.FarfallaThrowLeft:
                    sb.Draw(m_farfallaSprite, m_position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    break;
            }
        }
    }
}
