using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void InsertToken();
    void EjectToken();
    void TrunCrank();
    void Dispense();
}

// ==== Concreate states
public class WinnerState : IState
{
    private GumballMachine gumballMachine;

    public WinnerState(GumballMachine gumballMachine)
    {
        this.gumballMachine = gumballMachine;
    }

    public void InsertToken()
    {
        
    }

    public void EjectToken()
    {
        
    }

    public void TrunCrank()
    {
        
    }

    public void Dispense()
    {
        
    }
}

public class SoldState : IState
{
    private GumballMachine gumballMachine;

    public SoldState(GumballMachine gumballMachine)
    {
        this.gumballMachine = gumballMachine;
    }

    public void InsertToken()
    {
        Debug.Log("Please wait, we are already giving you a gumball!");
    }

    public void EjectToken()
    {
        Debug.Log("Sorry, you already turned the crank");
    }

    public void TrunCrank()
    {
        Debug.Log("Turning twice doesn't get you another gumball!");
    }

    public void Dispense()
    {
        gumballMachine.ReleaseBall();
        if (gumballMachine.GetCount() > 0)
        {
            gumballMachine.SetState(gumballMachine.GetNoTokenState());
        }
        else
        {
            Debug.Log("Opps! out of gumballs!");
            gumballMachine.SetState(gumballMachine.GetSoldOutState());
        }
    }
}

public class SoldOutState : IState
{
    private GumballMachine gumballMachine;

    public SoldOutState(GumballMachine gumballMachine)
    {
        this.gumballMachine = gumballMachine;
    }

    public void InsertToken()
    {
        Debug.Log("You can't insert a token, the machine is sold out!");
    }

    public void EjectToken()
    {
        Debug.Log("You can't eject, you haven't inserted a quarter yet!");
    }

    public void TrunCrank()
    {
        Debug.Log("You turned! But there are no gumballs!");
    }

    public void Dispense()
    {
        Debug.Log("No gumball dispensed");
    }
}

public class NoTokenState : IState
{
    private GumballMachine gumballMachine;

    public NoTokenState(GumballMachine gumballMachine)
    {
        this.gumballMachine = gumballMachine;
    }

    public void InsertToken()
    {
        Debug.Log("You inserted a token");
        gumballMachine.SetState(gumballMachine.GetHasTokenState());
    }

    public void EjectToken()
    {
        Debug.Log("You haven't inserted a token");
    }

    public void TrunCrank()
    {
        Debug.Log("You turned! But there are no token!");
    }

    public void Dispense()
    {
        Debug.Log("You need to pay first");
    }
}

public class HasTokenState : IState
{
    private GumballMachine gumballMachine;

    public HasTokenState(GumballMachine gumballMachine)
    {
        this.gumballMachine = gumballMachine;
    }

    public void InsertToken()
    {
        Debug.Log("You can't insert another token");
    }

    public void EjectToken()
    {
        Debug.Log("Token returned");
        gumballMachine.SetState(gumballMachine.GetNoTokenState());
    }

    public void TrunCrank()
    {
        Debug.Log("You turned...");
        gumballMachine.SetState(gumballMachine.GetSoldState());
    }

    public void Dispense()
    {
        Debug.Log("No gumball dispensed");
    }
}
