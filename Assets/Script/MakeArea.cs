using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeArea : AreaInfo
{
    public string findCode;
    public JsonManger areaInfo;
    public SpriteRenderer areaInfoImage;

    private void Start()
    {
        areaInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
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
                Type = areaInfo.information.area[i].Type;
                Name = areaInfo.information.area[i].Name;
                Grade = areaInfo.information.area[i].Grade;
                UpgradeWood = areaInfo.information.area[i].UpgradeWood;
                UpgradeIron = areaInfo.information.area[i].UpgradeIron;
                Health = areaInfo.information.area[i].Health;
                Output = areaInfo.information.area[i].Output;
                Movement = areaInfo.information.area[i].Movement;
                Destroy = areaInfo.information.area[i].Destroy;
                Repair = areaInfo.information.area[i].Repair;
                Effect = areaInfo.information.area[i].Effect;
                BuildTurn = areaInfo.information.area[i].BuildTurn;

                areaInfoImage.sprite = areaInfo.information.area[i].Picture;
                if(areaInfo.information.area[i].Type == "Barracks")
                {
                    transform.tag = "Barracks";
                    Destroy = true;
                }
                else if(areaInfo.information.area[i].Type == "Enemy Base")
                {
                    transform.tag = "Enemy Base";
                }
                else
                {
                    transform.tag = "Area";
                }
                
            }
        }

        if(Destroy == true)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}
