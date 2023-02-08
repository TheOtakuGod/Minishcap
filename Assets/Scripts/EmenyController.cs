using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private PlayerController PlayerController;
    public float speed;
    Animator animator;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameObject PlayerControllerObject = GameObject.FindWithTag("PlayerController");

        if (PlayerControllerObject != null)
        {
            PlayerController = PlayerControllerObject.GetComponent<PlayerController>();
            print("Found the PlayerController Script!");
        }

        if (PlayerController == null)
        {
            print("Cannot find GameController Script!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnConliisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }


}
