using UnityEngine;

namespace App.Scripts.Utils.Extensions
{
  public static class VectorExtension
  {
    public static Vector3 AddY(this Vector3 vector, float add) => new Vector3(vector.x, vector.y + add, vector.z);
    public static Vector3 AddX(this Vector3 vector, float add) => new Vector3(vector.x + add, vector.y, vector.z);
    public static Vector3 AddZ(this Vector3 vector, float add) => new Vector3(vector.x, vector.y, vector.z + add);
    public static Vector3 ZeroX(this Vector3 vector) => new Vector3(0f, vector.y, vector.z);
    public static Vector3 ZeroY(this Vector3 vector) => new Vector3(vector.x, 0f, vector.z);
    public static Vector3 ZeroZ(this Vector3 vector) => new Vector3(vector.x, vector.y, 0f);
    public static Vector3 SetX(this Vector3 vector, float x) => new Vector3(x, vector.y, vector.z);
    public static Vector3 SetY(this Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);
    public static Vector3 SetZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);
  }
}