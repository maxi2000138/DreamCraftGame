using UnityEngine;

namespace App.Scripts.Utils
{
  public static class Mathematics
  {
    public static float Remap(float iMin, float iMax, float oMin, float oMax, float value)
    {
      return Mathf.Lerp(oMin, oMax, Mathf.InverseLerp(iMin, iMax, value));
    }
    
    public static float HorizontalProjectedSqrDistance(this Vector3 from, Vector3 to)
    {
      var distanceVector = to - from;
      distanceVector.y = 0;
      
      return distanceVector.sqrMagnitude;
    }
  }
}