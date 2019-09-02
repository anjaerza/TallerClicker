using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemymanager : MonoBehaviour
{
    [SerializeField]private float health = 100;
    [SerializeField]private float actualHp ;
    [SerializeField] private Rigidbody2D rbcoinA;
    [SerializeField] private Rigidbody2D rbcoinB;
    private Transform puntomuerte;
    [SerializeField] private int probmonedaB;
    [SerializeField] private int random;
    public float puntuacionnivel;
    [SerializeField]private Image barranivel;

    [SerializeField] private string tipoEnemigo;
    [SerializeField] private float speed;
    [SerializeField] private int multip;

    GameObject enemigo;
    GameObject torreta;


    public float ActualHp { get => actualHp; set => actualHp = value; }
    public float Speed { get => speed; set => speed = value; }
    public string TipoEnemigo { get => tipoEnemigo; set => tipoEnemigo = value; }


    // Start is called before the first frame update
    void Start()
    {
        barranivel = GameObject.Find("BarraNivel").GetComponent<Image>();
        ActualHp = health;
        enemigo = GameObject.Find(TipoEnemigo);
        Speed = 0.2f;
        health = 100;

        health = health * (1 + (GameObject.Find("BarraNivel").GetComponent<level>().Nivelactual)/5);
        Speed = Speed * (1 + (GameObject.Find("BarraNivel").GetComponent<level>().Nivelactual)/5);



       
  
        //Lo que dice multip es el multiplicador de dinero, eso lo estoy aplicando en el codigo de más abajo, en la parte del GoldDrop

        if (TipoEnemigo == "FodderPlus")
        {
            multip = 2;
            health = health * 3;
            Speed = Speed * 1.5f;
        }

        if(TipoEnemigo == "General")
        {
            multip = 6;
            health = health * 2;
            Speed = Speed * 2f;
        }
        if (TipoEnemigo == "Fodder")
        {
            multip = 1;
        }


    }

    // Update is called once per frame
    void Update()
    {
        torreta = GameObject.Find("Torreta");
        shoot berserk = torreta.GetComponent<shoot>();
        puntomuerte = GetComponent<Transform>();
       
        if (ActualHp <= 0)
        {
            barranivel.fillAmount += puntuacionnivel / 100;
            random = Random.Range(1, 100);
            if (random <= probmonedaB)
            {
                if (berserk.Berserker == true)
                {
                    Rigidbody2D rbbalaclon = Instantiate(rbcoinB, puntomuerte.position, puntomuerte.rotation);

                    Coin2 clonescript = rbbalaclon.GetComponent<Coin2>();


                    clonescript.M = multip*3;

                    
                    Destroy(gameObject);
                }
                if (berserk.Berserker == false)
                {
                    Rigidbody2D rbbalaclon = Instantiate(rbcoinB, puntomuerte.position, puntomuerte.rotation);

                    Coin2 clonescript = rbbalaclon.GetComponent<Coin2>();


                    clonescript.M = multip ;

                   
                    Destroy(gameObject);
                }

            }
            else if(random >= probmonedaB)
            {
                if (berserk.Berserker == false)
                {
                    Rigidbody2D rbbalaclon = Instantiate(rbcoinA, puntomuerte.position, puntomuerte.rotation);
                    Coin clonescript = rbbalaclon.GetComponent<Coin>();

                    clonescript.M = multip;

                    
                    Destroy(gameObject);
                }
                if (berserk.Berserker == true)
                {
                    Rigidbody2D rbbalaclon = Instantiate(rbcoinA, puntomuerte.position, puntomuerte.rotation);
                    Coin clonescript = rbbalaclon.GetComponent<Coin>();

                    clonescript.M = multip*3;
                    
                    Destroy(gameObject);
                }
            }

            
        }
    }

    public void Recibedano(int dano)
    {
        ActualHp -= dano;
    }
    
  

}
