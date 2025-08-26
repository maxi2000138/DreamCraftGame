using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Infrastructure.StateMachine.States.Interfaces
{
  public interface IExitState : IState
  {
    public UniTask Exit(IGameStateMachine gameStateMachine);
  }
}