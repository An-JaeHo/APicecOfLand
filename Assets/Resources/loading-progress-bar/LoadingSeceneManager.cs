using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSeceneManager : MonoBehaviour
{
    public List<GameObject> MonList;
    public Transform p;
    GameObject Mon;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0, 17);
        Mon = Instantiate(MonList[num], p);
        Mon.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        Mon.transform.GetChild(0).GetComponent<Animator>().SetBool("Move", true);
    }
}
