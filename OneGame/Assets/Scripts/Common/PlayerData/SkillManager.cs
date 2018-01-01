using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDataObject
{
    public class SkillManager:MonoBehaviour
    {
        private static SkillManager instance;
        public static SkillManager Instance
        {
            get
            {
                return instance;
            }
        }
        private void Awake()
        {
            instance = this;
        }

        public Skill GetSkill(string id)
        {
            if (dictionary.ContainsKey(id))
            {
                return dictionary[id];
            }

            throw new System.Exception("skill id doesn't exist");
        }

        public Dictionary<string, Skill> dictionary = new Dictionary<string, Skill>()
        {
            {"0001",new Skill()
            {
                Name="大力金刚指",
                AttackPower=50,
                DefensePower=0,
                Id="0001",
                EnhanceHP=0,
                
            } },
            {"0002",new Skill()
            {
                Name="化骨绵掌",
                AttackPower=30,
                DefensePower=0,
                Id="0002",
                EnhanceHP=0,
            } },
            {"0003",new Skill()
            {
                Name="一阳指",
                AttackPower=50,
                DefensePower=0,
                Id="0003",
                EnhanceHP=0,

            } },
            {"0004",new Skill()
            {
                Name="降龙十八掌",
                AttackPower=50,
                DefensePower=0,
                Id="0004",
                EnhanceHP=0,
            } },
            {"0005",new Skill()
            {
                Name="乾坤大挪移",
                AttackPower=50,
                DefensePower=0,
                Id="0005",
                EnhanceHP=0,
            } },
            {"0006",new Skill()
            {
                Name="辟邪剑",
                AttackPower=50,
                DefensePower=0,
                Id="0006",
                EnhanceHP=0,
            } },
            {"0007",new Skill()
            {
                Name="独孤九剑",
                AttackPower=80,
                DefensePower=0,
                Id="0007",
                EnhanceHP=0,
            } },
        };
    }
    public class Skill
    {
        public string Name;
        public string Id;
        enum SkillType
        {
            Attack,
            Defense,
            Enhance,
        }

        public int AttackPower;

        public int DefensePower;

        public int EnhanceHP;
    }
}

