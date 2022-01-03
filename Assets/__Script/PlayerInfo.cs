using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : GenericSingletonClass<PlayerInfo>
{
    [Header("Ues In Game")]
    public int milk;
    public int flour;
    public int sugar;
    public int people;

    [Header("Area Make Souce")]
    public int updateMilk;
    public int updateFlour;
    public int updateSugar;
    public int updatePeople;

    [Space (10f)]
    public int turnPoint;
    public int killingPoint;

    public void StartGame()
    {
        milk = 150;
        flour = 150;
        sugar = 150;
        people = 3;
        turnPoint = 0;
        killingPoint = 0;
        updateMilk = 0;
        updateFlour = 0;
        updateSugar = 0;
        updatePeople = 0;
    }

    private void Awake()
    {
        milk = 150;
        flour = 150;
        sugar = 150;
        people = 3;
        turnPoint = 0;
        killingPoint = 0;
        updateMilk = 0;
        updateFlour = 0;
        updateSugar = 0;
        updatePeople = 0;
    }

    public void ResetGame()
    {
        milk = 150;
        flour = 150;
        sugar = 150;
        people = 3;
        turnPoint = 0;
        killingPoint = 0;
        updateMilk = 0;
        updateFlour = 0;
        updateSugar = 0;
        updatePeople = 0;
        SceneMgr.GoGameMainScene();
    }

    
}
