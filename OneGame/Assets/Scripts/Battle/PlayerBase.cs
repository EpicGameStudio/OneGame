using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerBase: NPCBase
{
    public override float Attack
    {
        get
        {
            return PlayerAttack;
        }

        set
        {
            PlayerAttack = value;
        }
    }
    public override float Defense
    {
        get
        {
            return PlayerDefense;
        }

        set
        {
            base.Defense = value;
        }
    }
    public override float HP
    {
        get
        {
            return PlayerHP;
        }

        set
        {
            PlayerHP = value;
        }
    }
    public override float MaxHP
    {
        get
        {
            return PlayerMaxHP;
        }

        set
        {
            PlayerMaxHP = value;
        }
    }
    public override float MaxAttack
    {
        get
        {
            return PlayerMaxAttack;
        }

        set
        {
            PlayerMaxAttack = value;
        }
    }
    public override float MaxDefense
    {
        get
        {
            return PlayerMaxDefense;
        }

        set
        {
            PlayerMaxDefense = value;
        }
    }
    public override int Lv
    {
        get
        {
            return PlayerLv;
        }

        set
        {
            PlayerLv = value;
        }
    }

    public float PlayerMaxHP;
    public float PlayerHP;

    public float PlayerAttack;
    public float PlayerMaxAttack;

    public float PlayerDefense;
    public float PlayerMaxDefense;

    public int PlayerLv;

    public int Exp = 0;
}
