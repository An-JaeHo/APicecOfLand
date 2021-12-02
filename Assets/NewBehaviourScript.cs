using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject game;


    private void Start()
    {
        GetComponent<HighLightObjController>().testMaterial = HighLightObjController.HighLight(game);
        GetComponent<HighLightObjController>().test();
    }
}
