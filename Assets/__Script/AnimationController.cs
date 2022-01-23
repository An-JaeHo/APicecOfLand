using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public void CheckDeadAni()
    {
        if (transform.parent.parent.tag == "Army")
        {
            transform.parent.parent.GetComponent<SoldierManger>().input.BarrackUi.GetComponent<BarrackController>().usingPeople--;
            transform.parent.parent.GetComponent<SoldierManger>().input.BarrackUi.GetComponent<BarrackController>().supplyManger.playerInfo.updateMilk += transform.parent.parent.GetComponent<SoldierManger>().soldier.ConsumeFood;
            transform.parent.parent.GetComponent<SoldierManger>().input.BarrackUi.GetComponent<BarrackController>().supplyManger.JustUpdateSupply();
            transform.parent.parent.GetComponent<SoldierManger>().buttonManger.amrys.Remove(transform.parent.parent.gameObject);
            Destroy(transform.parent.parent.gameObject);
        }
        else if (transform.parent.parent.tag == "Enemy")
        {
            if(transform.parent.parent.GetComponent<MakeEnemy>().tutorialCheck)
            {
                transform.parent.parent.GetComponent<TutorialEnemyManger>().buttonManger.GetComponent<TutorialInvenController>().InputCard(1);
            }
            else
            {
                transform.parent.parent.GetComponent<EnemyController>().invenManger.InputCard(transform.parent.parent.GetComponent<MakeEnemy>().Grade);
                transform.parent.parent.GetComponent<EnemyController>().playerInfo.killingPoint++;
                transform.parent.parent.GetComponent<EnemyController>().transform.parent.GetComponent<BoxCollider2D>().enabled = true;
                transform.parent.parent.GetComponent<EnemyController>().buttonManger.enemys.Remove(transform.gameObject);
                GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>().CheckTile();
            }

            Destroy(transform.parent.parent.gameObject);
        }
        else if (transform.parent.parent.tag == "Boss")
        {
            transform.parent.parent.GetComponent<EnemyController>().invenManger.InputCard(4);
            transform.parent.parent.GetComponent<EnemyController>().buttonManger.enemys.Remove(transform.parent.parent.gameObject);
            transform.parent.parent.GetComponent<EnemyController>().playerInfo.killingPoint++;
            transform.parent.parent.GetComponent<EnemyController>().tiles.bossHP.SetActive(false);
            transform.parent.parent.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(transform.parent.parent.gameObject);
            GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>().CheckTile();
        }
        
    }

    public void CandleDeadAni()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
