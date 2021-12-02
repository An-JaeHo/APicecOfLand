using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightObjController : MonoBehaviour
{
    static public List<SpriteRenderer> material;

    public List<SpriteRenderer> testMaterial;

    void Start()
    {
        material = new List<SpriteRenderer>();
    }

    public static List<SpriteRenderer> HighLight(GameObject gameObject)
    {
        material = new List<SpriteRenderer>();

        for (int i = 0; i < gameObject.GetComponentsInChildren<SpriteRenderer>().Length; i++)
        {
            material.Add(gameObject.GetComponentsInChildren<SpriteRenderer>()[i]);
        }

        return material;
    }

    public void test()
    {
        InvokeRepeating("StartHighLight", 0f, 0.5f);
        InvokeRepeating("endHighLight", 0.25f, 1f);
    }

    void StartHighLight()
    {
        for (int i = 0; i < testMaterial.Count; i++)
        {
            testMaterial[i].color = Color.black;
        }
    }

    void endHighLight()
    {
        for (int i = 0; i < testMaterial.Count; i++)
        {
            testMaterial[i].color = Color.white;
        }
    }
}
