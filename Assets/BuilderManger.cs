using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManger : MonoBehaviour
{
    public AreaManger areaManger;
    
    void CheckAreaCount()
    {
        if(transform.parent.tag == "Area")
        {
            areaManger = transform.parent.GetComponent<AreaManger>();
        }

        
    }
}
