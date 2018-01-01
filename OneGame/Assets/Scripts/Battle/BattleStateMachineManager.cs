using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachineManager : MonoBehaviour
{
    //this can define what state should go now and update UI

    Dictionary<string, BattleState> States;
    public BattleState currentState;
    private BattleMessageBoxManager dialogManager;

    public enum BattleState
    {
        Wait,
        TakeAction,
        Performation,
    }

    private void Awake()
    {
        dialogManager = FindObjectOfType<BattleMessageBoxManager>();
        States = new Dictionary<string, BattleState>();
        InitStates();
        
    }
    // Use this for initialization
    void Start ()
    {
        
        dialogManager.SetDialogActive(true);
        GoToState("entry");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// all states name:
    /// 
    /// 1,entry
    /// 2,attack
    /// 3,bag
    /// 4,team
    /// 5,runaway
    /// 
    /// </summary>

    #region Init States
    private void InitStates()
    {
        if (States == null)
            States = new Dictionary<string, BattleState>();


        List<string> statesList;
        //1 attack
        //statesList = new List<string> { "attack","bag", "team", "runaway"};
        //States.Add("entry", new BattleState()
        //{
        //    Name = "entry",
        //    StateAction = () => 
        //    {
        //        dialogManager.dialogLines = new string[] { "what do you want to do?", "good!!" };
        //    },
        //    StatesCanGoTo = statesList,
        //});

        //statesList = new List<string> { "attack_affect", "entry" };
        //States.Add("attack", new BattleState()
        //{
        //    Name = "attack",
        //    StateAction = () =>
        //    {

        //    },
        //    StatesCanGoTo = statesList,
        //});

        //statesList = new List<string> { "bag_affect", "entry" };
        //States.Add("bag", new BattleState()
        //{
        //    Name = "bag",
        //    StateAction = () =>
        //    {

        //    },
        //    StatesCanGoTo = statesList,
        //});

        //statesList = new List<string> { "team_affect", "entry" };
        //States.Add("team", new BattleState()
        //{
        //    Name = "team",
        //    StateAction = () =>
        //    {

        //    },
        //    StatesCanGoTo = statesList,
        //});

        //statesList = new List<string> { "runaway_affect", "entry" };
        //States.Add("runaway", new BattleState()
        //{
        //    Name = "runaway",
        //    StateAction = () =>
        //    {

        //    },
        //    StatesCanGoTo = statesList,
        //});

    }
    #endregion

    #region Go to state
    public void GoToState(string name)
    {
        if (States.ContainsKey(name))
        {
            //currentState = States[name];
            //var temp = currentState.StateAction;
            //if(temp!=null)
            //    temp.Invoke();
        }
    }
    #endregion
}


