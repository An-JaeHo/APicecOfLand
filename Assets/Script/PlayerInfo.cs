using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : GenericSingletonClass<PlayerInfo>
{
    public string day;
    public string name;
    public int food;
    public int wood;
    public int iron;
    public int people;
    public int maxArea;
    public int myArea;

    public int updateFood;
    public int updateWood;
    public int updateIron;
    public int updatePeople;

    public int turnPoint;
    public int killingPoint;

    public bool playerBuffCheck;
    public bool playerDeBuffCheck;
    public bool playerGuardianCheck;
    public Buff playerBuff;
    public DeBuff playerDebuff;
    public Boss playerGuardian;

    private void Start()
    {
        food = 500;
        wood = 500;
        iron = 500;
        people = 500;
        turnPoint = 0;
        killingPoint = 0;
    }
}
