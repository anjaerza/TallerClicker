using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{
    Rigidbody2D torretafuerza;
    Rigidbody2D rb;
    GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        torretafuerza = GameObject.Find("Torreta").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        bullet = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Pared")
        {

            GameObject torreta = GameObject.Find("Torreta");
            shoot fuerzatorreta = torreta.GetComponent<shoot>();
            ContactPoint2D hit = collision.GetContact(0);
             rb.velocity= Vector2.Reflect(rb.velocity, hit.normal);
        }


    }
    
    
}
