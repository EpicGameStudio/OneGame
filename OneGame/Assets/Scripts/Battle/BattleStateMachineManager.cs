using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStateMachineManager : MonoBehaviour
{
    //this can define what state should go now and update UI

    Dictionary<string, BattleState> States;
   
    private BattleMessageBoxManager dialogManager;

    public PlayerStateMachine player;
    public EnemyStateMachine enemy;
    GameObject Selector;
    GameObject EnemyStatus;
    GameObject PlayerStatus;

    Transform enemyHP;
    Transform playerHP;
    Transform playerExp;

    public enum BattleState
    {
        Wait,
        TakeAction,
        Performation,
    }

    private void Awake()
    {
        EnemyStatus = GameObject.Find("EnemyStatus");
        PlayerStatus = GameObject.Find("PlayerStatus");

        enemyHP = EnemyStatus.transform.Find("HPBackground");
        playerHP= PlayerStatus.transform.Find("HPBackground");
        playerExp = PlayerStatus.transform.Find("ExpBackground"); 
        player = FindObjectOfType<PlayerStateMachine>();
        enemy = FindObjectOfType<EnemyStateMachine>();
        dialogManager = FindObjectOfType<BattleMessageBoxManager>();

        Selector = GameObject.Find("Selector");
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
        UpdateStatus();
        if (player.currentState == PlayerStateMachine.PlayerState.Waiting)
        {
            Selector.SetActive(false);
        }
        else if (player.currentState == PlayerStateMachine.PlayerState.ChooseAction)
        {
            Selector.SetActive(true);
        }
        else if (player.currentState == PlayerStateMachine.PlayerState.Win)
        {
            player.playerBase.Exp += enemy.enemyBase.Lv;
            if (player.playerBase.Exp % (player.playerBase.Lv*256) > (player.playerBase.Lv-1))
            {
                player.playerBase.Lv++;
            }

            SceneManager.LoadScene("OverWorld");
        }
    }


    private void UpdateStatus()
    {
        var eHPValue = (float)enemy.enemyBase.HP / enemy.enemyBase.MaxHP;
        var pHPValue = (float)player.playerBase.HP / player.playerBase.MaxHP;
        enemyHP.transform.localScale = new Vector3(eHPValue,1f,1f);
        playerHP.transform.localScale = new Vector3(pHPValue,1f,1f);

        var pExpValue = (float)player.playerBase.Exp / (player.playerBase.Lv + 1 * 128);
        playerExp.transform.localScale = new Vector3(pExpValue,1,1);
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


