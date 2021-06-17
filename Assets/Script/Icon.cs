﻿using System.Collections;
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
        if (inputManger.hitObj.tag == skill.Type)
        {
            card.hitTransform = inputManger.hitObj.transform;
            card.carInfo = skill.Picture;
            card.hitTransform.GetComponent<SoldierManger>().buffIconPrefeb = skill.Picture;
            card.hitTransform.GetComponent<SoldierManger>().buffList.Add(skill.Picture);
            card.FindSkill(transform.name);
            gameObject.SetActive(false);
        }
        else
        {
            transform.position = slot.transform.position;
            transform.SetParent(slot.transform);
            image.raycastTarget = true;
        }
        

        if (deleteCheck)
        {
            gameObject.SetActive(false);
            transform.parent = GameObject.Find("CardPool").transform;
            invenManger.cardCount--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Army")
        {
            armyCheck = true;
        }

        if(collision.transform.tag == "WasteBasket")
        {
            deleteCheck = true;
        }
        
        inputManger.hitObj = collision.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Army")
        {
            armyCheck = false;
        }

        if (collision.transform.tag == "WasteBasket")
        {
            deleteCheck = false;
        }
    }
}