using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float input;
    public Text healthUI;
    public float moveSpeed = 10f;
    Rigidbody2D rb;
    Animator amin;
    public int health;
    public GameObject panel;
    // adding dash step
    public float dashStartTime;
    private float dashTime;
    private bool isDashing;
    public float dashSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
        healthUI.text = health.ToString(); // pay attention to the text properties
    }
     void Update()
    {
        if (input != 0)
        {
            amin.SetBool("isRunning", true);
        }
        else
        {
            amin.SetBool("isRunning", false);
        }
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false) { // press space to active dash status and also isDashing = false
            moveSpeed += dashSpeed; // increase the moving speed
            isDashing = true;
            dashTime = dashStartTime; // set the dash time to dash start time(THIS CAN BE INITIALIZED IN UNITY SINCE IT'S PUBLIC)

        }
        if (dashTime <= 0 && isDashing == true) // dash is over
        {
            isDashing = false;
            moveSpeed -= dashSpeed; // restore the original speed
        }
        else
        {
            dashTime -= Time.deltaTime; // decrease the dash time as time goes by
        }
    }

    // Update is called once per frame
    void FixedUpdate() // use the FixedUpdate funtion because we used the physicss
    {
        input = Input.GetAxisRaw("Horizontal");
        //Vector2 origin = new Vector2(0f, 0f);
        rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);

    }

    public void takeDamage(int damage)
    {
        health -= damage;
        healthUI.text = health.ToString();
        if (health <= 0)
        {
            // destroy the player
            healthUI.text = "0";
            panel.SetActive(true);
            Destroy(gameObject); // gameObject refers the object that this script attached to
        }
        // health -= damage;
    }
}
