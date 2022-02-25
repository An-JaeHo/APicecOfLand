using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInfo : MonoBehaviour
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public int Grade;
    public string Type = "Grass";
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
    public bool Movement;
    public int repairMilk;
    public int repairSugar;
    public int repairFlour;
}

public class MakeArea : AreaInfo
{
    public string findCode;
    public JsonManger areaInfo;
    public SpriteRenderer areaInfoImage;
    public AreaManger areaManger;
    public Sprite readyBuild;
    public bool firstBuild;
    public int maxGrade;

    private void Start()
    {
        areaInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        areaManger = GetComponent<AreaManger>();
        firstBuild = true;
        Type = "Grass";
    }

    public void InputAreaInfo(string code)
    {
        areaInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        areaInfoImage = GetComponent<SpriteRenderer>();
        //areaManger.pureSprite = GetComponent<SpriteRenderer>().sprite;

        for (int i = 0; i < areaInfo.information.area.Length; i++)
        {
            if (areaInfo.information.area[i].Code == code)
            {
                Code = areaInfo.information.area[i].Code;
                Picture = areaInfo.information.area[i].Picture;
                Name = areaInfo.information.area[i].Name;
                Grade = areaInfo.information.area[i].Grade;
                Type = areaInfo.information.area[i].Type;
                BaseFlour = areaInfo.information.area[i].BaseFlour;
                UpgradeFlour = areaInfo.information.area[i].UpgradeFlour;
                BaseSugar = areaInfo.information.area[i].BaseSugar;
                UpgradeSugar = areaInfo.information.area[i].UpgradeSugar;
                MilkOutput = areaInfo.information.area[i].MilkOutput;
                FlourOutput = areaInfo.information.area[i].FlourOutput;
                SugarOutput = areaInfo.information.area[i].SugarOutput;
                Population = areaInfo.information.area[i].Population;
                Destroy = false;
                Repair = areaInfo.information.area[i].Repair;
                BuildTurn = areaInfo.information.area[i].BuildTurn;
                Effect = areaInfo.information.area[i].Effect;
                Attack = areaInfo.information.area[i].Attack;
                Heal = areaInfo.information.area[i].Heal;
                Movement = true;
                repairMilk = areaInfo.information.area[i].RepairMilk;
                repairSugar = areaInfo.information.area[i].RepairSugar;
                repairFlour = areaInfo.information.area[i].RepairFlour;

                areaInfoImage.sprite = areaInfo.information.area[i].Picture;

                if (areaInfo.information.area[i].Code == "Area 13" || areaInfo.information.area[i].Code == "Area 14" || areaInfo.information.area[i].Code == "Area 15")
                {
                    transform.tag = "Barracks";
                }
                else if (areaInfo.information.area[i].Code == "Area 23" || areaInfo.information.area[i].Code == "Area 24" || areaInfo.information.area[i].Code == "Area 25")
                {
                    transform.tag = "Enemy Base";
                }
                else
                {
                    transform.tag = "Area";
                }

            }
        }
    }
}
