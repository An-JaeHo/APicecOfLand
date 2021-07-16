﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class JsonManger : GenericSingletonClass<JsonManger>
{
    public const string fileName = "Information.json";

    public TextAsset streamingAssetsPath;
    public Information information;

    public Sprite[] item;
    public Sprite[] cardImg;
    public Sprite[] monsterImg;
    public Sprite[] bossImg;
    public Sprite[] enemyImg;

    

    public override void Awake()
    {
        base.Awake();

        streamingAssetsPath = Resources.Load("information") as TextAsset;
        //streamingAssetsPath += "/" + fileName;
        StartCoroutine(CallDate());
    }


    private IEnumerator CallDate()
    {
        //string jsonString = File.ReadAllText(streamingAssetsPath.text);
#if UNITY_EDITOR || UNITY_IOS
        //string jsonfile = File.ReadAllText(streamingAssetsPath.text);
#elif UNITY_ANDROID

       //WWW www = new WWW(streamingAssetsPath);

       // //만약에 www의 처리가 완료 되었다면
       // if (www.isDone)
       // {
       //     //디버그 로그
       //     Debug.Log("Downloaded");
       // }

       // //www가 완료 될때까지 기다려줌
       // //yield return www;

       // //만약에 에러가 발생했다면
       // //if (www.error != null)
       // //{
       // //    //에러상황 던져줌
       // //    throw new Exception("www downloaded : " + www.error);
       // //}

       // //jsonString에다가 받은 데이터를 string으로 넣어줌
       // jsonString = www.text;

        information = JsonUtility.FromJson<Information>(streamingAssetsPath.text);

#endif

        information = JsonUtility.FromJson<Information>(streamingAssetsPath.text);
        
        LoadItem();
        loadAllImg();

        yield return null;

        
    }


    private void LoadItem()
    {
        object[] loadedItem = Resources.LoadAll("Area", typeof(Sprite));
        object[] loadedCard = Resources.LoadAll("Card", typeof(Sprite));
        object[] loadedmonster = Resources.LoadAll("Monster", typeof(Sprite));
        object[] loadedGD = Resources.LoadAll("Boss", typeof(Sprite));
        object[] loadEnemy = Resources.LoadAll("Enemy", typeof(Sprite));

        item = new Sprite[loadedItem.Length];
        cardImg = new Sprite[loadedCard.Length];
        monsterImg = new Sprite[loadedmonster.Length];
        bossImg = new Sprite[loadedGD.Length];
        enemyImg = new Sprite[loadEnemy.Length];

        for (int i = 0; i < loadedItem.Length; i++)
        {
            item[i] = (Sprite)loadedItem[i];
        }

        for (int i = 0; i < loadedCard.Length; i++)
        {
            cardImg[i] = (Sprite)loadedCard[i];
        }

        for (int i = 0; i < loadedmonster.Length; i++)
        {
            monsterImg[i] = (Sprite)loadedmonster[i];
        }

        for (int i = 0; i < loadedGD.Length; i++)
        {
            bossImg[i] = (Sprite)loadedGD[i];
        }

        for (int i = 0; i < loadEnemy.Length; i++)
        {
            enemyImg[i] = (Sprite)loadEnemy[i];
        }
    }

    private void loadAllImg()
    {
        for (int i = 0; i < information.area.Length; i++)
        {
            for (int j = 0; j < item.Length; j++)
            {
                if (information.area[i].Code == item[j].name)
                {
                    information.area[i].Picture = item[j];
                }
            }
        }

        for (int i = 0; i < information.card.Length; i++)
        {
            for (int j = 0; j < cardImg.Length; j++)
            {
                if (information.card[i].Code == cardImg[j].name)
                {
                    information.card[i].Picture = cardImg[j];
                }
            }
        }

        for (int i = 0; i < information.monster.Length; i++)
        {
            for (int j = 0; j < monsterImg.Length; j++)
            {
                if (information.monster[i].Code == monsterImg[j].name)
                {
                    information.monster[i].Picture = monsterImg[j];
                }
            }
        }

        for (int i = 0; i < information.boss.Length; i++)
        {
            for (int j = 0; j < bossImg.Length; j++)
            {
                if (information.boss[i].Code == bossImg[j].name)
                {
                    information.boss[i].Picture = bossImg[j];
                }
            }
        }

        for (int i = 0; i < information.enemy.Length; i++)
        {
            for (int j = 0; j < enemyImg.Length; j++)
            {
                if (information.enemy[i].Code == enemyImg[j].name)
                {
                    information.enemy[i].Picture = enemyImg[j];
                }
            }
        }
    }
}
