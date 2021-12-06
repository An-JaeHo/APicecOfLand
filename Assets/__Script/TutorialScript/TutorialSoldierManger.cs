﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialSoldierManger : MonoBehaviour
{
    private int stayTime;
    private int moveUpPosition;
    private int y;
    private Vector3 movePosition;
    public TutorialButtonManger buttonManger;
    public Animator ani;

    public TutorialTileManger tileManger;
    public TutorialInputManger input;
    public GameObject rangePrefeb;
    public MakeSoldier soldier;
    public List<GameObject> rangeList;
    public Transform enemy;
    public bool move;
    public bool attack;
    public bool capitalPoint;
    public GameObject buffIconGameObj;
    public Sprite buffIconPrefeb;
    public List<Sprite> buffList;
    public List<GameObject> buffPrefebList;
    public int buffCount;

    float pureattack;
    float puredefend;
    float pureMoveRange;
    public float totalHp;
    public bool movePoint;
    public bool cardMovePoint;
    public int builderPoint;
    public float countAttack;
    public bool directionCheck;

    //레벨에따른 다른 이미지
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;
    public Sprite level4;
    public Sprite level5;

    void Start()
    {
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TutorialTileManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialButtonManger>();
        input = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialInputManger>();
        soldier = GetComponent<MakeSoldier>();
        directionCheck = true;

        ani = transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        totalHp = soldier.HelthPoint;
        stayTime = 0;
        move = false;
        movePoint = true;
        cardMovePoint = false;
        capitalPoint = false;
        countAttack = 0;

        pureattack = transform.GetComponent<MakeSoldier>().BaseAttack;
        puredefend = transform.GetComponent<MakeSoldier>().Defensive;
        pureMoveRange = transform.GetComponent<MakeSoldier>().Movement;
        builderPoint = 0;
    }

    private void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime * 100f);
            stayTime++;

            if (transform.position == movePosition)
            {
                ani.SetBool("Move", false);
                input.armyMove = true;
                stayTime = 0;
                buttonManger.button.GetComponent<Button>().interactable = true;

                if (!input.finalCheck)
                {
                    tileManger.SpawnEnemy();
                    tileManger.talkManger.NextTalk();
                    tileManger.talkManger.stopTalkNum = 2;
                    tileManger.talkManger.talkCheck = true;
                }
                input.talk = false;
                movePoint = true;

                if (transform.parent.GetComponent<MakeArea>().Name == "우주선")
                {
                    //transform.GetComponent<AudioSource>().clip = SoundController.instance.buildSounds[2].audio;
                    //transform.GetComponent<AudioSource>().Play();
                    input.talkManger.stopTalkNum = 7;
                    input.talkManger.NextScriptButton();
                    tileManger.talkManger.talkCheck = true;
                    transform.parent.GetComponent<AreaManger>().TurnArea();
                    transform.parent.GetComponent<MakeArea>().Name = "Grass";
                }

                move = false;
            }
        }

    }

    public void SoldierAction()
    {
        if (move)
        {
            StartCoroutine(Move());
        }

        if (attack)
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Move()
    {
        movePosition = new Vector3(transform.parent.position.x, transform.parent.position.y + 25, transform.parent.position.z - 10);
        ani.SetBool("Move", true);
        buttonManger.button.GetComponent<Button>().interactable = false;

        if (cardMovePoint)
        {
            movePoint = true;
            cardMovePoint = false;
        }
        
        yield return null;
    }

    IEnumerator Attack()
    {
        buttonManger.button.GetComponent<Button>().interactable = false;

        //AenemyhelthPoint – (((Atack_sum/Defend_sum)*30)+치명타대미지))
        //
        //공격자: (BaseAttack + (RiseAttack * Level)) = Atack_sum
        //
        //방어자: ((BaseDefend + (RiseDefend * Level)) = Defend_sum
        //
        //치명타 대미지:(치명타 확률)> (Atack_sum * (0.7~11))

        float attackSum = soldier.BaseAttack + (soldier.RiseAttack * soldier.Level);

        if (enemy != null)
        {
            if (int.Parse(transform.parent.parent.name) <= int.Parse(enemy.parent.parent.name)
            && Mathf.Abs(int.Parse(transform.parent.parent.name) - int.Parse(enemy.parent.parent.name)) <= 10)
            {
                directionCheck = true;
                transform.transform.GetChild(1).localScale = new Vector3(0.4f, 0.4f);
            }
            else if (int.Parse(transform.parent.parent.name) > int.Parse(enemy.parent.parent.name)
                && Mathf.Abs(int.Parse(transform.parent.parent.name) - int.Parse(enemy.parent.parent.name)) <= 10)
            {
                directionCheck = false;
                transform.transform.GetChild(1).localScale = new Vector3(-0.4f, 0.4f);
            }


            float randnum = Random.Range(0.8f, 1.2f);
            float randCritical = Random.Range(0.7f, 1.1f);
            //적이 받는 데미지
            if (enemy.tag == "Enemy")
            {
                float defendSum = enemy.GetComponent<MakeEnemy>().BaseDefensive + (enemy.GetComponent<MakeEnemy>().RiseAttack * enemy.GetComponent<MakeEnemy>().Level);
                enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)((((attackSum / defendSum) * 30)));

                float randCri = Random.Range(0, 100);
                if (randCri <= soldier.Critical)
                {
                    enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)(attackSum + randCritical);
                }
            }
            else
            {
                float defendSum = enemy.GetComponent<GDController>().Defensive + (enemy.GetComponent<GDController>().RiseAttack);
                enemy.GetComponent<GDController>().HelthPoint -= (int)((((attackSum / defendSum) * 30)));

                float randCri = Random.Range(0, 100);
                if (randCri <= soldier.Critical)
                {
                    enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)(attackSum + randCritical);
                }
            }

            ani.SetTrigger("Attack");

            //for (int i = 0; i < SoundController.instance.monsterSounds.Length; i++)
            //{
            //    if (SoundController.instance.monsterSounds[i].name == transform.GetComponent<MakeSoldier>().Name)
            //    {
            //        AudioClip audio = SoundController.instance.monsterSounds[i].audio;
            //        transform.GetComponent<AudioSource>().clip = audio;
            //        transform.GetComponent<AudioSource>().Play();
            //    }
            //}

            yield return new WaitForSeconds(0.5f);

            attack = false;
            movePoint = true;
            enemy.GetComponent<MakeEnemy>().BaseHelthPoint = 0;
            enemy.GetComponent<TutorialEnemyManger>().HpBarScale();

            if (enemy.tag == "Enemy")
            {
                if (enemy.GetComponent<MakeEnemy>().BaseHelthPoint <= 0)
                {
                    enemy.GetComponent<TutorialEnemyManger>().ani.SetTrigger("Damage");
                    soldier.nowExp += enemy.GetComponent<MakeEnemy>().DropExperiencePoint;
                    input.ChangeLandInfo();
                    input.finalCheck = true;
                    tileManger.talkManger.FinalTalk();
                    tileManger.talkManger.stopTalkNum = 3;
                    tileManger.talkManger.talkCheck = true;
                    enemy.parent.GetComponent<BoxCollider2D>().enabled = false;
                    Destroy(enemy.gameObject);
                }
                else
                {
                    enemy.GetComponent<TutorialEnemyManger>().ani.SetTrigger("Damage");
                }
            }
        }

        if (cardMovePoint)
        {
            movePoint = true;
            cardMovePoint = false;
        }

        buttonManger.button.GetComponent<Button>().interactable = false;
        yield return null;
    }

    public void HpBarScale()
    {
        Transform hpBar = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0);

        float nowHp = soldier.HelthPoint / totalHp;

        if (nowHp <= 0)
        {
            nowHp = 0;
        }

        hpBar.localScale = new Vector3(nowHp, 1f);
    }

    public void ExpBarScale()
    {
        Transform expBar = transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0);
        int exp = soldier.nowExp;
        float totalexp = soldier.Experience;
        float nowExp = soldier.nowExp / totalexp;

        if (nowExp <= 0)
        {
            nowExp = 0;
        }

        if (nowExp >= 1)
        {
            nowExp = 1;
        }

        expBar.localScale = new Vector3(nowExp, 1f);

        if (nowExp == 1)
        {
            LevelUpCheck();
        }
    }

    public void CheckBuildCount()
    {
        if (transform.parent.GetComponent<MakeArea>().BuildTurn != builderPoint
            && transform.parent.GetComponent<MakeArea>().firstBuild == true)
        {
            movePoint = false;
            builderPoint++;
        }
        else
        {
            movePoint = true;
            if (transform.parent.tag == "Area" || transform.parent.tag == "Barracks")
            {
                transform.parent.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<MakeArea>().Picture;
            }
            else
            {
                transform.parent.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<AreaManger>().pureSprite;
            }

            transform.parent.GetComponent<MakeArea>().Destroy = false;
            transform.parent.GetComponent<MakeArea>().firstBuild = false;
            transform.parent.GetComponent<AreaManger>().CheckUpdateMaterial();

            builderPoint = 0;
        }


    }

    public void MakeBuffIcon(string code)
    {
        int i = buffPrefebList.Count;
        GameObject icon = Instantiate(buffIconGameObj, transform);
        icon.GetComponent<InputSkill>().MakeCard(code);
        icon.GetComponent<SpriteRenderer>().sortingOrder = transform.GetComponent<SpriteRenderer>().sortingOrder + 1;
        icon.GetComponent<SpriteRenderer>().sprite = icon.GetComponent<InputSkill>().Picture;
        buffCount = icon.GetComponent<InputSkill>().Turn;

        icon.transform.position = new Vector3(icon.transform.position.x - 10 + ((i - 1) * 15), transform.GetChild(0).position.y + 100);
        buffPrefebList.Add(icon);
    }

    public void ReturnPure()
    {
        soldier.BaseAttack = pureattack;
        soldier.Defensive = puredefend;
        soldier.Movement = (int)pureMoveRange;
    }

    public void CheckBuff()
    {
        for (int i = 0; i < buffPrefebList.Count; i++)
        {
            if (buffPrefebList[i].GetComponent<InputSkill>().Turn > 0)
            {
                switch (buffPrefebList[i].GetComponent<InputSkill>().Code)
                {
                    case "Card 10":
                        soldier.Movement++;
                        break;
                    case "Card 11":
                        soldier.Movement++;
                        break;
                    case "Card 22":
                        cardMovePoint = true;
                        break;
                    case "Card 23":
                        cardMovePoint = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void LevelUpCheck()
    {
        if (soldier.nowExp >= soldier.Experience)
        {
            soldier.Level++;
            soldier.BaseAttack += soldier.RiseAttack;
            soldier.Critical += soldier.RiseCritical;
            soldier.Defensive += soldier.RiseDefensive;
            soldier.Critical += soldier.RiseCritical;
            soldier.HelthPoint = (int)totalHp;
            soldier.nowExp = 0;
        }

        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = transform.GetComponent<MakeSoldier>().Level.ToString(); ;
    }
}
