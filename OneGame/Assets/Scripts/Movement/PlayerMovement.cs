using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region Field
    public float RunSpeed;
    public Direction directionStruct;
    private Animator animator;
    private Vector2 direction;
    private Rigidbody2D rigibody2D;
    public PlayerBase playerBase;
    public bool IsBusy = false;

    #endregion

    #region Properties
    private PlayerMovementStateBase currentState;
    public PlayerMovementStateBase CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
        }
    }
    #endregion

    // Use this for initialization
    void Awake()
    {
        animator = this.GetComponent<Animator>();
        if (animator == null)
            throw new ArgumentNullException("animator");

        rigibody2D = this.GetComponent<Rigidbody2D>();
        if (rigibody2D == null)
            throw new ArgumentNullException("rigibody2D");
    }

    private void Start()
    {
        currentState = PlayerMovementStateBase.PlayerIdleState;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private Direction Vector2Direction(Vector2 direction)
    {
        if (Vector2.Dot(direction, Vector2.up) <= 1)
        {
            return Direction.Up;
        }
        else if (Vector2.Dot(direction, Vector2.down) <= 1)
        {
            return Direction.Down;
        }
        else if (Vector2.Dot(direction, Vector2.left) <= 1)
        {
            return Direction.Left;

        }
        else if (Vector2.Dot(direction, Vector2.right) <= 1)
        {
            return Direction.Right;
        }
        return Direction.Down;
    }

    private Vector2 Direction2Vector(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Vector2.up;
            case Direction.Down:
                return Vector2.down;
            case Direction.Right:
                return Vector2.right;
            case Direction.Left:
                return Vector2.left;
            default:
                return Vector2.down;
        }
    }

    private void FixedUpdate()
    {
        //if player is busy, cannot move for the moment. 
        if (IsBusy)
        {
            StopMovement();
            return;
        }

        currentState.HandleInput(this);
        currentState.UpdateMovement(this);
        Debug.Log(currentState.ToString());
        
       
    }

    IEnumerable Wait()
    {
        return null;
    }

    public Animator GetPlayerAnimator()
    {
        return animator;
    }

    public void StopMovement()
    {
        rigibody2D.velocity = Vector2.zero;
    }

    public void Move(Direction direction,float speed)
    {
        switch (direction)
        {
            case Direction.Up:
                //this.transform.position += Vector3.up * RunSpeed *Time.deltaTime;
                rigibody2D.velocity = Vector3.up * speed;
                break;
            case Direction.Down:
                //this.transform.position -= Vector3.up * RunSpeed * Time.deltaTime;
                rigibody2D.velocity = Vector3.down * speed;
                break;
            case Direction.Right:
                //this.transform.position += Vector3.right * RunSpeed * Time.deltaTime;
                rigibody2D.velocity = Vector3.right * speed;
                break;
            case Direction.Left:
                //this.transform.position -= Vector3.right * RunSpeed * Time.deltaTime;
                rigibody2D.velocity = Vector3.left * speed;
                break;
            default:
                break;
        }
    }
}


public class PlayerMovementStateBase
{
    private static PlayerWalking playerWalkingState;
    public static PlayerWalking PlayerWalkingState
    { 
        get
        {
            if (playerWalkingState == null)
                playerWalkingState = new PlayerWalking();
            return playerWalkingState;
        }
    }

    private static PlayerRuning playerRuningState;
    public static PlayerRuning PlayerRuningState
    {
        get
        {
            if (playerRuningState == null)
                playerRuningState = new PlayerRuning();
            return playerRuningState;
        }
    }

    private static PlayerIdle playerIdleState;
    public static PlayerIdle PlayerIdleState
    {
        get
        {
            if (playerIdleState == null)
                playerIdleState = new PlayerIdle();
            return playerIdleState;
        }
    }

    public virtual void HandleInput(PlayerMovement player)
    {

    }

    public virtual void UpdateMovement(PlayerMovement player)
    {

    }
}

public class PlayerWalking : PlayerMovementStateBase
{
    #region Field
    private float walkingSpeend = 3.0f;
    #endregion

    public override void HandleInput(PlayerMovement player)
    {
        if (Input.GetButtonDown("Run"))
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxisRaw("Horizontal");
            if (vertical != 0 || horizontal != 0)
            {
                player.CurrentState = PlayerMovementStateBase.PlayerRuningState;
            }
            else
            {
                player.CurrentState = PlayerMovementStateBase.PlayerIdleState;
            }
                
        }
        else
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxisRaw("Horizontal");
            if (vertical == 0 && horizontal == 0)
            {
                player.CurrentState = PlayerMovementStateBase.PlayerIdleState;
            }
        }
    }

    public override void UpdateMovement(PlayerMovement player)
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var animator = player.GetPlayerAnimator();
        animator.SetBool("IsMoving", false);
        if (horizontal > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("LastMoveX", horizontal);
            animator.SetFloat("LastMoveY", 0);
            player.Move(Direction.Right, walkingSpeend);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("LastMoveX", horizontal);
            player.Move(Direction.Left, walkingSpeend);
        }
        else if (vertical > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveY", vertical);
            animator.SetFloat("MoveX", vertical);
            animator.SetFloat("LastMoveY", vertical);
            animator.SetFloat("LastMoveX", 0);
            player.Move(Direction.Up, walkingSpeend);
        }
        else if (vertical < 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveY", vertical);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("LastMoveY", vertical);
            animator.SetFloat("LastMoveX", 0);
            player.Move(Direction.Down, walkingSpeend);
        }
    }
}

public class PlayerIdle : PlayerMovementStateBase
{
    public override void HandleInput(PlayerMovement player)
    {
        if (Input.GetButton("Run"))
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxisRaw("Horizontal");
            if (vertical!=0 || horizontal!=0)
            {
                player.CurrentState = PlayerMovementStateBase.PlayerRuningState;
            }            
        }
        else
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxisRaw("Horizontal");
            if (vertical != 0 || horizontal != 0)
            {
                player.CurrentState = PlayerMovementStateBase.PlayerWalkingState;
            }
        }
    }

    public override void UpdateMovement(PlayerMovement player)
    {
        var animator = player.GetPlayerAnimator();
        animator.SetBool("IsMoving", false);
        player.StopMovement();
    }
}

public class PlayerRuning:PlayerMovementStateBase
{
    #region Field
    private float runingSpeed = 5.0f;
    #endregion
    public override void UpdateMovement(PlayerMovement player)
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var animator = player.GetPlayerAnimator();
        animator.SetBool("IsMoving", false);
        if (horizontal > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("LastMoveX", horizontal);
            animator.SetFloat("LastMoveY", 0);
            player.Move(Direction.Right, runingSpeed);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("LastMoveX", horizontal);
            player.Move(Direction.Left, runingSpeed);
        }
        else if (vertical > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveY", vertical);
            animator.SetFloat("MoveX", vertical);
            animator.SetFloat("LastMoveY", vertical);
            animator.SetFloat("LastMoveX", 0);
            player.Move(Direction.Up, runingSpeed);
        }
        else if (vertical < 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveY", vertical);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("LastMoveY", vertical);
            animator.SetFloat("LastMoveX", 0);
            player.Move(Direction.Down, runingSpeed);
        }
    }

    public override void HandleInput(PlayerMovement player)
    {
        if (!Input.GetButton("Run"))
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxisRaw("Horizontal");
            if (vertical != 0 || horizontal != 0)
            {
                player.CurrentState = PlayerMovementStateBase.PlayerWalkingState;
            }
            else
            {
                player.CurrentState = PlayerMovementStateBase.PlayerIdleState;
            }
        }
        else
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxisRaw("Horizontal");
            if (vertical == 0 && horizontal == 0)
            {
                player.CurrentState = PlayerMovementStateBase.PlayerIdleState;
            }
        }
    }
}


