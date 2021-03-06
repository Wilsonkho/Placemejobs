﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Principal;

public class CustomPrincipal : IPrincipal
{
    private IIdentity _identity;
    private string[] _roles;
    public CustomPrincipal(IIdentity identity, string[] roles)
    {
        _identity = identity;
        _roles = new string[roles.Length];
        roles.CopyTo(_roles, 0);
        Array.Sort(_roles);
    }

    public IIdentity Identity
    {
        get
        {
            return _identity;
        }
    }

    public bool IsInRole(string role)
    {
        return Array.BinarySearch(_roles, role) >= 0 ? true : false;
    }
}