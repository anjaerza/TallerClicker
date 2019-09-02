using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibreriaTienda;
public class ManagerTienda : MonoBehaviour
{

   public StoreManager SM;
    public PlayerWallet billetera;
    public banco bc;
    
    // Start is called before the first frame update
    void Start()
    {
        billetera = new PlayerWallet();
        SM = new StoreManager(billetera);

        SM.billetera.dineroJugador[0] = bc.goldCounterA;
        SM.billetera.dineroJugador[1] = bc.goldCounterB;

    }


    void Update()
    {
        SM.billetera.dineroJugador[0] = bc.goldCounterA;
        SM.billetera.dineroJugador[1] = bc.goldCounterB;




        Debug.Log(SM.billetera.dineroJugador[1]);

    }
    public void ComprarUpgrade( Upgrade p) {
        Mejora item = new Mejora();

       
        item = p.storeItem;
        if(SM.CanPurcheaseItem(item))
        {
            SM.BuyItem(item);
            
            bc.goldCounterA = SM.billetera.dineroJugador[0];
            bc.goldCounterB = SM.billetera.dineroJugador[1];
            p.Click();


        }
        
        
       



    }
    public void ComprarSkill(skill p)
    {
        Habilidad item = new Habilidad();

        item = p.storeItem;


        SM.BuyItem(item);
        if(SM.CanPurcheaseItem(item))
        {
            p.Mejorar();
            bc.goldCounterA = SM.billetera.dineroJugador[0];
            bc.goldCounterB = SM.billetera.dineroJugador[1];


        }


        
        



    }
    
}
