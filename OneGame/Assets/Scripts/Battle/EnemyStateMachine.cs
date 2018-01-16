using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDataObject;

public class EnemyStateMachine : MonoBehaviour {

    public EnemyBase enemyBase;

    public enum EnemyState
    {
        Waiting,
        Action,
        Dead,
    }
    public EnemyState CurrentState;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (CurrentState)
        {
            case EnemyState.Waiting:
            {
                break;
            }
            case EnemyState.Action:
            {

                    break;
            }
            case EnemyState.Dead:
            {
                    break;
            }
            default:
                break;
        }
	}
}
