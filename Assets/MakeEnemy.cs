using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public string Code;
    //public Sprite Picture;
    public string Name;
    public int Grade;
    public string Specialities;
    public int MaxLevel;
    public int BaseHelthPoint;
    public int RiseHelthPoint;
    public float BaseAttack;
    public float RiseAttack;
    public float BaseDefensive;
    public float RiseDefensive;
    public int AttackRange;
    public int AttackNumber;
    public int Movement;
    public string Spone1;
    public string Spone2;
    public string Spone3;
    public string Drop;
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
                //Picture = enemyInfo.information.enemy[i].Picture;
                Name = enemyInfo.information.enemy[i].Name;
                Grade = enemyInfo.information.enemy[i].Grade;
                Specialities = enemyInfo.information.enemy[i].Specialities;
                MaxLevel = enemyInfo.information.enemy[i].MaxLevel;
                BaseHelthPoint = enemyInfo.information.enemy[i].BaseHelthPoint;
                RiseHelthPoint = enemyInfo.information.enemy[i].RiseHelthPoint;
                BaseAttack = enemyInfo.information.enemy[i].BaseAttack;
                RiseAttack = enemyInfo.information.enemy[i].RiseAttack;
                BaseDefensive = enemyInfo.information.enemy[i].BaseDefensive;
                RiseDefensive = enemyInfo.information.enemy[i].RiseDefensive;
                AttackRange = enemyInfo.information.enemy[i].AttackRange;
                AttackNumber = enemyInfo.information.enemy[i].AttackNumber;
                Movement = enemyInfo.information.enemy[i].Movement;
                Spone1 = enemyInfo.information.enemy[i].Code;
                Spone2 = enemyInfo.information.enemy[i].Code;
                Spone3 = enemyInfo.information.enemy[i].Code;
                Drop = enemyInfo.information.enemy[i].Code;

                //GetComponent<SpriteRenderer>().sprite = Picture;
            }
        }
    }
}
