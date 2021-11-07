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

    private void Start()
    {
        ani = transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TutorialTileManger>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialButtonManger>();
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

                move = false;
            }
        }
    }

    public void SoldierAction()
    {
        if (move)
        {
            StartCoroutine(Move());
        }
    }

    public IEnumerator Move()
    {
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialButtonManger>();
        tileManger = GameObject.FindGameObjectWithTag("Tile").GetComponent<TutorialTileManger>();
        ani = transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        transform.SetParent(tileManger.tileList[1].GetChild(0));
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
