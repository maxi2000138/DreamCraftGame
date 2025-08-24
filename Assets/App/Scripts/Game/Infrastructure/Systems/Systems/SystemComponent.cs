﻿using System.Collections.Generic;
using App.Scripts.Game.Infrastructure.Systems.Components;

namespace App.Scripts.Game.Infrastructure.Systems.Systems
{
    public abstract class SystemComponent<T> : SystemBase where T : IComponent
    {
        private readonly List<T> _components;
        
        protected IReadOnlyList<T> Components => _components;

        protected SystemComponent()
        {
            _components = new List<T>();
        }

        protected override void OnEnableSystem()
        {
            base.OnEnableSystem();
            
            ComponentsContainer<T>.OnRegistered += OnEnableComponent;
            ComponentsContainer<T>.OnUnregistered += OnDisableComponent;
        }

        protected override void OnDisableSystem()
        {
            base.OnDisableSystem();
            
            ComponentsContainer<T>.OnRegistered -= OnEnableComponent;
            ComponentsContainer<T>.OnUnregistered -= OnDisableComponent;
        }

        protected virtual void OnEnableComponent(T component)
        {
            if (_components.Contains(component))
            {
                return;
            }
            
            _components.Add(component);
        }

        protected virtual void OnDisableComponent(T component)
        {
            _components.Remove(component);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _components.Clear();
        }
    }

}