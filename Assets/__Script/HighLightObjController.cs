using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightObjController : MonoBehaviour
{
    static public List<SpriteRenderer> material;
    static bool checkHight;
    static List<Color> pureColor;


    void Start()
    {
        checkHight = true;
        material = new List<SpriteRenderer>();
    }

    public static List<SpriteRenderer> HighLight(GameObject gameObject)
    {
        material = new List<SpriteRenderer>();
        pureColor = new List<Color>();

        for (int i = 0; i < gameObject.GetComponentsInChildren<SpriteRenderer>().Length; i++)
        {
            material.Add(gameObject.GetComponentsInChildren<SpriteRenderer>()[i]);
            pureColor.Add(gameObject.GetComponentsInChildren<SpriteRenderer>()[i].color);
        }
        
        return material;
    }

    public void StartHighLightObj()
    {
        //InvokeRepeating("StartHighLight", 0f, 0.5f);
        //Invoke("StartHighLight", 0f);
        for (int i = 0; i < material.Count; i++)
        {
            material[i].color = Color.gray;
        }
    }

    public void StopHighLightObj()
    {
        Invoke("endHighLight", 0f);
    }

    void StartHighLight()
    {
        for (int i = 0; i < material.Count; i++)
        {
            material[i].color = Color.gray;
        }
        
    }

    void endHighLight()
    {
        for (int i = 0; i < material.Count; i++)
        {
            material[i].color = pureColor[i];
        }

        material.Clear();
        pureColor.Clear();
    }
}
