using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravMod;
    public float jumpMod;
    private bool onGround = true;
    public bool gameOver = false;

    void Start()
    {
       rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravMod;
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if (spaceDown && onGround)
        {
            rbPlayer.AddForce(Vector3.up * jumpMod, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            onGround = true;

        else if (collision.gameObject.CompareTag("Obs"))
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
