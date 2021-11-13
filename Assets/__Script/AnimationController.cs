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
            Destroy(transform.parent.parent.gameObject);
        }
        else if (transform.parent.parent.tag == "Builder")
        {
            //transform.parent.parent.GetComponent<SoldierManger>().tileManger.DeadBulider(transform.parent.parent.gameObject);
        }
        else if (transform.parent.parent.tag == "Enemy")
        {
            transform.parent.parent.GetComponent<EnemyController>().invenManger.InputCard(transform.parent.parent.GetComponent<MakeEnemy>().Grade);
            transform.parent.parent.GetComponent<EnemyController>().playerInfo.killingPoint++;
            transform.parent.parent.GetComponent<EnemyController>().transform.parent.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(transform.parent.parent.gameObject);
        }
        else if (transform.parent.parent.tag == "Boss")
        {
            transform.parent.parent.GetComponent<EnemyController>().invenManger.InputCard(4);
            transform.parent.parent.GetComponent<EnemyController>().buttonManger.enemys.Remove(transform.parent.parent.gameObject);
            transform.parent.parent.GetComponent<EnemyController>().playerInfo.killingPoint++;
            transform.parent.parent.GetComponent<EnemyController>().tiles.bossHP.SetActive(false);
            transform.parent.parent.GetComponent<EnemyController>().tiles.bossText.SetActive(false);
            transform.parent.parent.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(transform.parent.parent.gameObject);
        }

        GameObject.FindGameObjectWithTag("Tile").GetComponent<TileManger>().CheckTile();
    }
}
