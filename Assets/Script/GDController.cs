using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDInfo : MonoBehaviour
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
                Type = TroopInfo.information.boss[i].Type;
                MaxLevel = TroopInfo.information.boss[i].MaxLevel;
                HelthPoint = TroopInfo.information.boss[i].HelthPoint;
                BaseAttack = TroopInfo.information.boss[i].BaseAttack;
                RiseAttack = TroopInfo.information.boss[i].RiseAttack;
                Defensive = TroopInfo.information.boss[i].Defensive;
                RiseDefensive = TroopInfo.information.boss[i].RiseDefensive;
                AttackRange = TroopInfo.information.boss[i].AttackRange;
                AttackNumber = TroopInfo.information.boss[i].AttackNumber;
                Movement = TroopInfo.information.boss[i].Movement;
                turn = TroopInfo.information.boss[i].turn;
                InherentAbiltiy = TroopInfo.information.boss[i].InherentAbiltiy;
                Drop = TroopInfo.information.boss[i].Drop;
            }
        }
    }
}
