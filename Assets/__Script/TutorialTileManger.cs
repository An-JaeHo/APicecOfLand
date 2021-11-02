using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TutorialTileManger : MonoBehaviour
{
    public GameObject tilePrefab;
    public TutorialSupplyManger supplyManger;
    public List<Transform> tileList;
    public GameObject arrow;
    public GameObject enemyPrefab;
    public List<Transform> enemyMakeLand;
    public List<Transform> enemyLand;
    public TutorialTalkManger talkManger;
    // 타일 구분용 list
    List<Transform> nextLand;
    public Sprite[] sprites;
    public List<String> enemy1Code;
    public List<String> enemy2Code;
    public List<String> enemy3Code;
    public List<String> enemy4Code;
    public GameObject[] enemyObj;

    private void Start()
    {
        object[] loadEnemy = Resources.LoadAll("Enemy", typeof(GameObject));
        enemyObj = new GameObject[loadEnemy.Length];

        for (int i = 0; i < loadEnemy.Length; i++)
        {
            enemyObj[i] = (GameObject)loadEnemy[i];
        }
    }

    public void StartTile()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject land = Instantiate(tilePrefab, new Vector3(transform.position.x + (i * 87f), transform.position.y), Quaternion.identity);
            land.transform.GetChild(0).tag = "Grass";
            land.transform.GetChild(0).GetComponent<AreaManger>().pureTag = "Grass";
            land.transform.GetChild(0).GetComponent<AreaManger>().pureCode = "Grass";
            land.transform.GetChild(0).GetComponent<MakeArea>().Movement = true;
            land.name = (tileList.Count + 1).ToString();
            tileList.Add(land.transform);
            land.transform.SetParent(transform);
            arrow.SetActive(true);

            if (land.name != "4")
            {
                land.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        supplyManger.TutorialSupply();
    }

    public void SpawnEnemy()
    {
        int enemyRandRand = UnityEngine.Random.Range(0, 100);
        
        for (int i = 0; i < enemyLand.Count; i++)
        {
            if (enemyLand[i].childCount == 0 && enemyLand[i].tag == "Enemy Base")
            {
                GameObject noChildEnemy = Instantiate(enemyPrefab, new Vector3(enemyLand[i].position.x, enemyLand[i].position.y + 25f), Quaternion.identity);
                noChildEnemy.transform.SetParent(enemyLand[i]);

                switch (enemyLand[i].GetComponent<MakeArea>().Grade)
                {
                    case 1:
                        noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo("Enemy 1");
                        break;
                    case 2:
                        noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo("Enemy 2");
                        break;
                    case 3:

                        int enemyrand = UnityEngine.Random.Range(0, 100);

                        if (enemyrand > 90)
                        {
                            noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo("Enemy 3");
                        }
                        else
                        {
                            noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo("Enemy 4");
                        }
                        break;
                    default:
                        break;
                }

                for (int j = 0; j < enemyObj.Length; j++)
                {
                    if (enemyObj[j].name == noChildEnemy.GetComponent<MakeEnemy>().Code)
                    {
                        GameObject enemyPicture = Instantiate(enemyObj[j], new Vector3(noChildEnemy.transform.position.x, noChildEnemy.transform.position.y - 55), Quaternion.identity);
                        enemyPicture.transform.SetParent(noChildEnemy.transform);
                    }
                }
            }
        }

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(tileList[0].GetChild(0).position.x, tileList[0].GetChild(0).position.y + 25f), Quaternion.identity);
        enemy.transform.SetParent(tileList[0].GetChild(0));
        tileList[0].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 30");
        enemy.GetComponent<MakeEnemy>().InputEnemyInfo("Enemy 1");

        for (int i = 0; i < enemyObj.Length; i++)
        {
            if (enemyObj[i].name == enemy.GetComponent<MakeEnemy>().Code)
            {
                GameObject enemyPicture = Instantiate(enemyObj[i], new Vector3(enemy.transform.position.x, enemy.transform.position.y - 55), Quaternion.identity);
                enemyPicture.transform.SetParent(enemy.transform);
            }
        }
        enemy.GetComponent<TutorialEnemyManger>().move = true;
        enemy.GetComponent<TutorialEnemyManger>().SoldierAction();
    }
}
