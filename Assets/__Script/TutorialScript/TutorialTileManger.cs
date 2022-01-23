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
    public GameObject enemyPrefab;
    public List<Transform> enemyMakeLand;
    public List<Transform> enemyLand;
    public TutorialTalkManger talkManger;

    // 타일 구분용 list
    private List<Transform> nextLand;
    public Sprite[] sprites;
    private List<String> enemy1Code;
    private List<String> enemy2Code;
    private List<String> enemy3Code;
    private List<String> enemy4Code;
    public GameObject[] enemyObj;
    public GameObject cakeCastle;
    public GameObject tutorialLand;

    public Transform enemyTile;
    public Transform tutorialEnemy;

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
        for (int i = 0; i < 17; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                GameObject land = Instantiate(tilePrefab, new Vector3(transform.position.x + (j * 89f), transform.position.y + (-i * 87f)), Quaternion.identity);
                land.transform.SetParent(transform);
                land.transform.name = (tileList.Count + 1).ToString();
                land.GetComponent<SpriteRenderer>().sortingOrder = i * 2;
                land.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;

                if (land.name == "110")
                {
                    enemyTile = land.transform.GetChild(0);
                }

                if (land.name == "127" || land.name == "128" || land.name == "129"
                || land.name == "144" || land.name == "145" || land.name == "146"
                || land.name == "163" || land.name == "161" || land.name == "162")
                {
                    land.SetActive(true);

                    if (land.name == "127")
                    {
                        tutorialLand = land;
                        land.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
                    }

                    if (land.name == "145")
                    {
                        land.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[1];
                        land.transform.GetChild(0).tag = "Capital";
                        land.GetComponentInChildren<MakeArea>().Movement = true;
                        land.GetComponentInChildren<AreaManger>().pureTag = "Capital";
                        cakeCastle = land;
                        cakeCastle.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0f / 255f);
                    }
                    else
                    {
                        land.transform.GetChild(0).tag = "Grass";
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureTag = "Grass";
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureCode = "Grass";
                        land.transform.GetChild(0).GetComponent<MakeArea>().Movement = true;
                        land.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[0];
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureSprite = sprites[0];
                        enemyMakeLand.Add(land.transform);
                    }
                }
                else
                {
                    land.SetActive(false);
                }

                if (land.transform.childCount != 0)
                    land.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = i * 2 + 1;


                tileList.Add(land.transform.GetChild(0));
            }
        }
    }

    public void SpawnEnemy()
    {
        int enemyRandRand = UnityEngine.Random.Range(0, 100);

        GameObject noChildEnemy = Instantiate(enemyPrefab, new Vector3(enemyTile.position.x, enemyTile.position.y + 25f), Quaternion.identity);
        noChildEnemy.transform.SetParent(enemyTile.transform);
        tutorialEnemy = noChildEnemy.transform;

        switch (enemyTile.GetComponent<MakeArea>().Grade)
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
