using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArea : MonoBehaviour
{
    public Sprite[] sprites;
    public int land;
    public int wood;
    public int iron;
    public ButtonManger buttonManger;
    public GameObject enemyPrefeb;
    public GameObject enemy;
    int a;


    int enemyNum;

    private void Start()
    {
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        a = 0;
        enemyNum = 0;
    }

    public void RandomLand()
    {
        object[] loadedAreaBeta = Resources.LoadAll("AreaBeta", typeof(Sprite));
        sprites = new Sprite[loadedAreaBeta.Length];

        for (int i = 0; i < loadedAreaBeta.Length; i++)
        {
            sprites[i] = (Sprite)loadedAreaBeta[i];
        }


        if (sprites != null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int rand = Random.Range(0, 3);

                if (i != 4)
                {
                    if (rand == 0)
                    {
                        transform.GetChild(i).tag = "Grass";
                        transform.GetChild(i).GetComponent<AreaManger>().pureCode = "Grass";
                    }
                    else if (rand == 1)
                    {
                        transform.GetChild(i).tag = "Stone";
                        transform.GetChild(i).GetComponent<AreaManger>().pureCode = "Stone";
                    }
                    else if (rand == 2)
                    {
                        transform.GetChild(i).tag = "Wood";
                        transform.GetChild(i).GetComponent<AreaManger>().pureCode = "Wood";
                    }

                    transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = sprites[rand];
                    transform.GetChild(i).GetComponent<AreaManger>().pureSprite = sprites[rand];


                }
            }
        }
    }

    public GameObject MakeEnemy()
    {
        int i = new int();
        List<Transform> emptyland = new List<Transform>();
        enemyPrefeb.tag = "Enemy";

        for (int j = 0; j < transform.childCount; j++)
        {
            if(transform.GetChild(j).childCount ==0)
            {
                emptyland.Add(transform.GetChild(j));
            }
        }

        if(emptyland.Count !=0)
        {
            i = Random.Range(0, emptyland.Count);

            if (emptyland[i].childCount == 0)
            {
                enemy = Instantiate(enemyPrefeb, emptyland[i]);
                enemy.name = "Troop 20";
                enemy.GetComponent<MakeSoldier>().SuperMagic(enemy.name);
                enemy.GetComponent<SpriteRenderer>().sprite = enemy.GetComponent<MakeSoldier>().Picture;

                enemy.name = enemyNum.ToString();
                enemyNum++;
                return enemy;
            }
        }

        return null;
    }
}

