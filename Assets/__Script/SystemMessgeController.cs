using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMessgeController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject systemmessge;
    static public SupplyManger supplyManger;
    static public TileManger tileManger;
    static public InvenManger invenManger;
    static public GameObject systemaMessgeBar;

    [Header("Set in ViualStudio")]
    static private float timer;
    static private bool messgeCheck;

    private void Start()
    {
        messgeCheck = false;
        systemaMessgeBar = systemmessge;
        timer = 0f;
    }

    private void Update()
    {
        if (messgeCheck)
        {
            timer += Time.deltaTime;
            
            systemaMessgeBar.SetActive(true);

            if(timer>=5)
            {
                float colorA = ((timer - 5) / 5) * 255;
                systemaMessgeBar.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, (255f-colorA)/255f);
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().color = new Color(0 / 255f, 0 / 255f, 0 / 255f, (255f - colorA) / 255f);

                if (timer >10)
                {
                    systemaMessgeBar.SetActive(false);
                    systemaMessgeBar.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
                    systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 255f / 255f);
                    messgeCheck = false;
                }
            }
        }
    }

    public static void SystemMessge(object messge)
    {
        switch (messge)
        {
            case "boss":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "다음턴에 보스가 등장합니다.";
                break;
            case "milk":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "우유 자원이 마이너스 상태입니다.";
                break;
            case "sugar":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "설탕 자원이 마이너스 상태입니다.";
                break;
            case "flour":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "밀가루 자원이 마이너스 상태입니다.";
                break;
            case "people":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "인구가 최대입니다.";
                break;
            case "inven":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "스킬 인벤토리가 가득 찼습니다.";
                break;
            case "skill":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "잘못된 대상입니다.";
                break;
            default:
                break;
        }
        systemaMessgeBar.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f/ 255f);
        messgeCheck = true;
        timer = 0f;
    }
}
