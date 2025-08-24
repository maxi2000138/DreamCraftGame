using System;
using System.Collections.Generic;
public sealed class Registry
{
    private IDictionary<Type, Registration> _registrations = new Dictionary<Type, Registration>(128);
}
