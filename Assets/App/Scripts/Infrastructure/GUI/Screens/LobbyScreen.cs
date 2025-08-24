﻿using App.Scripts.Utils.Constants;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using R3;

namespace App.Scripts.Infrastructure.GUI.Screens
{
  public class LobbyScreen : BaseScreen
  {

    protected override void OnEnable()
    {
      base.OnEnable();

      _button
        .OnClickAsObservable()
        .ThrottleFirst(ButtonSettings.ClickThrottle)
        .Subscribe(_ => Hide().Forget())
        .AddTo(LifeTimeDisposable);
    }

    
    public override ScreenType GetScreenType() => ScreenType.Lobby;
    
    protected override async UniTask Hide()
    {
      await base.Hide();

      await FadeCanvas(1f, 0f).AsyncWaitForCompletion().AsUniTask();
      CloseScreen.Execute(Unit.Default);
    }

  }


}