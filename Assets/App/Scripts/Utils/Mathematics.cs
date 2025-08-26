using UnityEngine;

namespace App.Scripts.Utils
{
  public class Mathematics
  {
    public static float Remap(float iMin, float iMax, float oMin, float oMax, float value)
    {
      return Mathf.Lerp(oMin, oMax, Mathf.InverseLerp(iMin, iMax, value));
    }
  }
}