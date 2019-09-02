using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour

{

    [SerializeField] private int resistencia;
    [SerializeField] private int resMax;

    [SerializeField] private float tiempMax;


    private float tiempoTrans;
    // Start is called before the first frame update
    void Start()
    {
        tiempMax= GameObject.Find("barrera").GetComponent<skill>().TiempoEscudo;
        resMax = GameObject.Find("barrera").GetComponent<skill>().VidaEscudo;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        resistencia = resMax;
        tiempoTrans = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTrans += Time.deltaTime;
        if (resistencia <= 0 || tiempoTrans>tiempMax)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (resistencia > 0)
        {
            if (collision != null && (collision.gameObject.tag == "Fodder" || collision.gameObject.tag == "FooderPlus" || collision.gameObject.tag == "General"))
            {

                collision.gameObject.GetComponent<enemymanager>().Recibedano(100);
                resistencia--;
            }
        }
        
    }

    public void PonerEscudo()
    {
        tiempMax = GameObject.Find("barrera").GetComponent<skill>().TiempoEscudo;
        resMax = GameObject.Find("barrera").GetComponent<skill>().VidaEscudo;
        resistencia = resMax;
        tiempoTrans = 0;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;


    }
}
