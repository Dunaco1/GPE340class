using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Controller
{
    private Animator anim;
    private Camera playerCamera;

    // Start is called before the first frame update
    public override void Start()
    {

        // Set this Camera (player Camera) to the mainCamera tag
        playerCamera = Camera.main;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Calls the Move function from our pawn gathered from our parent class, 
        // and sends the inputs for the Horizontal and Vertical Axis.
        pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        base.Update();

        // Rotate towards the Mouse Cursor in Game Space
        pawn.RotateTowards(GetMousePosition());

    }


    public Vector3 GetMousePosition()
    {
        // Creates a Vector to hold the mouse's position.
        Vector3 mouseCursorInGame = new Vector3();

        // Gets the plane that our Character is on
        Plane playerPlane = new Plane(Vector3.up, pawn.transform.position);

        // Casts the Ray for our Mouse position
        Ray cursorRay = new Ray();
        cursorRay = playerCamera.ScreenPointToRay(Input.mousePosition);

        // See if our mouse ray hits the plane the player is on
        float hitDistance;
        if (playerPlane.Raycast(cursorRay, out hitDistance))
        {
            // sets the location of the ray to our returning variable
            mouseCursorInGame = cursorRay.GetPoint(hitDistance);
        }

        // Send the cursor's location
        return mouseCursorInGame;
    }
}
