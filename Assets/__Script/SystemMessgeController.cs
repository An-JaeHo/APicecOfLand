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
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "�����Ͽ� ������ �����մϴ�.";
                break;
            case "milk":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "���� �ڿ��� ���̳ʽ� �����Դϴ�.";
                break;
            case "sugar":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "���� �ڿ��� ���̳ʽ� �����Դϴ�.";
                break;
            case "flour":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "�а��� �ڿ��� ���̳ʽ� �����Դϴ�.";
                break;
            case "people":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "�α��� �ִ��Դϴ�.";
                break;
            case "inven":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "��ų �κ��丮�� ���� á���ϴ�.";
                break;
            case "skill":
                systemaMessgeBar.transform.GetChild(0).GetComponent<Text>().text = "�߸��� ����Դϴ�.";
                break;
            default:
                break;
        }
        systemaMessgeBar.GetComponent<Image>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f/ 255f);
        messgeCheck = true;
        timer = 0f;
    }
}
