using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniCheck : MonoBehaviour
{
    public List<GameObject> buildList;
    public GameObject parentGameObj;
    public GameObject stateUi;
    public bool checkOverlap;
    public bool listCheck;
    int i;

    private void Start()
    {
        parentGameObj.transform.position = new Vector3(parentGameObj.transform.position.x - 251, parentGameObj.transform.position.y);
        i = 0; ;
        checkOverlap = true;
        listCheck = true;
    }

    public void CheckArea(Transform game)
    {
        for (int j = 0; j < buildList.Count; j++)
        {
            if (buildList[j].name == game.name)
            {
                //buildList[j].name = game.name;
                buildList[j].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = game.GetComponent<MakeArea>().Picture;
                buildList[j].transform.GetChild(2).GetChild(0).GetComponent<Text>().text = game.GetComponent<MakeArea>().Name;
                listCheck = false;
            }
        }

        if(listCheck)
        {
            GameObject obj = Instantiate(stateUi, parentGameObj.transform.GetChild(0));
            obj.name = game.name;
            obj.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = game.GetComponent<MakeArea>().Picture;
            obj.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = game.GetComponent<MakeArea>().Name;
            obj.transform.position = new Vector3(parentGameObj.transform.GetChild(0).position.x, (parentGameObj.transform.GetChild(0).position.y - 40) - (i * 80));
            parentGameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(parentGameObj.GetComponent<RectTransform>().sizeDelta.x, (buildList.Count + 1) * 140);

            if (checkOverlap)
            {
                buildList.Add(obj);
            }

            i++;
        }

        listCheck = true;
    }
}
