using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    public TMP_Text countText;
    public TMP_Text GameOverText;
    private int countValue = 0;
    private int countAmount;
    private int scoreAmount;
    private int scoreValue = 0;
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
    public AudioClip healthSound;
    public AudioClip fairySound;
    AudioSource audioSource;
    Rigidbody2D rigidbody2d;
    Animator animator;
    bool gameOver;
    public GameObject projectilePrefab;

    public GameObject healthPrefab;

    public GameObject hitPrefab;
    



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        SetCountText();

        level =  1;

        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        currentHealth = 5;
        GameOverText.text = "";
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

        rigidbody2d.MovePosition(position);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            countValue = countValue + 1;

            SetCountText();
        }

          

        if (other.gameObject.CompareTag("Door"))
        {
            if (countValue == 1)
            {
                SceneManager.LoadScene("Second Scene");
            }
        }
    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void Update()
    {
        Vector2 move = new Vector2(horizontal, vertical);

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }


        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.G))
        {
            isInvincible = true;
            animator.SetTrigger("Block");
        }
        
        if (Input.GetKeyUp(KeyCode.G))
        {
            isInvincible = false;
        }


        if (Input.GetKey("spacebar"))
        {
            animator.SetTrigger("Roll");
        }



        if (Input.GetKey(KeyCode.R))
        {

            if (gameOver == true)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 

            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            animator.SetTrigger("Hit");

            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

        }

        if (currentHealth < 1)
        {
            speed = 0;
            GameOverText.text = "You lose! Press R to restart";
            gameOver = true;
            audioSource.Stop();
            audioSource.PlayOneShot(loseSound);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

        if (amount >= 0)
        {
            GameObject projectileObject = Instantiate(healthPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        }
    }

    void SetCountText()
    {
        countText.text = "Count value: " + countValue.ToString();
    }

    public void ChangeScore(int scoreAmount)
    {
        scoreValue += 1;

        if (scoreValue >= 1)
        {
            gameOver = true;
            GameOverText.text = "You Win! Game by Romeo, Bailey Rowles, Robert Guzman, and Skyler Donovan";
            audioSource.Stop();
            audioSource.PlayOneShot(winSound);

        }

    }

}