using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTileManger : MonoBehaviour
{
    public GameObject tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject land = Instantiate(tilePrefab, new Vector3(transform.position.x + (i * 87f), transform.position.y), Quaternion.identity);
            land.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
