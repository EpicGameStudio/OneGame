using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCMovement : MonoBehaviour {

    #region Field
    public Direction direction;
    public NPCMovementType movementType;
    public float speed;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    #endregion


    private void Awake()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        if (rigidbody2D == null)
            throw new ArgumentNullException("rigidbody2D");

        animator = this.GetComponent<Animator>();
        if (animator == null)
            throw new ArgumentNullException("animator");
        

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
