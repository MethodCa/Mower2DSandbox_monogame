using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Mower
{
    public class Sprite
    {
        public Rectangle texture;
        public byte type;
        private byte totalAnimationFrames;
        private byte currentFrame;
        private int frameDuration;
        private byte animationType;
        private float animationTimeChecker = 0;

        /// <summary>
        /// <para>
        /// <typeparamref name="Sprite"/> constructor. The class constructs a <typeparamref name="Sprite"/> object that contains a <typeparamref name="Rectangle"/>
        /// that stores the position of the texture in a texture atlas, aditionally has additional variables to achive and control animations.
        /// The Sprite object can be an animated or static texture, to create an animated <typeparamref name="Sprite"/> the following parameters must be 
        /// sent to the constructor:
        /// </para>
        /// <para>
        /// <typeparamref name="byte"/> <paramref name="tileType"></paramref> Type of tile for game-mechanics use: 0->Grass, 1->MowedGrass, 2->ConcreteBlock, 3->Dock, 4->Water, 5->Wood, 6->Roomba.<br/> 
        /// <typeparamref name="byte"/> <paramref name="animationType"></paramref> Type of animation, 0->Static Tile, 1->Loop animation, 2->One time animation.<br/>
        /// <typeparamref name="int"/> <paramref name="frameDuration"></paramref> Frame duration in miliseconds<br/>
        /// <typeparamref name="byte"/> <paramref name="totalAnimationFrames"></paramref> The quantity of frames to animate the texture of the <typeparamref name="Sprite"/> Object.<br/>
        /// </para>
        /// </summary>
        /// <param name="tileType">Type of tile for game-mechanics use: 0->Grass, 1->MowedGrass, 2->ConcreteBlock, 3->Dock, 4->Water, 5->Wood, 6->Roomba.</param>
        /// <param name="animationType">Type of animation, 0->Static Tile, 1->Loop animation, 2->One time animation.</param>
        /// <param name="frameDuration">Frame duration in miliseconds.</param>
        /// <param name="totalAnimationFrames">The quantity of frames to animate the texture of the GameObject.</param>
        /// <returns><typeparamref name="Sprite"/></returns>
        public Sprite(byte tileType, byte animationType, int frameDuration, byte totalAnimationFrames)
        {
            switch (tileType)
            {
                case 0: this.texture = new Rectangle(2, 2, 32, 32); break;
                case 1: this.texture = new Rectangle(2, 2, 32, 32); break;
                case 2: this.texture = new Rectangle(326, 2, 32, 32); break;
                case 3: this.texture = new Rectangle(362, 2, 32, 32); break;
                case 4: this.texture = new Rectangle(398, 2, 32, 32); break;
                case 5: this.texture = new Rectangle(686, 2, 32, 32); break;
                case 6: this.texture = new Rectangle(722, 2, 32, 32); break;
                default: this.texture = new Rectangle(792, 2, 32, 32); break;
            };
            this.totalAnimationFrames = --totalAnimationFrames;
            this.currentFrame = 0;
            this.frameDuration = frameDuration;
            this.animationType = animationType;
            this.type = tileType;
        }
        /// <summary>
        /// <para>
        /// <typeparamref name="Sprite"/> constructor. The class constructs a <typeparamref name="Sprite"/> object that contains a <typeparamref name="Rectangle"/>
        /// that stores the position of the texture in a texture atlas. This constructor creates static sprites ONLY. To create a <typeparamref name="Sprite"/> the following parameters must be 
        /// sent to the constructor:
        /// </para>
        /// <para>
        /// <typeparamref name="byte"/> <paramref name="tileType"></paramref> Type of tile for game-mechanics use: 0->Grass, 1->MowedGrass, 2->ConcreteBlock, 3->Dock, 4->Water, 5->Wood, 6->Roomba.<br/> 
        /// <typeparamref name="byte"/> <paramref name="animationType"></paramref> Type of animation, 0->Static Tile, 1->Loop animation, 2->One time animation.<br/>
        /// <typeparamref name="int"/> <paramref name="frameDuration"></paramref> Frame duration in miliseconds<br/>
        /// <typeparamref name="byte"/> <paramref name="totalAnimationFrames"></paramref> The quantity of frames to animate the texture of the <typeparamref name="Sprite"/> Object.<br/>
        /// </para>
        /// </summary>
        /// <param name="tileType">Type of tile for game-mechanics use: 0->Grass, 1->MowedGrass, 2->ConcreteBlock, 3->Dock, 4->Water, 5->Wood, 6->Roomba.</param>
        /// <param name="animationType">Type of animation, 0->Static Tile, 1->Loop animation, 2->One time animation.</param>
        /// <param name="frameDuration">Frame duration in miliseconds.</param>
        /// <param name="totalAnimationFrames">The quantity of frames to animate the texture of the GameObject.</param>
        /// <returns><typeparamref name="Sprite"/></returns>
        public Sprite(byte type)
        {
            switch (type)
            {
                case 0: this.texture = new Rectangle(2, 2, 32, 32); break;
                case 1: this.texture = new Rectangle(290, 2, 32, 32); break;
                case 2: this.texture = new Rectangle(326, 2, 32, 32); break;
                case 3: this.texture = new Rectangle(362, 2, 32, 32); break;
                case 4: this.texture = new Rectangle(398, 2, 32, 32); break;
                case 5: this.texture = new Rectangle(686, 2, 32, 32); break;
                case 6: this.texture = new Rectangle(722, 2, 32, 32); break;
                default: this.texture = new Rectangle(792, 2, 32, 32); break;
            }
            this.type = type;
        }
        /// <summary>
        /// <para>
        /// <typeparamref name="Sprite"/> Update function. This method should be invoked each frame and is in charge of updating the animation frames using
        /// <paramref name="animationType"></paramref> 0: For a static frame, 1: to loop the animation frames and 2: to play the animation one time only.<br/>
        /// <paramref name="frameDuration"></paramref> is used to wait <strong>X</strong> miliseconds to change to the next frame that should be displayed.<br/>
        /// <paramref name="currentFrame"></paramref> is incremented each frame, if <paramref name="currentFrame"></paramref> is greater than 
        /// <paramref name="totalAnimationFrames"></paramref>, <paramref name="currentFrame"></paramref> is set to 0 to loop the animation or set = 
        /// <paramref name="totalAnimationFrames"></paramref> to stop the animation in the last frame.
        /// </para>
        /// <para>
        /// <typeparamref name="byte"/> <paramref name="tileType"></paramref> Type of tile for game-mechanics use: 0->Grass, 1->MowedGrass, 2->ConcreteBlock, 3->Dock, 4->Water, 5->Wood, 6->Roomba.<br/> 
        /// <typeparamref name="byte"/> <paramref name="animationType"></paramref> Type of animation, 0->Static Tile, 1->Loop animation, 2->One time animation.<br/>
        /// <typeparamref name="int"/> <paramref name="frameDuration"></paramref> Frame duration in miliseconds<br/>
        /// <typeparamref name="byte"/> <paramref name="totalAnimationFrames"></paramref> The quantity of frames to animate the texture of the <typeparamref name="Sprite"/> Object.<br/>
        /// </para>
        /// </summary>
        /// <param name="tileType">Type of tile for game-mechanics use: 0->Grass, 1->MowedGrass, 2->ConcreteBlock, 3->Dock, 4->Water, 5->Wood, 6->Roomba.</param>
        /// <param name="animationType">Type of animation, 0->Static Tile, 1->Loop animation, 2->One time animation.</param>
        /// <param name="frameDuration">Frame duration in miliseconds.</param>
        /// <param name="totalAnimationFrames">The quantity of frames to animate the texture of the GameObject.</param>
        public void Update(GameTime gameTime)
        {
            //Update animation of Sprite
            if (!(this.animationType == 0))
            {
                if (animationTimeChecker >= frameDuration)
                {
                    currentFrame++;
                    if (currentFrame > totalAnimationFrames)
                    {
                        if (animationType == 1)
                            currentFrame = 0;
                        else
                            currentFrame = totalAnimationFrames;
                    }
                    animationTimeChecker = 0;
                }
            }
            this.animationTimeChecker += (float)gameTime.ElapsedGameTime.Milliseconds;
        }
        public Rectangle Render()
        {
            int offset = (texture.Width + 4) * (currentFrame);
            return new Rectangle(texture.X + offset, texture.Y, texture.Width, texture.Height);
        }
    }
    public class Collider
    {
        public Rectangle boundingBox;
        public bool triggered;
        public Vector2 lastFramePosition;

        public Collider(Rectangle boundingBox, bool triggered)
        {
            this.boundingBox = boundingBox;
            this.triggered = triggered;
        }

        public bool Collision(Collider other)
        {
            if (other.boundingBox.Intersects(this.boundingBox))
            {
                return true;
            }
            else
               return false;
        }
    }
    public class GameObject
    {
        public Vector2 position;
        public Sprite sprite;
        public Collider collider;

        /// <summary>
        /// <typeparamref name="GameObject"/> constructor. The class constructs 2 types of <typeparamref name="GameObject"/>, animated or static, to create an animated <typeparamref name="GameObject"/> 
        /// the following parameters must be sent to the constructor:
        /// <para>
        /// <typeparamref name="Vector2"/> <paramref name="position"></paramref> The in-game position for the <typeparamref name="GameObject"/>.<br/>
        /// <typeparamref name="Sprite"/> <paramref name="sprite"></paramref> The sprite that will be rendered for the <typeparamref name="GameObject"/>.<br/>
        /// </para>
        /// </summary>
        /// <param name="position">The in-game position for the <typeparamref name="GameObject"/>.</param>
        /// <param name="sprite">The sprite that will be rendered for the <typeparamref name="GameObject"/>.</param>
        /// <returns><typeparamref name="GameObject"/></returns>
        public GameObject(Vector2 position, Sprite sprite, Collider collider)
        { 
            this.position = position;
            this.sprite = sprite;
            this.collider = collider;
        }
        public virtual void Update(GameTime gameTime)
        {
            collider.boundingBox = new Rectangle((int)position.X, (int)position.Y, sprite.texture.Width, sprite.texture.Height);
            sprite.Update(gameTime); 
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D atlas)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(atlas, this.position, sprite.Render(), Color.White);
            spriteBatch.End();
        }
    }
    public class Mower : GameObject
    {
        public float velocity;
        public float angle;

        public Mower(Vector2 position, Sprite sprite, Collider collider, float velocity, float angle) : base(position, sprite, collider) 
        {
            this.velocity = velocity;
            this.angle = angle;
        }
        public override void Update(GameTime gameTime)
        {
            //Update position of gameObject
            position += calculateDirection(angle, velocity, (float)gameTime.ElapsedGameTime.TotalSeconds);
            //Update GameObject
            base.Update(gameTime);
        }
        public Vector2 calculateDirection(float angle, float velocity, float deltaTime)
        {
            float radianAngle = MathHelper.ToRadians(angle);
            Vector2 direction = new Vector2((float)Math.Sin(radianAngle), (float)Math.Cos(radianAngle));
            return direction * velocity * deltaTime;
        }
    }
    public class MowerApp : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        private Texture2D atlas;
        private Mower mower;
        int[,] rawMap = {
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,4,4,4,4,4,4,4,2,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,4,4,4,4,4,4,4,2,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,4,4,4,4,4,4,4,2,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5 },
            {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5 },
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5 }
        };
        List<GameObject> map = new List<GameObject>();
        public MowerApp()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // Create Mower GameObject

            mower = new Mower(
                new Vector2(384, 224),
                new Sprite(6),
                new Collider(new Rectangle(), false),
                200,
                90);
            //Create level
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    Vector2 position = new Vector2(j * 32, i * 32);
                    GameObject tile;
                    Collider collider = new Collider(new Rectangle((int)position.X, (int)position.Y, 32, 32), false);
                    Collider triggeredCollider = new Collider(new Rectangle((int)position.X, (int)position.Y, 32, 32), true);
                    switch (rawMap[i, j])
                    {
                        case 0: tile = new GameObject(position, new Sprite(0), triggeredCollider); break;
                        case 1: tile = new GameObject(position, new Sprite(1), triggeredCollider); break;
                        case 2: tile = new GameObject(position, new Sprite(2), triggeredCollider); break;
                        case 3: tile = new GameObject(position, new Sprite(3), triggeredCollider); break;
                        case 4: tile = new GameObject(position, new Sprite(4,1,200,8), triggeredCollider); break;
                        case 5: tile = new GameObject(position, new Sprite(5), collider); break;
                        default: tile = new GameObject(position, new Sprite(0), triggeredCollider); break;
                    }
                    map.Add(tile);
                }
            }
            base.Initialize();
        }
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("fonts/Aseprite");
            atlas = Content.Load<Texture2D>("sprites/atlas");
        }
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //Update Mower
            mower.collider.lastFramePosition = mower.position;
            mower.Update(gameTime);
            //Update Map
            for (int i = 0; i < map.Count; i++)
            {
                map[i].Update(gameTime);
                if (mower.collider.Collision(map[i].collider))
                {
                    if (map[i].sprite.type == 5 || map[i].sprite.type == 2)
                    {
                        mower.position = mower.collider.lastFramePosition;
                        mower.angle = (mower.angle - 180 + 75);
                        int correctedAngle = ((int)mower.angle + (int)(Math.Abs(mower.angle) / 360) * 360);
                        mower.angle = correctedAngle < 0 ? 360 + correctedAngle : correctedAngle;
                    }
                    if (map[i].sprite.type == 0)
                    {
                        Collider triggeredCollider = new Collider(new Rectangle((int)map[i].position.X, (int)map[i].position.Y, 32, 32), true);
                        map.Add(new GameObject(map[i].position, new Sprite(1, 2, 80, 9), triggeredCollider));
                        map.RemoveAt(i);
                    }
                }
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        { 
            // TODO: Add your drawing code here
            GraphicsDevice.Clear(Color.Black);
            foreach (GameObject i in map)
                i.Draw(_spriteBatch, atlas);
            mower.Draw(_spriteBatch, atlas);
            base.Draw(gameTime);
        }
    }
}