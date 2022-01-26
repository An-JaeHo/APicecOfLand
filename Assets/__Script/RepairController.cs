using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairController : MonoBehaviour
{
    [Header ("Set in Inspector")]
    public TileManger tileManger;
    public InputManger inputManger;

    [Space(10f)]
    public PlayerInfo playerInfo;
    public Image destoryArea;
    public Image repairArea;
    public Text repairMilk;
    public Text repairSugar;
    public Text repairFlour;
    public Button readyToRepairButton;

    [Header("Set in VisualStudio")]
    private Transform hitArea;

    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
    }

    public void SettingRepair()
    {
        hitArea = inputManger.hitObj;
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();

        for (int i = 0; i < tileManger.areaImges.Length; i++)
        {
            if (hitArea.GetComponent<MakeArea>().Code == tileManger.areaImges[i].name)
            {
                repairArea.sprite = tileManger.areaImges[i];
                repairMilk.text = hitArea.GetComponent<MakeArea>().repairMilk.ToString() + "°³";
                repairSugar.text = hitArea.GetComponent<MakeArea>().repairSugar.ToString() + "°³";
                repairFlour.text = hitArea.GetComponent<MakeArea>().repairFlour.ToString() + "°³";

                if (playerInfo.milk < hitArea.GetComponent<MakeArea>().repairMilk
                    || playerInfo.sugar < hitArea.GetComponent<MakeArea>().repairSugar
                    || playerInfo.flour < hitArea.GetComponent<MakeArea>().repairFlour)
                {
                    readyToRepairButton.interactable = false;
                }
            }
        }

        destoryArea.sprite = hitArea.GetComponent<SpriteRenderer>().sprite;
    }

    public void StartRepairButton()
    {
        hitArea.GetComponent<MakeArea>().InputAreaInfo(hitArea.GetComponent<MakeArea>().Code);
        hitArea.GetComponent<AreaManger>().CheckUpdateMaterial();
        tileManger.buttonManger.tiles.Add(hitArea);
        tileManger.supplyManger.JustUpdateSupply();
        tileManger.buttonManger.RepairButton();
    }
}
