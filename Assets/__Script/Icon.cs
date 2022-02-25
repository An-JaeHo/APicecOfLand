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
    
    private bool deleteCheck;

    public bool tutorialCheck;
    public bool tutorialMoveCheck;

    void Awake()
    {
        image = GetComponent<Image>();
        skillInven = GameObject.Find("SkillInven");
        invenManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<InvenManger>();
        tutorialMoveCheck = false;
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
        if (tutorialCheck)
        {
            if (tutorialMoveCheck)
            {
                transform.SetParent(transform.parent.parent.parent);
                image.raycastTarget = false;
            }
        }
        else
        {
            transform.SetParent(transform.parent.parent.parent);
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (tutorialCheck)
        {
            if (tutorialMoveCheck)
            {
                transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
                tutorialInputManger.mouseCheck = false;
                card.tutorialCheck = tutorialCheck;

                Vector3 p = Input.mousePosition;
                p.z = 800;
                Vector3 pos = Camera.main.ScreenToWorldPoint(p);
                transform.position = pos;
            }
        }
        else
        {
            transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
            Vector3 p = Input.mousePosition;
            p.z = 800;
            Vector3 pos = Camera.main.ScreenToWorldPoint(p);
            transform.position = pos;
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
                if (tutorialMoveCheck)
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
            }
            else
            {
                if (inputManger.hitObj.tag == skill.Type)
                {
                    if (inputManger.hitObj.tag != "Capital")
                    {
                        if (inputManger.hitObj.tag == "Enemy")
                        {
                            for (int i = 0; i < inputManger.hitObj.GetComponent<EnemyController>().buffPrefebList.Count; i++)
                            {
                                if (inputManger.hitObj.GetComponent<EnemyController>().buffPrefebList[i].GetComponent<InputSkill>().Name == skill.Name
                                    && inputManger.hitObj.GetComponent<EnemyController>().buffPrefebList[i].GetComponent<InputSkill>().Grade <= skill.Grade)
                                {
                                    inputManger.hitObj.GetComponent<EnemyController>().buffPrefebList[i].GetComponent<InputSkill>().card.RemoveCardEffect(inputManger.hitObj.GetComponent<EnemyController>().buffPrefebList[i].GetComponent<InputSkill>().Code);
                                    Destroy(inputManger.hitObj.GetComponent<EnemyController>().buffPrefebList[i]);
                                    inputManger.hitObj.GetComponent<EnemyController>().buffPrefebList.Remove(inputManger.hitObj.GetComponent<EnemyController>().buffPrefebList[i]);
                                }
                            }
                        }
                        else
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

                                inputManger.hitObj.GetComponent<SoldierManger>().AttachCountNumCheck();
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

        invenManger.CardNameCheck();
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
    }
}
