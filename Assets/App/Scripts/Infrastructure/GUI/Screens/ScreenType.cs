namespace App.Scripts.Infrastructure.GUI.Screens
{
    public enum ScreenType : byte
    {
        Game      = 0,
        Lobby     = 1,
        GameEnd   = 2,
        
        None     = byte.MaxValue,
    }
}