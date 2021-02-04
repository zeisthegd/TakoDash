using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class Coordinator : Node2D
{
    public static Vector2 GetGlobalTouchPosition(Vector2 touchEventPosition)
    {
        Vector2 globalTouchPos = SceneManager.Tako.GetCanvasTransform().AffineInverse().Xform(touchEventPosition);
        return globalTouchPos;
    }
}
