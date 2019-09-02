using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour

    
{

    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private int numEnemigos;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        numEnemigos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fodder")
        {
            numEnemigos++;
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag!="Shock")
        {
            Destroy(collision.gameObject);
        }
    }
}
