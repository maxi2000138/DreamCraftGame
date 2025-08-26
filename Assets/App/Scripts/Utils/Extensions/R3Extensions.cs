#nullable enable
using System;
using Cysharp.Threading.Tasks;
using R3;

namespace App.Scripts.Utils.Extensions
{
  public static class R3Extensions
  {
    public static Observable<T> First<T>(this Observable<T> source) => source.Take(1);
    public static Observable<T> First<T>(this Observable<T> source, Func<T, bool> predicate) => source.Where(predicate).Take(1);
    
    public static void SetValueAndForceNotify<T>(this ReactiveProperty<T> source, T value)
    {
      source.Value = value;
      source.ForceNotify();
    }
    
    public static UniTask ToUniTask(this ReactiveCommand command)
    {
      var tcs = new UniTaskCompletionSource();
      IDisposable? disposable = null;

      disposable = command.Subscribe(_ =>
      {
        tcs.TrySetResult();
        disposable?.Dispose();
      });

      return tcs.Task;
    }
  }
}