using UnityEngine;

[System.Serializable]
public class Information
{
    public Area[] area;
    public Enemy[] enemy;
    public Boss[] boss;
    public Card[] card;
    public Monster[] monster;
    public UnitUpgrade[] unitUpgrade;
}

[System.Serializable]
public class Area
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public int Grade;
    public string Type;
    public int BaseFlour;
    public int UpgradeFlour;
    public int BaseSugar;
    public int UpgradeSugar;
    public int Health;
    public int MilkOutput;
    public int FlourOutput;
    public int SugarOutput;
    public int Population;
    public bool Destroy;
    public bool Repair;
    public int BuildTurn;
    public string Effect;
    public int Attack;
    public float Heal;
    public int RepairMilk;
    public int RepairSugar;
    public int RepairFlour;
}

[System.Serializable]
public class Enemy
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public int Grade;
    public string Specialities;
    public int MaxLevel;
    public int BaseHelthPoint;
    public int RiseHelthPoint;
    public float BaseAttack;
    public float RiseAttack;
    public float BaseDefensive;
    public float RiseDefensive;
    public int AttackRange;
    public int AttackNumber;
    public int Movement;
    public string Spone1;
    public string Spone2;
    public string Spone3;
    public string Drop;
    public int DropExperiencePoint;
}

[System.Serializable]
public class Boss
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public string Type;
    public int MaxLevel;
    public int HelthPoint;
    public int BaseAttack;
    public int RiseAttack;
    public int Defensive;
    public int RiseDefensive;
    public int AttackRange;
    public int AttackNumber;
    public int Movement;
    public int turn;
    public string InherentAbiltiy;
    public string Drop;
}

[System.Serializable]
public class Card
{
    public string Code;
    public Sprite Picture;
    public string Type;
    public string Name;
    public int Grade;
    public int Turn;
    public int AllAttack;
    public int AttackRange;
    public int AttackNumber;
    public int HelthPoint;
    public int Movement;
    public int Milk;
    public int Milk2;
    public int Flour;
    public int Flour2;
    public int Sugar;
    public int Sugar2;
    public int Population;
    public int CountAttack;
    public int Stack;
}

[System.Serializable]
public class Monster
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public int Grade;
    public string Specialities;
    public int MaxLevel;
    public int HelthPoint;
    public int PopulationNumber;
    public int ProductionExpense;
    public int ConsumeFood;
    public string UnderEvolutin;
    public int EvolutionLevel;
    public float BaseAttack;
    public float RiseAttack;
    public float Defensive;
    public float RiseDefensive;
    public int Critical;
    public int RiseCritical;
    public int AttackRange;
    public int Movement;
    public int Experience;
    public int RiseHealth;
    public int AttackNumber;
    public int MovementNumber;
}

[System.Serializable]
public class UnitUpgrade
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public int NowLevel;
    public int UpgradeMilk;
    public int UpgradeFlour;
    public int UpgradeSugar;
}