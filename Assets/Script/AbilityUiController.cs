using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUiController : MonoBehaviour
{
    public GameObject BuffNDebuffPrefeb;
    public SaveMgr saveMgr;

    public void BuffButton()
    {
        Transform content = transform.GetChild(0).GetChild(0).GetChild(0);
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        gameObject.SetActive(true);
        
        for (int i=0; i< saveMgr.buffs.Count; i++)
        {
            GameObject prefeb = Instantiate(BuffNDebuffPrefeb,content);
            prefeb.transform.name = saveMgr.buffs[i].Name;
            prefeb.transform.GetComponentInChildren<Text>().text = saveMgr.buffs[i].Name;
            prefeb.GetComponent<BuffNDeBuffInfo>().buffCheck = true;
            prefeb.GetComponent<BuffNDeBuffInfo>().buff = saveMgr.buffs[i];
            Debug.Log("afaf");
        }

        gameObject.SetActive(true);
    }

    public void DeBuffButton()
    {
        Transform content = transform.GetChild(0).GetChild(0).GetChild(0);
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
        gameObject.SetActive(true);

        for (int i = 0; i < saveMgr.buffs.Count; i++)
        {
            GameObject prefeb = Instantiate(BuffNDebuffPrefeb, content);
            prefeb.transform.name = saveMgr.deBuffs[i].Name;
            prefeb.transform.GetComponentInChildren<Text>().text = saveMgr.deBuffs[i].Name;
            prefeb.GetComponent<BuffNDeBuffInfo>().buffCheck = false;
            prefeb.GetComponent<BuffNDeBuffInfo>().deBuff = saveMgr.deBuffs[i];
            
        }

        gameObject.SetActive(true);
    }

    public void ClearAll()
    {
        Transform content = transform.GetChild(0).GetChild(0).GetChild(0);

        while(content.childCount !=0)
        {
            for(int i =0; i<content.childCount;i++)
            {
                content.GetChild(i).SetParent(GameObject.Find("ObjPool").transform);
            }
        }
    }
}
