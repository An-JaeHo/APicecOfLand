using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpGradeMonsterInfo : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject upGradeMonsterPrefeb;
    public UpGradeSceneWindow upGradeSceneWindow;
    public ToggleController toggleController;
    public UpGradeButtonManger buttonManger;
    [Header("Set in VisualStudio")]
    public PlayerInfo playerInfo;
    public GameObject[] MonsterObj;
    public List<GameObject> monsters;
    public GameObject[] arrayMonsters;
    public SaveMgr saveMgr;
    public float interporlateNum;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        object[] loadMonster = Resources.LoadAll("Monster", typeof(GameObject));
        MonsterObj = new GameObject[loadMonster.Length];
        arrayMonsters = new GameObject[5];
        for (int i = 0; i < loadMonster.Length; i++)
        {
            MonsterObj[i] = (GameObject)loadMonster[i];
        }

        saveMgr.Load();
        LoadMonsterInfo();
        monsters.AddRange(arrayMonsters);

        upGradeSceneWindow.UpGradeCheck(monsters[2].transform);
        toggleController.CheckToggle();
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
                    monster.transform.localPosition = new Vector3(-1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[0] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveCherryGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 2")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[0] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveCherryGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 3")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[0] = monster;
                    //monsters.Add(monster);
                }
            }

            if (saveMgr.playerSave.SaveCandyGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 4")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-540, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[1] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveCandyGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 5")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-540, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[1] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveCandyGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 6")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(-540, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;

                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[1] = monster;
                    //monsters.Add(monster);
                }
            }

            if (saveMgr.playerSave.SaveSkittlesGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 7")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(0, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[2] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveSkittlesGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 8")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(0, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[2] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveSkittlesGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 9")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(0, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[2] = monster;
                    //monsters.Add(monster);
                }
            }

            if (saveMgr.playerSave.SaveDonutsGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 10")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(540f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[3] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveDonutsGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 11")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(540f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[3] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveDonutsGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 12")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(540f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[3] = monster;
                    //monsters.Add(monster);
                }
            }

            if (saveMgr.playerSave.SaveSchneeballenGrade == 1)
            {
                if (MonsterObj[i].name == "Mon 13")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[4] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveSchneeballenGrade == 2)
            {
                if (MonsterObj[i].name == "Mon 14")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[4] = monster;
                    //monsters.Add(monster);
                }
            }
            else if (saveMgr.playerSave.SaveSchneeballenGrade == 3)
            {
                if (MonsterObj[i].name == "Mon 15")
                {
                    GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);
                    monster.transform.localPosition = new Vector3(1080f, -900f);
                    monster.GetComponent<MakeSoldier>().SuperMagic(MonsterObj[i].name);
                    monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                    GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                    schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                    schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                    schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
                    arrayMonsters[4] = monster;
                }
            }
        }

        
    }

    public void LevelCheck(GameObject soldier, int level)
    {
        soldier.GetComponent<MakeSoldier>().Level = level;
        soldier.GetComponent<MakeSoldier>().BaseAttack += (soldier.GetComponent<MakeSoldier>().RiseAttack * (level - 1));
        soldier.GetComponent<MakeSoldier>().Critical += (soldier.GetComponent<MakeSoldier>().RiseCritical * (level - 1));
        soldier.GetComponent<MakeSoldier>().Defensive += (soldier.GetComponent<MakeSoldier>().RiseDefensive * (level - 1));
        soldier.GetComponent<MakeSoldier>().Critical += (soldier.GetComponent<MakeSoldier>().RiseCritical * (level - 1));
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
                Vector3 nextPos = new Vector3(monsters[i].GetComponent<MakeSoldier>().nowPosition.x - 540f, monsters[i].transform.localPosition.y);
                monsters[i].transform.localPosition = Vector3.Lerp(monsters[i].GetComponent<MakeSoldier>().nowPosition, nextPos, -interporlateNum);
            }
        }
    }

    public void FindAndMakeMonster()
    {
        GameObject monster = Instantiate(upGradeMonsterPrefeb, transform);

        if (interporlateNum == 1)
        {
            Destroy(monsters[monsters.Count - 1]);
            monsters.Remove(monsters[monsters.Count - 1]);

            if (monsters[0].GetComponent<MakeSoldier>().Name == "æÁ√ ∏”«…")
            {
                if (saveMgr.playerSave.SaveChocoGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 16");
                    LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
                }
                else if (saveMgr.playerSave.SaveChocoGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 17");
                    LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
                }
                else if (saveMgr.playerSave.SaveChocoGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 18");
                    LevelCheck(monster, saveMgr.playerSave.SaveChocoLevel);
                }
            }
            else if (monsters[0].GetComponent<MakeSoldier>().Name == "¡¯¿˙ƒÌ≈∞")
            {
                if (saveMgr.playerSave.SaveCherryGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 1");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveCherryGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 2");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveCherryGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 3");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
            }
            else if (monsters[0].GetComponent<MakeSoldier>().Name == "Ω∫≈∞∆≤¡Óƒ…¿Ã≈©")
            {
                if (saveMgr.playerSave.SaveCandyGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 4");
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                }
                else if (saveMgr.playerSave.SaveCandyGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 5");
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                }
                else if (saveMgr.playerSave.SaveCandyGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 6");
                    LevelCheck(monster, saveMgr.playerSave.SaveCandyLevel);
                }
            }
            else if (monsters[0].GetComponent<MakeSoldier>().Name == "µµ≥”√˜")
            {
                if (saveMgr.playerSave.SaveSkittlesGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 7");
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                }
                else if (saveMgr.playerSave.SaveSkittlesGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 8");
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                }
                else if (saveMgr.playerSave.SaveSkittlesGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 9");
                    LevelCheck(monster, saveMgr.playerSave.SaveSkittlesLevel);
                }
            }
            else if (monsters[0].GetComponent<MakeSoldier>().Name == "Ω¥¥œπﬂ∑ª")
            {
                if (saveMgr.playerSave.SaveDonutsGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 10");
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                }
                else if (saveMgr.playerSave.SaveDonutsGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 11");
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                }
                else if (saveMgr.playerSave.SaveDonutsGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 12");
                    LevelCheck(monster, saveMgr.playerSave.SaveDonutsLevel);
                }
            }
            else if (monsters[0].GetComponent<MakeSoldier>().Name == "√ ƒ⁄ƒ®ƒÌ≈∞")
            {
                if (saveMgr.playerSave.SaveSchneeballenGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 13");
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                }
                else if (saveMgr.playerSave.SaveSchneeballenGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 14");
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                }
                else if (saveMgr.playerSave.SaveSchneeballenGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 15");
                    LevelCheck(monster, saveMgr.playerSave.SaveSchneeballenLevel);
                }
            }

            monster.transform.localPosition = new Vector3(-1100f, -900f);
            monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
            monsters.Insert(0, monster);
        }
        else if (interporlateNum == -1)
        {
            Destroy(monsters[0]);
            monsters.Remove(monsters[0]);

            if (monsters[monsters.Count-1].GetComponent<MakeSoldier>().Name == "æÁ√ ∏”«…")
            {
                if (saveMgr.playerSave.SaveCandyGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 4");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveCandyGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 5");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveCandyGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 6");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
            }
            else if (monsters[monsters.Count - 1].GetComponent<MakeSoldier>().Name == "¡¯¿˙ƒÌ≈∞")
            {
                if (saveMgr.playerSave.SaveSkittlesGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 7");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveSkittlesGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 8");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveSkittlesGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 9");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
            }
            else if (monsters[monsters.Count - 1].GetComponent<MakeSoldier>().Name == "Ω∫≈∞∆≤¡Óƒ…¿Ã≈©")
            {
                if (saveMgr.playerSave.SaveDonutsGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 10");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveDonutsGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 11");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveDonutsGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 12");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
            }
            else if (monsters[monsters.Count - 1].GetComponent<MakeSoldier>().Name == "µµ≥”√˜")
            {
                if (saveMgr.playerSave.SaveSchneeballenGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 13");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveSchneeballenGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 14");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveSchneeballenGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 15");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
            }
            else if (monsters[monsters.Count - 1].GetComponent<MakeSoldier>().Name == "Ω¥¥œπﬂ∑ª")
            {
                if (saveMgr.playerSave.SaveChocoGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 16");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveChocoGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 17");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveChocoGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 18");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
            }
            else if (monsters[monsters.Count - 1].GetComponent<MakeSoldier>().Name == "√ ƒ⁄ƒ®ƒÌ≈∞")
            {
                if (saveMgr.playerSave.SaveCherryGrade == 1)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 1");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveCherryGrade == 2)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 2");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
                else if (saveMgr.playerSave.SaveCherryGrade == 3)
                {
                    monster.GetComponent<MakeSoldier>().SuperMagic("Mon 3");
                    LevelCheck(monster, saveMgr.playerSave.SaveCherryLevel);
                }
            }
            
            monster.transform.localPosition = new Vector3(1100f, -900f);
            monster.GetComponent<MakeSoldier>().nowPosition = monster.transform.localPosition;
            monsters.Add(monster);
        }

        for (int i = 0; i < MonsterObj.Length; i++)
        {
            if (MonsterObj[i].name == monster.GetComponent<MakeSoldier>().Code)
            {
                GameObject schneeballen = Instantiate(MonsterObj[i], monster.transform);
                schneeballen.transform.position = new Vector3(schneeballen.transform.position.x, schneeballen.transform.position.y - 0.3f);
                schneeballen.transform.localScale = new Vector3(0.8f, 0.8f);
                schneeballen.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Waiting");
            }
        }

        interporlateNum = 0;
        


        upGradeSceneWindow.UpGradeCheck(monsters[2].transform);
        toggleController.CheckToggle();
    }
}
