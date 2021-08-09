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

    public int cherryLevel;
    public int cherryGrade;

    public int candyLevel;
    public int candyGrade;

    public int skittlesLevel;
    public int skittlesGrade;

    public int donutsLevel;
    public int donutsGrade;

    public int schneeballenLevel;
    public int schneeballenGrade;

    public int chocoLevel;
    public int chocoGrade;
}

public class SaveMgr : MonoBehaviour
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
        fonlderPath = Application.streamingAssetsPath;
        sceneMgr = GetComponent<SceneMgr>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();

        playerSave.cherryLevel=1;
        playerSave.cherryGrade = 1;

        playerSave.candyLevel = 1;
        playerSave.candyGrade = 1;

        playerSave.skittlesLevel = 1;
        playerSave.skittlesGrade = 1;

        playerSave.donutsLevel = 1;
        playerSave.donutsGrade = 1;

        playerSave.schneeballenLevel = 1;
        playerSave.schneeballenGrade = 1;

        playerSave.chocoLevel = 1;
        playerSave.chocoGrade = 1;

        Load();
    }


    public void Save()
    {
        if (!File.Exists(fonlderPath + "/save.txt"))
        {
            playerSave.flour = player.flour;
            playerSave.sugar = player.sugar;
            playerSave.milk = player.milk;
            string saveString = JsonUtility.ToJson(playerSave);
            File.WriteAllText(fonlderPath + "/save.txt", saveString);
        }
        else
        {
            playerSave.flour += player.flour;
            playerSave.sugar += player.sugar;
            playerSave.milk += player.milk;
            
            string saveString = JsonUtility.ToJson(playerSave);
            File.WriteAllText(fonlderPath + "/save.txt", saveString);
        }
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
        }
    }
}
