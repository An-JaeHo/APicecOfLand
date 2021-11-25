using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpGradeMonsterInfo : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public GameObject upGradeMonsterPrefeb;
    public GameObject[] MonsterObj;
    public SaveMgr saveMgr;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        object[] loadMonster = Resources.LoadAll("Monster", typeof(GameObject));
        MonsterObj = new GameObject[loadMonster.Length];

        for (int i = 0; i < loadMonster.Length; i++)
        {
            MonsterObj[i] = (GameObject)loadMonster[i];
        }

        saveMgr.Load();
        LoadMonsterInfo();
    }

    public void LoadMonsterInfo()
    {
        for (int i = 0; i < MonsterObj.Length; i++)
        {
            if (saveMgr.playerSave.SaveCherryGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 1")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-7f, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveCherryGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 2")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-7f, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveCherryGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 3")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-7f, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }

            if (saveMgr.playerSave.SaveCandyGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 4")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-1, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveCandyGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 5")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-1, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveCandyGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 6")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-1, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }

            if (saveMgr.playerSave.SaveSkittlesGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 7")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(4, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveSkittlesGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 8")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(4, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveSkittlesGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 9")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(4, -2.5f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }

            if (saveMgr.playerSave.SaveDonutsGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 10")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-4f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveDonutsGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 11")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-4f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveDonutsGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 12")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(-4f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }

            if (saveMgr.playerSave.SaveSchneeballenGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 13")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(1.5f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveSchneeballenGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 14")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(1.5f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveSchneeballenGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 15")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(1.5f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }

            if (saveMgr.playerSave.SaveChocoGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 16")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(6.5f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveChocoGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 17")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(6.5f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                }
            }
            else if (saveMgr.playerSave.SaveChocoGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 18")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.position = new Vector3(6.5f, 0);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.5f, 0.5f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
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
    }

}
