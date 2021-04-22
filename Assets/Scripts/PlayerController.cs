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

    private Animator animPlayer;
    public ParticleSystem splodySystem;
    public ParticleSystem dirtySystem;

    public AudioClip jumpSound;
    public AudioClip bonkSound;

    private AudioSource noiseMaker;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravMod;

        animPlayer = GetComponent<Animator>();

        noiseMaker = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if (spaceDown && onGround && !gameOver)
        {
            rbPlayer.AddForce(Vector3.up * jumpMod, ForceMode.Impulse);
            onGround = false;
            animPlayer.SetTrigger("Jump_trig");
            dirtySystem.Stop();
            noiseMaker.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtySystem.Play();
        }

        else if (collision.gameObject.CompareTag("Obs"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            animPlayer.SetBool("Death_b", true);
            animPlayer.SetInteger("DeathType_int", 2);
            splodySystem.Play();
            noiseMaker.PlayOneShot(bonkSound, 1.0f);
        }
    }
}
