using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonManger : MonoBehaviour
{
    public GameObject bulidUpgradeUi;
    public GameObject armyUpgradeUi;
    public GameObject buildUi;
    public GameObject barrackWindow;
    public GameObject settingUi;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildUiButton()
    {
        if (buildUi.activeSelf)
        {
            buildUi.SetActive(false);
        }
        else
        {
            buildUi.SetActive(true);
        }
    }

    public void BuildUpGreadeUiButton()
    {
        if (bulidUpgradeUi.activeSelf)
        {
            bulidUpgradeUi.SetActive(false);
        }
        else
        {
            bulidUpgradeUi.SetActive(true);
        }
    }

    public void ArmyUpgradeButton()
    {
        if (armyUpgradeUi.activeSelf)
        {
            armyUpgradeUi.SetActive(false);
        }
        else
        {
            armyUpgradeUi.SetActive(true);
        }
    }

    public void BarrackButton()
    {
        if (barrackWindow.activeSelf)
        {
            barrackWindow.SetActive(false);
        }
        else
        {
            barrackWindow.SetActive(true);
            barrackWindow.GetComponent<BarrackController>().barrackMonsterSprite.gameObject.SetActive(false);
        }
    }

    public void SettingButton()
    {
        if (settingUi.activeSelf)
        {
            settingUi.SetActive(false);
        }
        else
        {
            settingUi.SetActive(true);
        }
    }
}
