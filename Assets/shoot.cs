using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject spawn;
    public Rigidbody2D[] rbbala;
    [SerializeField] private int fuerza;
    [SerializeField] private int dano;
    [SerializeField] private int rangoaoe;

    [SerializeField] private int tipob;
    [SerializeField] private bool berserker;
    private float duracionBerserker;
    private float tiempoTrans;

    [SerializeField] private float tiempoentredisparos;
    [SerializeField] private float Nuevofirerate;
    private int contador ;
    float valoriginal;


    [SerializeField]private float tasadisparo = 1;

    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Dano { get => dano; set => dano = value; }
    public int Rangoaoe { get => rangoaoe; set => rangoaoe = value; }

    public float Tasadisparo { get => tasadisparo; set => tasadisparo = value; }
    public int Tipob { get => tipob; set => tipob = value; }
    public bool Berserker { get => berserker; set => berserker = value; }



    // Use this for initialization
    void Start()
    {
       
            StartCoroutine("Empezar");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Berserker == false)
        {
            valoriginal = tiempoentredisparos;
        }
        if (Berserker == true)
        {
            tiempoTrans += Time.deltaTime;
            if (tiempoTrans < duracionBerserker)
            {
                //Esto es lo que traté de hacer para que el berserker aumente la plata, modifica un multiplo M.
                //Cuidado con tocar cualquier cosa que no tenga M, eso es para el Berserker y eso sí funciona.

                tiempoentredisparos = valoriginal /4;
                
            }
            else
            {
                tiempoentredisparos = valoriginal;

                

                Berserker = false;
                tiempoTrans = 0;
            }
        }
     
        Destroy(GameObject.Find("sbala(Clone)"), 1);
        Nuevofirerate  = tiempoentredisparos / Tasadisparo;
           

            if (Tasadisparo <= 1 )
            {
                Tasadisparo = 1;

          
           
            }
            else
            {
                Tasadisparo -= Time.deltaTime*4 ;

            }
            if ( Nuevofirerate<= 0.2)
            {
            
                Nuevofirerate = 0.2f;
            }
        

        if (Input.GetButtonDown("Fire1"))

        {
    
            //Rigidbody2D rbbalaclon = Instantiate(rbbala, spawn.transform.position, spawn.transform.rotation);
           // rbbalaclon.AddForce(transform.right * fuerza);
            Tasadisparo++;
        }

       


    }
    IEnumerator Shoot()
    {



        while (contador < 1 )
        {


            Rigidbody2D rbbalaclon = Instantiate(rbbala[Tipob], spawn.transform.position, spawn.transform.rotation);
            rbbalaclon.velocity = (transform.right * Fuerza);
            if (Tipob == 1)
            {
                Tipob = 0;
            }
            yield return new WaitForSeconds(Nuevofirerate);


        }


    }
    IEnumerator Empezar()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine("Shoot");

    }

    public void BerserkerOn(bool estado, float tiempo)
    {
        Berserker = estado;
        duracionBerserker = tiempo;

    }
    
}
