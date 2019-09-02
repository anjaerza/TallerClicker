using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : MonoBehaviour
{
    private GameObject habilidad;
    // Start is called before the first frame update
    void Start()
    {
        habilidad = GameObject.Find("barrido");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fodder")
        {
            Debug.Log("AAAAAAAAAAAA VIVA MADURO");
            collision.GetComponent<enemymanager>().Recibedano(habilidad.GetComponent<skill>().DanoShock);
        }
    }
}
