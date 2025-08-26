using App.Scripts.Game.Infrastructure.StateMachine.States.Interfaces;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Infrastructure.StateMachine
{
  public interface IGameStateMachine
  {
    UniTask Enter<TState>() where TState : IState;
  }
}