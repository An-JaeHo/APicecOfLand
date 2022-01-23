using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEnemyManger : MonoBehaviour
{
    private Vector3 movePosition;
    public TutorialButtonManger buttonManger;
    public Animator ani;
    public TutorialTileManger tileManger;
    public TutorialInputManger input;
    public GameObject rangePrefeb;
    public MakeSoldier soldier;
    public List<GameObject> rangeList;
    public Transform enemy;
    public bool move;
    public bool attack;
    public bool capitalPoint;
    public GameObject buffIconGameObj;
    public Sprite buffIconPrefeb;
    public List<Sprite> buffList;
    public List<GameObject> buffPrefebList;
    public int buffCount;
    public GameObject moveTile;
    public Sprite[] destroyAreaObj;

    private void Start()
    {
        ani = transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TutorialTileManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialButtonManger>();
        input = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialInputManger>();
        object[] loadDestroyArea = Resources.LoadAll("AreaBroken", typeof(Sprite));
        destroyAreaObj = new Sprite[loadDestroyArea.Length];
        GetComponent<MakeEnemy>().tutorialCheck = true;

        for (int i = 0; i < loadDestroyArea.Length; i++)
        {
            destroyAreaObj[i] = (Sprite)loadDestroyArea[i];
        }
    }

    private void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime * 100f);

            if (transform.position == movePosition)
            {
                ani.SetBool("Move", false);
                buttonManger.button.GetComponent<Button>().interactable = true;
                transform.parent.GetComponent<AreaManger>().ReturnUpdateSouce();

                transform.parent.GetComponent<MakeArea>().Name = null;
                transform.parent.GetComponent<MakeArea>().Type = "Grass";
                transform.parent.GetComponent<MakeArea>().Grade = 0;
                transform.parent.GetComponent<MakeArea>().UpgradeFlour = 0;
                transform.parent.GetComponent<MakeArea>().UpgradeSugar = 0;
                transform.parent.GetComponent<MakeArea>().MilkOutput = 0;
                transform.parent.GetComponent<MakeArea>().FlourOutput = 0;
                transform.parent.GetComponent<MakeArea>().SugarOutput = 0;
                transform.parent.GetComponent<MakeArea>().Movement = true;
                transform.parent.GetComponent<MakeArea>().Destroy = true;
                transform.parent.GetComponent<MakeArea>().Repair = false;
                transform.parent.GetComponent<MakeArea>().Effect = null;
                transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
                transform.parent.tag = "Grass";

                for (int i = 0; i < destroyAreaObj.Length; i++)
                {
                    if (transform.parent.GetComponent<MakeArea>().Code == destroyAreaObj[i].name)
                    {
                        transform.parent.GetComponent<MakeArea>().Picture = destroyAreaObj[i];
                        transform.parent.GetComponent<SpriteRenderer>().sprite = destroyAreaObj[i];
                        input.talkManger.stopTalkNum = 8;
                        input.talkManger.NextScriptButton();
                    }
                }

                move = false;
            }
        }
    }

    public void SoldierAction()
    {
        move = true;
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialButtonManger>();
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TutorialTileManger>();
        ani = transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        transform.SetParent(moveTile.transform);
        buttonManger.button.GetComponent<Button>().interactable = false;
        ani.SetBool("Move", true);
        movePosition = new Vector3(transform.parent.position.x, transform.parent.position.y + 25, transform.parent.position.z - 10);
        
        yield return null;
    }

    public void HpBarScale()
    {
        if (transform.tag == "Enemy")
        {
            Transform hpBar = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0);
            float nowHp = 0;

            if (nowHp <= 0)
            {
                nowHp = 0;
            }
            hpBar.localScale = new Vector3(nowHp, 1f);
        }
    }
}
