using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorManager : MonoBehaviour
{
    public PlayerStateMachine player;
    public EnemyStateMachine enemy;

    private void Awake()
    {
        player = FindObjectOfType<PlayerStateMachine>();
        enemy = FindObjectOfType<EnemyStateMachine>();
    }
    public void PlayerAttact()
    {
        var playerBase = player.playerBase;
        var enemyBase = enemy.enemyBase;

       
        StartCoroutine(TakeAction());
    }

    IEnumerator TakeAction()
    {
        var playerBase = player.playerBase;
        var enemyBase = enemy.enemyBase;
        yield return new WaitForSeconds(0.5f);
        var hurt = CalculateHurting(playerBase, enemyBase);
        enemyBase.HP -= (int)hurt;
        if (enemyBase.HP <= 0)
        {
            player.currentState = PlayerStateMachine.PlayerState.Win;
        }
        else if (playerBase.HP <= 0)
        {
            player.currentState = PlayerStateMachine.PlayerState.Dead;
        }
        else if (enemyBase.HP > 0)
        {
            player.currentState = PlayerStateMachine.PlayerState.ChooseAction;
        }
    }

    private float CalculateHurting(PlayerBase player,EnemyBase enemy)
    {
       var val = (float)((player.Lv * 0.4 + 2) * player.Attack / enemy.Defense / 50 + 2) * Random.Range(217, 255) / 255;
        return val;
    }

    public void OpenBagMenu()
    {

    }

    public void OpenTeamMenu()
    {

    }

    public void PlayerRunaway()
    {

    }

}
