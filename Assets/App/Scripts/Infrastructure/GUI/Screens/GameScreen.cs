using Cysharp.Threading.Tasks;

namespace App.Scripts.Infrastructure.GUI.Screens
{
    public sealed class GameScreen : BaseScreen
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            
            Show().Forget();
        }

        public override ScreenType GetScreenType() => ScreenType.Game;
    }
}