﻿using App.Scripts.Infrastructure.Pool.Item;
using R3;

namespace App.Scripts.Game.Infrastructure.Systems.Components
{
  public abstract class MonoComponent : MonoSpawnableItem, IComponent
  {
    public CompositeDisposable LifetimeDisposable { get; private set; }

    public void SetActive(bool isActive) => gameObject.SetActive(isActive);

    
    public virtual void OnComponentCreate() => LifetimeDisposable = new CompositeDisposable();
    public virtual void OnComponentEnable() { }
    public virtual void OnComponentDisable() => LifetimeDisposable?.Clear();
    public virtual void OnComponentDestroy() => LifetimeDisposable?.Dispose();
    

    private void Awake()
    {
      OnComponentCreate();
    }

    private void OnDestroy()
    {
      OnComponentDestroy();
    }

    public override void OnSpawned()
    {
      base.OnSpawned();

      SetActive(true);
    }
    
    public override void OnDespawned()
    {
      base.OnDespawned();
      
      SetActive(false);
    }
  }
  
  public abstract class MonoComponent<T> : MonoComponent where T : MonoComponent
  {
    private void OnEnable()
    {
      base.OnComponentEnable();
      ComponentsContainer<T>.Registered(this);
    }

    private void OnDisable()
    {
      base.OnComponentDisable();
      ComponentsContainer<T>.Unregistered(this);
    }
  }
}