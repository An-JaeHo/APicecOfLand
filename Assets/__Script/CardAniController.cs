using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAniController : MonoBehaviour
{
    private GameObject parentObj;

    private void Start()
    {
        parentObj = transform.parent.gameObject;
    }

    public void DestroyObj()
    {
        parentObj.SetActive(false);
        Destroy(parentObj);
    }
}
