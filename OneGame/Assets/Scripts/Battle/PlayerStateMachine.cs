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
    }

    public PlayerData Data;


    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
