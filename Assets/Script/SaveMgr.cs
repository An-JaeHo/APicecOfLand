﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// 이렇게 바꾸면 바뀌나?
[System.Serializable]
public class Save
{
    public Boss swordGuardian;
    public Boss bowGuardian;
    public Boss spearGuardian;
    public Boss cavalryGuardian;

    public List<Boss> guardians;
    public List<Buff> buffs = new List<Buff>();
    public List<DeBuff> deBuffs = new List<DeBuff>();
}

public class SaveMgr : MonoBehaviour
{
    public string fonlderPath;
    public PlayerInfo player;
    public InputField inputField;
    public SceneMgr sceneMgr;
    public JsonManger json;
    public GameObject abilityUi;
    public List<Buff> buffs;
    public List<DeBuff> deBuffs;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        fonlderPath = Application.streamingAssetsPath;
        sceneMgr = GetComponent<SceneMgr>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();

    }


    public void Save()
    {
        Save save = CreateSave();

        if (!File.Exists(fonlderPath + "/save.txt"))
        {
            save.swordGuardian = json.information.boss[0];
            save.bowGuardian = json.information.boss[1];
            save.spearGuardian = json.information.boss[2];
            save.cavalryGuardian = json.information.boss[3];
            save.buffs.Add(json.information.buff[0]);
            save.buffs.Add(json.information.buff[5]);

            save.deBuffs.Add(json.information.debuff[0]);
            save.deBuffs.Add(json.information.debuff[2]);
        }

        string saveString = JsonUtility.ToJson(save);
        File.WriteAllText(fonlderPath + "/save.txt", saveString);

        sceneMgr.GoGameScene();
    }


    public void Load()
    {
        if (!File.Exists(fonlderPath + "/save.txt"))
        {
            //파일이 없습니다 창을 띠우자
            Debug.Log(json.information.boss[0].Name);
            Save();
        }
        else
        {
            string loadFile = File.ReadAllText(fonlderPath + "/save.txt");

            Save save = JsonUtility.FromJson<Save>(loadFile);

            if(save.buffs.Count !=0)
            {
                for(int i=0; i< save.buffs.Count; i++)
                {
                    buffs.Add(save.buffs[i]);
                }
            }

            if (save.deBuffs.Count != 0)
            {
                for (int i = 0; i < save.deBuffs.Count; i++)
                {
                    deBuffs.Add(save.deBuffs[i]);
                }
            }

            Debug.Log("afafaf");
        }
    }

    public Save CreateSave()
    {
        Save save = new Save();

        //save.name = player.name;
        //save.day = player.day;
        //save.food = player.food;
        //save.maxArea = player.maxArea;
        //save.myArea = player.myArea;

        //if (player.areaPosition.Count != 0)
        //{
        //    for(int i =0; i< player.areaPosition.Count; i++)
        //    {
        //        save.areaPosition.Add(player.areaPosition[i]);
        //        save.areaCode.Add(player.areaCode[i]);
        //    }
        //}

        //if (player.armyPosition.Count != 0)
        //{
        //    for (int i = 0; i < player.armyPosition.Count; i++)
        //    {
        //        save.armyPosition.Add(player.armyPosition[i]);
        //        save.armyCode.Add(player.armyCode[i]);
        //    }
        //}

        return save;
    }
}
