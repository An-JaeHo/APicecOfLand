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

    //카드 생성
    public InvenManger invenManger;

    //공격용
    public Transform target;
    public PlayerInfo playerInfo;
    public float totalHp;
    public MakeEnemy enemy;
    public Animator ani;

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
        enemy = GetComponent<MakeEnemy>();
        totalHp = enemy.BaseHelthPoint;
        finishMove = false;
        findArmy = false;
        ani = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        //HpBarScale();
    }

    public void EnemyMove()
    {
        parentTile = transform.parent;
        tiles = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        int myName = int.Parse(transform.parent.parent.name);

        rangeManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<RangeManger>();
        rangeTiles = rangeManger.EnemyRange(gameObject);
        string code = transform.GetComponent<MakeEnemy>().Code;

        if (parentTile)
        {
            transform.SetParent(parentTile);
        }

        switch (code)
        {
            case "Enemy 1":
                Sword();
                break;
            case "Enemy 2":
                Bow();
                break;
            case "Enemy 3":
                SpearMan();
                break;
            case "Enemy 4":
                CavalryMan();
                break;
        }

        PathFinding();

        for (int i = 0; i < tiles.activeChildtileList.Count; i++)
        {
            //위아래 17 양옆 1
            if(tiles.activeChildtileList[i].GetChild(0).childCount !=0)
            {
                if (tiles.activeChildtileList[i].name == (myName - 17).ToString() || tiles.activeChildtileList[i].name == (myName + 17).ToString()
                || tiles.activeChildtileList[i].name == (myName + 1).ToString() || tiles.activeChildtileList[i].name == (myName + 1).ToString())
                {
                    findArmy = true;
                    target = tiles.activeChildtileList[i].GetChild(0).GetChild(0);
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
                        transform.SetParent(tiles.activeChildtileList[i].GetChild(0));
                    }
                }
                
                parentTile = transform.parent;
                StartCoroutine(Move());
            }
            rangeTiles.Clear();
        }
    }

    #region  상대병력 이동
    private void Sword()
    {
        List<Transform> target = new List<Transform>();
        
        for (int i = 0; i < rangeTiles.Count; i++)
        {
            if (rangeTiles[i].childCount != 0)
            {
                if (rangeTiles[i].GetChild(0).tag == "Monster")
                {
                    //target.Add(rangeTiles[i]);
                    targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y);
                    return;
                }
                
                if (rangeTiles[i].tag == "Capital")
                {
                    //target.Add(rangeTiles[i]);
                    targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y);
                    return;
                }
            }
            else
            {
                if (rangeTiles[i].tag == "Area" || rangeTiles[i].tag == "Barrack")
                {
                    //target.Add(rangeTiles[i]);
                    targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y);
                    return;
                }

                if (rangeTiles[i].tag == "Capital")
                {
                    //target.Add(rangeTiles[i]);
                    targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y);
                    return;
                }
            }
        }

        //Mathf.Abs((int)Vector3.Distance(obj.transform.parent.position, tileInfo.transform.position)

        //int num = Mathf.Abs((int)Vector3.Distance(transform.position, target[0].position));

        //for(int i=0; i< target.Count; i++)
        //{
        //    if (num >= Mathf.Abs((int)Vector3.Distance(transform.position, target[i].position)))
        //    {
        //        num = Mathf.Abs((int)Vector3.Distance(transform.position, target[i].position));
        //        targetPos = new Vector2Int((int)target[i].position.x, (int)target[i].position.y);
        //        //Debug.Log(target[i].name + " " + Mathf.Abs((int)Vector3.Distance(transform.position, target[i].position)));
        //    }
        //}
    }

    private void Bow()
    {
        for (int i = 0; i < rangeTiles.Count; i++)
        {
            if (rangeTiles[i].tag == "Army")
            {
                targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y);
                return;
            }

            if (rangeTiles[i].tag == "Area" || rangeTiles[i].tag == "Barrack")
            {
                targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y);
                return;
            }

            //if (rangeTiles[i].tag == "Area")
            //{

            //}
        }
    }

    private void SpearMan()
    {
        for (int i = 0; i < rangeTiles.Count; i++)
        {
            if (rangeTiles[i].tag == "Army")
            {
                targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y);
                return;
            }

            if (rangeTiles[i].tag == "Area" || rangeTiles[i].tag == "Barrack")
            {
                targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y); 
                return;
            }

            //if (rangeTiles[i].tag == "Area")
            //{

            //}
        }
    }

    private void CavalryMan()
    {
        for (int i = 0; i < rangeTiles.Count; i++)
        {
            if (rangeTiles[i].tag == "Area" || rangeTiles[i].tag == "Barrack")
            {
                targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y);
                return;
            }

            if (rangeTiles[i].tag == "Army")
            {
                targetPos = new Vector2Int((int)rangeTiles[i].position.x, (int)rangeTiles[i].position.y); 
                return;
            }

            //if (rangeTiles[i].tag == "Area")
            //{

            //}
        }
    }
    #endregion


    IEnumerator Move()
    {
        buttonManger.button.GetComponent<Button>().interactable = false;
        Vector3 vector3 = new Vector3(FinalNodeList[1].x, (float)(FinalNodeList[1].y + 30f), -10f);

        while (transform.position != vector3 && !finishMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, vector3, Time.deltaTime * 300f);

            yield return new WaitForSeconds(0.008f);
        }

        yield return new WaitForSeconds(1f);
        buttonManger.button.GetComponent<Button>().interactable = true;
        yield return null;
    }

    IEnumerator Attack()
    {
        buttonManger.button.GetComponent<Button>().interactable = false;
        ani.SetBool("Attack", findArmy);
        float randnum = Random.Range(0.8f, 1.2f);
        target.GetComponent<MakeSoldier>().HelthPoint -= (int)((transform.GetComponent<MakeEnemy>().BaseAttack * randnum) - (target.GetComponent<MakeSoldier>().Defensive));
        target.GetComponent<SoldierManger>().HpBarScale();

        if(target.GetComponent<SoldierManger>().totalHp <=0)
        {
            buttonManger.builders.Remove(target.gameObject);
            Destroy(target.gameObject);
        }
        yield return new WaitForSeconds(1f);
        findArmy = false;
        ani.SetBool("Attack", findArmy);
        buttonManger.button.GetComponent<Button>().interactable = true;
        yield return null;
    }

    public void PathFinding()
    {
        //타일정보를 가져와서 안에 넣는다
        NodeArray = new List<Node>();
        for (int i = 0; i < tiles.activeChildtileList.Count; i++)
        {
            Node tileNode = new Node((int)tiles.activeChildtileList[i].GetChild(0).position.x, (int)tiles.activeChildtileList[i].transform.GetChild(0).position.y);
            NodeArray.Add(tileNode);
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

    public void Dead()
    {
        if (transform.GetComponent<MakeEnemy>().BaseHelthPoint <= 0)
        {
            gameObject.SetActive(false);
            invenManger.InputCard(GetComponent<MakeEnemy>().Grade);
            buttonManger.enemys.Remove(gameObject);
            transform.SetParent(GameObject.Find("ArmyPool").transform);
            playerInfo.killingPoint++;
        }
    }

    //public void HpBarScale()
    //{
    //    Transform hpBar = transform.GetChild(0).GetChild(0);

    //    float nowHp = enemy.HelthPoint / totalHp;
    //    hpBar.localScale = new Vector3(nowHp, 1f);
    //    //hpBar.localScale = new Vector3(nowHp, 1f);
    //}
}



