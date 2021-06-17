using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject testObj;

    public void fuck(GameObject testInput)
    {
      testObj = testInput;
    }

    private void LateUpdate()
    {
        if(testObj != null)
        {
            transform.position = testObj.transform.position;
        }
    }
}
