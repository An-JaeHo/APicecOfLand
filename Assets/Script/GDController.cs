using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDController : GDInfo
{
    public JsonManger TroopInfo;
    public SpriteRenderer troopInfoImage;
    
    public void MakeGD(string code)
    {
        troopInfoImage = GetComponent<SpriteRenderer>();
        TroopInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();

        for (int i = 0; i < TroopInfo.information.boss.Length; i++)
        {
            if (TroopInfo.information.boss[i].Code == code)
            {
                Code = TroopInfo.information.boss[i].Code;
                Picture = TroopInfo.information.boss[i].Picture;
                Name = TroopInfo.information.boss[i].Name;
                Specialities = TroopInfo.information.boss[i].Specialities;
                Level = TroopInfo.information.boss[i].Level;
                MaxLevel = TroopInfo.information.boss[i].MaxLevel;
                ExperiencePoint = TroopInfo.information.boss[i].ExperiencePoint;
                RiseExperiencePoint = TroopInfo.information.boss[i].RiseExperiencePoint;
                HelthPoint = TroopInfo.information.boss[i].HelthPoint;
                BaseAttack = TroopInfo.information.boss[i].BaseAttack;
                Defensive = TroopInfo.information.boss[i].Defensive;
                InherentAbiltiy = TroopInfo.information.boss[i].InherentAbiltiy;
            }
        }
    }
}
