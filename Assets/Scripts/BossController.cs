using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private PlayerController PlayerController;
    public float speed;
    Animator animator;
    private float distance;
    public GameObject Player;

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
        distance = Vector2.Distance(transform.position, Player.transform.position);

        Vector2 direction = Player.transform.position - transform.position;

        direction.Normalize();

        float angle = Mathf.Atan(direction.x) * Mathf.Rad2Deg;

        if (distance < 7)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }



    void OnConliisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-2);
        }
    }

}
