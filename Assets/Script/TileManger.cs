using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TileManger : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject emptyPrefab;
    public GameObject enemyPrefab;
    public GameObject builderPrefebs;
    public List<Transform> tileList;
    public List<GameObject> activeTileList;
    public List<GameObject> SelectTile;
    public List<Transform> activeChildtileList;
    public List<Transform> builderMakeLand;
    public List<Transform> enemyMakeLand;
    GameObject tileInfo;
    

    public int wight;
    public int hight;
    public int tileCount;
    public Color color;
    private ButtonManger buttonManger;
    private PlayerInfo playerInfo;
    private SupplyManger supplyManger;
    List<GameObject> list;

    // 타일 구분용 list
    List<Transform> nextLand;
    public Sprite[] sprites;

    private void Awake()
    {
        tileList = new List<Transform>();
        SelectTile = new List<GameObject>();
        builderMakeLand = new List<Transform>();
        enemyMakeLand = new List<Transform>();
        activeTileList = new List<GameObject>();
        nextLand = new List<Transform>();
        wight = 300;
        hight = 300;
        tileCount = 0;

        list = new List<GameObject>();
    }

    private void Start()
    {
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        supplyManger = GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>();

        object[] loadedAreaBeta = Resources.LoadAll("AreaBeta", typeof(Sprite));
        sprites = new Sprite[loadedAreaBeta.Length];

        for (int i = 0; i < loadedAreaBeta.Length; i++)
        {
            sprites[i] = (Sprite)loadedAreaBeta[i];
        }

        for (int i = 0; i < 17; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                GameObject land = Instantiate(tilePrefab, new Vector3(transform.position.x + (j * 87f), transform.position.y + (-i * 87f)), Quaternion.identity);
                land.transform.SetParent(transform);
                land.transform.name = (tileList.Count + 1).ToString();
                land.GetComponent<SpriteRenderer>().sortingOrder = i * 2;

                if (land.name == "127" || land.name == "128" || land.name == "129"
                    || land.name == "144" || land.name == "145" || land.name == "146"
                    || land.name == "163" || land.name == "161" || land.name == "162")
                {
                    land.SetActive(true);

                    if (land.name == "145")
                    {
                        land.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[4];
                        land.transform.GetChild(0).tag = "Capital";
                        land.GetComponentInChildren<MakeArea>().Movement = true;
                        land.GetComponentInChildren<AreaManger>().pureTag = "Capital";

                        activeChildtileList.Add(land.transform);
                    }

                    if (land.name == "127" || land.name == "128" || land.name == "162")
                    {
                        land.transform.GetChild(0).tag = "Grass";
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureTag = "Grass";
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureCode = "Grass";
                        land.transform.GetChild(0).GetComponent<MakeArea>().Movement = true;
                        land.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[0];
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureSprite = sprites[0];
                        activeChildtileList.Add(land.transform);
                        builderMakeLand.Add(land.transform);
                        enemyMakeLand.Add(land.transform);
                    }

                    if (land.name == "129" || land.name == "163" || land.name == "144")
                    {
                        land.transform.GetChild(0).tag = "Stone";
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureTag = "Stone";
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureCode = "Stone";
                        land.transform.GetChild(0).GetComponent<MakeArea>().Movement = true;
                        land.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[1];
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureSprite = sprites[1];
                        activeChildtileList.Add(land.transform);
                        builderMakeLand.Add(land.transform);
                        enemyMakeLand.Add(land.transform);
                    }

                    if (land.name == "146" || land.name == "161")
                    {
                        land.transform.GetChild(0).tag = "Wood";
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureTag = "Wood";
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureCode = "Wood";
                        land.transform.GetChild(0).GetComponent<MakeArea>().Movement = true;
                        land.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[2];
                        land.transform.GetChild(0).GetComponent<AreaManger>().pureSprite = sprites[2];
                        activeChildtileList.Add(land.transform);
                        builderMakeLand.Add(land.transform);
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

        MakeBulider();
    }

    public void CheckTile()
    {
        activeChildtileList.Clear();

        for (int i = 0; i < activeTileList.Count; i++)
        {
            for (int j = 0; j < activeTileList[i].transform.childCount; j++)
            {
                activeChildtileList.Add(activeTileList[i].transform.GetChild(j));
            }
        }
    }

    public void NextLand()
    {
        //109 91 73 55 37 19 1
        int startNum = 0;
        int num = 0;
        int maxnum = 0;
        int pureStrartnum = 0;

        //차례에 따라 5, 7, 9, 11, 13, 15, 17
        //턴에   타라 15,25,45,75,110,150,200
        int count = 0;
        int lengthLand = 0;

        //5x5
        if (playerInfo.turnPoint == 15)
        {
            startNum = 109;
            maxnum = 4;
            lengthLand = 5;
        }
        else if (playerInfo.turnPoint == 25)
        {
            startNum = 91;
            maxnum = 6;
            lengthLand = 7;
        }
        else if (playerInfo.turnPoint == 45)
        {
            startNum = 73;
            maxnum = 8;
            lengthLand = 9;
        }
        else if (playerInfo.turnPoint == 75)
        {
            startNum = 55;
            maxnum = 10;
            lengthLand = 11;
        }
        else if (playerInfo.turnPoint == 110)
        {
            startNum = 37;
            maxnum = 12;
            lengthLand = 13;
        }
        else if (playerInfo.turnPoint == 150)
        {
            startNum = 19;
            maxnum = 14;
            lengthLand = 15;
        }
        else if (playerInfo.turnPoint == 200)
        {
            startNum = 1;
            maxnum = 16;
            lengthLand = 17;
        }

        pureStrartnum = startNum;

        for (int i = 0; i < tileList.Count; i++)
        {
            if (tileList[i].parent.name == startNum.ToString())
            {
                if (num != maxnum)
                {
                    startNum++;
                    num++;
                }
                else if (num == maxnum)
                {
                    num = 0;
                    startNum = pureStrartnum;
                    startNum += 17;
                    pureStrartnum = startNum;
                    count++;
                }

                if (tileList[i].parent.gameObject.activeSelf != true)
                {
                    tileList[i].parent.gameObject.SetActive(true);
                    tileList[i].GetComponent<MakeArea>().Movement = true;
                    activeChildtileList.Add(tileList[i].transform.parent);
                    builderMakeLand.Add(tileList[i].transform.parent);
                    enemyMakeLand.Add(tileList[i].transform.parent);
                    RandomLand(tileList[i].gameObject);
                }

                if (count == lengthLand)
                {
                    count = 0;
                    MakeBulider();
                    return;
                }
            }
        }
    }

    public void RandomLand(GameObject obj)
    {
        object[] loadedAreaBeta = Resources.LoadAll("AreaBeta", typeof(Sprite));
        sprites = new Sprite[loadedAreaBeta.Length];

        for (int i = 0; i < loadedAreaBeta.Length; i++)
        {
            sprites[i] = (Sprite)loadedAreaBeta[i];
        }



        if (sprites != null)
        {
            int rand = UnityEngine.Random.Range(0, 3);

            if (rand == 0)
            {
                obj.transform.tag = "Grass";
                obj.transform.GetComponent<AreaManger>().pureCode = "Grass";
                obj.transform.GetComponent<AreaManger>().pureTag = "Grass";
            }
            else if (rand == 1)
            {
                obj.transform.tag = "Stone";
                obj.transform.GetComponent<AreaManger>().pureCode = "Stone";
                obj.transform.GetComponent<AreaManger>().pureTag = "Stone";
            }
            else if (rand == 2)
            {
                obj.transform.tag = "Wood";
                obj.transform.GetComponent<AreaManger>().pureCode = "Wood";
                obj.transform.GetComponent<AreaManger>().pureTag = "Wood";
            }

            obj.transform.GetComponent<SpriteRenderer>().sprite = sprites[rand];
            obj.transform.GetComponent<AreaManger>().pureSprite = sprites[rand];
        }
    }

    public void MakeBulider()
    {
        int rand = UnityEngine.Random.Range(0, builderMakeLand.Count);

        if (builderMakeLand[rand].GetChild(0).childCount == 0)
        {
            GameObject bulider = Instantiate(builderPrefebs,
                new Vector3(builderMakeLand[rand].GetChild(0).position.x, builderMakeLand[rand].GetChild(0).position.y + 25f), Quaternion.identity);
            bulider.transform.SetParent(builderMakeLand[rand].GetChild(0));
            bulider.name = "Bulider";
            buttonManger.builders.Add(bulider);
        }
        builderMakeLand.Clear();
    }

    public void SpawnEnemy()
    {
        List<Transform> noChildLand = enemyMakeLand;

        for(int i=0; i< noChildLand.Count;i++)
        {
            if(noChildLand[i].GetChild(0).childCount !=0)
            {
                noChildLand.RemoveAt(i);
            }
        }

        if (playerInfo.turnPoint == 10)
        {
            int rand = UnityEngine.Random.Range(0, noChildLand.Count);
            noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 27");

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(noChildLand[rand].GetChild(0).position.x,noChildLand[rand].GetChild(0).position.y + 25f), Quaternion.identity);
            enemy.transform.SetParent(noChildLand[rand].GetChild(0));
            enemy.GetComponent<MakeEnemy>().InputEnemyInfo("Enemy 1");
            buttonManger.enemys.Add(enemy);
        }
    }
}
