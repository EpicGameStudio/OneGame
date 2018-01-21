using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    #region Field
    GameObject player;
    PlayerBase playerBase;

    GameObject enemy;
    EnemyBase enemyBase;

    
    private bool isInBattle;
    private BattleState currentState = BattleState.Waiting;

    private Transform playerBar;
    private Transform playerBarHP;
    private Image playerDisplayer;

    private Button attackInput;
    private Button runAwayInput;
    private Button packageInput;

    private Transform enemyBar;   
    private Transform enemyBarHP;
    private Image enemyDisplayer;

    enum BattleState
    {
        Start,
        Waiting,
        Win,
        Dead,
        Processing,
        RunAway,
        End,
    }
    #endregion


    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        //enemyBase = new EnemyBase("1000") { Id = "1000", Attack = 10, Defense = 10, HP = 20, Name = "None", MaxHP = 20 };
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        if (!isInBattle)
            return;
        enemyBarHP.localScale = new Vector3(enemyBase.HP/enemyBase.MaxHP, 1, 1);
        playerBarHP.localScale = new Vector3(playerBase.HP / playerBase.MaxHP, 1, 1);
    }


    public void OnRunAway()
    {
        currentState = BattleState.RunAway;
        //StopCoroutine("StartBattleCore");
        //this.gameObject.SetActive(false);
    }

    public void OnAttack()
    {
        if (currentState == BattleState.Processing)
            return;
        StartCoroutine("PlayerAttack");
    }

    private IEnumerator PlayerAttack()
    {
        yield return EnemyAnimation();
        if (MakeDamage(playerBase, enemyBase))
        {
            currentState = BattleState.Win;
        }
        else
        {
            currentState = BattleState.Processing;
            
            yield return new WaitForSeconds(2f);
            yield return PlayerAnimation();
            if (MakeDamage(enemyBase,playerBase))
            {
                currentState = BattleState.Dead;
            }
            else
                currentState = BattleState.Waiting;            
        }
        
    }

    private bool MakeDamage(NPCBase offence, NPCBase defence)
    {
        //攻击方等级 × 2 ÷ 5 + 2） × 技能威力 × 攻击方攻击力 ÷ 防御方防御力 ÷ 50 + 2
        float a = (offence.Attack / defence.Defense );
        a /= 50.0f;
        var damage = (offence.Lv * 2.0f / 5.0f + 2.0f) * 50.0f * (offence.Attack / defence.Defense / 50.0f) + 2.0f;
        //float damage = (offence.Lv * 2.0f / 5.0f + 2.0f) * 50.0f * a + 2.0f;
        if (defence.HP <= damage)
        {
            defence.HP = 0;
            return true;
        }
        else
            defence.HP -= damage;
        return false;
    }

    private IEnumerator EnemyAnimation()
    {
        int i = 6;

        while (i > 0)
        {
            if (i % 2 == 0)
            {
                enemyDisplayer.color = new Color(255, 0, 0);
            }               
            else
            {
                enemyDisplayer.color = new Color(255, 255, 255, 255);
            }
            i--;
            yield return new WaitForSeconds(0.05f);
        }
        enemyDisplayer.color = new Color(255, 255, 255, 255);
    }

    private IEnumerator PlayerAnimation()
    {
        int i = 6;

        while (i > 0)
        {
            if (i % 2 == 0)
            {
                playerDisplayer.color = new Color(255, 0, 0);
            }
            else
            {
                playerDisplayer.color = new Color(255, 255, 255, 255);
            }
            i--;
            yield return new WaitForSeconds(0.05f);
        }
        playerDisplayer.color = new Color(255, 255, 255, 255);
    }

    IEnumerator StartBattleCore()
    {
        isInBattle = true;
        while (isInBattle)
        {
            yield return new WaitForSeconds(1f);
            switch (currentState)
            {
                case BattleState.Start:
                    
                    currentState = BattleState.Waiting;                    
                    break;
                case BattleState.Waiting:
                    EnableInput(true);
                    break;
                case BattleState.Win:
                    isInBattle = false;
                    break;
                case BattleState.Processing:
                    EnableInput(false);
                    break;
                case BattleState.Dead:
                    isInBattle = false;
                    break;
                case BattleState.RunAway:
                    isInBattle = false;
                    break;
                default:
                    break;
            }
        }
        currentState = BattleState.Start;
        EnableInput(false);
        this.gameObject.SetActive(false);
    }

    private void Initialize()
    {
        //attackButton = transform.Find("Attack").gameObject;
        //var buttton = attackButton.GetComponent<Button>();
        if (player == null)
            player = GameObject.Find("Player");
        playerBase = player.GetComponent<PlayerMovement>().playerBase;

        playerBar = gameObject.transform.Find("PlayerBar");
        playerBarHP = playerBar.Find("HPForeground");
        playerDisplayer = this.gameObject.transform.Find("PlayerDisplayer").GetComponent<Image>();

        enemyBar = gameObject.transform.Find("EnemyBar");
        enemyBarHP = enemyBar.Find("HPForeground");
        enemyDisplayer = this.gameObject.transform.Find("EnemyDisplayer").GetComponent<Image>();

        attackInput = gameObject.transform.Find("Attack").gameObject.GetComponent<Button>();
        packageInput = gameObject.transform.Find("Items").gameObject.GetComponent<Button>();
        runAwayInput = gameObject.transform.Find("Runaway").gameObject.GetComponent<Button>();
        EnableInput(false);
          
        enemyBase = new EnemyBase("1000") { Id = "1000", Attack = 10, Defense = 10, HP = 20, Name = "None", MaxHP = 20 };
    }

    private void EnableInput(bool triggle)
    {
        attackInput.interactable = triggle;
        packageInput.interactable = triggle;
        runAwayInput.interactable = triggle;
    }

    public void StartBattle()
    {
        Initialize();
        StartCoroutine("StartBattleCore");
    }
}
