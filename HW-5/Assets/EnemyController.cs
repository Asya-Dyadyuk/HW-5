using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float timeToWait  = 5f;

    private Rigidbody2D _rb;
    private Vector2 _leftBoudaryPosition; //left position of the enemy
    private Vector2 _rightBoudaryPosition; //right position of the enemy

    private bool _isFacingRight = true;
    private bool _isWait = false;
    private float _waitTime;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _leftBoudaryPosition = transform.position; //left point will be where the enemy standing in the first place.
        _rightBoudaryPosition = _leftBoudaryPosition + Vector2.right *walkDistance; //right point is where the left point + walk distance.left+(x+distance,0)
        _waitTime = timeToWait;

    }
    private void FixedUpdate()
    {
        Vector2 nextPoint = Vector2.right * walkSpeed * Time.fixedDeltaTime; //going right
        if (!_isFacingRight) //if the anamy looking to left
        {
            nextPoint.x *= -1; //negative speed, mooving right
        }
        if(!_isWait)
        _rb.MovePosition((Vector2)transform.position + nextPoint); 
    }
    //to see the path of the anamy
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBoudaryPosition, _rightBoudaryPosition); //where to drow the line
    }
    //flip the anamy
    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
    //if the enemy should wait
    private bool ShouldWait()
    {
        bool isOutOfRightBoundary = _isFacingRight && transform.position.x >= _rightBoudaryPosition.x;// the enemy get to the right point that he need to wait 
        bool isOutOfLeftBoundary = !_isFacingRight && transform.position.x <= _leftBoudaryPosition.x;// the enemy get to the left point that he need to wait
        return isOutOfRightBoundary || isOutOfLeftBoundary;
    }
    // Update is called once per frame
    private void Wait()
    {
        _waitTime -= Time.deltaTime;
        if (_waitTime < 0f)
        {
            _waitTime = timeToWait;
            _isWait = false;
            Flip(); //flip the enemy after he stopped to wait
        }

    }
  
    void Update()
    {
        //timer for the enemy to wait
        if (_isWait)
        {
            Wait();
        }

        if (ShouldWait())
        {
            _isWait = true;//wait
        }
    }
}
