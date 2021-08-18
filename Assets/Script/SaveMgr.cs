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

            player.GameCherryGrade = 1;
            player.GameCherryLevel = 1;

            player.GameCandyGrade = 1;
            player.GameCandyLevel = 1;

            player.GameSkittlesGrade = 1;
            player.GameSkittlesLevel = 1;

            player.GameDonutsGrade = 1;
            player.GameDonutsLevel = 1;

            player.GameSchneeballenGrade = 1;
            player.GameSchneeballenLevel = 1;

            player.GameChocoGrade = 1;
            player.GameChocoLevel = 1;
        }
        else
        {
            playerSave.flour += player.flour;
            playerSave.sugar += player.sugar;
            playerSave.milk += player.milk;
        }

        playerSave.SaveCherryGrade = player.GameCherryGrade;
        playerSave.SaveCherryLevel = player.GameCherryLevel;

        playerSave.SaveCandyGrade = player.GameCandyGrade;
        playerSave.SaveCandyLevel = player.GameCandyLevel;

        playerSave.SaveSkittlesGrade = player.GameSkittlesGrade;
        playerSave.SaveSkittlesLevel = player.GameSkittlesLevel;

        playerSave.SaveDonutsGrade = player.GameDonutsGrade;
        playerSave.SaveDonutsLevel = player.GameDonutsLevel;

        playerSave.SaveSchneeballenGrade = player.GameSchneeballenGrade;
        playerSave.SaveSchneeballenLevel = player.GameSchneeballenLevel;

        playerSave.SaveChocoGrade = player.GameChocoGrade;
        playerSave.SaveChocoLevel = player.GameChocoLevel;

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

            player.playerMilk = playerSave.milk;
            player.playerSugar = playerSave.sugar;
            player.playerFlour = playerSave.flour;

            player.GameCherryGrade = playerSave.SaveCherryGrade;
            player.GameCherryLevel = playerSave.SaveCherryLevel;

            player.GameCandyGrade =playerSave.SaveCandyGrade;
            player.GameCandyLevel = playerSave.SaveCandyLevel ;

            player.GameSkittlesGrade = playerSave.SaveSkittlesGrade;
            player.GameSkittlesLevel = playerSave.SaveSkittlesLevel;

            player.GameDonutsGrade = playerSave.SaveDonutsGrade;
            player.GameDonutsLevel =playerSave.SaveDonutsLevel ;

            player.GameSchneeballenGrade = playerSave.SaveSchneeballenGrade;
            player.GameSchneeballenLevel = playerSave.SaveSchneeballenLevel;

            player.GameChocoGrade = playerSave.SaveChocoGrade ;
            player.GameChocoLevel = playerSave.SaveChocoLevel;
        }
    }
}
