using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusCardController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject supplyObj;
    public Image bonusImgae;
    public Text bonusText;
    public Animator animator;
    public addMobManger addmobManger;

    [Header("Set in Code")]
    public GameEndController gameEndController;

    [Header("Bonus Card Composition")]
    public Sprite[] bonusImgaes;
    public GameObject cardBack;
    public GameObject cardFront;
    public Sprite BonusImage;
    public Sprite noBonusImage;
    public bool addCheck;

    [Space(10f)]
    public int milk;
    public int flour;
    public int sugar;
    private bool buttonCheck;

    private bool supplyCheck;
    private int pureMilkSupply;
    private int pureFlourSupply;
    private int pureSugarSupply;
    private int sumMilkSupply;
    private int sumFlourSupply;
    private int sumSugarSupply;
    private float times;

    private void Start()
    {
        buttonCheck = false;
        gameEndController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameEndController>();
    }

    private void Update()
    {
        if (supplyCheck)
        {
            times += Time.deltaTime;

            gameEndController.supply.transform.GetChild(0).GetChild(0).GetComponent<Text>().text 
                = ((int)Mathf.Lerp(pureMilkSupply, sumMilkSupply, times / 3)).ToString();
            gameEndController.supply.transform.GetChild(1).GetChild(0).GetComponent<Text>().text 
                = ((int)Mathf.Lerp(pureSugarSupply, sumSugarSupply, times / 3)).ToString();
            gameEndController.supply.transform.GetChild(2).GetChild(0).GetComponent<Text>().text 
                = ((int)Mathf.Lerp(pureFlourSupply, sumFlourSupply, times / 3)).ToString();

            if (times / 3 >= 1)
            {
                gameEndController.saveMgr.playerSave.milk = sumMilkSupply;
                gameEndController.saveMgr.playerSave.sugar = sumSugarSupply;
                gameEndController.saveMgr.playerSave.flour = sumFlourSupply;
                supplyCheck = false;
            }
        }
        else
        {
            times = 0;
        }
    }

    public void RandomSupply()
    {
        int supplyRand = Random.Range(0, 3);
        int rand = Random.Range(30, 101);

        milk = 0;
        flour = 0;
        sugar = 0;

        if (supplyRand ==0)
        {
            milk = rand;
            bonusImgae.sprite = bonusImgaes[0];
            bonusText.text =milk.ToString();
        }
        else if (supplyRand == 1)
        {
            sugar = rand;
            bonusImgae.sprite = bonusImgaes[2];
            bonusText.text = sugar.ToString();
        }
        else
        {
            flour = rand;
            bonusImgae.sprite = bonusImgaes[1];
            bonusText.text = flour.ToString();
        }
    }

    public void ChoseCard()
    {
        buttonCheck = true;
        animator.SetTrigger("Flip");
        cardFront.gameObject.SetActive(true);
        addmobManger.bonusCard = gameObject;
        gameEndController.addButton.GetComponent<Button>().interactable = true;

        pureMilkSupply = gameEndController.saveMgr.playerSave.milk;
        pureSugarSupply = gameEndController.saveMgr.playerSave.sugar;
        pureFlourSupply = gameEndController.saveMgr.playerSave.flour;

        sumMilkSupply = gameEndController.saveMgr.playerSave.milk + milk;
        sumSugarSupply = gameEndController.saveMgr.playerSave.sugar + sugar;
        sumFlourSupply = gameEndController.saveMgr.playerSave.flour +flour;
        
        for (int i = 0; i < gameEndController.bonuses.Length; i++)
        {
            gameEndController.bonuses[i].GetComponent<BonusCardController>().cardBack.GetComponent<Button>().interactable = false;
            gameEndController.bonuses[i].transform.GetChild(1).GetComponent<Button>().interactable = false;
        }

        supplyCheck = true;
    }
}
