using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Media;

namespace GME1003GoblinDanceParty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Declare some variables
        private int _numStars;                             //how many stars?
        private List<int> _starsX;                         //list of star x-coordinates
        private List<int> _starsY;                         //list of star y-coordinates
        private List<float> _starsRot;                     //list of rotation for each star
        private List<float> _starsTrans;                   //list of transparency for each star
        private List<float> _starsScale;                   //list of the scale for each star
        private List<Color> _starsColour;                  //list of the colour for each star

        private Texture2D _christmasSphere, _background;  //the sprite image for our star
        private Random _rng;                              //for all our random number needs


        //***This is for the goblin. Ignore it.
        Goblin goblin;
        Song music;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _rng = new Random();                 //finish setting up our Randon 
            _numStars = _rng.Next(50,301);       //random number of stars between 50 and 300
            _starsX = new List<int>();           //stars X coordinate
            _starsY = new List<int>();           //stars Y coordinate
            _starsRot = new List<float>();       //stars rotation
            _starsTrans = new List<float>();     //stars transparency
            _starsScale = new List<float>();     //stars scale
            _starsColour = new List<Color>();      //stars colour

            //use a separate for loop for each list - for practice
            //List of X coordinates
            for (int i = 0; i < _numStars; i++) 
            { 
                _starsX.Add(_rng.Next(0, 801)); //all star x-coordinates are between 0 and 801
            }

            //List of Y coordinates
            for (int i = 0; i < _numStars; i++)
            {
                _starsY.Add(_rng.Next(0, 481)); //all star y-coordinates are between 0 and 480
            }

            //List of Rotation
            for (int i = 0; i < _numStars; i++)
            {
                _starsRot.Add(_rng.Next(0, 101) / 100f);
            }

            //List of Transparency
            for (int i = 0; i < _numStars; i++)
            {
                _starsTrans.Add(_rng.Next(25, 101) / 100f);
            }

            //List of Scale
            for (int i = 0; i < _numStars; i++)
            {
                _starsScale.Add(_rng.Next(25, 101) / 100f);
            }

            //List of Colours
            for (int i = 0; i < _numStars; i++)
            {
                _starsColour.Add(new Color(128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129)));
            }


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load out star sprite, and background
            _christmasSphere = Content.Load<Texture2D>("ChristmasSphere");
            _background = Content.Load<Texture2D>("christmasBackground");


            //***This is for the goblin. Ignore it for now.
            goblin = new Goblin(Content.Load<Texture2D>("goblinChristmasSprite"), 400, 400);
            music = Content.Load<Song>("Song");
            
            //if you're tired of the music player, comment this out!
            MediaPlayer.Play(music);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

   
            //***This is for the goblin. Ignore it for now.
            goblin.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            _spriteBatch.Begin();

            //it would be great to have a background image here! 
            _spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            //this is where we draw the stars...
            for (int i = 0; i < _numStars; i++) 
            {
                _spriteBatch.Draw(_christmasSphere, 
                    new Vector2(_starsX[i], _starsY[i]),    //set the star position
                    null,                                   //ignore this
                    _starsColour[i] * _starsTrans[i],         //set colour and transparency
                    _starsRot[i],                          //set rotation
                    new Vector2(_christmasSphere.Width / 2, _christmasSphere.Height / 2), //ignore this
                    new Vector2(_starsScale[i], _starsScale[i]),    //set scale (same number 2x)
                    SpriteEffects.None,                     //ignore this
                    0f);                                    //ignore this
            }
            _spriteBatch.End();



            //***This is for the goblin. Ignore it for now.
            goblin.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
