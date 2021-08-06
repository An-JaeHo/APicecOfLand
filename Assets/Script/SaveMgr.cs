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
    public Dictionary<string, int> monsterLevels;
}

public class SaveMgr : MonoBehaviour
{
    public string fonlderPath;
    public PlayerInfo player;
    public SceneMgr sceneMgr;
    public JsonManger json;
    public GameObject abilityUi;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        fonlderPath = Application.streamingAssetsPath;
        sceneMgr = GetComponent<SceneMgr>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
    }


    public void Save()
    {
        if (!File.Exists(fonlderPath + "/save.txt"))
        {
            Save save = new Save();
            save.flour = player.flour;
            save.sugar = player.sugar;
            save.milk = player.milk;

            save.monsterLevels = player.monsterLevels;


            string saveString = JsonUtility.ToJson(save);
            File.WriteAllText(fonlderPath + "/save.txt", saveString);
        }
        else
        {
            string loadFile = File.ReadAllText(fonlderPath + "/save.txt");
            Save save = JsonUtility.FromJson<Save>(loadFile);
            save.flour += player.flour;
            save.sugar += player.sugar;
            save.milk += player.milk;

            save.monsterLevels.Clear();
            save.monsterLevels = player.monsterLevels;

            string saveString = JsonUtility.ToJson(save);
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
            Save save = JsonUtility.FromJson<Save>(loadFile);

            player.playerMilk = save.milk;
            player.playerSugar = save.sugar;
            player.playerFlour = save.flour;
            player.monsterLevels = save.monsterLevels;
        }
    }
}
