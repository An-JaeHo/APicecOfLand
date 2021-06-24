﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierInfo : MonoBehaviour
{
    public string Code;
    public Sprite Picture;
    public string Name; 
    public int Grade;
    public string Specialities;
    public int MaxLevel;
    public int HelthPoint;
    public int populationNumber;
    public int ProductionExpense;
    public int ConsumeFood;
    public string UnderEvolutin;
    public int EvolutionLevel;
    public float BaseAttack;
    public float RiseAttack;
    public float Defensive;
    public float RiseDefensive;
    public string Critical;
    public string RiseCritical;
    public int AttackRange;
    public int Movement;
    public int Level;
    public float pureAttack;
    public float pureDefensive;
    public int pureRange;
}

public class MakeSoldier : SoldierInfo
{
    public JsonManger TroopInfo;
    public SpriteRenderer troopInfoImage;

    private void Start()
    {
        //TroopInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        troopInfoImage = GetComponent<SpriteRenderer>();
    }

    public void SuperMagic(string code)
    {
        TroopInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();

        for (int i = 0; i < TroopInfo.information.monster.Length; i++)
        {
            if (TroopInfo.information.monster[i].Code == code)
            {
                Code = TroopInfo.information.monster[i].Code;
                Picture = TroopInfo.information.monster[i].Picture;
                Name = TroopInfo.information.monster[i].Name;
                Grade = TroopInfo.information.monster[i].Grade;
                Specialities = TroopInfo.information.monster[i].Specialities;
                MaxLevel = TroopInfo.information.monster[i].MaxLevel;
                HelthPoint = TroopInfo.information.monster[i].HelthPoint;
                populationNumber = TroopInfo.information.monster[i].populationNumber;
                ProductionExpense = TroopInfo.information.monster[i].ProductionExpense;
                ConsumeFood = TroopInfo.information.monster[i].ConsumeFood;
                UnderEvolutin = TroopInfo.information.monster[i].UnderEvolutin;
                EvolutionLevel = TroopInfo.information.monster[i].EvolutionLevel;
                BaseAttack = TroopInfo.information.monster[i].BaseAttack;
                RiseAttack = TroopInfo.information.monster[i].RiseAttack;
                Defensive = TroopInfo.information.monster[i].Defensive;
                RiseDefensive = TroopInfo.information.monster[i].RiseDefensive;
                Critical = TroopInfo.information.monster[i].Critical;
                RiseCritical = TroopInfo.information.monster[i].RiseCritical;
                AttackRange = TroopInfo.information.monster[i].AttackRange;
                Movement = TroopInfo.information.monster[i].Movement;

                Level = 0;
                pureAttack = TroopInfo.information.monster[i].BaseAttack;
                pureDefensive = TroopInfo.information.monster[i].Defensive;
                pureRange = TroopInfo.information.monster[i].AttackRange;
            }
        }

        
    }
}

