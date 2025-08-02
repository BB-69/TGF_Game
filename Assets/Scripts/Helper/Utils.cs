using UnityEngine;

namespace Utils
{
    public class CustomHelper
    {
        public static string Get8DirectionName(Vector2 v)
        {
            if (v.x == 0)
            {
                if (v.y > 0) return "UP";
                if (v.y < 0) return "DOWN";
                return "NONE";
            }
            else if (v.y == 0)
            {
                if (v.x > 0) return "RIGHT";
                if (v.x < 0) return "LEFT";
                return "NONE";
            }
            else
            {
                if (v.x > 0 && v.y > 0) return "RIGHT"; // change later for diagonal support
                if (v.x > 0 && v.y < 0) return "RIGHT";
                if (v.x < 0 && v.y < 0) return "LEFT";
                if (v.x < 0 && v.y > 0) return "LEFT";
                return "NONE";
            }
        }

        public static bool CompareTagList(GameObject obj, string[] tagList)
        {
            foreach (string t in tagList)
            {
                if (obj.CompareTag(t)) return true;
            }
            return false;
        }

        public static Vector2 RotateVector2ByDegree(Vector2 v, float deg)
        {
            float rad = deg * Mathf.Deg2Rad;
            return new Vector2(
                v.x * Mathf.Cos(rad) - v.y * Mathf.Sin(rad),
                v.x * Mathf.Sin(rad) + v.y * Mathf.Cos(rad)
            );
        }
    }
}
