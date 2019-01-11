using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Danksouls.Source
{
    public interface ICamera
    {   
        string GetName();
        Vector3 GetPosition();
        void SetPosition(Vector3 position);
        Vector3 GetTarget();
        Matrix Getworld();
        Matrix GetView();
        void UpdateMouseRot(MouseState current, MouseState past, float timeDifference);
        void AddToCameraPosition(Vector3 vectorToAdd);
        void UpdateViewMatrix();
        Matrix GetProjection();
        Viewport GetViewport();

        

    }
}
