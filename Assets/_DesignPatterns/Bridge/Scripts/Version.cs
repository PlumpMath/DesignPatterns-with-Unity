using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Version
{
    public Version(IVersion version)
    {
        _version = version;
    }

    private IVersion _version;

    public string GetVersion()
    {
        return "Version" + " <<< BRIDGE >>>> " + _version.GetVersion();
    }
}
