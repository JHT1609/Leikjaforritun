using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*refrence https://www.youtube.com/watch?v=kWhOMJMihC0*/

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
    public GameObject crossHair;
    public GameObject arrowPrefab;

    public int damageB1;
    public int damageB2;
    public int damageB3;

    public Vector2 movementDirection;
    public float movementSpeed;

    public Rigidbody2D rb;
    public Animator animator;

    private Rigidbody2D myrigidbody2D;

    private Vector3 mousePosition;
    private Vector2 crosshairPos;
    private Vector2 transform2D;
    private Quaternion arrowRotation;

    public GameObject bigMap;

    private void Awake()
    {
        count = 100;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessInputs();
        Move();
        Animate();
    }

    private void Update()
    {

        //crossHair.transform.position = Input.mousePosition.x;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        crosshairPos.x = mousePosition.x;
        crosshairPos.y = mousePosition.y;

        crossHair.transform.position = crosshairPos;

        transform2D.x = transform.position.x;
        transform2D.y = transform.position.y;

        if (Input.GetButtonDown("Fire1"))
        {
            
            arrowRotation = Quaternion.FromToRotation(Vector2.right, crosshairPos - transform2D);
            GameObject arrow = Instantiate(arrowPrefab, transform.position, arrowRotation);
            arrow.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(250f, 0));
            Destroy(arrow, 10.0f);
        }

        if (Input.GetKeyDown("m"))
        {
            bigMap.SetActive(true);
        }
        else if (Input.GetKeyUp("m"))
        {
            bigMap.SetActive(false);
        }

        SetCountText();
        loseText.text = "You Lose :(";
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
        // Hér er verið að skoða hvað hver óvinur á að meiða mikið
        if (other.gameObject.CompareTag("Enemy"))
        {
            count = count - 5;
            health -= 5;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Boss1"))
        {
            count = count - damageB1;
            health -= damageB1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Boss2"))
        {
            count = count - damageB2;
            health -= damageB2;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Boss3"))
        {
            count = count - damageB3;
            health -= damageB3;
            SetCountText();
        }
        // ------------------------------------

        if (other.gameObject.tag == "Euphoria")
        {
            Destroy(other.gameObject);
            MOVEMENT_BASE_SPEED = 6.5f;
            health = 200;
            StartCoroutine(ResetPower());
        }
    }
    void SetCountText()
    {
        Health.text = "Health: " + health;
        if (health <= 0)
        {
            loseLvlUI.SetActive(true);
            loseText.text = "You Lose :(";
            gameObject.SetActive(false);
        }
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage");
        print("HIT!");
    }
    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(10);
        MOVEMENT_BASE_SPEED = 4.0f;
        health = 100;
    }
}
