using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    public TMP_Text countText;
    public TMP_Text GameOverText;
    private int countValue = 0;
    private int countAmount;
    int currentHealth;
    public static int level;
    public float timeInvincible = 2.0f;
    float invincibleTimer;
    Vector2 lookDirection = new Vector2(1, 0);
    float horizontal;
    float vertical;

    public int health { get { return currentHealth; } }
    bool isInvincible;
    public int maxHealth = 5;
    public AudioClip backgroundSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip hitSound;
    public AudioClip damageSound;
    AudioSource audioSource;
    Rigidbody2D rigidbody2d;

    bool gameOver;

    public GameObject hitPrefab;
    



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        SetCountText();

        level =  1;
    }

    void FixedUpdate()
    {

        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal");


        float moveVertical = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);


        rb2d.AddForce(movement * speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))

            other.gameObject.SetActive(false);

        countValue = countValue + 1;

        SetCountText();
    }

    void Update()
    {
        Vector2 move = new Vector2(horizontal, vertical);


        horizontal = Input.GetAxis("Horizontal");

        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Door"));
            if (hit.collider != null)
            {
                if (countValue == 1)
                {
                    SceneManager.LoadScene("Second Scene");
                }
            }
        }


    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            
        }

        if (currentHealth < 1)
        {
            speed = 0;
            GameOverText.text = "You lose!";
            gameOver = true;

        }
    }

    void SetCountText()
    {
        countText.text = "Count value: " + countValue.ToString();
    }

}