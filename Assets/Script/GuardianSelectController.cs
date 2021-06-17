using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardianSelectController : MonoBehaviour
{
    public JsonManger json;
    public GameObject guardianPrefebs;
    public ScrollRect scrollRect;
    
    void Start()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        scrollRect = transform.GetComponentInChildren<ScrollRect>();

        for(int i=0; i<json.information.boss.Length;i++)
        {
            GameObject gameObject = Instantiate(guardianPrefebs, scrollRect.content);
            
            if(i > 4)
            {
                gameObject.transform.position = new Vector3(scrollRect.content.position.x + 90 + ((i-5) * 140), scrollRect.content.position.y - 250);
            }
            else
            {
                gameObject.transform.position = new Vector3(scrollRect.content.position.x + 90 + (i * 140), scrollRect.content.position.y - 100);
            }

            gameObject.name = json.information.boss[i].Name;
        }
    }
}
