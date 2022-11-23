using UnityEngine;
using UnityEngine.EventSystems;

namespace Code
{
    public static class Extensions
    {
        public static Vector3 WithY(this Vector3 self, float y)
        {
            self.y = y;
            return self;
        }

        public static Vector3 AsWorldPositionFor(this Vector3 self, Vector3 position)
        {
            Plane plane = new Plane(Vector3.up, position);
            Ray ray = Camera.main.ScreenPointToRay(self);
            if (plane.Raycast(ray, out var distance))
            {
                return ray.origin + ray.direction * distance;
            }

            return position;
        }
        
        public static Vector3 AsWorldPositionFor(this PointerEventData self, Vector3 position)
        {
            return AsWorldPositionFor(self.position, position);
        }

        public static Color GetMaterialColor(this MonoBehaviour self)
        {
            return self.GetComponent<Renderer>().material.color;
        }
    }
}