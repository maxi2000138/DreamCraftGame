﻿using UnityEngine;

namespace App.Scripts.Infrastructure.GUI.Canvas
{
    public sealed class StaticCanvas : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Canvas _canvas;
        [SerializeField] private CanvasGroup _canvasGroup;

        public UnityEngine.Canvas Canvas => _canvas;
        public CanvasGroup CanvasGroup => _canvasGroup;
    }
}