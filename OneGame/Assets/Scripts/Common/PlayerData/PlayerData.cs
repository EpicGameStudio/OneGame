using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDataObject
{
    public class PlayerData
    {
        private double[] position = new double[3] { 0, 0, 0, };
        public double[] Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public int MaxHP { get; set; }
        public int HP { get; set; }

        public int Exp { get; set; }

        public int Lv { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        private List<Skill> skills = new List<Skill>();
        public List<Skill> Skills
        {
            get
            {
                if (skills.Count == 0)
                {
                    skills.Add(SkillManager.Instance.GetSkill("0001"));
                    skills.Add(SkillManager.Instance.GetSkill("0002"));
                }
                return skills;
            }
        }
             
        //public GameObject Object { get; set; }
    }

    
}

