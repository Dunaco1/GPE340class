using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Allows designers to allow what target for our camera to follow
    public Transform targetToFollow;

    // variable to hold our height that we want the camera to remain at.

    public Vector3 offset;

    // LateUpdate is called once per frame after the Update() for smooth transistion after movement has been made in Update()
    void LateUpdate()
    {
        // Sets our camera's position to the location of the gameobject we want to follow without changing the height it is at.
        transform.position = targetToFollow.position + offset;
    }
}
