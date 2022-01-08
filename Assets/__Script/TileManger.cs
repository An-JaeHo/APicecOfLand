using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private GameObject tileInfo;
    public JsonManger json;

    //알람용 UI
    public GameObject attackAlarm;
    public GameObject defendAlarm;

    //타일체크용
    public int attackTurn;
    public bool attackTurnCheck;
    private float timer;
    private bool alarmCheck;
    private bool makeTileCheck;
    public int wight;
    public int hight;
    public int tileCount;
    public Color color;
    public ButtonManger buttonManger;
    private PlayerInfo playerInfo;
    public SupplyManger supplyManger;
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
    public Sprite[] destroyAreaObj;
    public Sprite[] areaImges;
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
        attackTurn = 0;
        timer = 0;
        list = new List<GameObject>();
        attackTurnCheck = true;
        alarmCheck = false;
        makeTileCheck = false;
    }

    private void Start()
    {
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        supplyManger = GameObject.FindGameObjectWithTag("Supply").GetComponent<SupplyManger>();
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();

        LoadAllImge();
        

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
        SortGrade();
        alarmCheck = true;
        defendAlarm.SetActive(true);
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

        if(alarmCheck)
        {
            timer += Time.deltaTime;

            if(timer >3f)
            {
                attackAlarm.SetActive(false);
                defendAlarm.SetActive(false);
                alarmCheck = false;
                timer = 0;
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

                if(tileList[i].GetComponent<MakeArea>().Name == "치료소")
                {
                    float heathPoint;

                    if(tileList[i].GetComponent<MakeArea>().Grade ==1)
                    {
                        heathPoint = 0.05f;
                    }
                    else if(tileList[i].GetComponent<MakeArea>().Grade == 2)
                    {
                        heathPoint = 0.1f;
                    }
                    else
                    {
                        heathPoint = 0.2f;
                    }

                    if(tileList[i].GetChild(0).tag == "Army")
                    {
                        tileList[i].GetChild(0).GetComponent<MakeSoldier>().HelthPoint += (int)(tileList[i].GetChild(0).GetComponent<SoldierManger>().totalHp * heathPoint);

                        if (tileList[i].GetChild(0).GetComponent<SoldierManger>().totalHp< tileList[i].GetChild(0).GetComponent<MakeSoldier>().HelthPoint)
                        {
                            tileList[i].GetChild(0).GetComponent<MakeSoldier>().HelthPoint = (int)tileList[i].GetChild(0).GetComponent<SoldierManger>().totalHp;
                        }

                        
                    }
                    
                }
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
        if (playerInfo.turnPoint == 3)
        {
            enemyMakeLand.Clear();
            startNum = 109;
            maxnum = 4;
            lengthLand = 5;
            makeTileCheck = true;
        }
        else if (playerInfo.turnPoint == 26)
        {
            enemyMakeLand.Clear();
            startNum = 91;
            maxnum = 6;
            lengthLand = 7;
            makeTileCheck = true;
        }
        else if (playerInfo.turnPoint == 62)
        {
            enemyMakeLand.Clear();
            startNum = 73;
            maxnum = 8;
            lengthLand = 9;
            makeTileCheck = true;
        }
        else if (playerInfo.turnPoint == 122)
        {
            enemyMakeLand.Clear();
            startNum = 55;
            maxnum = 10;
            lengthLand = 11;
            makeTileCheck = true;
        }
        //else if (playerInfo.turnPoint == 123)
        //{
        //    enemyMakeLand.Clear();
        //    startNum = 37;
        //    maxnum = 12;
        //    lengthLand = 13;
        //    attackTurn++;
        //    makeTileCheck = true;
        //}
        //else if (playerInfo.turnPoint == 181)
        //{
        //    enemyMakeLand.Clear();
        //    startNum = 19;
        //    maxnum = 14;
        //    lengthLand = 15;
        //    attackTurn++;
        //    makeTileCheck = true;
        //}

        pureStrartnum = startNum;

        if(makeTileCheck)
        {
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
                        tileList[i].GetComponent<AreaManger>().pureTag = "Grass";
                        tileList[i].GetComponent<AreaManger>().pureCode = "Grass";
                        tileList[i].GetComponent<MakeArea>().Movement = true;
                        tileList[i].GetComponent<SpriteRenderer>().sprite = sprites[0];
                        tileList[i].GetComponent<AreaManger>().pureSprite = sprites[0];
                        activeChildtileList.Add(tileList[i].transform.parent);
                        enemyMakeLand.Add(tileList[i].transform.parent);
                    }

                    if (count == lengthLand && playerInfo.turnPoint <= 70)
                    {
                        count = 0;

                        int randint = UnityEngine.Random.Range(1, 4);

                        for (int f = 0; f < randint; f++)
                        {
                            int randomObj = UnityEngine.Random.Range(0, enemyMakeLand.Count);

                            enemyMakeLand[randomObj].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 28");
                            enemyMakeLand[randomObj].GetChild(0).GetComponent<MakeArea>().Movement = false;
                            enemyMakeLand.Remove(enemyMakeLand[randomObj]);
                        }

                        return;
                    }
                }
            }

            makeTileCheck = false;
        }
    }

    private void EnemyGradeSort()
    {
        if (enemyLand.Count != 0)
        {
            for (int i = 0; i < enemyLand.Count; i++)
            {
                if (enemyLand[i].childCount == 0 && enemyLand[i].tag == "Enemy Base")
                {
                    GameObject noChildEnemy = Instantiate(enemyPrefab, new Vector3(enemyLand[i].position.x, enemyLand[i].position.y + 25f), Quaternion.identity);
                    noChildEnemy.transform.SetParent(enemyLand[i]);
                    int enemyrand = UnityEngine.Random.Range(0, 100);

                    switch (enemyLand[i].GetComponent<MakeArea>().Grade)
                    {
                        case 1:
                            noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy1Code[0]);
                            break;
                        case 2:
                            if (enemyrand < 50)
                            {
                                noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy1Code[0]);
                            }
                            else
                            {
                                noChildEnemy.GetComponent<MakeEnemy>().InputEnemyInfo(enemy2Code[0]);
                            }
                            break;
                        case 3:
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

    public void SpawnEnemy()
    {
        List<Transform> noChildLand = enemyMakeLand;

        for (int i=0; i< noChildLand.Count;i++)
        {
            if(noChildLand[i].GetChild(0).childCount !=0)
            {
                noChildLand.RemoveAt(i);
            }
        }

        //디펜스
        if (playerInfo.turnPoint == 9)
        {
            alarmCheck = true;
            defendAlarm.SetActive(true);

            if (enemyLand.Count != 0)
            {
                SceneMgr.GoGameEndScene();
            }
        }
        else if (playerInfo.turnPoint == 25)
        {
            alarmCheck = true;
            defendAlarm.SetActive(true);

            if (enemyLand.Count != 0)
            {
                SceneMgr.GoGameEndScene();
            }
        }
        else if (playerInfo.turnPoint == 41)
        {
            alarmCheck = true;
            defendAlarm.SetActive(true);

            if (enemyLand.Count != 0)
            {
                SceneMgr.GoGameEndScene();
            }
        }
        else if (playerInfo.turnPoint == 61)
        {
            alarmCheck = true;
            defendAlarm.SetActive(true);

            if (enemyLand.Count != 0)
            {
                SceneMgr.GoGameEndScene();
            }
        }
        else if (playerInfo.turnPoint == 81)
        {
            alarmCheck = true;
            defendAlarm.SetActive(true);

            if (enemyLand.Count != 0)
            {
                SceneMgr.GoGameEndScene();
            }
        }

        //어택
        if (3 <= playerInfo.turnPoint && 9 > playerInfo.turnPoint)
        {
            if (attackTurnCheck)
            {
                attackAlarm.SetActive(true);
                alarmCheck = true;
                attackTurn++;
                for (int i = 0; i < attackTurn; i++)
                {
                    int rand = UnityEngine.Random.Range(0, noChildLand.Count - 1);
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 23");
                    enemyLand.Add(noChildLand[rand].GetChild(0));
                    noChildLand.Remove(noChildLand[rand]);
                }
                buttonManger.DestroyCheckArea();
            }

            if(playerInfo.turnPoint ==3)
            {
                EnemyGradeSort();
            }

            attackTurnCheck = false;
        }
        else if (11 <= playerInfo.turnPoint && 25 > playerInfo.turnPoint)
        {
            if (attackTurnCheck)
            {
                attackTurn++;
                attackAlarm.SetActive(true);
                alarmCheck = true;
                for (int i = 0; i < attackTurn; i++)
                {
                    int rand = UnityEngine.Random.Range(0, noChildLand.Count - 1);
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 23");
                    enemyLand.Add(noChildLand[rand].GetChild(0));
                    noChildLand.Remove(noChildLand[rand]);
                }

                buttonManger.DestroyCheckArea();
            }

            if (playerInfo.turnPoint == 11)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 13)
            {
                EnemyGradeSort();
            }

            attackTurnCheck = false;
        }
        else if (26 <= playerInfo.turnPoint && 41 > playerInfo.turnPoint)
        {
            if (attackTurnCheck)
            {
                attackTurn++;
                attackAlarm.SetActive(true);
                alarmCheck = true;
                for (int i = 0; i < attackTurn; i++)
                {
                    int rand = UnityEngine.Random.Range(0, noChildLand.Count - 1);
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 23");
                    enemyLand.Add(noChildLand[rand].GetChild(0));
                    noChildLand.Remove(noChildLand[rand]);
                }

                buttonManger.DestroyCheckArea();
            }

            if (playerInfo.turnPoint == 26)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 28)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 30)
            {
                EnemyGradeSort();
            }

            attackTurnCheck = false;
        }
        else if (42 <= playerInfo.turnPoint && 61 > playerInfo.turnPoint)
        {

            if (attackTurnCheck)
            {
                attackAlarm.SetActive(true);
                alarmCheck = true;
                attackTurn++;

                for (int i = 0; i < attackTurn; i++)
                {
                    int rand = UnityEngine.Random.Range(0, noChildLand.Count - 1);
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 24");
                    enemyLand.Add(noChildLand[rand].GetChild(0));
                    noChildLand.Remove(noChildLand[rand]);
                }

                buttonManger.DestroyCheckArea();
            }

            if (playerInfo.turnPoint == 42)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 44)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 46)
            {
                EnemyGradeSort();
            }

            attackTurnCheck = false;
        }
        else if (62 <= playerInfo.turnPoint && 81 > playerInfo.turnPoint)
        {
            
            if (attackTurnCheck)
            {
                attackTurn++;
                attackAlarm.SetActive(true);
                alarmCheck = true;
                for (int i = 0; i < attackTurn; i++)
                {
                    int rand = UnityEngine.Random.Range(0, noChildLand.Count - 1);
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 24");
                    enemyLand.Add(noChildLand[rand].GetChild(0));
                    noChildLand.Remove(noChildLand[rand]);
                }

                buttonManger.DestroyCheckArea();
            }

            if (playerInfo.turnPoint == 62)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 64)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 66)
            {
                EnemyGradeSort();
            }

            attackTurnCheck = false;
        }
        else if (82 <= playerInfo.turnPoint && 101 > playerInfo.turnPoint)
        {
            if (attackTurnCheck)
            {
                attackTurn++;
                attackAlarm.SetActive(true);
                alarmCheck = true;
                for (int i = 0; i < attackTurn; i++)
                {
                    int rand = UnityEngine.Random.Range(0, noChildLand.Count - 1);
                    noChildLand[rand].GetChild(0).GetComponent<MakeArea>().InputAreaInfo("Area 24");
                    enemyLand.Add(noChildLand[rand].GetChild(0));
                    noChildLand.Remove(noChildLand[rand]);
                }

                buttonManger.DestroyCheckArea();
            }

            if (playerInfo.turnPoint == 82)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 84)
            {
                EnemyGradeSort();
            }
            else if (playerInfo.turnPoint == 86)
            {
                EnemyGradeSort();
            }

            attackTurnCheck = false;
        }
        else
        {
            attackTurnCheck = true;
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

        Enemy.GetComponent<MakeEnemy>().BaseAttack += Enemy.GetComponent<MakeEnemy>().RiseAttack * (randLevel-1);
        Enemy.GetComponent<MakeEnemy>().BaseDefensive += Enemy.GetComponent<MakeEnemy>().RiseDefensive * (randLevel - 1);
        Enemy.GetComponent<MakeEnemy>().BaseHelthPoint += Enemy.GetComponent<MakeEnemy>().RiseHelthPoint * (randLevel - 1);
        Enemy.GetComponent<MakeEnemy>().Level = randLevel;
        Enemy.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = Enemy.GetComponent<MakeEnemy>().Level.ToString();
    }

    public void LoadAllImge()
    {
        object[] loadarea =Resources.LoadAll("Area", typeof(Sprite));
        areaImges = new Sprite[loadarea.Length];

        object[] loadedAreaBeta = Resources.LoadAll("StartArea", typeof(Sprite));
        sprites = new Sprite[loadedAreaBeta.Length];

        object[] loadMonster = Resources.LoadAll("Monster", typeof(GameObject));
        MonsterObj = new GameObject[loadMonster.Length];

        object[] loadEnemy = Resources.LoadAll("Enemy", typeof(GameObject));
        enemyObj = new GameObject[loadEnemy.Length];

        object[] loadBoss = Resources.LoadAll("Boss", typeof(GameObject));
        bossObj = new GameObject[loadBoss.Length];

        object[] loadDestroyArea = Resources.LoadAll("AreaBroken", typeof(Sprite));
        destroyAreaObj = new Sprite[loadDestroyArea.Length];

        for (int i = 0; i < loadarea.Length; i++)
        {
            areaImges[i] = (Sprite)loadarea[i];
        }

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

        for (int i = 0; i < loadDestroyArea.Length; i++)
        {
            destroyAreaObj[i] = (Sprite)loadDestroyArea[i];
        }
    }
}
