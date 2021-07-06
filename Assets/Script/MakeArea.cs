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
    public int UpgradeFlour;
    public int BaseSugar;
    public int UpgradeSugar;
    public int MilkOutput;
    public int FlourOutput;
    public int SugarOutput;
    public int Population;
    public bool Destroy;
    public bool Repair;
    public int BuildTurn;
    public string Effect;
    public int Attack;
    public bool Movement;
}

public class MakeArea : AreaInfo
{
    public string findCode;
    public JsonManger areaInfo;
    public SpriteRenderer areaInfoImage;
    public AreaManger areaManger;
    public bool firstBuild;

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

        for (int i = 0; i < areaInfo.information.area.Length; i++)
        {
            if (areaInfo.information.area[i].Code == code)
            {
                Code = areaInfo.information.area[i].Code;
                Picture = areaInfo.information.area[i].Picture;
                Name = areaInfo.information.area[i].Name;
                Grade = areaInfo.information.area[i].Grade;
                Type = areaInfo.information.area[i].Type;
                UpgradeFlour = areaInfo.information.area[i].UpgradeFlour;
                BaseSugar = areaInfo.information.area[i].BaseSugar;
                UpgradeSugar = areaInfo.information.area[i].UpgradeSugar;
                MilkOutput = areaInfo.information.area[i].MilkOutput;
                FlourOutput = areaInfo.information.area[i].FlourOutput;
                SugarOutput = areaInfo.information.area[i].SugarOutput;
                Population = areaInfo.information.area[i].Population;
                Destroy = areaInfo.information.area[i].Destroy;
                Repair = areaInfo.information.area[i].Repair;
                BuildTurn = areaInfo.information.area[i].BuildTurn;
                Effect = areaInfo.information.area[i].Effect;
                Attack = areaInfo.information.area[i].Attack;
                Movement = true;

                areaInfoImage.sprite = areaInfo.information.area[i].Picture;

                if(areaInfo.information.area[i].Code == "Area 17" || areaInfo.information.area[i].Code == "Area 18" || areaInfo.information.area[i].Code == "Area 19")
                {
                    transform.tag = "Barracks";
                    Destroy = true;
                }
                else if(areaInfo.information.area[i].Code == "Area 30" || areaInfo.information.area[i].Code == "Area 31" || areaInfo.information.area[i].Code == "Area 32")
                {
                    transform.tag = "Enemy Base";
                    firstBuild = false;
                }
                else
                {
                    transform.tag = "Area";
                    Destroy = true;
                }
                
            }
        }

        if(Destroy == true)
        {
            areaInfoImage.sprite = areaManger.tileManger.sprites[2];
        }
    }
}
