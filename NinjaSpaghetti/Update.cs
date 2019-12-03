using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaSpaghetti
{
    class Update
    {
        // New Food Collision
        /* 
         for (int k = 0; k < fungo.Count; k++)
                {
                    for (int y = 0; y < guanciale.Count; y++)
                    {
                        if (fungo[k].m_rect.Intersects(guanciale[y].m_rect))
                        {
                            fungo.RemoveAt(k);
                            guanciale.RemoveAt(y);
                            break;
                        }
                    }
                    for (int z = 0; z < uovo.Count; z++)
                    {
                        if (fungo[k].m_rect.Intersects(uovo[z].m_rect))
                        {
                            fungo.RemoveAt(k);
                            uovo.RemoveAt(z);
                            break;
                        }
                    }
                    for (int l = 0; l < casu.Count; l++)
                    {
                        if (fungo[k].m_rect.Intersects(casu[l].m_rect))
                        {
                            fungo.RemoveAt(k);
                            casu.RemoveAt(l);
                            break;
                        }
                    }
                    for (int i = 0; i < peppe.Count; i++)
                    {
                        if (fungo[k].m_rect.Intersects(peppe[i].m_rect))
                        {
                            fungo.RemoveAt(k);
                            peppe.RemoveAt(i);
                            break;
                        }
                    }
                */


        /*
          GamePlay

         //Level Setting
            level = true;
            if (countIncreaser == true && m_state)
            {
                life = 3;
                casuCount = 2;
                guancialeCount = 2;
                uovoCount = 2;
                peppeCount = 2;
                countIncreaser = false;
            }
            pad1_Old = pad1_Curr;
            pad1_Curr = GamePad.GetState(PlayerIndex.One);
            //Player(s)
            p1Char.UpdateMe(pad1_Curr, pad1_Old, GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
            //Farfalla Update
            if (pad1_Curr.Buttons.B == ButtonState.Pressed && pad1_Old.Buttons.B == ButtonState.Released)
            {
                if (p1Char.m_currentState == AnimState.FacingRight || p1Char.m_currentState == AnimState.WalkingRight || p1Char.m_currentState == AnimState.AirborneRight)
                    farfalla.Add(new Farfalla(farfallaImg, p1Char.CollisionRect.X + 20, p1Char.CollisionRect.Y + 25, 10));

                if (p1Char.m_currentState == AnimState.FacingLeft || p1Char.m_currentState == AnimState.WalkingLeft || p1Char.m_currentState == AnimState.AirborneLeft)
                    farfalla.Add(new Farfalla(farfallaImg, p1Char.CollisionRect.X, p1Char.CollisionRect.Y + 25, -10));

                isVisible = true;
            }

            if (isVisible == true)
            {
                for (int i = 0; i < farfalla.Count; i++)
                {
                    farfalla[i].UpdateMe();
                }
            }

            if (spawn >= 1)
            {
                spawn = 0;
                if (fungo.Count < 5)
                {
                    fungo.Add(new Food(Content.Load<Texture2D>("Mush"), RNG, graphics.PreferredBackBufferWidth, -1, 1));
                }
                if (uovoCount > 0)
                {
                    if (uovo.Count < 1)
                    {
                        uovo.Add(new Food(Content.Load<Texture2D>("ovo"), RNG, graphics.PreferredBackBufferWidth, -1, 1));
                    }
                }
                if (guancialeCount > 0)
                {
                    if (guanciale.Count < 1)
                    {
                        guanciale.Add(new Food(Content.Load<Texture2D>("Guanciale"), RNG, graphics.PreferredBackBufferWidth, -1, 1));
                    }
                }
                if (casuCount > 0)
                {
                    if (casu.Count < 1)
                    {
                        casu.Add(new Food(Content.Load<Texture2D>("casu"), RNG, graphics.PreferredBackBufferWidth, -1, 1));
                    }
                }
                if (peppeCount > 0)
                {
                    if (peppe.Count < 1)
                    {
                        peppe.Add(new Food(Content.Load<Texture2D>("Peppe"), RNG, graphics.PreferredBackBufferWidth, -1, 1));
                    }
                }
            }

            //Updating
            for (int i = 0; i < fungo.Count; i++)
            {
                fungo[i].UpdateMe(GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
            }
            // m_state == GamesState.Level2 { add  enemie }
            // m_state == GamesState.Level3 { add  enemies }

            for (int i = 0; i < panna.Count; i++)
            {
                panna[i].UpdateMe(GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
            }
            for (int i = 0; i < puddu.Count; i++)
            {
                puddu[i].UpdateMe(GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
            }
            for (int i = 0; i < casu.Count; i++)
            {
                casu[i].UpdateMe(GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
            }
            for (int i = 0; i < guanciale.Count; i++)
            {
                guanciale[i].UpdateMe(GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
            }
            for (int i = 0; i < uovo.Count; i++)
            {
                uovo[i].UpdateMe(GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
            }
            for (int i = 0; i < peppe.Count; i++)
            {
                peppe[i].UpdateMe(GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
            }

            PotCollsion();
            FoodCollision();
            FarfallaCollision();
            //Score modifier
            if (collision == true)
            {
                life = life - 1;
                collision = false;
            }
            if (casuPot == true)
            {
                casuCount = casuCount - 1;
                casuPot = false;
            }
            if (uovoPot == true)
            {
                uovoCount = uovoCount - 1; ;
                uovoPot = false;
            }
            if (guancialePot == true)
            {
                guancialeCount = guancialeCount - 1;
                guancialePot = false;
            }
            if (peppePot == true)
            {
                peppeCount = peppeCount - 1;
                peppePot = false;
            }
            if (casuCount == 0 && uovoCount == 0 && peppeCount == 0 && guancialeCount == 0)
            {
                completed = true;
                //spritebatch Completed press start to move to level 2
                
            }
            if (completed == false)
            {
                if (pad1_Curr.Buttons.Start == ButtonState.Pressed && pad1_Old.Buttons.Start == ButtonState.Released)
                {
                    countIncreaser = true;
                    _state = GameStates.Level2;
                }
            }
            if (life == 0)
            {
                _state = GameStates.GameOver;
            }

          
         */




    }
}
