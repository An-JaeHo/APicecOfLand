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
    [Header("Set in Code")]
    public GameEndController gameEndController;

    [Header("Bonus Card Composition")]
    public Sprite[] bonusImgaes;
    public GameObject cardBack;
    public GameObject cardFront;
    public Sprite BonusImage;
    public Sprite noBonusImage;

    [Space(10f)]
    public int milk;
    public int flour;
    public int sugar;
    private bool buttonCheck;

    private void Start()
    {
        buttonCheck = false;
        gameEndController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameEndController>();
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

        gameEndController.saveMgr.playerSave.milk += milk;
        gameEndController.saveMgr.playerSave.sugar += sugar;
        gameEndController.saveMgr.playerSave.flour += flour;

        for (int i = 0; i < gameEndController.bonuses.Length; i++)
        {
            gameEndController.bonuses[i].GetComponent<BonusCardController>().cardBack.GetComponent<Button>().enabled = false;
        }
    }
}
