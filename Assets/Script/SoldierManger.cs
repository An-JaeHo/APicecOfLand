using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierManger : MonoBehaviour
{
    private int stayTime;
    private int moveUpPosition;
    private int y;
    private Vector3 movePosition;
    private ButtonManger buttonManger;
    public Animator ani;

    public TileManger tileManger;
    public InputManger input;
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

    float pureattack;
    float puredefend;
    public float totalHp;
    public bool movePoint;
    public int builderPoint;

    void Start()
    {
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        input = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputManger>();
        soldier = GetComponent<MakeSoldier>();
        ani = transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        totalHp = soldier.HelthPoint;
        stayTime = 0;
        move = false;
        movePoint = true;
        capitalPoint = false;

        pureattack = transform.GetComponent<MakeSoldier>().BaseAttack;
        puredefend = transform.GetComponent<MakeSoldier>().Defensive;
        builderPoint = 0;
    }

    public void SoldierAction()
    {
        if (move)
        {
            StartCoroutine(Move());
        }

        if (attack)
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Move()
    {
        movePosition = new Vector3(transform.parent.position.x + 10, transform.parent.position.y + 25, transform.parent.position.z - 10);
        while (transform.position != movePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime * 300f);
            movePoint = false;
            stayTime++;
            buttonManger.button.GetComponent<Button>().interactable = false;
            yield return new WaitForSeconds(0.008f);
        }

        if (transform.position == movePosition)
        {
            input.armyMove = true;
            move = false;
            stayTime = 0;
            buttonManger.button.GetComponent<Button>().interactable = true;
            if (transform.parent.tag == "Enemy Base")
            {
                transform.parent.GetComponent<AreaManger>().TurnArea();
            }
        }

        yield return null;
    }

    IEnumerator Attack()
    {
        if (enemy != null)
        {
            float randnum = Random.Range(0.8f, 1.2f);
            //적이 받는 데미지
            //enemy.GetComponent<MakeEnemy>().HelthPoint -=                (int)((soldier.BaseAttack * randnum) - ((enemy.GetComponent<MakeEnemy>().Defensive)));
            ani.SetTrigger("Attack");
            enemy.GetComponent<EnemyController>().ani.SetTrigger("Damage");
            yield return new WaitForSeconds(1f);
            enemy.GetComponent<MakeEnemy>().BaseHelthPoint = 0;
            attack = false;
            movePoint = false;
            enemy.GetComponent<EnemyController>().Dead();
        }

        HpBarScale();

        yield return null;
    }

    public void HpBarScale()
    {
        //Transform hpBar = transform.GetChild(0).GetChild(0);

        //float nowHp = soldier.HelthPoint / totalHp;
        //hpBar.localScale = new Vector3(nowHp, 1f);
        //hpBar.localScale = new Vector3(nowHp, 1f);
    }

    public void CheckBuildCount()
    {
        if (transform.parent.GetComponent<MakeArea>().BuildTurn != builderPoint
            && transform.parent.GetComponent<MakeArea>().Destroy == true)
        {
            movePoint = false;
            builderPoint++;
        }
        else
        {
            movePoint = true;
            transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
            transform.parent.GetComponent<MakeArea>().Destroy = false;
            builderPoint = 0;
        }
    }

    public void MakeBuffIcon()
    {
        int i = buffList.Count;
        GameObject icon = Instantiate(buffIconGameObj, transform);
        icon.GetComponent<SpriteRenderer>().sortingOrder = transform.GetComponent<SpriteRenderer>().sortingOrder + 1;
        icon.GetComponent<SpriteRenderer>().sprite = buffIconPrefeb;


        icon.transform.position = new Vector3(icon.transform.position.x - 35+((i-1)*25), icon.transform.position.y + 50);
        buffPrefebList.Add(icon);
    }
}
