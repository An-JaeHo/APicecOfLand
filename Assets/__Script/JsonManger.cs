using System.Collections;
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
        StartCoroutine(CallDate());
    }

    private IEnumerator CallDate()
    {
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
