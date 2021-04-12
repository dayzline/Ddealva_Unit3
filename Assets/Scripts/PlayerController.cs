using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravMod;
    public float jumpMod;
    private bool onGround = true;

    void Start()
    {
       rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravMod;
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if (spaceDown)
        {
            rbPlayer.AddForce(Vector3.up * jumpMod, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;

    }
}
