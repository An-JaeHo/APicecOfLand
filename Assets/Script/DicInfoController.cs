using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicInfoController : MonoBehaviour
{
    public DictionaryController dicInfo;

    public List<Enemy> enemys;
    public List<Area> areas;

    public bool armyCheck;
    public bool areaCheck;


    void Start()
    {
        dicInfo = GameObject.FindGameObjectWithTag("Diction").GetComponent<DictionaryController>();
        armyCheck = false;
        areaCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(armyCheck == true)
        {

        }

        if(areaCheck == true)
        {

        }    
    }

    public void NextObj()
    {
       
    }
}
