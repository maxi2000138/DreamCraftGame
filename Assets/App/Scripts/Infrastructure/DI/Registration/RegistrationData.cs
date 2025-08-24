using System;
using System.Collections.Generic;

public class RegistrationData
{
    public Dictionary<Type, Registration> Registrations { get; private set; }

    private List<RegistrationBuilder> _builders = new();
    
    public void AddRegistrationBuilder(RegistrationBuilder registrationBuilder)
    {
        _builders.Add(registrationBuilder);
    }

    public void Build()
    {
        Registrations = new();
        
        foreach (RegistrationBuilder builder in _builders) 
        {
            foreach (Type interfaceType in builder.InterfaceTypes)
            {
                AddRegistration(interfaceType, builder);
            }
        }
    }

    private void AddRegistration(Type interfaceType, RegistrationBuilder registrationBuilder)
    {
        if(Registrations.ContainsKey(interfaceType) == false)
            Registrations.Add(interfaceType, new Registration());
            
        Registrations[interfaceType].AddBuilder(registrationBuilder);
    }
}
