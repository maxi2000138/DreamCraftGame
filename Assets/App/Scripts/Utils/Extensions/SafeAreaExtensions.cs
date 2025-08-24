﻿using UnityEngine;

namespace App.Scripts.Utils.Extensions
{
  public static class SafeAreaExtensions
  {
    public static void ApplySafeArea(this RectTransform rectTransform)
    {
      Rect rect = Screen.safeArea;
            
      Vector2 anchorMin = rect.position;
      Vector2 anchorMax = rect.position + rect.size;
      anchorMin.x /= Screen.width;
      anchorMin.y /= Screen.height;
      anchorMax.x /= Screen.width;
      anchorMax.y /= Screen.height;
      rectTransform.anchorMin = anchorMin;
      rectTransform.anchorMax = anchorMax;
    }
  }
}