using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpGradeMonsterInfo : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public GameObject upGradeMonsterPrefeb;
    public GameObject[] MonsterObj;
    public List<GameObject> monsters;
    public SaveMgr saveMgr;
    public float interporlateNum;

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
                    monster.transform.localPosition = new Vector3(0, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveCherryGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 2")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(0, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveCherryGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 3")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(0, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }

            if (saveMgr.playerSave.SaveCandyGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 4")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(540, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveCandyGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 5")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(540, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveCandyGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 6")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(540, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;

                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }

            if (saveMgr.playerSave.SaveSkittlesGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 7")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(1080, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveSkittlesGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 8")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(1080, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveSkittlesGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 9")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(1080, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }

            if (saveMgr.playerSave.SaveDonutsGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 10")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveDonutsGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 11")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveDonutsGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 12")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }

            if (saveMgr.playerSave.SaveSchneeballenGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 13")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-540f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveSchneeballenGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 14")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-540f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveSchneeballenGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 15")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-540f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    monsters.Add(monster);
                }
            }

            //if (saveMgr.playerSave.SaveChocoGrade == 1)
            //{
            //    if (MonsterObj[i].name == "Mon 16")
            //    {
            //        GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
            //        monster.transform.localPosition = new Vector3(2700, -900f);
            //        monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
            //        LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
            //        GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
            //        schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
            //        schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
            //        schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
            //    }
            //}
            //else if (saveMgr.playerSave.SaveChocoGrade == 2)
            //{
            //    if (MonsterObj[i].name == "Mon 17")
            //    {
            //        GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
            //        monster.transform.localPosition = new Vector3(2700, -900f);
            //        monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
            //        LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
            //        GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
            //        schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
            //        schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
            //        schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
            //    }
            //}
            //else if (saveMgr.playerSave.SaveChocoGrade == 3)
            //{
            //    if (MonsterObj[i].name == "Mon 18")
            //    {
            //        GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
            //        monster.transform.localPosition = new Vector3(2700, -900f);
            //        monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
            //        LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
            //        GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
            //        schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
            //        schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
            //        schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
            //    }
            //}
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

    public void RoundMonster()
    {
        if (interporlateNum > 0)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                Vector3 nextPos = new Vector3(monsters[i].GetComponent<MakeSoldier>().nowPosition.x + 540f, monsters[i].transform.localPosition.y);
                monsters[i].transform.localPosition = Vector3.Lerp(monsters[i].GetComponent<MakeSoldier>().nowPosition, nextPos, interporlateNum);
            }
            
        }
        else
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                Vector3 nextPos = new Vector3(monsters[i].GetComponent<MakeSoldier>().nowPosition.x -540f, monsters[i].transform.localPosition.y);
                monsters[i].transform.localPosition = Vector3.Lerp(monsters[i].GetComponent<MakeSoldier>().nowPosition, nextPos, -interporlateNum);
            }
        }
    }
}
