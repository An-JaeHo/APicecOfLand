using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        for (int i = 0; i < MonsterObj.Length; i++)
        {
            if (playerInfo.GameCherryGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 1")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-6, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameCherryGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 2")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-6, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameCherryGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 3")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-6, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }

            if (playerInfo.GameCandyGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 4")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-1, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameCandyGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 5")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-1, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameCandyGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 6")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-1, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }

            if (playerInfo.GameSkittlesGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 7")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(4, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameSkittlesGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 8")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(4, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameSkittlesGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 9")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(4, 1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }

            if (playerInfo.GameDonutsGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 10")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-3.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameDonutsGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 11")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-3.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameDonutsGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 12")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-3.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }

            if (playerInfo.GameSchneeballenGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 13")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(1.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameSchneeballenGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 14")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(1.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameSchneeballenGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 15")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(1.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }

            if (playerInfo.GameChocoGrade == 1)
            {
                if(MonsterObj[i].name == "Mon 16")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(6.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameChocoLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position .y- 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameChocoGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 17")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(6.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameChocoLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
            else if (playerInfo.GameChocoGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 18")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(6.5f, -1);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, playerInfo.GameChocoLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.4f, 0.4f);
                }
            }
        }
    }

    public void LevelCheck(GameObject soldier, int level)
    {
        soldier.GetComponent<MakeSoldier>().Level = level;
        soldier.GetComponent<MakeSoldier>().BaseAttack += (soldier.GetComponent<MakeSoldier>().RiseAttack*(level-1));
        soldier.GetComponent<MakeSoldier>().Critical += (soldier.GetComponent<MakeSoldier>().RiseCritical * (level - 1));
        soldier.GetComponent<MakeSoldier>().Defensive += (soldier.GetComponent<MakeSoldier>().RiseDefensive * (level - 1));
        soldier.GetComponent<MakeSoldier>().Critical += (soldier.GetComponent<MakeSoldier>().RiseCritical * (level - 1));

        soldier.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = soldier.GetComponent<MakeSoldier>().Level.ToString();
        Debug.Log("sf");
    }

}
