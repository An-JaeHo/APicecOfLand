using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighLightObjController : MonoBehaviour
{
    static public List<Material> material;
    static public bool checkHight;
    static List<Color> pureColor = new List<Color>();
    static List<Material> saveMaterial = new List<Material>();

    void Start()
    {
        checkHight = true;
        material = new List<Material>();
    }

    public static void HighLight(GameObject gameObject)
    {
        material = new List<Material>();

        if(checkHight)
        {
            for (int i = 0; i < gameObject.GetComponentsInChildren<SpriteRenderer>().Length; i++)
            {
                material.Add(gameObject.GetComponentsInChildren<SpriteRenderer>()[i].material);
                saveMaterial.Add(gameObject.GetComponentsInChildren<SpriteRenderer>()[i].material);
                pureColor.Add(gameObject.GetComponentsInChildren<SpriteRenderer>()[i].color);
            }
        }
        else
        {
            for (int i = 0; i < gameObject.GetComponentsInChildren<Image>().Length; i++)
            {
                material.Add(gameObject.GetComponentsInChildren<Image>()[i].material);
                saveMaterial.Add(gameObject.GetComponentsInChildren<Image>()[i].material);
                pureColor.Add(gameObject.GetComponentsInChildren<Image>()[i].color);
            }

            Debug.Log(saveMaterial.Count);
        }
    }

    public void StartHighLightObj()
    {
        //InvokeRepeating("StartHighLight", 0f, 0.5f);
        Invoke("StartHighLight", 0f);

        //for (int i = 0; i < material.Count; i++)
        //{
        //    material[i].color = Color.gray;
        //}
    }

    public void StopHighLightObj()
    {
        Invoke("endHighLight", 0f);
    }

    void StartHighLight()
    {
        for (int i = 0; i < saveMaterial.Count; i++)
        {
            saveMaterial[i].color = Color.gray;
        }
        Debug.Log(saveMaterial.Count);
    }

    void endHighLight()
    {
        for (int i = 0; i < saveMaterial.Count; i++)
        {
            saveMaterial[i].color = pureColor[i];
        }
        saveMaterial.Clear();
        pureColor.Clear();
        checkHight = true;
    }
}
