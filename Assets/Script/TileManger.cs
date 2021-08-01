using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TileManger : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject enemyPrefab;
    public GameObject builderPrefebs;
    public List<Transform> tileList;
    public List<GameObject> activeTileList;
    public List<GameObject> SelectTile;
    public List<Transform> activeChildtileList;
    public List<Transform> builderMakeLand;
    public List<Transform> enemyMakeLand;
    public List<Transform> enemyLand;
    GameObject tileInfo;
    public JsonManger json;

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
    public List<String> enemy1Code;
    public List<String> enemy2Code;
    public List<String> enemy3Code;
    public List<String> enemy4Code;

    //아몰랑 ㅅㅂ
    public GameObject[] enemyObj;
    public GameObject[] MonsterObj;
    public GameObject[] bossObj;
    public GameObject particlePrefeb;

    //보스
    public GameObject bossPrefeb;
    public GameObject bossHP;
    public GameObject bossText;
    float alpha = 1.0f;
    float speed = 0.5f;

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
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        object[] loadedAreaBeta = Resources.LoadAll("StartArea", typeof(Sprite));
        sprites = new Sprite[loadedAreaBeta.Length];

        object[] loadMonster = Resources.LoadAll("Monster", typeof(GameObject));
        MonsterObj = new GameObject[loadMonster.Length];

        object[] loadEnemy = Resources.LoadAll("Enemy", typeof(GameObject));
        enemyObj = new GameObject[loadEnemy.Length];

        object[] loadBoss = Resources.LoadAll("Boss", typeof(GameObject));
        bossObj = new GameObject[loadBoss.Length];

        for (int i = 0; i < loadedAreaBeta.Length; i++)
        {
            sprites[i] = (Sprite)loadedAreaBeta[i];
        }

        for (int i = 0; i < loadEnemy.Length; i++)
        {
            enemyObj[i] = (GameObject)loadEnemy[i];
        }
        
        for (int i = 0; i < loadMonster.Length; i++)
        {
            MonsterObj[i] = (GameObject)loadMonster[i];
        }

        for (int i = 0; i < loadBoss.Length; i++)
        {
            bossObj[i] = (GameObject)loadBoss[i];
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
                        land.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[1];
                        land.transform.GetChild(0).tag = "Capital";
                        land.GetComponentInChildren<MakeArea>().Movement = true;
                        land.GetComponentInChildren<AreaManger>().pureTag = "Capital";

                        activeChildtileList.Add(land.transform);
                    }
                    else
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
        SortGrade();
    }

    private void Update()
    {
        if(bossText.activeSelf == true)
        {
            if (alpha > 0)
            {
                bossText.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
                bossText.transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, alpha);
                alpha -= Time.deltaTime * speed;
            }
            else
            {
                bossText.SetActive(false);
            }
        }
    }

    public void CheckTile()
    {
        for (int i = 0; i < tileList.Count; i++)
        {
            if(tileList[i].childCount !=0)
            {
                tileList[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                tileList[i].GetComponent<BoxCollider2D>().enabled = true;
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
        //턴에   따라 8, 15, 30, 50, 70, 100, 120
        int count = 0;
        int lengthLand = 0;

        //5x5
        if (playerInfo.turnPoint == 8)
        {
            enemyMakeLand.Clear();
            startNum = 109;
            maxnum = 4;
            lengthLand = 5;
        }
        else if (playerInfo.turnPoint == 15)
        {
            enemyMakeLand.Clear();
            startNum = 91;
            maxnum = 6;
            lengthLand = 7;
        }
        else if (playerInfo.turnPoint == 30)
        {
            enemyMakeLand.Clear();
            startNum = 73;
            maxnum = 8;
            lengthLand = 9;
        }
        else if (playerInfo.turnPoint == 50)
        {
            enemyMakeLand.Clear();
            startNum = 55;
            maxnum = 10;
            lengthLand = 11;
        }
        else if (playerInfo.turnPoint == 70)
        {
            enemyMakeLand.Clear();
            startNum = 37;
            maxnum = 12;
            lengthLand = 13;
        }
        else if (playerInfo.turnPoint == 100)
        {
            enemyMakeLand.Clear();
            startNum = 19;
            maxnum = 14;
            lengthLand = 15;
        }
        else if (playerInfo.turnPoint == 120)
        {
            enemyMakeLand.Clear();
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

                if (count == lengthLand && playerInfo.turnPoint <= 70)
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
        object[] loadedAreaBeta = Resources.LoadAll("StartArea", typeof(Sprite));
        sprites = new Sprite[loadedAreaBeta.Length];

        for (int i = 0; i < loadedAreaBeta.Length; i++)
        {
            sprites[i] = (Sprite)loadedAreaBeta[i];
        }

        if (sprites != null)
        {
            int rand = UnityEngine.Random.Range(0, 3);

            obj.transform.tag = "Grass";
            obj.transform.GetComponent<AreaManger>().pureCode = "Grass";
            obj.transform.GetComponent<AreaManger>().pureTag = "Grass";
            obj.transform.GetComponent<SpriteRenderer>().sprite = sprites[0];
            obj.transform.GetComponent<AreaManger>().pureSprite = sprites[0];
        }
    }

    public void DeadBulider(GameObject builder)
    {
        List<Transform> builderLand = activeChildtileList;

        for (int i = 0; i < activeChildtileList.Count; i++)
        {
            if(activeChildtileList[i].GetChild(0).childCount ==0
                && activeChildtileList[i].tag != "Capital")
            {
                builderLand.Add(activeChildtileList[i]);
            }
        }

        int rand = UnityEngine.Random.Range(0, builderLand.Count - 2);

        builder.SetActive(false);
        builder.transform.position = new Vector3(builderLand[rand].GetChild(0).position.x + 10f, builderLand[rand].GetChild(0).position.y + 25f);
        builder.transform.SetParent(builderLand[rand].GetChild(0));
        builder.GetComponent<MakeSoldier>().HelthPoint = 500;
        builder.GetComponent<SoldierManger>().HpBarScale();
        builder.SetActive(true);

    }

    public void MakeBulider()
    {
        int rand = UnityEngine.Random.Range(0, builderMakeLand.Count-1);

        if (builderMakeLand[rand].GetChild(0).childCount == 0)
        {
            GameObject bulider = Instantiate(builderPrefebs,new Vector3(builderMakeLand[rand].GetChild(0).position.x, builderMakeLand[rand].GetChild(0).position.y + 25f), Quaternion.identity);
            bulider.transform.SetParent(builderMakeLand[rand].GetChild(0));
            bulider.name = "Mon 19";
            bulider.GetComponent<MakeSoldier>().SuperMagic(bulider.name);
            playerInfo.updateMilk -= bulider.GetComponent<MakeSoldier>().ConsumeFood;
            

            for (int i = 0; i < MonsterObj.Length; i++)
            {
                if (MonsterObj[i].name == bulider.GetComponent<MakeSoldier>().Code)
                {
                    GameObject monsterPicture = Instantiate(MonsterObj[i], new Vector3(bulider.transform.position.x, bulider.transform.position.y - 55), Quaternion.identity);
                    monsterPicture.transform.SetParent(bulider.transform);
                }
            }
            
            buttonManger.builders.Add(bulider);
        }

        builderMakeLand.Clear();
    }

    public void SpawnEnemy()
    {
        List<Transform> noChildLand = enemyMakeLand;
        int rand = UnityEngine.Random.Range(0, noChildLand.Count-1);
        int enemyRandRand = UnityEngine.Random.Range(0, 100);

        for (int i=0; i< noChildLand.Count;i++)
        {
            if(noChildLand[i].GetChild(0).childCount !=0)
            {
                noChildLand.RemoveAt(i);
            }
        }

        if (enemyLand.Count != 0)
        {
            if (playerInfo.turnPoint % 2 == 0)
            {
                for (int i = 0; i < enemyLand.Count; i++)
                {
                    if (enemyLand[i].childCount == 0 && enemyLand[i].tag == "Enemy Base")
                    {
                        GameObject noChildEnemy = Instantiate(enemyPrefab, new Vector3(enemyLand[i].position.x, enemyLand[i].position.y + 25f), Quaternion.identity);
                        noChildEnemy.transform.SetParent(enemyLand[i]);

                        switch (enemyLand[i].GetComponent<MakeArea>().Grade)
                        {
                            case 1:
                                noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy1Code[0]);
                                break;
                            case 2:
                                noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy2Code[0]);
                                break;
                            case 3:

                                int enemyrand = UnityEngine.Random.Range(0, 100);

                                if (enemyrand > 90)
                                {
                                    noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy3Code[0]);
                                }
                                else
                                {
                                    noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy4Code[0]);
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
                        LevelCheck(noChildEnemy);
                        buttonManger.enemys.Add(noChildEnemy);
                    }
                }
            }
        }

        if (playerInfo.turnPoint % 4 == 0 && playerInfo.turnPoint >= 8)
        {

            if(playerInfo.turnPoint == 20)
            {
                bossHP.SetActive(true);
                bossText.SetActive(true);

                GameObject boss = Instantiate(bossPrefeb, new Vector3(noChildLand[rand].GetChild(0).position.x, noChildLand[rand].GetChild(0).position.y + 25f), Quaternion.identity);
                boss.transform.SetParent(noChildLand[rand].GetChild(0));
                noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 31");
                boss.GetComponent<GDController>().MakeGD("Boss 1");

                for (int i = 0; i < bossObj.Length; i++)
                {
                    if (bossObj[i].name == boss.GetComponent<GDController>().Code)
                    {
                        GameObject enemyPicture = Instantiate(bossObj[i], new Vector3(boss.transform.position.x, boss.transform.position.y - 55), Quaternion.identity);
                        enemyPicture.transform.SetParent(boss.transform);
                    }
                }
                enemyLand.Add(noChildLand[rand].GetChild(0));

                noChildLand.Remove(noChildLand[rand]);
                rand = UnityEngine.Random.Range(0, noChildLand.Count - 1);
                buttonManger.enemys.Add(boss);
            }

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(noChildLand[rand].GetChild(0).position.x, noChildLand[rand].GetChild(0).position.y + 25f), Quaternion.identity);
            enemy.transform.SetParent(noChildLand[rand].GetChild(0));

            // 8 15 30 50 70 100 120
            if (playerInfo.turnPoint < 30)
            {
                noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 30");
                enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy1Code[0]);
            }
            else if (playerInfo.turnPoint < 50)
            {
                if (enemyRandRand > 50)
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 30");
                    enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy1Code[0]);
                }
                else
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 31");
                    enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy2Code[0]);
                }
            }
            else if (playerInfo.turnPoint < 70)
            {
                if (enemyRandRand < 80)
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 31");
                    enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy2Code[0]);
                }
                else
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 32");

                    int enemyrand = UnityEngine.Random.Range(0, 100);

                    if(enemyrand > 90)
                    {
                        enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy3Code[0]);
                    }
                    else
                    {
                        enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy4Code[0]);
                    }
                    
                }
            }
            else if (playerInfo.turnPoint < 100)
            {
                if (enemyRandRand > 50)
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 31");
                    enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy2Code[0]);
                }
                else
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 32");
                    int enemyrand = UnityEngine.Random.Range(0, 100);

                    if (enemyrand > 90)
                    {
                        enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy3Code[0]);
                    }
                    else
                    {
                        enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy4Code[0]);
                    }
                }
            }
            else if (playerInfo.turnPoint < 120)
            {
                if (enemyRandRand > 50)
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 31");
                    enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy2Code[0]);
                }
                else
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 32");
                    int enemyrand = UnityEngine.Random.Range(0, 100);

                    if(enemyrand > 90)
                    {
                        enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy3Code[0]);
                    }
                    else
                    {
                        enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy4Code[0]);
                    }
                }
            }
            else
            {
                if (enemyRandRand > 80)
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 31");
                    enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy2Code[0]);
                }
                else
                {
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 32");
                    int enemyrand = UnityEngine.Random.Range(0, 100);

                    if (enemyrand > 90)
                    {
                        enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy3Code[0]);
                    }
                    else
                    {
                        enemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy4Code[0]);
                    }
                }
            }

            for (int i = 0; i < enemyObj.Length; i++)
            {
                if (enemyObj[i].name == enemy.GetComponent<MakeEnemy>().Code)
                {
                    
                    GameObject enemyPicture = Instantiate(enemyObj[i], new Vector3(enemy.transform.position.x, enemy.transform.position.y - 55), Quaternion.identity);
                    enemyPicture.transform.SetParent(enemy.transform);
                }
            }
            LevelCheck(enemy);
            buttonManger.enemys.Add(enemy);
            enemyLand.Add(noChildLand[rand].GetChild(0));
        }
    }

    public void SortGrade()
    {
        for (int i = 0; i < json.information.enemy.Length; i++)
        {
            if (json.information.enemy[i].Grade == 1)
            {
                enemy1Code.Add(json.information.enemy[i].Code);
            }

            if (json.information.enemy[i].Grade == 2)
            {
                enemy2Code.Add(json.information.enemy[i].Code);
            }

            if (json.information.enemy[i].Grade == 3)
            {
                enemy3Code.Add(json.information.enemy[i].Code);
            }

            if (json.information.enemy[i].Grade == 4)
            {
                enemy4Code.Add(json.information.enemy[i].Code);
            }
        }
    }

    public void LevelCheck(GameObject Enemy)
    {
        int randLevel = new int();

        Debug.Log("ss");
        if (playerInfo.turnPoint <= 20)
        {
            randLevel = UnityEngine.Random.Range(1, 6);
        }
        else if (playerInfo.turnPoint <= 50)
        {
            randLevel = UnityEngine.Random.Range(5, 21);
        }
        else if (playerInfo.turnPoint <= 100)
        {
            randLevel = UnityEngine.Random.Range(15, 31);
        }
        else if (playerInfo.turnPoint <= 150)
        {
            randLevel = UnityEngine.Random.Range(20, 51);
        }
        else if (playerInfo.turnPoint <= 200)
        {
            randLevel = UnityEngine.Random.Range(30, 50);
        }

        Enemy.GetComponent<MakeEnemy>().BaseAttack += Enemy.GetComponent<MakeEnemy>().RiseAttack * randLevel;
        Enemy.GetComponent<MakeEnemy>().BaseDefensive += Enemy.GetComponent<MakeEnemy>().RiseDefensive * randLevel;
        Enemy.GetComponent<MakeEnemy>().BaseHelthPoint += Enemy.GetComponent<MakeEnemy>().RiseHelthPoint * randLevel;
        Enemy.GetComponent<MakeEnemy>().Level += randLevel;
    }
}
