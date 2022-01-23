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
    public TutorialInputManger tutorialInputManger;
    public InputSkill skill;
    public CardList card;
    public GameObject skillInven;
    public InvenManger invenManger;
    public GameObject cardImpactObj;
    private bool armyCheck;
    private bool deleteCheck;

    public bool tutorialCheck;

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
        if(tutorialCheck)
        {
            tutorialInputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TutorialInputManger>();
        }
        else
        {
            inputManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputManger>();
        }
        
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

        if (tutorialCheck)
        {
            tutorialInputManger.mouseCheck = false;
            card.tutorialCheck = tutorialCheck;
        }
        else
        {
            inputManger.mouseCheck = false;
        }
        
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
            if (tutorialCheck)
            {
                if (tutorialInputManger.hitObj.tag == skill.Type)
                {
                    if (tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList.Count != 0)
                    {
                        for (int i = 0; i < tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList.Count; i++)
                        {
                            if (tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList[i].GetComponent<InputSkill>().Name == skill.Name
                                && tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList[i].GetComponent<InputSkill>().Grade <= skill.Grade)
                            {
                                tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList[i].GetComponent<InputSkill>().card.RemoveCardEffect(tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList[i].GetComponent<InputSkill>().Code);
                                Destroy(tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList[i]);
                                tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList.Remove(tutorialInputManger.hitObj.GetComponent<TutorialSoldierManger>().buffPrefebList[i]);
                            }
                        }
                    }

                    card.carInfo = skill.Picture;
                    GameObject cardImpact = Instantiate(cardImpactObj, tutorialInputManger.hitObj);
                    cardImpact.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = card.carInfo;
                    cardImpact.transform.localPosition = new Vector3(-0.7f, 0);
                    cardImpact.transform.localScale = new Vector3(0.5f, 0.5f);
                    cardImpact.SetActive(true);
                    card.FindCard(skill.Code);

                    if (skill.Stack > 1)
                    {
                        transform.position = slot.transform.position;
                        transform.SetParent(slot.transform);
                        image.raycastTarget = true;
                        skill.Stack--;
                        transform.GetChild(0).GetComponent<Text>().text = skill.Stack.ToString();
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    
                }
                else
                {
                    transform.position = slot.transform.position;
                    transform.SetParent(slot.transform);
                    image.raycastTarget = true;
                    SystemMessgeController.SystemMessge("skill");
                }

                tutorialInputManger.mouseCheck = true;
            }
            else
            {
                if (inputManger.hitObj.tag == skill.Type)
                {
                    if (inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList.Count != 0)
                    {
                        for (int i = 0; i < inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList.Count; i++)
                        {
                            if (inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList[i].GetComponent<InputSkill>().Name == skill.Name
                                && inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList[i].GetComponent<InputSkill>().Grade <= skill.Grade)
                            {
                                inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList[i].GetComponent<InputSkill>().card.RemoveCardEffect(inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList[i].GetComponent<InputSkill>().Code);
                                Destroy(inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList[i]);
                                inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList.Remove(inputManger.hitObj.GetComponent<SoldierManger>().buffPrefebList[i]);
                            }
                        }
                    }

                    card.carInfo = skill.Picture;
                    
                    GameObject cardImpact = Instantiate(cardImpactObj, inputManger.hitObj);
                    cardImpact.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = card.carInfo;
                    cardImpact.transform.localPosition = new Vector3(-0.7f, 0);
                    cardImpact.transform.localScale = new Vector3(0.5f, 0.5f);
                    cardImpact.SetActive(true);
                    card.FindCard(skill.Code);

                    if (skill.Stack > 1)
                    {
                        transform.position = slot.transform.position;
                        transform.SetParent(slot.transform);
                        image.raycastTarget = true;
                        skill.Stack--;
                        transform.GetChild(0).GetComponent<Text>().text = skill.Stack.ToString();
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    inputManger.hitObj.GetComponent<SoldierManger>().AttachCountNumCheck();
                }
                else
                {
                    transform.position = slot.transform.position;
                    transform.SetParent(slot.transform);
                    image.raycastTarget = true;
                    SystemMessgeController.SystemMessge("skill");
                }

                inputManger.mouseCheck = true;
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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

        if (tutorialCheck)
        {
            tutorialInputManger.hitObj = collision.transform;
        }
        else
        {
            inputManger.hitObj = collision.transform;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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
