using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviEnemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector2.one;
        velocidad = GetComponent<enemymanager>().Speed;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("pared (1)").GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("pared (1)").GetComponent<Collider2D>());
        if (GetComponent<enemymanager>().TipoEnemigo != "General")
        {
            transform.position += Vector3.up * -1 * velocidad * Time.deltaTime;
        }
        else
        {

            transform.position += dir * -1 * velocidad*3 * Time.deltaTime;
            
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pared")
        {
            dir.x = (dir.x) * -1;
        }
    }
}
