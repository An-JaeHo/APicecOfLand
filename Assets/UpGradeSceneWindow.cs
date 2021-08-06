using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeSceneWindow : MonoBehaviour
{
    

    public void UpGradeCheck(Transform obj)
    {
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = obj.GetComponent<MakeSoldier>().Picture;
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Level.ToString();
        transform.GetChild(3).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Name;

        transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().HelthPoint.ToString();

        transform.GetChild(4).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().BaseAttack.ToString();

        transform.GetChild(4).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Defensive.ToString();

        transform.GetChild(4).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = obj.GetComponent<MakeSoldier>().Critical.ToString();

    }
}
