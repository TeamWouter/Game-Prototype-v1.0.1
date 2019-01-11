using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Danksouls.Source.Camera
{
    public class BCamera : ICamera
    {
        private string _name = "B";

        private Vector3 _position;
        private Vector3 _target;
        
        private Matrix _world;
        private Matrix _view;
        private Matrix _projection;

        private Viewport _viewport;

        private const float rotationSpeed = 0.3f;
        private float leftrightRot = MathHelper.PiOver2;
        private float updownRot = -MathHelper.Pi / 10.0f;

        public BCamera(GraphicsDeviceManager graphics)
        {
            
            _position = new Vector3(0f, 1f, 0f);
            _target = new Vector3(0f, 0f, 0f);

            _world = Matrix.CreateWorld(_target, new Vector3(1f, 0f, 0f), Vector3.Up);

            _view = Matrix.CreateLookAt(_position, _target,
                new Vector3(0f, 0f, 0f));
            _projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(120),
                graphics.GraphicsDevice.DisplayMode.AspectRatio,
                1f, 1000f);

            _viewport = new Viewport();
            _viewport.X = 400;
            _viewport.Y = 0;
            _viewport.Width = 800;
            _viewport.Height = 400;
            _viewport.MinDepth = 0;
            _viewport.MaxDepth = 1;
        }



        public string GetName()
        {
            return _name;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

        public void SetPosition(Vector3 position)
        {
            _position = position;
        }

        public Vector3 GetTarget()
        {
            return _position;
        }

        public Matrix Getworld()
        {
            return _world;
        }

        public Matrix GetView()
        {
            return _view;
        }

        public void UpdateMouseRot(MouseState current, MouseState past, float timeDifference)
        {
            float xDifference = current.X - past.X;
            float yDifference = current.Y - past.Y;
            leftrightRot -= rotationSpeed * xDifference * timeDifference;
            updownRot -= rotationSpeed * yDifference * timeDifference;
            Mouse.SetPosition(past.X, past.Y);
            UpdateViewMatrix();
        }

        public void AddToCameraPosition(Vector3 vectorToAdd)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            SetPosition(_position + 30.0f * rotatedVector);
            UpdateViewMatrix();
        }

        public void UpdateViewMatrix()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);

            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = _position + cameraRotatedTarget;

            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            _view = Matrix.CreateLookAt(_position, cameraFinalTarget, cameraRotatedUpVector);
        }

        public Matrix GetProjection()
        {
            return _projection;
        }

        public Viewport GetViewport()
        {
            return _viewport;
        }
    }
}
