using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public UpGradeMonsterInfo upGradeMonsterInfo;
    public Sprite nomalToggle;

    [Header("Set in VisualStudio")]
    public List<Transform> images;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            images.Add(transform.GetChild(i));
        }
    }

    public void CheckToggle()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].GetComponent<Image>().color = new Color(127f / 255f, 127f / 255f, 127f / 255f, 134f / 255f);
            images[i].GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
        }

        if (upGradeMonsterInfo.monsters[2].GetComponent<MakeSoldier>().Name == "æÁ√ ∏”«…")
        {
            images[0].GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
            images[0].GetComponent<Image>().color = Color.white;
        }
        else if (upGradeMonsterInfo.monsters[2].GetComponent<MakeSoldier>().Name == "¡¯¿˙ƒÌ≈∞")
        {
            images[1].GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
            images[1].GetComponent<Image>().color = Color.white;
        }
        else if (upGradeMonsterInfo.monsters[2].GetComponent<MakeSoldier>().Name == "Ω∫≈∞∆≤¡Óƒ…¿Ã≈©")
        {
            images[2].GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
            images[2].GetComponent<Image>().color = Color.white;
        }
        else if (upGradeMonsterInfo.monsters[2].GetComponent<MakeSoldier>().Name == "µµ≥”√˜")
        {
            images[3].GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
            images[3].GetComponent<Image>().color = Color.white;
        }
        else if (upGradeMonsterInfo.monsters[2].GetComponent<MakeSoldier>().Name == "Ω¥¥œπﬂ∑ª")
        {
            images[4].GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
            images[4].GetComponent<Image>().color = Color.white;
        }          
        else if (upGradeMonsterInfo.monsters[2].GetComponent<MakeSoldier>().Name == "√ ƒ⁄ƒ®ƒÌ≈∞")
        {
            images[5].GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
            images[5].GetComponent<Image>().color = Color.white;
        }
    }
}
