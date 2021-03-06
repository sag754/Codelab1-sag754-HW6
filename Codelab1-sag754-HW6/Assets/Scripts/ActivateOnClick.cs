﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnClick : MonoBehaviour
{
    Rigidbody rb; //var for rigidbody

    public AudioClip boop;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get RigidBody Component
        rb.isKinematic = true; //Make it Kinematic (ie, doen't move with physics)
        GetComponent<AudioSource>().clip = boop;
    }

    private void OnMouseDown() //if you click on the object
    {
        rb.isKinematic = false; //make it able to move w/ physics
    }

    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
