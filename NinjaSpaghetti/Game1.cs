using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace NinjaSpaghetti
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        enum GameStates
        {
            Intro,
            Instruction,
            Level1,
            Level2,
            Level3,
            Congratulation,
            StanzaSegreta,
            GameOver
        }
        //GameStates variable
        GameStates _state;
        //Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Sfondo
        Background background;
        //Intro
        Intro intro;
        Intro gameOver;
        Intro gratz;
        //Platforms
        List<Platform> platforms;
        List<Platform> platformsIntro;
        List<Platform> platformsWin;
        List<Platform> credits;
        //Pot
        Pentola Pot;
        Pentola Pot_2;
        //Score
        ScoreSprite face;
        ScoreSprite casuScore;
        ScoreSprite peppeScore;
        ScoreSprite guancialeScore;
        ScoreSprite uovoScore;
        List<ScoreSprite> heart;
        SpriteFont Count;
        //Instruction Sprite
        //Enemies
        InsSPrite fungoIns;
        InsSPrite pannaIns;
        InsSPrite pudduIns;
        //Recipe Food
        InsSPrite casuIns;
        InsSPrite guancialeIns;
        InsSPrite uovoIns;
        InsSPrite peppeIns;
        //Congratulation Sprite
        /*
        InsSPrite casuIns_2;
        InsSPrite guancialeIns_2;
        InsSPrite uovoIns_2;
        InsSPrite peppeIns_2;
        */
        //Text
        SpriteFont recipe;
        SpriteFont enemies;
        //Moving Food
        //Enemies
        List<Food> fungo;
        Texture2D fungoImg;
        List<Food> panna;
        Texture2D pannaImg;
        List<Food> puddu;
        Texture2D pudduImg;
        //Carbonara Recipe Food
        List<Food> casu;
        Texture2D casuImg;
        List<Food> guanciale;
        Texture2D guancialeImg;
        List<Food> uovo;
        Texture2D uovoImg;
        List<Food> peppe;
        Texture2D peppeImg;
        //Flags
        Flags ita_flag;
        Flags uk_flag;
        Flags usa_flag;
        Flags jap_flag;
        //Ninja Spaghetti
        NinjaSpaghetti p1Char;
        //Farfalla
        List<Farfalla> farfalla;
        Texture2D farfallaImg;
        bool isVisible;
        //Pad
        GamePadState pad1_Curr;
        GamePadState pad1_Old;
        //Gravity
        const float GRAVITY = 0.3f;
        //Ground Level
        const int GROUNDLEVEL = 580;
        //Random
        Random RNG;
        //Spawn
        float spawn = 0;
        //Count
        int life;
        int casuCount;
        int guancialeCount;
        int uovoCount;
        int peppeCount;
        //Count bool modifier
        bool collision;
        bool casuPot;
        bool guancialePot;
        bool uovoPot;
        bool peppePot;
        bool countIncreaser;
        bool completed;
        bool stanzaSegreta;
        //Sound
        SoundEffect jump;
        SoundEffect shoot;
        SoundEffect game_Over;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Resolution
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            //RNG
            RNG = new Random();
            //List
            //Heart
            heart = new List<ScoreSprite>();
            //Farfalla
            farfalla = new List<Farfalla>();
            //Enemies
            fungo = new List<Food>();
            panna = new List<Food>();
            puddu = new List<Food>();
            //Carbonara Recipe
            casu = new List<Food>();
            uovo = new List<Food>();
            guanciale = new List<Food>();
            peppe = new List<Food>();
            //Platform
            platforms = new List<Platform>();
            platformsIntro = new List<Platform>(); 
            platformsWin = new List<Platform>();
            credits = new List<Platform>();
            //Farfalla
            isVisible = false;
            //Collision
            collision = false;
            //Level completed
            completed = false;
            //StanzaSegreta
            stanzaSegreta = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Sfondo
            background = new Background(Content.Load<Texture2D>("Background"), 0, 0);
            //Intro
            intro = new Intro(Content.Load<Texture2D>("Intro"), 150, 100);
            //Press Start

            //Instruction Sprite
            //Enemies
            fungoIns = new InsSPrite(Content.Load<Texture2D>("Mush"), 550, 250);
            pudduIns = new InsSPrite(Content.Load<Texture2D>("Puddu"), 640, 250);
            pannaIns = new InsSPrite(Content.Load<Texture2D>("Cream"), 730, 250);
            //Recipe
            uovoIns = new InsSPrite(Content.Load<Texture2D>("ovo"), 30, 250);
            peppeIns = new InsSPrite(Content.Load<Texture2D>("Peppe"), 100, 250);
            guancialeIns = new InsSPrite(Content.Load<Texture2D>("Guanciale"), 170, 250);
            casuIns = new InsSPrite(Content.Load<Texture2D>("casu"), 240, 250);
            //Instruction Text
            recipe = Content.Load<SpriteFont>("Count");
            enemies = Content.Load<SpriteFont>("Count");
            //ScoreSprite
            casuScore = new ScoreSprite(Content.Load<Texture2D>("casu"), 270, 20);
            uovoScore = new ScoreSprite(Content.Load<Texture2D>("ovo"), 350, 20);
            guancialeScore = new ScoreSprite(Content.Load<Texture2D>("Guanciale"), 430, 20);
            peppeScore = new ScoreSprite(Content.Load<Texture2D>("Peppe"), 510, 20);
            face = new ScoreSprite(Content.Load<Texture2D>("face"), 650, 20);
            heart.Add(new ScoreSprite(Content.Load<Texture2D>("heart"), 674, 20));
            heart.Add(new ScoreSprite(Content.Load<Texture2D>("heart"), 698, 20));
            heart.Add(new ScoreSprite(Content.Load<Texture2D>("heart"), 722, 20));
            Count = Content.Load<SpriteFont>("Count");
            //Congratulation
            gratz = new Intro(Content.Load<Texture2D>("Gratz"), 150, 150);
            /*
            uovoIns_2 = new InsSPrite(Content.Load<Texture2D>("ovo"), 30, 110);
            peppeIns_2 = new InsSPrite(Content.Load<Texture2D>("Peppe"), 100, 110);
            guancialeIns_2 = new InsSPrite(Content.Load<Texture2D>("Guanciale"), 170, 110);
            casuIns_2 = new InsSPrite(Content.Load<Texture2D>("casu"), 240, 110);
            */
            Pot_2 = new Pentola(Content.Load<Texture2D>("Pentola"), 376, 120);
            //GameOver
            gameOver = new Intro(Content.Load<Texture2D>("gameOver3"), 150, 100);
            //Platform Load
            //platforms
            //Top
            platforms.Add(new Platform(Content.Load<Texture2D>("Platform"), -50, 150));
            platforms.Add(new Platform(Content.Load<Texture2D>("Platform"), 450, 150));
            //Mid
            platforms.Add(new Platform(Content.Load<Texture2D>("Platform"), 200, 300));
            platforms.Add(new Platform(Content.Load<Texture2D>("Platform"), -300, 325));
            platforms.Add(new Platform(Content.Load<Texture2D>("Platform"), 700, 325));
            //Bottom
            platforms.Add(new Platform(Content.Load<Texture2D>("Platform"), -100, 450));
            platforms.Add(new Platform(Content.Load<Texture2D>("Platform"), 500, 450));
            //platformsIntro
            platformsIntro.Add(new Platform(Content.Load<Texture2D>("Platform"), 500, 300));
            platformsIntro.Add(new Platform(Content.Load<Texture2D>("Platform"), -100, 300));
            //platformsWin
            platformsWin.Add(new Platform(Content.Load<Texture2D>("Platform"), -430, 300));
            platformsWin.Add(new Platform(Content.Load<Texture2D>("Platform"), -430, 450));
            platformsWin.Add(new Platform(Content.Load<Texture2D>("Platform"), 0, 150));
            platformsWin.Add(new Platform(Content.Load<Texture2D>("Platform"), 400, 150));
            platformsWin.Add(new Platform(Content.Load<Texture2D>("Platform"), 200, 450));
            //credits Platform
            credits.Add(new Platform(Content.Load<Texture2D>("Platform"), -100, 325));
            credits.Add(new Platform(Content.Load<Texture2D>("Platform"), 500, 325));
            //Pot
            Pot = new Pentola(Content.Load<Texture2D>("Pentola"), 376, 546);
            //Flags
            ita_flag = new Flags(Content.Load<Texture2D>("ita_flag"), 10, 10);
            uk_flag = new Flags(Content.Load<Texture2D>("uk_flag"), 54, 10);
            usa_flag = new Flags(Content.Load<Texture2D>("merica_flag"), 98, 10);
            jap_flag = new Flags(Content.Load<Texture2D>("Jpa_flag"), 142, 10);
            //Player(s)
            p1Char = new NinjaSpaghetti(Content.Load<Texture2D>("stand3"), Content.Load<Texture2D>("run3"), Content.Load<Texture2D>("jump3"), Content.Load<Texture2D>("stand"), Content.Load<Texture2D>("stand"), 50, 580);
            //Farfalla
            farfallaImg = Content.Load<Texture2D>("Farfalla");
            //Enemies
            fungoImg = Content.Load<Texture2D>("Mush");
            pannaImg = Content.Load<Texture2D>("Cream");
            pudduImg = Content.Load<Texture2D>("Puddu");
            //Carbonara Recipe
            casuImg = Content.Load<Texture2D>("casu");
            uovoImg = Content.Load<Texture2D>("ovo");
            guancialeImg = Content.Load<Texture2D>("Guanciale");
            peppeImg = Content.Load<Texture2D>("Peppe");
            //Sound
            jump = Content.Load<SoundEffect>("salto");
            shoot = Content.Load<SoundEffect>("sparo");
            game_Over = Content.Load<SoundEffect>("gameOver");

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            //Spawn change
            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Layers
            switch (_state)
            {
                case GameStates.Intro:
                    IntroUpdate(gameTime);
                    break;
                case GameStates.Instruction:
                    InstructionUpdate(gameTime);
                    break;
                case GameStates.Level1:
                    Level1Update(gameTime);
                    break;
                case GameStates.Level2:
                    Level2Update(gameTime);
                    break;
                case GameStates.Level3:
                    Level3Update(gameTime);
                    break;
                case GameStates.Congratulation:
                    CongratulationUpdate(gameTime);
                    break;
                case GameStates.StanzaSegreta:
                    StanzaSegretaUpdate(gameTime);
                    break;
                case GameStates.GameOver:
                    GameOverUpdate(gameTime);
                    break;
            }

            base.Update(gameTime);
        }
        //Handle Pot Collision
        void PotCollsion()
        {
            //1 Bad Food
            for (int i = 0; i < fungo.Count; i++)
            {
                if (fungo[i].m_rect.Intersects(Pot.Surface))
                {

                    collision = true;
                    fungo.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < panna.Count; i++)
            {
                if (panna[i].m_rect.Intersects(Pot.Surface))
                {
                    collision = true;
                    panna.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < puddu.Count; i++)
            {
                if (puddu[i].m_rect.Intersects(Pot.Surface))
                {
                    collision = true;
                    puddu.RemoveAt(i);
                    break;
                }
            }
            //2 Recipe Food
            for (int i = 0; i < casu.Count; i++)
            {
                if (casu[i].m_rect.Intersects(Pot.Surface))
                {
                    casuPot = true;
                    casu.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < guanciale.Count; i++)
            {
                if (guanciale[i].m_rect.Intersects(Pot.Surface))
                {
                    guancialePot = true;
                    guanciale.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < uovo.Count; i++)
            {
                if (uovo[i].m_rect.Intersects(Pot.Surface))
                {
                    uovoPot = true;
                    uovo.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < peppe.Count; i++)
            {
                if (peppe[i].m_rect.Intersects(Pot.Surface))
                {
                    peppePot = true;
                    peppe.RemoveAt(i);
                    break;
                }
            }
            if (p1Char.CollisionRect.Intersects(Pot_2.Surface) && stanzaSegreta == true)
            {
                _state = GameStates.StanzaSegreta;
            }
        }

        //Handle Food Collision
        void FoodCollision()
        {
            /////////////////////////////////////////
            //Fungo hit Recipe Food
            for (int k = 0; k < fungo.Count; k++)
                for (int y = 0; y < guanciale.Count; y++)
                {
                    if (fungo[k].m_rect.Intersects(guanciale[y].m_rect))
                    {
                        fungo.RemoveAt(k);
                        guanciale.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < fungo.Count; k++)
                for (int y = 0; y < peppe.Count; y++)
                {
                    if (fungo[k].m_rect.Intersects(peppe[y].m_rect))
                    {
                        fungo.RemoveAt(k);
                        peppe.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < fungo.Count; k++)
                for (int y = 0; y < uovo.Count; y++)
                {
                    if (fungo[k].m_rect.Intersects(uovo[y].m_rect))
                    {
                        fungo.RemoveAt(k);
                        uovo.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < fungo.Count; k++)
                for (int y = 0; y < casu.Count; y++)
                {
                    if (fungo[k].m_rect.Intersects(casu[y].m_rect))
                    {
                        fungo.RemoveAt(k);
                        casu.RemoveAt(y);
                        break;
                    }
                }
            //////////////////////////////////////////
            //Puddu hit Recipe Food
            for (int k = 0; k < puddu.Count; k++)
                for (int y = 0; y < guanciale.Count; y++)
                {
                    if (puddu[k].m_rect.Intersects(guanciale[y].m_rect))
                    {
                        puddu.RemoveAt(k);
                        guanciale.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < puddu.Count; k++)
                for (int y = 0; y < peppe.Count; y++)
                {
                    if (puddu[k].m_rect.Intersects(peppe[y].m_rect))
                    {
                        puddu.RemoveAt(k);
                        peppe.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < puddu.Count; k++)
                for (int y = 0; y < uovo.Count; y++)
                {
                    if (puddu[k].m_rect.Intersects(uovo[y].m_rect))
                    {
                        puddu.RemoveAt(k);
                        uovo.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < puddu.Count; k++)
                for (int y = 0; y < casu.Count; y++)
                {
                    if (puddu[k].m_rect.Intersects(casu[y].m_rect))
                    {
                        puddu.RemoveAt(k);
                        casu.RemoveAt(y);
                        break;
                    }
                }
            //////////////////////////////////////////
            //Panna hit Recipe Food
            for (int k = 0; k < panna.Count; k++)
                for (int y = 0; y < guanciale.Count; y++)
                {
                    if (panna[k].m_rect.Intersects(guanciale[y].m_rect))
                    {
                        panna.RemoveAt(k);
                        guanciale.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < panna.Count; k++)
                for (int y = 0; y < peppe.Count; y++)
                {
                    if (panna[k].m_rect.Intersects(peppe[y].m_rect))
                    {
                        panna.RemoveAt(k);
                        peppe.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < panna.Count; k++)
                for (int y = 0; y < uovo.Count; y++)
                {
                    if (panna[k].m_rect.Intersects(uovo[y].m_rect))
                    {
                        panna.RemoveAt(k);
                        uovo.RemoveAt(y);
                        break;
                    }
                }
            for (int k = 0; k < panna.Count; k++)
                for (int y = 0; y < casu.Count; y++)
                {
                    if (panna[k].m_rect.Intersects(casu[y].m_rect))
                    {
                        panna.RemoveAt(k);
                        casu.RemoveAt(y);
                        break;
                    }
                }
        }
        //Handle Farfalla Bullet Collision    
        void FarfallaCollision()
        {
            for (int i = 0; i < farfalla.Count; i++)
                for (int j = 0; j < fungo.Count; j++)
                {
                    if (fungo[j].m_rect.Intersects(farfalla[i].CollisionRect))
                    {
                        farfalla.RemoveAt(i);
                        fungo.RemoveAt(j);
                        break;
                    }
                }
            for (int i = 0; i < farfalla.Count; i++)
                for (int z = 0; z < puddu.Count; z++)
                {
                    if (puddu[z].m_rect.Intersects(farfalla[i].CollisionRect))
                    {
                        farfalla.RemoveAt(i);
                        puddu.RemoveAt(z);
                        break;
                    }
                }
            for (int i = 0; i < farfalla.Count; i++)
                for (int l = 0; l < panna.Count; l++)
                {
                    if (panna[l].m_rect.Intersects(farfalla[i].CollisionRect))
                    {
                        farfalla.RemoveAt(i);
                        panna.RemoveAt(l);
                        break;
                    }
                }
        }

        void Reset()
        {
            
        }
        //GamePlay Code
        void GamePlay()
        {
            //Level Setting
            if (countIncreaser == true && _state == GameStates.Instruction)
            {
                if (countIncreaser == true)
                {
                    life = 3;
                    casuCount = 99;
                    guancialeCount = 99;
                    uovoCount = 99;
                    peppeCount = 99;
                    countIncreaser = false;
                }
            }
            if (countIncreaser == true && _state == GameStates.Level1)
            {
                life = 3;
                casuCount = 2;
                guancialeCount = 2;
                uovoCount = 2;
                peppeCount = 2;
                countIncreaser = false;
            }
            if (countIncreaser == true && _state == GameStates.Level2)
            {
                life = 3;
                casuCount = 3;
                guancialeCount = 3;
                uovoCount = 3;
                peppeCount = 3;
                countIncreaser = false;
            }
            if (countIncreaser == true && _state == GameStates.Level3)
            {
                life = 3;
                casuCount = 4;
                guancialeCount = 4;
                uovoCount = 4;
                peppeCount = 4;
                countIncreaser = false;
            }
            pad1_Old = pad1_Curr;
            pad1_Curr = GamePad.GetState(PlayerIndex.One);
            //Player(s)
            if (_state == GameStates.Instruction)
            {
                p1Char.UpdateMe(pad1_Curr, pad1_Old, GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platformsIntro, stanzaSegreta, jump);
            }
            if (_state == GameStates.Level1 || _state == GameStates.Level2 || _state == GameStates.Level3)
            {
                p1Char.UpdateMe(pad1_Curr, pad1_Old, GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms, stanzaSegreta, jump);
            }
            if (_state == GameStates.Congratulation)
            {
                p1Char.UpdateMe(pad1_Curr, pad1_Old, GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platformsWin, stanzaSegreta, jump);
            }
            //Farfalla Update
            if (pad1_Curr.Buttons.B == ButtonState.Pressed && pad1_Old.Buttons.B == ButtonState.Released)
            {
                if (p1Char.m_currentState == AnimState.FacingRight || p1Char.m_currentState == AnimState.WalkingRight || p1Char.m_currentState == AnimState.AirborneRight)
                    farfalla.Add(new Farfalla(farfallaImg, p1Char.CollisionRect.X + 20, p1Char.CollisionRect.Y + 25, 10));

                if (p1Char.m_currentState == AnimState.FacingLeft || p1Char.m_currentState == AnimState.WalkingLeft || p1Char.m_currentState == AnimState.AirborneLeft)
                    farfalla.Add(new Farfalla(farfallaImg, p1Char.CollisionRect.X, p1Char.CollisionRect.Y + 25, -10));

                shoot.Play();

                isVisible = true;
            }

            if (isVisible == true)
            {
                for (int i = 0; i < farfalla.Count; i++)
                {
                    farfalla[i].UpdateMe();
                }
            }
            //Spawn  
            if (spawn >= 1)
            {
                //Enemies Spawn
                spawn = 0;
                if (_state == GameStates.Level1)
                {
                    if (fungo.Count < 6)
                    {
                        fungo.Add(new Food(Content.Load<Texture2D>("Mush"), RNG, graphics.PreferredBackBufferWidth, -2, 1));
                    }
                }
                if (_state == GameStates.Level2)
                {
                    if (fungo.Count < 4)
                    {
                        fungo.Add(new Food(Content.Load<Texture2D>("Mush"), RNG, graphics.PreferredBackBufferWidth, -2, 1));
                    }
                    if (puddu.Count < 4)
                    {
                        puddu.Add(new Food(Content.Load<Texture2D>("Puddu"), RNG, graphics.PreferredBackBufferWidth, -2, 1));
                    }
                }
                if (_state == GameStates.Level3)
                {
                    if (fungo.Count < 3)
                    {
                        fungo.Add(new Food(Content.Load<Texture2D>("Mush"), RNG, graphics.PreferredBackBufferWidth, -2, 1));
                    }
                    if (puddu.Count < 3)
                    {
                        puddu.Add(new Food(Content.Load<Texture2D>("Puddu"), RNG, graphics.PreferredBackBufferWidth, -2, 2));
                    }
                    if (panna.Count < 3)
                    {
                        panna.Add(new Food(Content.Load<Texture2D>("Cream"), RNG, graphics.PreferredBackBufferWidth, -2, 1));
                    }
                }
                //Recipe Spawn
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
            if (_state == GameStates.Level1 || _state == GameStates.Level2 || _state == GameStates.Level3)
            {
                //Updating
                for (int i = 0; i < fungo.Count; i++)
                {
                    fungo[i].UpdateMe(GraphicsDevice.Viewport.Bounds, GRAVITY, GROUNDLEVEL, platforms);
                }
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
            }
            
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
            //Completed Level
            if (casuCount == 0 && uovoCount == 0 && peppeCount == 0 && guancialeCount == 0)
            {
                completed = true;
            }
            //Gameover condition
            if (life == 0 && completed == false)
            {
                _state = GameStates.GameOver;
                game_Over.Play();
            }
        }
        void IntroUpdate(GameTime gameTime)
        {
            stanzaSegreta = false;
            pad1_Old = pad1_Curr;
            pad1_Curr = GamePad.GetState(PlayerIndex.One);
            if (pad1_Curr.Buttons.Start == ButtonState.Pressed && pad1_Old.Buttons.Start == ButtonState.Released)
            {
                _state = GameStates.Instruction;
                countIncreaser = true;
            }
        }
        void InstructionUpdate(GameTime gameTime)
        {
            GamePlay();
            //Changing GamesState
            if (pad1_Curr.Buttons.Start == ButtonState.Pressed && pad1_Old.Buttons.Start == ButtonState.Released)
            {
                countIncreaser = true;
                _state = GameStates.Level1;
            }
        }
        
        void Level1Update(GameTime gameTime)
        {
            GamePlay();
            PotCollsion();
            FoodCollision();
            FarfallaCollision();

            //Changing GamesState
            if (completed == true)
            {
                if (pad1_Curr.Buttons.Start == ButtonState.Pressed && pad1_Old.Buttons.Start == ButtonState.Released)
                {
                    completed = false;
                    countIncreaser = true;
                    _state = GameStates.Level2;
                }
            }
            if (pad1_Curr.Buttons.X == ButtonState.Pressed && pad1_Old.Buttons.X == ButtonState.Released)
            {
                completed = true;
            }

        }
            
        void Level2Update(GameTime gameTime)
        {
            GamePlay();
            PotCollsion();
            FoodCollision();
            FarfallaCollision();

            //Changing GamesState
            if (completed == true)
            {
                if (pad1_Curr.Buttons.Start == ButtonState.Pressed && pad1_Old.Buttons.Start == ButtonState.Released)
                {
                    completed = false;
                    countIncreaser = true;
                    _state = GameStates.Level3;
                }
            }
            if (pad1_Curr.Buttons.X == ButtonState.Pressed && pad1_Old.Buttons.X == ButtonState.Released)
            {
                completed = true;
            }
        }
        void Level3Update(GameTime gameTime)
        {
            GamePlay();
            PotCollsion();
            FoodCollision();
            FarfallaCollision();

            //Changing GamesState
            if (completed == true)
            {
                if (pad1_Curr.Buttons.Start == ButtonState.Pressed && pad1_Old.Buttons.Start == ButtonState.Released)
                {
                    completed = false;
                    stanzaSegreta = true;
                    _state = GameStates.Congratulation;
                }
            }
            if (pad1_Curr.Buttons.X == ButtonState.Pressed && pad1_Old.Buttons.X == ButtonState.Released)
            {
                completed = true;
            }
        }
        void CongratulationUpdate(GameTime gameTime)
        {
            GamePlay();
            PotCollsion();
            if (pad1_Curr.Buttons.Start == ButtonState.Pressed && pad1_Old.Buttons.Start == ButtonState.Released)
            {
                _state = GameStates.Intro;
            }
        }

        void StanzaSegretaUpdate(GameTime gameTime)
        {
            GamePlay();
        }
        void GameOverUpdate(GameTime gameTime)
        {
            pad1_Old = pad1_Curr;
            pad1_Curr = GamePad.GetState(PlayerIndex.One);
            if (pad1_Curr.Buttons.Start == ButtonState.Pressed && pad1_Old.Buttons.Start == ButtonState.Released)
            {
                _state = GameStates.Intro;
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            //Drawing Layers Depending on the GameState
            spriteBatch.Begin();
            switch (_state)
            {
                case GameStates.Intro:
                    IntroDraw(gameTime);
                    break;
                case GameStates.Instruction:
                    InstructionDraw(gameTime);
                    break;
                case GameStates.Level1:
                    Level1Draw(gameTime);
                    break;
                case GameStates.Level2:
                    Level2Draw(gameTime);
                    break;
                case GameStates.Level3:
                    Level3Draw(gameTime);
                    break;
                case GameStates.Congratulation:
                    CongratulationDraw(gameTime);
                    break;
                case GameStates.StanzaSegreta:
                    stanzaSegretaDraw(gameTime);
                    break;
                case GameStates.GameOver:
                    GameOverDraw(gameTime);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        void Drawing(GameTime gameTime)
        {
            //Sfondo
            background.DrawMe(spriteBatch);
            //Player(s)
            p1Char.DrawMe(spriteBatch, gameTime);
            //Farfalla
            for (int i = 0; i < farfalla.Count; i++)
            {
                farfalla[i].DrawMe(spriteBatch);
            }
            //Specific Sprite for Level 1
            if (_state == GameStates.Level1)
            {
                //Flags
                ita_flag.DrawMe(spriteBatch);
                uk_flag.DrawMe(spriteBatch);
                //Fungo
                for (int i = 0; i < fungo.Count; i++)
                {
                    fungo[i].DrawMe(spriteBatch);
                }
            }
            //Specific Sprite for Level 2
            if (_state == GameStates.Level2)
            {
                //Flags
                ita_flag.DrawMe(spriteBatch);
                uk_flag.DrawMe(spriteBatch);
                usa_flag.DrawMe(spriteBatch);
                //Fungo
                for (int i = 0; i < fungo.Count; i++)
                {
                    fungo[i].DrawMe(spriteBatch);
                }
                //Puddu
                for (int i = 0; i < puddu.Count; i++)
                {
                    puddu[i].DrawMe(spriteBatch);
                }
            }
            //Specific Sprite for Level 3
            if (_state == GameStates.Level3)
            {

                //Flags
                ita_flag.DrawMe(spriteBatch);
                uk_flag.DrawMe(spriteBatch);
                usa_flag.DrawMe(spriteBatch);
                jap_flag.DrawMe(spriteBatch);
                //Fungo
                for (int i = 0; i < fungo.Count; i++)
                {
                    fungo[i].DrawMe(spriteBatch);
                }
                //Puddu
                for (int i = 0; i < puddu.Count; i++)
                {
                    puddu[i].DrawMe(spriteBatch);
                }
                //Cream
                for (int i = 0; i < panna.Count; i++)
                {
                    panna[i].DrawMe(spriteBatch);
                }
            }
            //Level 1/2/3 Sprite
            if (_state == GameStates.Level1 || _state == GameStates.Level2 || _state == GameStates.Level3)
            {
                //Pot
                Pot.DrawMe(spriteBatch);
                //ScoreSprite
                face.DrawMe(spriteBatch);
                uovoScore.DrawMe(spriteBatch);
                guancialeScore.DrawMe(spriteBatch);
                peppeScore.DrawMe(spriteBatch);
                casuScore.DrawMe(spriteBatch);
                spriteBatch.DrawString(Count, "" + casuCount, new Vector2(295, 15), Color.Red);
                spriteBatch.DrawString(Count, "" + uovoCount, new Vector2(375, 15), Color.Red);
                spriteBatch.DrawString(Count, "" + guancialeCount, new Vector2(460, 15), Color.Red);
                spriteBatch.DrawString(Count, "" + peppeCount, new Vector2(540, 15), Color.Red);
                //Hearts
                for (int i = 0; i < life; i++)
                {
                    heart[i].DrawMe(spriteBatch);
                }
                    
                for (int i = 0; i < platforms.Count; i++)
                {
                    platforms[i].DrawMe(spriteBatch);
                }
                //Egg
                for (int i = 0; i < uovo.Count; i++)
                {
                    uovo[i].DrawMe(spriteBatch);
                }
                //Peppe
                for (int i = 0; i < peppe.Count; i++)
                {
                    peppe[i].DrawMe(spriteBatch);
                }
                //Guanciale
                for (int i = 0; i < guanciale.Count; i++)
                {
                    guanciale[i].DrawMe(spriteBatch);
                }
                //Cheese
                for (int i = 0; i < casu.Count; i++)
                {
                    casu[i].DrawMe(spriteBatch);
                }
            }
            if (_state == GameStates.Congratulation)
            {
                gratz.DrawMe(spriteBatch);
                Pot_2.DrawMe(spriteBatch);
                /*
                uovoIns_2.DrawMe(spriteBatch);
                peppeIns_2.DrawMe(spriteBatch);
                guancialeIns_2.DrawMe(spriteBatch);
                casuIns_2.DrawMe(spriteBatch);
                */
                for (int i = 0; i < credits.Count; i++)
                {
                    credits[i].DrawMe(spriteBatch);
                }
                for (int i = 0; i < platformsWin.Count; i++)
                {
                    platformsWin[i].DrawMe(spriteBatch);
                }
            }
        }
        void IntroDraw(GameTime gameTime)
        {
            //Background
            background.DrawMe(spriteBatch);
            //Logo
            intro.DrawMe(spriteBatch);
            //Press Start

        }
        void InstructionDraw(GameTime gameTime)
        {
            //Sfondo
            background.DrawMe(spriteBatch);
            //Player(s)
            p1Char.DrawMe(spriteBatch, gameTime);
            //Farfalla
            for (int i = 0; i < farfalla.Count; i++)
            {
                farfalla[i].DrawMe(spriteBatch);
            }
            //Pot
            Pot.DrawMe(spriteBatch);
            //InsSPrite
            //Enemies
            fungoIns.DrawMe(spriteBatch);
            pudduIns.DrawMe(spriteBatch);
            pannaIns.DrawMe(spriteBatch);
            //Recipe
            uovoIns.DrawMe(spriteBatch);
            peppeIns.DrawMe(spriteBatch);
            guancialeIns.DrawMe(spriteBatch);
            casuIns.DrawMe(spriteBatch);
            //ScoreSprite
            face.DrawMe(spriteBatch);
            uovoScore.DrawMe(spriteBatch);
            guancialeScore.DrawMe(spriteBatch);
            peppeScore.DrawMe(spriteBatch);
            casuScore.DrawMe(spriteBatch);
            spriteBatch.DrawString(Count, "" + casuCount, new Vector2(295, 15), Color.Red);
            spriteBatch.DrawString(Count, "" + uovoCount, new Vector2(375, 15), Color.Red);
            spriteBatch.DrawString(Count, "" + guancialeCount, new Vector2(460, 15), Color.Red);
            spriteBatch.DrawString(Count, "" + peppeCount, new Vector2(540, 15), Color.Red);
            //Platform
            for (int i = 0; i < platformsIntro.Count; i++)
            {
                platformsIntro[i].DrawMe(spriteBatch);
            }
            //Hearts
            for (int i = 0; i < life; i++)
            {
                heart[i].DrawMe(spriteBatch);
            }
            //Flags
            ita_flag.DrawMe(spriteBatch);
            uk_flag.DrawMe(spriteBatch);
            usa_flag.DrawMe(spriteBatch);
            jap_flag.DrawMe(spriteBatch);
            //Text
            spriteBatch.DrawString(Count, "Recipe", new Vector2(20, 350), Color.Red);
            spriteBatch.DrawString(Count, "Enemies", new Vector2(520, 350), Color.Red);
            //PressStart

        }
        void Level1Draw(GameTime gameTime)
        {
            Drawing(gameTime);
        }

        void Level2Draw(GameTime gameTime)
        {
            Drawing(gameTime);
        }
        void Level3Draw(GameTime gameTime)
        {
            Drawing(gameTime);
        }
        void CongratulationDraw(GameTime gameTime)
        {
            Drawing(gameTime);
        }

        void stanzaSegretaDraw(GameTime gameTime)
        {
            //Background
            background.DrawMe(spriteBatch);
        }
        void GameOverDraw(GameTime gameTime)
        {
            //Background
            background.DrawMe(spriteBatch);
            //GameOver
            gameOver.DrawMe(spriteBatch);
            //Player(s)
            p1Char.DrawMe(spriteBatch, gameTime);
            //Farfalla
            for (int i = 0; i < farfalla.Count; i++)
            {
                farfalla[i].DrawMe(spriteBatch);
            }
        }
    }
}
