using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{

    //public Transform target;

    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        //Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        Vector3 direction = closestEnemy.transform.position - this.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        this.transform.rotation = rotation;
    }
}
