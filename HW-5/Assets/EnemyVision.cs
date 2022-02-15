using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private GameObject currentHitObject;
    [SerializeField] private float circleRadius;
    [SerializeField] private float maxDistance; //the distance that our enemy will see us
    [SerializeField] private LayerMask layerMask;

    private EnemyController _enemyController;
    private Vector2 _origin;
    private Vector2 _direction; //what direction the enemy looking

    private float _currentHitDistance;
    // Start is called before the first frame update
    void Start()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        _origin = transform.position;

        if (_enemyController.IsFacingRight)
        {
           _direction = Vector2.right;
        }
        else
        {
            _direction = Vector2.left;
        }
        
        RaycastHit2D hit = Physics2D.CircleCast(_origin, circleRadius, _direction, maxDistance, layerMask);//from point _origin with radious circleRadius in direction direction with maximum distance of maxDistance

        if (hit)
        {
            currentHitObject = hit.transform.gameObject;
            _currentHitDistance = hit.distance;
            if (currentHitObject.CompareTag("Player")) //If the enemy has seen the player, we want the enemy to follow the player.
            {
                _enemyController.StartChasingPlayer(); 
            }
            else //the enemy has not seen the player,dont change nothing
            {
                currentHitObject = null;
                _currentHitDistance = maxDistance;
            }
        }
       
        
    }
    //just for me
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos.DrawSphere(_origin + _direction * _currentHitDistance, circleRadius);
    }
}
