using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class NPCBase : ICharacter
{
    public virtual int Lv {get;set;}
    public virtual float HP { get; set; }
    public virtual float MaxHP { get; set; }
    public virtual float Attack {get;set;}
    public virtual float Defense { get; set; }
    public virtual string Name { get; set; }
    public virtual string Id{ get;set; }
    public virtual float MaxDefense { get; set; }
    public virtual float MaxAttack { get; set; }
}

public interface ICharacter
{
    string Id { get; set; }
    int Lv { get;set; }
    float HP { get; set; }
    float MaxHP { get; set; }
    float Attack { get; set; }
    float MaxAttack { get; set; }
    float Defense { get; set; }
    float MaxDefense { get; set; }
    string Name { get; set; }
}
