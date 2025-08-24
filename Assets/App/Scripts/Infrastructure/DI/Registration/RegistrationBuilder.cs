using System;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationBuilder
{
    public object Instance = null;
    
    public readonly Type ImplementationType;
    
    private List<object> _arguments = new List<object>();
    
    public object[] Arguments => _arguments.ToArray();
    public List<Type> InterfaceTypes { get; private set; }

    public RegistrationBuilder(Type implementationType)
    {
        ImplementationType = implementationType;
    }
    
    public RegistrationBuilder As(params Type[] interfaceTypes)
    {
        foreach (var interfaceType in interfaceTypes)
        {
            AddInterfaceType(interfaceType);
        }
        return this;
    }
    
    public void AddArguments(params object[] arguments)
    {
        _arguments.AddRange(arguments);
    }
    
    public RegistrationBuilder FromInstance(object instance)
    {
        Instance = instance;
        
        return this;
    }

    private void AddInterfaceType(Type interfaceType)
    {
        InterfaceTypes ??= new List<Type>();
        
        if (interfaceType.IsAssignableFrom(ImplementationType) == false)
        {
            throw new MyContainerException( $"{ImplementationType} is not assignable from {interfaceType}");
        }
        
        if (InterfaceTypes.Contains(interfaceType) == false)
            InterfaceTypes.Add(interfaceType);
    }
}