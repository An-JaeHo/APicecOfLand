using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParticle : MonoBehaviour
{
    public List<GameObject> myParticles;
    public SoldierManger soldierManger;

    public void PlayParitle()
    {
        soldierManger = transform.parent.parent.GetComponent<SoldierManger>();

        for (int i = 0; i < myParticles.Count; i++)
        {
            if(soldierManger.directionCheck)
            {
                myParticles[i].transform.localScale = new Vector3(18f, 30f);
            }
            else
            {
                myParticles[i].transform.localScale = new Vector3(-18f, 30f);
            }

            //myParticles[i].GetComponent<ParticleSystem>().Play();
        }
    }
}
