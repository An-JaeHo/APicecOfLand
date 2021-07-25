using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Icon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Slot slot;
    public Image image;
    public InputManger inputManger;
    public InputSkill skill;
    public CardList card;
    public GameObject skillInven;
    public InvenManger invenManger;
    private bool armyCheck;
    private bool deleteCheck;

    void Awake()
    {
        image = GetComponent<Image>();
        armyCheck = false;
        skillInven = GameObject.Find("SkillInven");
        
        invenManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<InvenManger>();
    }

    void Start()
    {
        slot = transform.parent.GetComponent<Slot>();
        slot.icon = this;
        inputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputManger>();
        skill = GetComponent<InputSkill>();
        card = GameObject.FindGameObjectWithTag("GameController").GetComponent<CardList>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.parent.parent.parent);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("마우스 위치 : " + Input.mousePosition + "카드 위치 : " + transform.position);
        transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
        //transform.position = new Vector3(Camera.main.ScreenToWorldPoint(eventData.position).x, Camera.main.ScreenToWorldPoint(eventData.position).y, 10);

        //마우스의 위치는 카메라의 위치에있다 그러니
        //마우스의 위치의 z값을 충돌할위치의 z값과 같은 선상에 맞추어서 해야 크기도 맞고 좋게보인다

        Vector3 p = Input.mousePosition;
        p.z = 800;
        Vector3 pos = Camera.main.ScreenToWorldPoint(p);
        transform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (deleteCheck)
        {
            invenManger.cardCount--;
            Destroy(gameObject);
        }
        else
        {
            if (inputManger.hitObj.tag == skill.Type)
            {
                card.carInfo = skill.Picture;
                card.FindCard(skill.Code);
                gameObject.SetActive(false);
            }
            else
            {
                transform.position = slot.transform.position;
                transform.SetParent(slot.transform);
                image.raycastTarget = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);

        if (collision.transform.tag == "Army")
        {
            card.SoldierPrefeb = collision.gameObject;

            if (collision.transform.parent.tag == "Capital")
            {
                card.AreaPrefeb = collision.transform.parent.gameObject;
            }
        }
        else if(collision.transform.tag == "Enemy")
        {
            card.EnemyPrefeb = collision.gameObject;
        }
        else if(collision.transform.tag == "Capital")
        {
            card.AreaPrefeb = collision.gameObject;
        }

        if (collision.transform.tag == "WasteBasket")
        {
            deleteCheck = true;
        }
        else
        {
            armyCheck = true;
        }

        inputManger.hitObj = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Army")
        {
            card.SoldierPrefeb = null;

            if (collision.transform.parent.tag == "Capital")
            {
                card.AreaPrefeb = null;
            }
        }
        else if (collision.transform.tag == "Enemy")
        {
            card.EnemyPrefeb = null;
        }
        else if (collision.transform.tag == "Capital")
        {
            card.AreaPrefeb = null;
        }

        if (collision.transform.tag == "WasteBasket")
        {
            deleteCheck = false;
        }
        else
        {
            deleteCheck = false;
        }
    }
}
