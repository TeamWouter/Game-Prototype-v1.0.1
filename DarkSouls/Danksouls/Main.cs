using System;
using System.Collections.Generic;
using System.Diagnostics;
using Danksouls.Source;
using Danksouls.Source.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Danksouls
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        private ICamera[] _cameras;

            //Mouse
        MouseState originalMouseState;
        MouseState currentMouseState;

        //BasicEffect for rendering
        BasicEffect basicEffect;

        //Geometric info
        VertexPositionTexture[] floorVerts;
        VertexBuffer vertexBuffer;

        //Load
        Skybox skybox;
        Texture2D image;
        Effect shaderEffect;

        Matrix world1 = Matrix.Identity;
        Matrix view1 = Matrix.CreateLookAt(new Vector3(20, 0, 0), new Vector3(0, 0, 0), Vector3.UnitY);
        Matrix projection1 = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 600f, 0.1f, 100f);
        Vector3 cameraPosition1;
        float angle1 = 0;
        float distance1 = 20;


        public Main()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1600;

            _cameras = new ICamera[3];  
        }

        protected override void Initialize()
        {
            base.Initialize();

            //Cameras
            _cameras[0] = new ACamera(graphics);
            _cameras[1] = new BCamera(graphics);
            _cameras[2] = new CCamera(graphics);
    
            //Mouse
            Mouse.SetPosition(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            originalMouseState = Mouse.GetState();

            //BasicEffect
            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Alpha = 1f;
            basicEffect.TextureEnabled = true;

            //Cull
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rasterizerState;

            //basicEffect.VertexColorEnabled = true;
            basicEffect.LightingEnabled = false;

            //Shapes
            floorVerts = new VertexPositionTexture[6];
            floorVerts[0] = new VertexPositionTexture(new Vector3(-50, 0, -50), new Vector2(0, 0));
            floorVerts[1] = new VertexPositionTexture(new Vector3(-50, 0, 50), new Vector2(0, 1));
            floorVerts[2] = new VertexPositionTexture(new Vector3(50, -0, -50), new Vector2(1, 0));
            floorVerts[3] = new VertexPositionTexture(floorVerts[1].Position, floorVerts[1].TextureCoordinate);
            floorVerts[4] = new VertexPositionTexture(new Vector3(50, 0, 50), new Vector2(1, 1));
            floorVerts[5] = new VertexPositionTexture(floorVerts[4].Position, floorVerts[4].TextureCoordinate);

            //Vert buffer
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(
                VertexPositionTexture), floorVerts.Length, BufferUsage.
                WriteOnly);
            vertexBuffer.SetData<VertexPositionTexture>(floorVerts);
            GraphicsDevice.SetVertexBuffer(vertexBuffer);
        }

        protected override void LoadContent()
        {
            image = Content.Load<Texture2D>("1000x1000");
            shaderEffect = Content.Load<Effect>("Shader");
            skybox = new Skybox("Skyboxes/Sunset", Content);

            Debug.Print("Text");
        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            float timeDifference = (float) gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                    Keys.Escape))
                Exit();

            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState != originalMouseState)
            {
                foreach (ICamera camera in _cameras)
                {
                    camera.UpdateMouseRot(currentMouseState, originalMouseState, timeDifference);
                }
            }

            Vector3 moveVector = new Vector3(0, 0, 0);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                moveVector += new Vector3(0, 0, -1);
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                moveVector += new Vector3(0, 0, 1);
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                moveVector += new Vector3(1, 0, 0);
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                moveVector += new Vector3(-1, 0, 0);
            if (keyState.IsKeyDown(Keys.Q))
                moveVector += new Vector3(0, 1, 0);
            if (keyState.IsKeyDown(Keys.Z))
                moveVector += new Vector3(0, -1, 0);

            foreach (ICamera camera in _cameras)
            {
                camera.AddToCameraPosition(moveVector * timeDifference);
            }

            angle1 += 0.002f;
            cameraPosition1 = distance1 * new Vector3((float)Math.Sin(angle1), 0, (float)Math.Cos(angle1));
            view1 = Matrix.CreateLookAt(cameraPosition1, new Vector3(0, 0, 0), Vector3.UnitY);

            base.Update(gameTime);
        }
 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            foreach (ICamera camera in _cameras)
            {
                //skybox.Draw(camera.GetView(), camera.GetProjection(), camera.GetPosition());

                graphics.GraphicsDevice.Viewport = camera.GetViewport();
                DrawQuad(camera.Getworld(), camera.GetView(), camera.GetProjection(), camera.GetName());

                

            }
           
            base.Draw(gameTime);
        }

        private void DrawQuad(Matrix world, Matrix view, Matrix projection, string cameraName)
        {
            basicEffect.Projection = projection;
            basicEffect.View = view;
            basicEffect.World = world;
            basicEffect.Texture = image;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.
                Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip
                    , 0, floorVerts.Length);
            }

            /* GRAY SHADER NOT WORKING
            if (cameraName.Equals("A") || cameraName.Equals("C"))
            {
                shaderEffect.CurrentTechnique.Passes[0].Apply();
                    GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip
                        , 0, floorVerts.Length);
                
            }
            */

        }








    }
}
