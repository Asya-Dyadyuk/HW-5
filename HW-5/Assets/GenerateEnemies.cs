using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount <5)
        {
            xPos = Random.Range(1, 70);
            Instantiate(theEnemy, new Vector3(xPos, 0,0), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}

