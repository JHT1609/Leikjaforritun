using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float MOVEMENT_BASE_SPEED = 1.0f;
    public int health;
    public int index;
    public string levelName;

    /*Health system doesnt work yet*/
    [Space(10)]
    public Text loseText;
    public Text Health;
    public GameObject loseLvlUI;
    private int count;
    public GameObject arrowPrefab;

    public Vector2 movementDirection;
    public float movementSpeed;

    public Rigidbody2D rb;
    public Animator animator;

    private void Awake()
    {
        count = 100;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

        SetCountText();
        loseText.text = "";

        ProcessInputs();
        Move();
        Animate();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(5.0f, 0.0f);
        }
    }

    void ProcessInputs() {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        
        animator.SetFloat("Speed", movementSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("HIT!");
            count = count - 50;
            health -= 50;
            SetCountText();
            Debug.Log("damage from enemy");
        }
    }
    void SetCountText()
    {
        Health.text = "Health: " + count.ToString();
        if (count >= 0)
        {
            loseLvlUI.SetActive(true);
            loseText.text = "You Lose :(";
        }
    }
}
