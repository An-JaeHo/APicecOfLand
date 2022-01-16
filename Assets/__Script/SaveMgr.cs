using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class Save
{
    public int milk;
    public int sugar;
    public int flour;

    public int SaveCherryLevel;
    public int SaveCherryGrade;

    public int SaveCandyLevel;
    public int SaveCandyGrade;

    public int SaveSkittlesLevel;
    public int SaveSkittlesGrade;

    public int SaveDonutsLevel;
    public int SaveDonutsGrade;

    public int SaveSchneeballenLevel;
    public int SaveSchneeballenGrade;

    public int SaveChocoLevel;
    public int SaveChocoGrade;
}

public class SaveMgr : GenericSingletonClass<SaveMgr>
{
    public string fonlderPath;
    public PlayerInfo player;
    public SceneMgr sceneMgr;
    public JsonManger json;
    public GameObject abilityUi;
    public Save playerSave;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        fonlderPath = Application.persistentDataPath;
        sceneMgr = GetComponent<SceneMgr>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
    }

    public void Save()
    {
        if (!File.Exists(fonlderPath + "/save.txt"))
        {
            playerSave.flour = player.flour;
            playerSave.sugar = player.sugar;
            playerSave.milk = player.milk;

            playerSave.SaveCherryGrade = 1;
            playerSave.SaveCherryLevel = 1;

            playerSave.SaveCandyGrade = 1;
            playerSave.SaveCandyLevel = 1;

            playerSave.SaveSkittlesGrade = 1;
            playerSave.SaveSkittlesLevel = 1;

            playerSave.SaveDonutsGrade = 1;
            playerSave.SaveDonutsLevel = 1;

            playerSave.SaveSchneeballenGrade = 1;
            playerSave.SaveSchneeballenLevel = 1;

            playerSave.SaveChocoGrade = 1;
            playerSave.SaveChocoLevel = 1;
        }

        string saveString = JsonUtility.ToJson(playerSave);
        File.WriteAllText(fonlderPath + "/save.txt", saveString);
    }

    public void JustSave()
    {
        string saveString = JsonUtility.ToJson(playerSave);
        File.WriteAllText(fonlderPath + "/save.txt", saveString);
    }

    public void Load()
    {
        if (!File.Exists(fonlderPath + "/save.txt"))
        {
            Save();
        }
        else
        {
            string loadFile = File.ReadAllText(fonlderPath + "/save.txt");
            playerSave = JsonUtility.FromJson<Save>(loadFile);
           
        }
    }

    public void DeleteSave()
    {
        File.Delete(fonlderPath + "/save.txt");
        
        //if (File.Exists(fonlderPath + "/save.txt"))
        //{
        //    playerSave.flour = 0;
        //    playerSave.sugar = 0;
        //    playerSave.milk = 0;

        //    playerSave.SaveCherryGrade = 1;
        //    playerSave.SaveCherryLevel = 1;

        //    playerSave.SaveCandyGrade = 1;
        //    playerSave.SaveCandyLevel = 1;

        //    playerSave.SaveSkittlesGrade = 1;
        //    playerSave.SaveSkittlesLevel = 1;

        //    playerSave.SaveDonutsGrade = 1;
        //    playerSave.SaveDonutsLevel = 1;

        //    playerSave.SaveSchneeballenGrade = 1;
        //    playerSave.SaveSchneeballenLevel = 1;

        //    playerSave.SaveChocoGrade = 1;
        //    playerSave.SaveChocoLevel = 1;

        //    string saveString = JsonUtility.ToJson(playerSave);
        //    File.WriteAllText(fonlderPath + "/save.txt", saveString);
        //}
        //else
        //{
        //    Save();
        //}
    }
}