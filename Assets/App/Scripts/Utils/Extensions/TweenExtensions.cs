﻿using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Utils.Extensions
{
  public static class TweenExtensions
  {
    public static Tween PunchTransform(this Transform transform)
    {
      return transform
        .DOPunchScale(Vector3.one * 0.25f, 0.25f, 1, 0.5f)
        .SetEase(Ease.InSine)
        .SetRelative()
        .SetLink(transform.gameObject)
        .OnComplete(() => transform.localScale = Vector3.one);
    }
  }
}