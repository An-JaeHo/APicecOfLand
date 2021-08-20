using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeMonsterInfo : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public GameObject upGradeMonsterPrefeb;
    public GameObject[] MonsterObj;
    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        object[] loadMonster = Resources.LoadAll("Monster", typeof(GameObject));
        MonsterObj = new GameObject[loadMonster.Length];

        for (int i = 0; i < loadMonster.Length; i++)
        {
            MonsterObj[i] = (GameObject)loadMonster[i];
        }

        LoadMonsterInfo();
    }

    public void LoadMonsterInfo()
    {
        //playerInfo.GameCherryLevel;
        //playerInfo.GameCherryGrade;
        //playerInfo.GameCandyLevel;
        //playerInfo.GameCandyGrade;
        //playerInfo.GameSkittlesLevel;
        //playerInfo.GameSkittlesGrade;
        //playerInfo.GameDonutsLevel;
        //playerInfo.GameDonutsGrade;
        //playerInfo.GameSchneeballenLevel;
        //playerInfo.GameSchneeballenGrade;
        //playerInfo.GameChocoLevel;
        //playerInfo.GameChocoGrade;

        for (int i = 0; i < MonsterObj.Length; i++)
        {
            if (playerInfo.GameSchneeballenGrade == 1)
            {
                if(MonsterObj[i].name == "Mon 13")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position .y- 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameSchneeballenGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 14")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(0, -0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameSchneeballenGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 15")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(0, -0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
        }
    }
}
