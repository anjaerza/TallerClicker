using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    Transform puntomuerte;
    [SerializeField] private float baseGold;
    GameObject Banco;
   
    private float goldDrop;
   
    GameObject barranivel;
    level nivel;
    [SerializeField]private float m;




    public float GoldDrop { get => goldDrop; set => goldDrop = value; }
    public float M { get => m; set => m = value; }
    public float BaseGold { get => baseGold; set => baseGold = value; }

    // Start is called before the first frame update
    void Start()
    {   
        
        barranivel = GameObject.Find("BarraNivel");
        nivel = barranivel.GetComponent<level>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        GoldDrop = BaseGold * ((nivel.Nivelactual - 1) * 10)*M;


       

    }
    void OnMouseDown()
    {
        Clickeado();
        

        


    }
    void Clickeado()
    {


        Banco = GameObject.Find("Torreta");
        banco contadormonedas = Banco.GetComponent<banco>();

        contadormonedas.goldCounterA += GoldDrop;

        Destroy(this.gameObject);


    }
}
