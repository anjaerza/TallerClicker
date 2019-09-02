using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LibreriaTienda;

public class skill : MonoBehaviour
{
    public Habilidad storeItem;
    [SerializeField] private float cooldown;
    public Image cooldownimage;
    private bool incooldown = false;
    private Button presionable;
    [SerializeField] private string poder;
    private shoot disparotorreta;
    [SerializeField] private int nivelActual;
    
    private const int nivelMax = 3;
    private bool CanUseOverkill = false;
    private float goldCounterA;
    private float goldCounterB;
    private int Actuallevel;


    [SerializeField] private float duracionBer;
    [SerializeField] private int danoShock;
    [SerializeField] private int vidaEscudo;
    [SerializeField] private float tiempoEscudo;

    [SerializeField] private float coste;
    [SerializeField] Text texto;
    private GameObject[] enemigosActivos;

    public int DanoShock { get => danoShock; set => danoShock = value; }
    public int VidaEscudo { get => vidaEscudo; set => vidaEscudo = value; }
    public float TiempoEscudo { get => tiempoEscudo; set => tiempoEscudo = value; }

    private void Start()
    {

        storeItem = new Habilidad();
        storeItem.tipoMoneda = 1;
        presionable = GetComponent<Button>();
        disparotorreta = GameObject.Find("Torreta").GetComponent<shoot>();
        nivelActual = 0;

    }
    // Update is called once per frame
    void Update()
    {
        storeItem.precio[1] = coste;
        storeItem.itemName = gameObject.name;
        GameObject barranivel = GameObject.Find("BarraNivel");
        level nivel = barranivel.GetComponent<level>();
        Actuallevel = nivel.Nivelactual;
        GameObject torreta = GameObject.Find("Torreta");
        banco fondos = torreta.GetComponent<banco>();
        goldCounterA = fondos.goldCounterA;
        goldCounterB = fondos.goldCounterB;

        if (Actuallevel >= 35 && goldCounterA >= coste && goldCounterB >= coste)
        {
            CanUseOverkill = true;
        }
        if (Actuallevel < 35 || goldCounterA < coste || goldCounterB < coste)
        {
            CanUseOverkill = false;
        }

        if (incooldown == true)
        {

            cooldownimage.fillAmount -= 1 / cooldown * Time.deltaTime;
        }
        if (cooldownimage.fillAmount == 0 && poder != "Overkill")
        {
            incooldown = false;
            presionable.interactable = true;
        }
        else if (poder == "Overkill")
        {


            if (CanUseOverkill == false)
            {
                presionable.interactable = false;
            }
            if (CanUseOverkill == true && cooldownimage.fillAmount == 0)
            {

                incooldown = false;
                presionable.interactable = true;


            }




        }
        texto.text = coste.ToString("F");
       

    }
    public void Click()
    {
        //Acá tengo un problema.Overkill solo deberia poderse presionar cuando se es lvl 35 o más, pero eso no se está cumpliendo.
        //La parte de else if(poder!="Overkill") sí funciona. Esa parte hace funcionar a los demás poderes.
        //Ninguna habilidad tiene aún un sistema que cobre.
        if (poder == "Overkill")
        {




            GameObject.Find("Torreta").GetComponent<banco>().goldCounterA -= coste;
            GameObject.Find("Torreta").GetComponent<banco>().goldCounterB -= coste;

            coste = coste * 2;

            presionable.interactable = false;
            cooldownimage.fillAmount = 1;
            incooldown = true;



        }

        else if (poder != "Overkill")
        {
            presionable.interactable = false;
            cooldownimage.fillAmount = 1;
            incooldown = true;

            if (poder == "Barrido")
            {
                disparotorreta.Tipob = 1;
            }

            if (poder == "Berserk")
            {
                disparotorreta.BerserkerOn(true, duracionBer);
            }

            if (poder == "Barrera")
            {
                GameObject.Find("escudo").GetComponent<Escudo>().PonerEscudo();
            }
        }

    }
    public void Mejorar()
    {
        if (nivelActual < nivelMax)
        {

                if (poder == "Barrido")
                {
                    
                    DanoShock = DanoShock * nivelActual + 1;
                    cooldown = cooldown * (2 / 3);
                    coste = coste * 2;
                    nivelActual++;

                }

                if (poder == "Berserk")
                {
                   
                    duracionBer = duracionBer + duracionBer * (1 / 2);
                    cooldown = cooldown * (2 / 3);
                    coste = coste * 2;
                    nivelActual++;
                }

                if (poder == "Barrera")
                {
                   
                    VidaEscudo += 2;
                    TiempoEscudo += 2;
                    cooldown = cooldown * (2 / 3);
                    coste = coste * 2;
                    nivelActual++;
                }
            
        }
    }


}
