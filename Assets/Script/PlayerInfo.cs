using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : GenericSingletonClass<PlayerInfo>
{
    public string day;
    public string name;
    public int milk;
    public int flour;
    public int sugar;
    public int people;
    public int maxArea;
    public int myArea;

    public int updateMilk;
    public int updateFlour;
    public int updateSugar;
    public int updatePeople;

    public int turnPoint;
    public int killingPoint;

    public bool playerBuffCheck;
    public bool playerDeBuffCheck;
    public bool playerGuardianCheck;
    public Boss playerGuardian;

    private void Start()
    {
        milk = 500;
        flour = 500;
        sugar = 500;
        people = 500;
        turnPoint = 0;
        killingPoint = 0;
    }
}
