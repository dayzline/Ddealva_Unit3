using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLefter : MonoBehaviour
{
    public float leftMove;
    public PlayerController p1;
    private float playerBounds = -5;

    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p1.gameOver == false)
            transform.Translate(Vector3.left * leftMove * Time.deltaTime);

        if (transform.position.y < playerBounds)
            Destroy(gameObject);
    }
}
