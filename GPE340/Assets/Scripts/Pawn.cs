using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public virtual void Awake()
    {

    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    // Base creation of our Pawn Move function
    public virtual void Move(Vector3 moveDirection) { }

    // Base creation of our RotateTowards Function
    public virtual void RotateTowards(Vector3 rotateTarget)
    {

    }
}
