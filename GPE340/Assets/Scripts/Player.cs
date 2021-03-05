using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pawn
{
    // Gives the Designers a tip for the speed variable
    [SerializeField] private Animator animator;
    public float rotateSpeed = 135f;
    public float speed = 1f;

 

    public override void Start()
    {
        // Grabs the Animator component attached to current object.
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {

    }


    // Our Move function for our player, needing a direction to move in.
    public override void Move(Vector3 moveDirection)
    {

        // Converts direction of movement from local space to world direction
        moveDirection = transform.InverseTransformDirection(moveDirection);

        // Set our animation parameters based on our movement data
        animator.SetFloat("Vertical", moveDirection.z * speed);
        animator.SetFloat("Horizontal", moveDirection.x * speed);
        base.Move(moveDirection);
    }

    // Allows our character to rotate towards our mouse
    public override void RotateTowards(Vector3 rotateTarget)
    {
        // Sets up a holding variable for our target location to rotate
        Quaternion targetRotation;

        //  Creates a vector to hold where we want to rotate towards
        Vector3 vectorToTarget = rotateTarget - transform.position;
        // Locks the Direction of Rotation, so it's only turning one way.
        targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        // Changes our rotation to match our desired location based off of frame updates.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        base.RotateTowards(rotateTarget);
    }

}
