using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                ProductionExpense = TroopInfo.information.monster[i].ProductionExpense;
                ConsumeFood = TroopInfo.information.monster[i].ConsumeFood;
                Level = TroopInfo.information.monster[i].Level;
                MaxLevel = TroopInfo.information.monster[i].MaxLevel;
                HelthPoint = TroopInfo.information.monster[i].HelthPoint;
                populationNumber = TroopInfo.information.monster[i].populationNumber; 
                ExperiencePoint = TroopInfo.information.monster[i].ExperiencePoint;
                BaseAttack = TroopInfo.information.monster[i].BaseAttack;
                RiseAttack = TroopInfo.information.monster[i].RiseAttack;
                Defensive = TroopInfo.information.monster[i].Defensive;
                RiseDefensive = TroopInfo.information.monster[i].RiseDefensive;
                AttackRange = TroopInfo.information.monster[i].AttackRange;
                MovementSpace = TroopInfo.information.monster[i].MovementSpace;

                pureAttack = TroopInfo.information.monster[i].BaseAttack;
                pureDefensive = TroopInfo.information.monster[i].Defensive;
                pureRange = TroopInfo.information.monster[i].AttackRange;
            }
        }

        
    }
}

