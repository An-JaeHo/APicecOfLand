using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossController : MonoBehaviour
{
    public JsonManger json;
    //public bossSelectController bossSelect;
    public GameObject boss;
    public PlayerInfo player;

    void Start()
    {
        json = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();
        //bossSelect = GameObject.Find("bossSelectPicture").GetComponent<bossSelectController>();
        boss = GameObject.Find("Gadian");
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
    }


    public void Findboss()
    {
        for(int i=0; i< json.information.boss.Length;i++)
        {
            if(json.information.boss[i].Name == transform.name)
            {
                //bossInfo.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = json.information.boss[i].Picture;
                boss.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = json.information.boss[i].Level.ToString();
                boss.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = json.information.boss[i].ExperiencePoint.ToString();
                boss.transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Text>().text = json.information.boss[i].Name.ToString();
                boss.transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<Text>().text = json.information.boss[i].HelthPoint.ToString();
                boss.transform.GetChild(2).GetChild(4).GetChild(0).GetComponent<Text>().text = json.information.boss[i].BaseAttack.ToString();
                boss.transform.GetChild(2).GetChild(5).GetChild(0).GetComponent<Text>().text = json.information.boss[i].Defensive.ToString();
                boss.transform.GetChild(2).GetChild(6).GetChild(1).GetComponent<Text>().text = json.information.boss[i].InherentAbiltiy;

                //bossSelect.gameObject.SetActive(false);

                //player.playerboss = json.information.boss[i];
            }    
        }

        //player.playerbossCheck = true;
    }
    
}
