using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVersion
{
    string GetVersion();
}

public class BridgePattern : MonoBehaviour {

	// Use this for initialization
	void Start () {

        var a = new Version(new VersionA()).GetVersion();
        var b = new Version(new VersionB()).GetVersion();
        print("- " + a);
        print("- " + b);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class VersionA : IVersion
{
    public string GetVersion()
    {
        return "Version A";
    }
}

public class VersionB : IVersion
{
    public string GetVersion()
    {
        return "Version B";
    }
}

