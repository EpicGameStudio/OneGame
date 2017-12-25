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
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        animator.SetBool("IsMoving", false);
        if (horizontal > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("LastMoveX", horizontal);
            animator.SetFloat("LastMoveY", 0);
            Move(Direction.Right);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", horizontal);
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("LastMoveX", horizontal);
            Move(Direction.Left);
        }
        else if (vertical > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveY", vertical);
            animator.SetFloat("MoveX", vertical);
            animator.SetFloat("LastMoveY", vertical);
            animator.SetFloat("LastMoveX", 0);
            Move(Direction.Up);
        }
        else if (vertical < 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveY", vertical);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("LastMoveY", vertical);
            animator.SetFloat("LastMoveX", 0);
            Move(Direction.Down);
        }
        if (horizontal == 0 && vertical == 0)
        {
            StopMovement();
        }
        //new WaitForSeconds(0.08f);
    }

    IEnumerable Wait()
    {
        return null;
    }


    private void StopMovement()
    {
        rigibody2D.velocity = Vector2.zero;
    }

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                //this.transform.position += Vector3.up * RunSpeed *Time.deltaTime;
                rigibody2D.velocity = Vector3.up * RunSpeed;
                break;
            case Direction.Down:
                //this.transform.position -= Vector3.up * RunSpeed * Time.deltaTime;
                rigibody2D.velocity = Vector3.down * RunSpeed;
                break;
            case Direction.Right:
                //this.transform.position += Vector3.right * RunSpeed * Time.deltaTime;
                rigibody2D.velocity = Vector3.right * RunSpeed;
                break;
            case Direction.Left:
                //this.transform.position -= Vector3.right * RunSpeed * Time.deltaTime;
                rigibody2D.velocity = Vector3.left * RunSpeed;
                break;
            default:
                break;
        }
    }
}
