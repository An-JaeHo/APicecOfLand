using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float limitTime;
    public int hourTime;
    public Text text;
    public ButtonManger buttonManger;
    public bool timerCheck;

    // Start is called before the first frame update
    void Start()
    {
        timerCheck = true;
        text = transform.GetChild(0).GetComponent<Text>();
        buttonManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<ButtonManger>();
        hourTime = 0;
        limitTime = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCheck)
        {
            limitTime -= Time.deltaTime;

            if (limitTime <=0)
            {
                timerCheck = false;
                buttonManger.TurnEnd();
            }
        }

        text.text = ((int)limitTime).ToString();
    }
}
