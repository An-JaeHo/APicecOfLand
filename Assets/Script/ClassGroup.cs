using UnityEngine;

[System.Serializable]
public class Information
{
    public Area[] area;
    public Enemy[] enemy;
    public Boss[] boss;
    public Card[] card;
    public Buff[] buff;
    public DeBuff[] debuff;
    public Monster[] monster;
}

[System.Serializable]
public class Area
{
    public string Code;
    public Sprite Picture;
    public string Type;
    public string Name;
    public int Grade;
    public int UpgradeWood;
    public int UpgradeIron;
    public int Health;
    public int Output;
    public bool Movement;
    public bool Destroy;
    public bool Repair;
    public string Effect;
    public int BuildTurn;
}

[System.Serializable]
public class Enemy
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public int Grade;
    public string Specialities;
    public int HelthPoint;
    public int BaseTroop;
    public float BaseAttack;
    public float Defensive;
    public int AttackRange;
    public int MovementSpace;
    public string DropExperiencePoint;
    public string DropItem;
}

[System.Serializable]
public class Boss
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public string Specialities;
    public int Level;
    public int MaxLevel;
    public float ExperiencePoint;
    public float RiseExperiencePoint;
    public int HelthPoint;
    public float BaseAttack;
    public float Defensive;
    public string InherentAbiltiy;
}

[System.Serializable]
public class Card
{
    public string Code;
    public Sprite Picture;
    public string Type;
    public string Name;
    public int Grade;
    public string Kind;
    public string Acquisition;
    public string Effect;
    public string Superposition;
    public int MaxStack;
}

[System.Serializable]
public class Buff
{
    public string Code;
    public string Type;
    public string Name;
    public int Grade;
    public string Acquisition;
    public string Effect;
}

[System.Serializable]
public class DeBuff
{
    public string Code;
    public string Type;
    public string Name;
    public int Grade;
    public string Acquisition;
    public string Effect;
}

[System.Serializable]
public class Monster
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public int Grade;
    public string Specialities;
    public int ProductionExpense;
    public int ConsumeFood;
    public int Level;
    public int MaxLevel;
    public int HelthPoint;
    public int populationNumber;
    public int ExperiencePoint;
    public float BaseAttack;
    public float RiseAttack;
    public float Defensive;
    public float RiseDefensive;
    public int AttackRange;
    public int MovementSpace;
}