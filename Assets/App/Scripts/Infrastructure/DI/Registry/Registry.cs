using System;
using System.Collections.Generic;
namespace App.Scripts.Infrastructure.DI.Registry
{
    public sealed class Registry
    {
        private IDictionary<Type, Registration.Registration> _registrations = new Dictionary<Type, Registration.Registration>(128);
    }
}
