using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float RunSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    enum Direction
    {
        Up,
        Down,
        Right,
        Left,
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        if (horizontal > 0)
        {
            Move(Direction.Right);
        }
        else if (horizontal < 0)
        {
            Move(Direction.Left);
        }
        else if (vertical > 0)
        {
            Move(Direction.Up);
        }
        else if (vertical < 0)
        {
            Move(Direction.Down);
        }
        new WaitForSeconds(0.08f);
    }

    IEnumerable Wait()
    {
        return null;
    }

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                this.transform.position += Vector3.up * RunSpeed *Time.deltaTime;
                break;
            case Direction.Down:
                this.transform.position -= Vector3.up * RunSpeed * Time.deltaTime;
                break;
            case Direction.Right:
                this.transform.position += Vector3.left * RunSpeed * Time.deltaTime;
                break;
            case Direction.Left:
                this.transform.position -= Vector3.left * RunSpeed * Time.deltaTime;
                break;
            default:
                break;
        }
    }
}
