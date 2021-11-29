using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Node
{
    public Node(int _x, int _y) { x = _x; y = _y; }
    public Node ParentNode;

    // G : 시작으로부터 이동했던 거리, H : |가로|+|세로| 장애물 무시하여 목표까지의 거리, F : G + H
    public int x, y, G, H;
    public int F { get { return G + H; } }
    public bool childCheck;
}

public class EnemyController : MonoBehaviour
{
    // AStar 알고리즘 필요한것
    public RangeManger rangeManger;
    public Vector2Int bottomLeft, topRight, targetPos;
    public List<Node> FinalNodeList;
    public bool dontCrossCorner;
    public ButtonManger buttonManger;
    public TileManger tiles;
    public List<Node> NodeArray;
    Node StartNode, TargetNode;
    public Node CurNode;
    public List<Node> OpenList, ClosedList;

    //타일서칭용
    public List<Transform> rangeTiles;
    private int stayTime;
    public bool finishMove;
    public bool findArmy;
    public Transform parentTile;
    List<Transform> targets;

    //카드 생성
    public InvenManger invenManger;

    //공격용
    public Transform target;
    public PlayerInfo playerInfo;
    public float totalHp;
    public MakeEnemy enemy;
    public GDController gd;
    public Animator ani;
    

    //버프 카운트
    public int buffCount;
    public GameObject buffIconGameObj;
    public Sprite buffIconPrefeb;
    public List<Sprite> buffList;
    public List<GameObject> buffPrefebList;
    public bool movePoint;
    public int pureDefend;
    public bool first;

    public bool move;
    Vector3 targetPostion;

    void Start()
    {
        bottomLeft.x = -150;
        bottomLeft.y = -1950;
        stayTime = 0;
        topRight.x = 1583;
        topRight.y = 150;
        rangeManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<RangeManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        tiles = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        invenManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<InvenManger>();
        playerInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        finishMove = false;
        findArmy = false;
        first = true;
        move = false;

        //HpBarScale();
        movePoint = true;
        ani = transform.GetChild(1).GetChild(0).GetComponent<Animator>();

        if (transform.tag == "Enemy")
        {
            enemy = GetComponent<MakeEnemy>();
            totalHp = enemy.BaseHelthPoint;
            pureDefend = (int)enemy.BaseDefensive;
        }
        else
        {
            gd = GetComponent<GDController>();
            totalHp = gd.HelthPoint;
            pureDefend = (int)gd.Defensive;
        }
    }

    private void Update()
    {
        if (move && !finishMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPostion, Time.deltaTime * 100f);

            if (transform.position == targetPostion)
            {
                move = false;
                tiles.CheckTile();
            }
        }
        else
        {
            ani.SetBool("Move", false);
        }
    }

    public void EnemyMove()
    {
        if (movePoint)
        {
            tiles = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
            rangeManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<RangeManger>();
            parentTile = transform.parent;
            int myName = int.Parse(transform.parent.parent.name);

            if (parentTile)
            {
                transform.SetParent(parentTile);
            }

            Sword();

            PathFinding();

            for (int i = 0; i < tiles.activeChildtileList.Count; i++)
            {
                //위아래 17 양옆 1
                if (tiles.activeChildtileList[i].GetChild(0).childCount != 0)
                {
                    if (tiles.activeChildtileList[i].name == (myName - 17).ToString() || tiles.activeChildtileList[i].name == (myName + 17).ToString()
                        || tiles.activeChildtileList[i].name == (myName - 1).ToString() || tiles.activeChildtileList[i].name == (myName + 1).ToString())
                    {
                        if(tiles.activeChildtileList[i].GetChild(0).GetChild(0).tag =="Army" || tiles.activeChildtileList[i].GetChild(0).GetChild(0).tag == "Builder")
                        {
                            findArmy = true;
                            target = tiles.activeChildtileList[i].GetChild(0).GetChild(0);
                            break;
                        }
                        else
                        {
                            target = null;
                        }
                    }
                }
            }

            if (findArmy)
            {
                StartCoroutine(Attack());
            }
            else
            {
                if (FinalNodeList.Count != 0)
                {
                    for (int i = 0; i < tiles.activeChildtileList.Count; i++)
                    {
                        if (FinalNodeList[1].x == tiles.activeChildtileList[i].GetChild(0).position.x
                            && FinalNodeList[1].y == tiles.activeChildtileList[i].GetChild(0).position.y + 0.5f)
                        {
                            if (int.Parse(transform.parent.parent.name) <= int.Parse(tiles.activeChildtileList[i].name)
                                && Mathf.Abs(int.Parse(transform.parent.parent.name) - int.Parse(tiles.activeChildtileList[i].name)) <= 10)
                            {
                                transform.transform.GetChild(1).localScale = new Vector3(0.4f, 0.4f);
                            }
                            else if (int.Parse(transform.parent.parent.name) > int.Parse(tiles.activeChildtileList[i].name)
                                && Mathf.Abs(int.Parse(transform.parent.parent.name) - int.Parse(tiles.activeChildtileList[i].name)) <= 10)
                            {
                                transform.transform.GetChild(1).localScale = new Vector3(-0.4f, 0.4f);
                            }

                            transform.SetParent(tiles.activeChildtileList[i].GetChild(0));
                        }
                    }

                    parentTile = transform.parent;
                    buttonManger.button.GetComponent<Button>().interactable = false;
                    targetPostion = new Vector3(FinalNodeList[1].x, (float)(FinalNodeList[1].y + 30f), -10f);

                    

                    ani.SetBool("Move", true);
                    move = true;
                    
                }
                rangeTiles.Clear();
            }
        }
        
        first = false;
    }

    #region  상대병력 이동
    private void Sword()
    {
        targets = new List<Transform>();

        for (int i = 0; i < tiles.activeChildtileList.Count; i++)
        {
            if (tiles.activeChildtileList[i].GetChild(0).tag == "Area" || tiles.activeChildtileList[i].GetChild(0).tag == "Barrack")
            {
                targets.Add(tiles.activeChildtileList[i].GetChild(0));
            }

            if (tiles.activeChildtileList[i].GetChild(0).tag == "Capital")
            {
                targets.Add(tiles.activeChildtileList[i].GetChild(0));
            }

        }

        float num = Mathf.Infinity;

        for(int i=0; i< targets.Count; i++)
        {
            if (num > (int)Vector2.Distance(transform.position, targets[i].position))
            {
                num = (int)Vector2.Distance(transform.position, targets[i].position);
                targetPos = new Vector2Int((int)targets[i].position.x, (int)targets[i].position.y);
            }
        }
    }
    #endregion


    

    IEnumerator Attack()
    {
        float randnum = Random.Range(0.8f, 1.2f);
        buttonManger.button.GetComponent<Button>().interactable = false;

        //AenemyhelthPoint – (((Atack_sum/Defend_sum)*30)*치명타대미지))
        //
        //공격자: (BaseAttack + (RiseAttack * Level)) = Atack_sum
        //
        //방어자: ((BaseDefend + (RiseDefend * Level)) = Defend_sum
        //
        //치명타 대미지:(치명타 확률)> (Atack_sum * (0.7~11))

        float randCritical = Random.Range(0.7f, 1.1f);

        float defendSum = target.GetComponent<MakeSoldier>().Defensive + (target.GetComponent<MakeSoldier>().RiseDefensive * target.GetComponent<MakeSoldier>().Level);

        if (target != null)
        {
            if (int.Parse(transform.parent.parent.name) <= int.Parse(target.parent.parent.name)
            && Mathf.Abs(int.Parse(transform.parent.parent.name) - int.Parse(target.parent.parent.name)) <= 10)
            {
                transform.transform.GetChild(1).localScale = new Vector3(0.4f, 0.4f);
            }
            else if (int.Parse(transform.parent.parent.name) > int.Parse(target.parent.parent.name)
                && Mathf.Abs(int.Parse(transform.parent.parent.name) - int.Parse(target.parent.parent.name)) <= 10)
            {
                transform.transform.GetChild(1).localScale = new Vector3(-0.4f, 0.4f);
            }


            if (transform.tag == "Enemy")
            {
                float attackSum = enemy.BaseAttack + (enemy.RiseAttack * enemy.Level);
                target.GetComponent<MakeSoldier>().HelthPoint -= (int)((((attackSum / defendSum) * 30)));

                if (target.GetComponent<SoldierManger>().countAttack > 0)
                {
                    transform.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)(target.GetComponent<MakeSoldier>().BaseAttack * target.GetComponent<SoldierManger>().countAttack);
                    target.GetComponent<SoldierManger>().countAttack = 0;
                }
            }
            else
            {
                float attackSum = gd.BaseAttack + (gd.RiseAttack * 1);
                target.GetComponent<MakeSoldier>().HelthPoint -= (int)((((attackSum / defendSum) * 30)));

                if (target.GetComponent<SoldierManger>().countAttack > 0)
                {
                    transform.GetComponent<GDController>().HelthPoint -= (int)((target.GetComponent<MakeSoldier>().BaseAttack) * target.GetComponent<SoldierManger>().countAttack);
                    target.GetComponent<SoldierManger>().countAttack = 0;
                }
            }

            target.GetComponent<SoldierManger>().HpBarScale();
            ani.SetTrigger("Attack");

            if (transform.tag == "Enemy")
            {
                for (int i = 0; i < SoundController.instance.enemySounds.Length; i++)
                {
                    if (SoundController.instance.enemySounds[i].name == transform.GetComponent<MakeEnemy>().Code)
                    {
                        AudioClip audio = SoundController.instance.enemySounds[i].audio;
                        transform.GetComponent<AudioSource>().clip = audio;
                        transform.GetComponent<AudioSource>().Play();
                    }
                }
            }
            yield return new WaitForSeconds(0.8f);

            if (target.GetComponent<MakeSoldier>().HelthPoint <= 0)
            {
                target.GetComponent<SoldierManger>().ani.SetBool("Dead",true);
                buttonManger.amrys.Remove(target.gameObject);
            }
            else
            {
                target.GetComponent<SoldierManger>().ani.SetTrigger("Damage");
            }
        }

        findArmy = false;
        tiles.CheckTile();
        yield return null;
    }

    public void PathFinding()
    {
        //타일정보를 가져와서 안에 넣는다
        NodeArray = new List<Node>();
        for (int i = 0; i < tiles.activeChildtileList.Count; i++)
        {
            if (tiles.activeChildtileList[i].transform.GetChild(0).childCount ==0)
            {
                Node tileNode = new Node((int)tiles.activeChildtileList[i].GetChild(0).position.x, (int)tiles.activeChildtileList[i].transform.GetChild(0).position.y);
                NodeArray.Add(tileNode);
            }
            else
            {
                if (tiles.activeChildtileList[i].transform.GetChild(0).GetChild(0).tag != "Enemy" && tiles.activeChildtileList[i].transform.GetChild(0).GetChild(0).tag != "GD")
                {
                    Node tileNode = new Node((int)tiles.activeChildtileList[i].GetChild(0).position.x, (int)tiles.activeChildtileList[i].transform.GetChild(0).position.y);
                    NodeArray.Add(tileNode);
                }
            }
        }
        
        // 시작과 끝 노드, 열린리스트와 닫힌리스트, 마지막리스트 초기화
        StartNode = new Node((int)transform.parent.position.x, (int)transform.parent.position.y);
        TargetNode = new Node(targetPos.x, targetPos.y);
        OpenList = new List<Node>() { StartNode };
        ClosedList = new List<Node>();
        FinalNodeList = new List<Node>();

        while (OpenList.Count > 0)
        {
            // 열린리스트 중 가장 F가 작고 F가 같다면 H가 작은 걸 현재노드로 하고 열린리스트에서 닫힌리스트로 옮기기
            CurNode = OpenList[0];

            for (int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].F <= CurNode.F && OpenList[i].H < CurNode.H)
                    CurNode = OpenList[i];

            }

            OpenList.Remove(CurNode);
            ClosedList.Add(CurNode);

            //TargetNode : 533, -900
            //Debug.Log("CurNode.x : "+CurNode.x);

            //Debug.Log("TargetNode.x : " + TargetNode.x + "  TargetNode.y : " + TargetNode.y);
            // 마지막
            if (CurNode.x == TargetNode.x && CurNode.y == TargetNode.y)
            {
                //Debug.Log("CurNode.x : " + CurNode.x + "  CurNode.y : " + CurNode.y);
                TargetNode.ParentNode = CurNode.ParentNode;
                Node TargetCurNode = TargetNode;
                
                if (TargetCurNode.ParentNode != null)
                {
                    while (TargetCurNode != StartNode)
                    {
                        FinalNodeList.Add(TargetCurNode);
                        TargetCurNode = TargetCurNode.ParentNode;
                    }
                    
                    FinalNodeList.Add(StartNode);
                    FinalNodeList.Reverse();
                }

                
                
                return;
            }
            // ↑ → ↓ ←
            // 이것도 위치에 따라 바꾸자
            for (int a = 0; a < NodeArray.Count; a++)
            {
                if (NodeArray[a].x == CurNode.x && NodeArray[a].y == CurNode.y + 87)
                {
                    OpenListAdd(CurNode.x, CurNode.y + 87, NodeArray[a]);
                }

                if (NodeArray[a].x == CurNode.x + 87 && NodeArray[a].y == CurNode.y)
                {
                    OpenListAdd(CurNode.x + 87, CurNode.y, NodeArray[a]);
                }

                if (NodeArray[a].x == CurNode.x && NodeArray[a].y == CurNode.y - 87)
                {
                    OpenListAdd(CurNode.x, CurNode.y - 87, NodeArray[a]);
                }

                if (NodeArray[a].x == CurNode.x - 87 && NodeArray[a].y == CurNode.y)
                {
                    OpenListAdd(CurNode.x - 87, CurNode.y, NodeArray[a]);
                }
            }
        }
    }

    void OpenListAdd(int checkX, int checkY, Node node)
    {
        //&& ClosedList.Contains(node)
        // 상하좌우 범위를 벗어나지 않고, 벽이 아니면서, 닫힌리스트에 없다면
        if (checkX >= bottomLeft.x && checkX < topRight.x + 87 && checkY >= bottomLeft.y && checkY < topRight.y + 87 && !ClosedList.Contains(node))
        {
            for (int i = 0; i < tiles.activeChildtileList.Count; i++)
            {
                if (tiles.activeChildtileList[i].GetChild(0).childCount == 0 )
                {
                    //tiles.activeChildtileList[i].GetChild(0).GetChild(0).tag != "Builder"
                    //if (node.x == tiles.activeChildtileList[i].transform.position.x && node.y == tiles.activeChildtileList[i].transform.position.y)
                    //{
                    //    return;
                    //}

                    //if (tiles.activeChildtileList[i].GetChild(0).GetChild(0).tag == "Enemy" 
                    //    && node.x == tiles.activeChildtileList[i].GetChild(0).transform.position.x 
                    //    && node.y == tiles.activeChildtileList[i].GetChild(0).transform.position.y)
                    //{
                    //    return;
                    //}
                    Node NeighborNode = node;
                    int MoveCost = CurNode.G + (CurNode.x - checkX == 0 || CurNode.y - checkY == 0 ? 100 : 140);
                    // 이동비용이 이웃노드G보다 작거나 또는 열린리스트에 이웃노드가 없다면 G, H, ParentNode를 설정 후 열린리스트에 추가
                    if (MoveCost < NeighborNode.G || !OpenList.Contains(NeighborNode))
                    {
                        NeighborNode.G = MoveCost;
                        NeighborNode.H = (Mathf.Abs(NeighborNode.x - TargetNode.x) + Mathf.Abs(NeighborNode.y - TargetNode.y)) * 10;
                        NeighborNode.ParentNode = CurNode;
                        OpenList.Add(NeighborNode);
                    }
                }
            }

            // 코너를 가로질러 가지 않을시, 이동 중에 수직수평 장애물이 있으면 안됨
            //if (dontCrossCorner) if (NodeArray[CurNode.x - bottomLeft.x, checkY - bottomLeft.y].isWall || NodeArray[checkX - bottomLeft.x, CurNode.y - bottomLeft.y].isWall) return;
            // 이웃노드에 넣고, 직선은 10, 대각선은 14비용
        }
    }

    public void HpBarScale()
    {
        if(transform.tag == "Enemy")
        {
            Transform hpBar = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0);
            float nowHp = enemy.BaseHelthPoint / totalHp;

            if (nowHp <= 0)
            {
                nowHp = 0;
            }
            hpBar.localScale = new Vector3(nowHp, 1f);
        }
        else
        {
            Transform hpBar = tiles.bossHP.transform.GetChild(1).GetChild(0);
            float nowHp = transform.GetComponent<GDController>().HelthPoint / totalHp;

            if (nowHp <= 0)
            {
                nowHp = 0;
            }
            hpBar.localScale = new Vector3(nowHp, 1f);

            tiles.bossHP.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = ((int)(nowHp * 100)).ToString()+"%";
        }
    }

    public void MakeBuffIcon(string code)
    {
        int i = buffPrefebList.Count;
        GameObject icon = Instantiate(buffIconGameObj, transform);
        icon.GetComponent<InputSkill>().MakeCard(code);
        icon.GetComponent<SpriteRenderer>().sortingOrder = transform.GetComponent<SpriteRenderer>().sortingOrder + 1;
        icon.GetComponent<SpriteRenderer>().sprite = icon.GetComponent<InputSkill>().Picture;

        icon.transform.position = new Vector3(icon.transform.position.x - 10 + ((i - 1) * 25), icon.transform.position.y + 20);
        buffPrefebList.Add(icon);
    }

    public void CheckBuff()
    {
        for (int i = 0; i < buffPrefebList.Count; i++)
        {
            if (buffPrefebList[i].GetComponent<InputSkill>().Turn != 0)
            {
                switch (buffPrefebList[i].GetComponent<InputSkill>().Code)
                {
                    case "Card 33":
                        movePoint = false;
                        break;
                    case "Card 34":
                        movePoint = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}



