using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float speed;
    public int damage;
    Player player;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        //player.takeDamage(damage);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.takeDamage(damage);
            print("We hit the playerrrr!!");
            // create the effect where the enemy hits the player
            Instantiate(particle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.tag == "ground")
        {
            // create the effect where the enemy hits the ground
            Instantiate(particle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
