using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Infrastructure.StateMachine.States.Interfaces
{
  public interface IEnterState : IState
  {
    public UniTask Enter(IGameStateMachine gameStateMachine);
  }
}