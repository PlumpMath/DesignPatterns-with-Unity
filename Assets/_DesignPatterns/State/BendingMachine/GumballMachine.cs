using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is the context
public class GumballMachine : MonoBehaviour {

    public Button InsertTokenButton;
    public Button EjectTokenButton;
    public Button TurnCrankButton;
    public Button DispenseButton;

    public Dropdown TokenAmountDropdown;

    public Text GumballCountText;

    public int count = 20;

    // hold each state
    private IState soldOutState;
    private IState noTokenState;
    private IState hasTokenState;
    private IState soldState;
    
    // current state
    private IState state;

    public int GetCount()
    {
        return count;
    }

    public void SetState(IState s)
    {
        state = s;
    }

    public IState GetNoTokenState()
    {
        return noTokenState;
    }

    public IState GetSoldState()
    {
        return soldState;
    }

    public IState GetHasTokenState()
    {
        return hasTokenState;
    }

    public IState GetSoldOutState()
    {
        return soldOutState;
    }

    void Awake()
    {
        
    }

    void Start()
    {
        soldOutState = new SoldOutState(this);
        noTokenState = new NoTokenState(this);
        hasTokenState = new HasTokenState(this);
        soldState = new SoldState(this);

        UpdateCountText();

        if (count > 0)
        {
            state = noTokenState;
        }
    }

    private void OnEnable()
    {
        InsertTokenButton.onClick.AddListener(InsertToken);
        EjectTokenButton.onClick.AddListener(EjectToken);
        TurnCrankButton.onClick.AddListener(TurnCrank);
        DispenseButton.onClick.AddListener(Dispense);

        TokenAmountDropdown.onValueChanged.AddListener(OnTokenValueChanged);
    }

    private void OnTokenValueChanged(int token)
    {
        
    }

    private void OnDisable()
    {
        InsertTokenButton.onClick.RemoveListener(InsertToken);
        EjectTokenButton.onClick.RemoveListener(EjectToken);
        TurnCrankButton.onClick.RemoveListener(TurnCrank);
        DispenseButton.onClick.RemoveListener(Dispense);
    }
    
    public void InsertToken()
    {
        state.InsertToken();
    }

    public void EjectToken()
    {
        state.EjectToken();
    }

    public void TurnCrank()
    {
        state.TrunCrank();
        state.Dispense();
    }

    public void Dispense()
    {
        
    }

    public void ReleaseBall()
    {
        if (count != 0)
        {
            count--;
        }
    }

    // refill method here?
    void UpdateCountText()
    {
        GumballCountText.text = count.ToString();
    }

}
