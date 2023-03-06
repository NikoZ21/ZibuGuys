using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public float speed = 2f; // speed of donut movement
    public float amplitude = 1.5f; // height of the arched path
    public float frequency = 0.5f; // frequency of the arched path

    private Vector3 initialPosition;
    private Rigidbody rigidBody;

    private bool isOntheGround = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yes colliding");
    }

}
