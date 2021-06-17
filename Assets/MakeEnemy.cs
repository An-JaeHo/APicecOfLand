using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public string Code;
    public Sprite Picture;
    public string Name;
    public int Grade;
    public string Specialities;
    public int HelthPoint;
    public int BaseTroop;
    public float BaseAttack;
    public float Defensive;
    public int AttackRange;
    public int MovementSpace;
    public string DropExperiencePoint;
    public string DropItem;
}

public class MakeEnemy : EnemyInfo
{
    public JsonManger enemyInfo;

    public void InputEnemyInfo(string code)
    {
        enemyInfo = GameObject.FindGameObjectWithTag("GameManger").GetComponent<JsonManger>();

        for (int i = 0; i < enemyInfo.information.enemy.Length; i++)
        {
            if (enemyInfo.information.enemy[i].Code == code)
            {
                Code = enemyInfo.information.enemy[i].Code;
                Picture = enemyInfo.information.enemy[i].Picture;
                Name = enemyInfo.information.enemy[i].Name;
                Grade = enemyInfo.information.enemy[i].Grade;
                Specialities = enemyInfo.information.enemy[i].Specialities;
                HelthPoint = enemyInfo.information.enemy[i].HelthPoint;
                BaseAttack = enemyInfo.information.enemy[i].BaseAttack;
                Defensive = enemyInfo.information.enemy[i].Defensive;
                AttackRange = enemyInfo.information.enemy[i].AttackRange;
                BaseTroop = enemyInfo.information.enemy[i].BaseTroop;
                MovementSpace = enemyInfo.information.enemy[i].MovementSpace;
                DropExperiencePoint = enemyInfo.information.enemy[i].DropExperiencePoint;
                DropItem = enemyInfo.information.enemy[i].DropItem;
            }
        }
    }
}
