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

    public void StartGame()
    {
        milk = 150;
        flour = 150;
        sugar = 150;
        people = 3;
        turnPoint = 0;
        killingPoint = 0;
    }

    private void Awake()
    {
        milk = 150;
        flour = 150;
        sugar = 150;
        people = 3;
        turnPoint = 10;
        killingPoint = 0;
    }

    public void ResetGame()
    {
        milk = 0;
        flour = 0;
        sugar = 0;
        people = 0;
        turnPoint = 0;
        killingPoint = 0;
        updateMilk = 0;
        updateFlour = 0;
        updateSugar = 0;
        updatePeople = 0;
        SceneMgr.GoGameMainScene();
    }
}
