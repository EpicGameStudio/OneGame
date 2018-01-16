using GameDataObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour {

    public enum PlayerState
    {
        Waiting,
        ChooseAction,
        Action,
        Dead,
        Win,
    }

    public PlayerBase playerBase;

    public PlayerData Data;

    public PlayerState currentState;

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        switch (currentState)
        {
            case PlayerState.Waiting:
                break;
            case PlayerState.ChooseAction:
                break;
            case PlayerState.Action:
                break;
            case PlayerState.Dead:
                break;
            default:
                break;
        }
    }
}
