using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZibuMovement : NetworkBehaviour
{
    [SerializeField] private float speed = 20f;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    [ClientCallback]
    void Update()
    {
        if (!isOwned) return;

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            CmdMove();
        }
    }

    [Command]
    public void CmdMove()
    {
        _rb.velocity = new Vector3(0, 0, speed * Input.GetAxis("Vertical"));
    }

}
