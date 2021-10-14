﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : GenericSingletonClass<PlayerInfo>
{
    public int milk;
    public int flour;
    public int sugar;
    public int people;

    public int updateMilk;
    public int updateFlour;
    public int updateSugar;
    public int updatePeople;

    public int turnPoint;
    public int killingPoint;
    //세이브용
    public int playerMilk;
    public int playerFlour;
    public int playerSugar;

    //public int GameCherryLevel;
    //public int GameCherryGrade;

    //public int GameCandyLevel;
    //public int GameCandyGrade;

    //public int GameSkittlesLevel;
    //public int GameSkittlesGrade;

    //public int GameDonutsLevel;
    //public int GameDonutsGrade;

    //public int GameSchneeballenLevel;
    //public int GameSchneeballenGrade;

    //public int GameChocoLevel;
    //public int GameChocoGrade;

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