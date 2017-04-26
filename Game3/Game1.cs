using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Game3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ArrowUp;
        Texture2D ArrowDown;
        Texture2D ArrowRight;
        Texture2D ArrowLeft;
        Texture2D Background;
        Level level;
        List<Control> controlList = new List<Control>();
        Song song;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ArrowUp = Content.Load<Texture2D>("UpArrow");
            ArrowDown = Content.Load<Texture2D>("DownArrow");
            ArrowLeft = Content.Load<Texture2D>("LeftArrow");
            ArrowRight = Content.Load<Texture2D>("RightArrow");
            Background = Content.Load<Texture2D>("BACKGROUND");
            level = new Level("TEST.txt", ArrowUp, ArrowDown, ArrowRight, ArrowLeft);
            // ArrowMove = new GameObject (ArrowUp, new Vector2(50, 360));

            controlList.Add(new Control(ArrowLeft, new Vector2(50, 380), Keys.Left));
            controlList.Add(new Control(ArrowRight, new Vector2(150, 380), Keys.Right));
            controlList.Add(new Control(ArrowUp, new Vector2(250, 370), Keys.Up));
            controlList.Add(new Control(ArrowDown, new Vector2(330, 370), Keys.Down));

            this.song = Content.Load <Song>("Penguin Song");
            MediaPlayer.Play(song);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            level.Update(gameTime);
            Beat currentBeat = level.CurrentBeat();
            if (currentBeat == null)
            {
                return;
            }
            foreach(Control control in controlList)
            {
                if (control.IsPressed())
                {
                    switch (control.actionKey)
                    {
                        case Keys.Up:
                            currentBeat.upPressed = true;
                            break;
                        case Keys.Down:
                            currentBeat.downPressed = true;
                            break;
                        case Keys.Left:
                            currentBeat.leftPressed = true;
                            break;
                        case Keys.Right:
                            currentBeat.rightPressed = true;
                            break;
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);

            foreach (Control control in controlList)
            {
                control.Draw(spriteBatch);
            }
            level.Draw(spriteBatch);

            spriteBatch.End();
                


            base.Draw(gameTime);
        }
    }
}
