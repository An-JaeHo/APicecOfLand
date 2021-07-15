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
    public int buffCount;

    float pureattack;
    float puredefend;
    float pureMoveRange;
    public float totalHp;
    public bool movePoint;
    public bool cardMovePoint;
    public int builderPoint;
    public float countAttack;

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
        cardMovePoint = false;
        capitalPoint = false;
        countAttack = 0;

        pureattack = transform.GetComponent<MakeSoldier>().BaseAttack;
        puredefend = transform.GetComponent<MakeSoldier>().Defensive;
        pureMoveRange = transform.GetComponent<MakeSoldier>().Movement;
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
        movePosition = new Vector3(transform.parent.position.x, transform.parent.position.y + 25, transform.parent.position.z - 10);
        ani.SetBool("Move", true);
        

        while (transform.position != movePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime * 300f);
            movePoint = false;
            stayTime++;
            buttonManger.button.GetComponent<Button>().interactable = false;
            yield return new WaitForSeconds(0.01f);
        }

        if (transform.position == movePosition)
        {
            input.armyMove = true;
            move = false;
            stayTime = 0;
            ani.SetBool("Move", false);

            if (transform.tag == "Builder")
            {
                transform.GetComponent<AudioSource>().clip = SoundController.instance.buildSounds[0].audio;
                transform.GetComponent<AudioSource>().Play();
                //yield return new WaitForSeconds(0.5f);
            }

            if (transform.parent.GetComponent<MakeArea>().Name == "우주선")
            {
                transform.GetComponent<AudioSource>().clip = SoundController.instance.buildSounds[2].audio;
                transform.GetComponent<AudioSource>().Play();
                transform.parent.GetComponent<AreaManger>().TurnArea();
                transform.parent.GetComponent<MakeArea>().Name = "Grass";
            }
        }

        
        if (cardMovePoint)
        {
            movePoint = true;
            cardMovePoint = false;
        }
        buttonManger.button.GetComponent<Button>().interactable = true;
        tileManger.CheckTile();
        yield return null;
    }

    IEnumerator Attack()
    {
        buttonManger.button.GetComponent<Button>().interactable = false;
        if (enemy != null)
        {
            float randnum = Random.Range(0.8f, 1.2f);
            //적이 받는 데미지
            if(enemy.tag == "Enemy")
            {
                enemy.GetComponent<MakeEnemy>().BaseHelthPoint -= (int)(soldier.BaseAttack * 10);
            }
            else
            {
                enemy.GetComponent<GDController>().HelthPoint-= (int)(soldier.BaseAttack * 10);
            }
            
            ani.SetTrigger("Attack");

            for (int i = 0; i < SoundController.instance.monsterSounds.Length; i++)
            {
                if(SoundController.instance.monsterSounds[i].name == transform.GetComponent<MakeSoldier>().Name)
                {
                    AudioClip audio = SoundController.instance.monsterSounds[i].audio;
                    transform.GetComponent<AudioSource>().clip = audio;
                    transform.GetComponent<AudioSource>().Play();
                }
            }
            yield return new WaitForSeconds(0.5f);
            enemy.GetComponent<EnemyController>().ani.SetTrigger("Damage");
            attack = false;
            movePoint = false;
            enemy.GetComponent<EnemyController>().Dead(transform);
            enemy.GetComponent<EnemyController>().HpBarScale();
        }

        if (cardMovePoint)
        {
            movePoint = true;
            cardMovePoint = false;
        }

        buttonManger.button.GetComponent<Button>().interactable = true;
        tileManger.CheckTile();
        yield return null;
    }

    public void HpBarScale()
    {
        Transform hpBar = transform.GetChild(0).GetChild(0);

        float nowHp = soldier.HelthPoint / totalHp;
        if(nowHp <=0)
        {
            nowHp = 0;
        }

        hpBar.localScale = new Vector3(nowHp, 1f);

    }

    public void Dead()
    {
        if (transform.GetComponent<MakeSoldier>().HelthPoint <= 0)
        {
            if(transform.tag == "Army")
            {
                buttonManger.amrys.Remove(gameObject);
                input.BarrackUi.GetComponent<BarrackController>().usingPeople--;
                input.BarrackUi.GetComponent<BarrackController>().supplyManger.updateFood +=  soldier.ConsumeFood;
                input.BarrackUi.GetComponent<BarrackController>().supplyManger.JustUpdateSupply();
                Destroy(this.gameObject);
            }
            else
            {
                tileManger.DeadBulider(gameObject);
            }
        }
    }

    public void CheckBuildCount()
    {
        if (transform.parent.GetComponent<MakeArea>().BuildTurn != builderPoint
            && transform.parent.GetComponent<MakeArea>().firstBuild == true)
        {
            movePoint = false;
            builderPoint++;
        }
        else
        {
            movePoint = true;
            transform.parent.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<MakeArea>().Picture;
            transform.parent.GetComponent<MakeArea>().Destroy = false;
            transform.parent.GetComponent<MakeArea>().firstBuild = false;

            if (transform.parent.GetComponent<MakeArea>().BuildTurn == builderPoint
            && !transform.parent.GetComponent<MakeArea>().Destroy)
            {
                transform.parent.GetComponent<AreaManger>().CheckUpdateMaterial();
            }

            builderPoint = 0;
        }

        
    }

    public void MakeBuffIcon(string code)
    {
        int i = buffPrefebList.Count;
        GameObject icon = Instantiate(buffIconGameObj, transform);
        icon.GetComponent<InputSkill>().MakeCard(code);
        icon.GetComponent<SpriteRenderer>().sortingOrder = transform.GetComponent<SpriteRenderer>().sortingOrder + 1;
        icon.GetComponent<SpriteRenderer>().sprite = icon.GetComponent<InputSkill>().Picture;
        buffCount = icon.GetComponent<InputSkill>().Turn;

        icon.transform.position = new Vector3(icon.transform.position.x - 10+((i-1)*25), icon.transform.position.y + 20);
        buffPrefebList.Add(icon);
    }

    public void ReturnPure()
    {
        soldier.BaseAttack = pureattack;
        soldier.Defensive = puredefend;
        soldier.Movement = (int)pureMoveRange;
    }

    public void CheckBuff()
    {
        for (int i = 0; i < buffPrefebList.Count; i++)
        {
            if(buffPrefebList[i].GetComponent<InputSkill>().Turn!= 0)
            {
                switch (buffPrefebList[i].GetComponent<InputSkill>().Code)
                {
                    case "Card 10":
                        soldier.Movement++;
                        break;
                    case "Card 11":
                        soldier.Movement++;
                        break;
                    case "Card 22":
                        cardMovePoint = true;
                        break;
                    case "Card 23":
                        cardMovePoint = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void LevelCheck()
    {
        if(transform.GetComponent<MakeSoldier>().exp >10)
        {
            transform.GetComponent<MakeSoldier>().Level++;
            transform.GetComponent<MakeSoldier>().BaseAttack += transform.GetComponent<MakeSoldier>().RiseAttack;
            transform.GetComponent<MakeSoldier>().Critical += transform.GetComponent<MakeSoldier>().RiseCritical;
            transform.GetComponent<MakeSoldier>().Defensive += transform.GetComponent<MakeSoldier>().RiseDefensive;
        }
    }
}
