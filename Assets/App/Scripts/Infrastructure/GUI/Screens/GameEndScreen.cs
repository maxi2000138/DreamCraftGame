﻿using App.Scripts.Utils.Extensions;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using R3;

namespace App.Scripts.Infrastructure.GUI.Screens
{
  public sealed class GameEndScreen : BaseScreen
  {
    private Tween _tween;

    protected override void OnEnable()
    {
      base.OnEnable();
            
      _button
        .OnClickAsObservable()
        .First()
        .Subscribe(_ => Hide().Forget())
        .AddTo(LifeTimeDisposable);
            
      Show().Forget();
    }
        
    public override ScreenType GetScreenType() => ScreenType.GameEnd;

    protected override async UniTask Show()
    {
      await base.Show();

      _tween = BounceButton();
    }

    protected override async UniTask Hide()
    {
      _tween?.Kill();

      await base.Hide();
            
      CloseScreen.Execute(Unit.Default);
    }
  }
}