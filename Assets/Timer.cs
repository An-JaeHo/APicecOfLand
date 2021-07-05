using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float limitTime;
    public int hourTime;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text= transform.GetChild(0).GetComponent<Text>();
        hourTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        limitTime += Time.deltaTime;

        if(limitTime >= 60)
        {
            hourTime++;
            limitTime = 0;
        }

        text.text = hourTime + " : " + (int)limitTime;
    }
}
