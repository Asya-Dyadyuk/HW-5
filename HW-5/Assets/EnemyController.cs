using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float timeToWait = 1f;
    [SerializeField] private float minDistanceToPlayer = 1.5f; //if the distanss less then 1.5 enemy will stand still.

    private Rigidbody2D _rb;
    private Transform _playerTransform;//the position of the player
    private Vector2 _leftBoudaryPosition; //left position of the enemy
    private Vector2 _rightBoudaryPosition; //right position of the enemy
    private Vector2 nextPoint;

    private bool _isFacingRight = true;
    private bool _isWait = false;
    private float _waitTime;
    private bool _isChasingPlayer; // if the enemy goes after the player
    public Animator animator; //-----
    float horizontalMove;//---

    public bool IsFacingRight
    {
        get => _isFacingRight;
    }

    public void StartChasingPlayer()
    {
        _isChasingPlayer = true;
    }
    // Start is called before the first frame update
    void Start()
    {

        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        _rb = GetComponent<Rigidbody2D>();
        _leftBoudaryPosition = transform.position; //left point will be where the enemy standing in the first place.
        _rightBoudaryPosition = _leftBoudaryPosition + Vector2.right * walkDistance; //right point is where the left point + walk distance.left+(x+distance,0)
        _waitTime = timeToWait;
    }

    private void FixedUpdate()
    {
        nextPoint = Vector2.right * walkSpeed * Time.fixedDeltaTime; //going right

        if(Mathf.Abs(DistanceToPlayer()) < minDistanceToPlayer)
        {
            return;
        }

        if (_isChasingPlayer) //go after our player
        {
            ChasePlayer();
        } 

        if (!_isWait && !_isChasingPlayer)
        {
            Patrol();
        }
           
    }

    private float DistanceToPlayer()
    {
        return _playerTransform.position.x - transform.position.x;
    }

    private void Patrol()
    {
        if (!_isFacingRight) //if the anamy looking to left
        {
            nextPoint.x *= -1; //negative speed, mooving right
        }
        _rb.MovePosition((Vector2)transform.position + nextPoint);
    }

    private void ChasePlayer()
    {
        float distance = (DistanceToPlayer()); //if player is on the right size of the enemy distance>0 otherwise distance<0
       
        if (distance < 0)
        {
            nextPoint.x *= -1;
        }
        //we choose to cheack <>0.2 becuse when we on the same spote with the enemy, the enemy dosnt know where to look
        if(distance > 0.2f && !_isFacingRight) //the player in the right side of the enemy but he is looking to the left size
        {
            Flip(); //flip the enemy
        }
        else if(distance < 0.2f && _isFacingRight)
        {
            Flip(); //flip the enemy
        }
        _rb.MovePosition((Vector2)transform.position + nextPoint);
    }
    //for me,to see the path of the enemy
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBoudaryPosition, _rightBoudaryPosition); //where to drow the line
    }
    //flip the enemy
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
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed; //-----
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); ///-----
        //timer for the enemy to wait
        if (_isWait && !_isChasingPlayer)
        {
            Wait();
        }

        if (ShouldWait())
        {
            _isWait = true;//wait
        }
    }


}
