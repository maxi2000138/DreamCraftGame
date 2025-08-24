using System;

namespace App.Scripts.Game.Infrastructure.Systems
{
    public interface ISystem : IDisposable
    {
        void EnableSystems();
        void DisableSystems();
        void Update();
        void FixedUpdate();
        void LateUpdate();
    }
}