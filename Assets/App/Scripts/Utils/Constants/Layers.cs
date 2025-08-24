using UnityEngine;

namespace App.Scripts.Utils.Constants
{
  public static class Layers
  {
    public static int Ground => 1 << LayerMask.NameToLayer(nameof(Ground));
  }
}