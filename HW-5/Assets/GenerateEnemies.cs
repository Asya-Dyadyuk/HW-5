using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public float xPos;
    public int enemyCount;


    Platform platformA;
    Platform platformB;
    Platform platformC1;
    Platform platformC2;
    Platform platformD;
    //platform A.
    const float platformAa = 3.7f;
    const float platformAb = 11.11f;
    const float platformAY = 0.27f;

    //platform B.
    const float platformBa = 12.93F;
    const float platformBb = 20.31f;
    const float platformBY = -0.08f;

    //platform C.
    const float platformC1a = 21.4f;
    const float platformC1b = 26.57f;
    const float platformC1Y = -2.73f;

    const float platformC2a = 30.19f;
    const float platformC2b = 52.77f;
    const float platformC2Y = -1.27f;

    //platform D.
    const float platformDa =  54.33f;
    const float platformDb = 76.83f;
    const float platformDY = -0.84f;


    // Start is called before the first frame update
    void Start()
    {
        //create the platforms
        platformA = new Platform(platformAa, platformAb);
        platformB = new Platform(platformBa, platformBb);
        platformC1 = new Platform(platformC1a, platformC1b);
        platformC2 = new Platform(platformC2a, platformC2b);
        platformD = new Platform(platformDa, platformDb);

        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 5)
        {
            enemyCount++;
            xPos = Random.Range(1, 77);
            // Platform A
            if (xPos >= platformA.getA() && xPos <= platformA.getB())
                Instantiate(theEnemy, new Vector2(xPos, platformAY), Quaternion.identity);
            //Platform B
            else if (xPos >= platformB.getA() && xPos <= platformB.getB())
                Instantiate(theEnemy, new Vector2(xPos, platformBY), Quaternion.identity);
            //Platform C part 1
            else if (xPos >= platformC1.getA() && xPos <= platformC1.getB())
                Instantiate(theEnemy, new Vector2(xPos, platformC1Y), Quaternion.identity);
            //Platform C part 2
            else if (xPos >= platformC2.getA() && xPos <= platformC2.getB())
                Instantiate(theEnemy, new Vector2(xPos, platformC2Y), Quaternion.identity);
            //Platform D
            else if (xPos >= platformD.getA() && xPos <= platformD.getB())
                Instantiate(theEnemy, new Vector2(xPos, platformDY), Quaternion.identity);
            //WE DID NOT CREATE NO ENEMY, REPET
            else
                enemyCount--;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

