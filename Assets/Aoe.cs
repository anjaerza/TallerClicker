using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aoe : MonoBehaviour
{

    private Animator anim;
    [SerializeField]private int rango;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rango = GameObject.Find("Torreta").GetComponent<shoot>().Rangoaoe;
    }

    // Update is called once per frame
    void Update()
    {
        rango= GameObject.Find("Torreta").GetComponent<shoot>().Rangoaoe;
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Fodder")
        {
            collision.GetComponent<enemymanager>().Recibedano(GameObject.Find("Torreta").GetComponent<shoot>().Dano);
            anim.SetInteger("rango", rango);
            if (rango == 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }

    }
}
