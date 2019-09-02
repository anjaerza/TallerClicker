using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LibreriaTienda;


public class banco : MonoBehaviour
{
   
    
    [SerializeField] private Text textomoneda;
    [SerializeField] private Text sufix;
    [SerializeField] private Text textomoneda2;
    [SerializeField] private Text sufix2;
    public float goldCounterA;
    public float goldCounterB;
    private float Mostrarpuntuacion;
    private float Mostrarpuntuacion2;

    
    
    





    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        textomoneda.text = Mostrarpuntuacion.ToString("F1");
        textomoneda2.text = Mostrarpuntuacion2.ToString("F1");

        if (goldCounterA <= 999.9f )
        {



            Mostrarpuntuacion = goldCounterA;

        }

        if (goldCounterA >999.9f && goldCounterA<= 999999.9f)
        {
            sufix.text = "K";
            
            
            Mostrarpuntuacion = goldCounterA / 1000;
            
        }
        if (goldCounterA > 999999.9f && goldCounterA<= 999999999.9f)
        {
            sufix.text = "M";

            
            Mostrarpuntuacion = goldCounterA / 1000000;
            
        }
        if (goldCounterA >999999999.9f && goldCounterA <= 999999999999.9f) 
        {
            sufix.text = "MM";
            
            Mostrarpuntuacion = goldCounterA / 1000000000;
            
        }
        if (goldCounterA > 999999999999.9f && goldCounterA <= 999999999999999.9f)
        {
            sufix.text = "B";
            
            Mostrarpuntuacion = goldCounterA / 1000000000000;
            

        }


        if (goldCounterA > 999999999999999.9f )
        {
            sufix.text = "BB";
            
            Mostrarpuntuacion = goldCounterA / 1000000000000000;
            

        }


        if (goldCounterB <= 999.9f)
        {



            Mostrarpuntuacion2 = goldCounterB;

        }


        if (goldCounterB > 999.9f && goldCounterB <= 999999.9f)
        {
            sufix2.text = "K";

           
            Mostrarpuntuacion2 = goldCounterB / 1000;
            
        }
        if (goldCounterB > 999999.9f && goldCounterB <= 999999999.9f)
        {
            sufix2.text = "M";
            

            Mostrarpuntuacion2 = goldCounterB / 1000000;
            
        }
        if (goldCounterB > 999999999.9f && goldCounterB <= 999999999999.9f)
        {
            sufix2.text = "MM";
            Mostrarpuntuacion2 = goldCounterB / 1000000000;
           
        }
        if (goldCounterB > 999999999999.9f && goldCounterB <= 999999999999999.9f)
        {
            sufix2.text = "B";
            Mostrarpuntuacion2 = goldCounterB / 1000000000000;
           

        }


        if (goldCounterB > 999999999999999.9f )
        {
            sufix2.text = "BB";
            Mostrarpuntuacion2 = goldCounterB / 1000000000000000;
           

        }

    
    }
   
   
   
}
