using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LibreriaTienda;

public class Upgrade : MonoBehaviour
{
    public Mejora storeItem;
    [SerializeField] private float cooldown;
    public Image cooldownimage;
    private bool incooldown = false;
    private Button presionable;
    [SerializeField] public int coste;
    private GameObject nivel;
    private GameObject torreta;
    [SerializeField] Text texto;
    [SerializeField] private string poder;
    private const int MAXMEJORA=3;
    [SerializeField] private int nivmejora;

    private void Start()
    {
        storeItem = new Mejora();
        storeItem.tipoMoneda = 0;
        presionable = GetComponent<Button>();
        coste = 1;
        nivel = GameObject.Find("BarraNivel");
        torreta = GameObject.Find("Torreta");
        nivmejora = 0;
        
    }
    // Update is called once per frame
    void Update()
    {
        storeItem.precio[0] = coste;
        storeItem.itemName = gameObject.name;
        texto.text = coste.ToString("F");
        if (incooldown == true)
        {

            cooldownimage.fillAmount -= 1 / cooldown * Time.deltaTime;
        }
        if (cooldownimage.fillAmount == 0)
        {
            incooldown = false;
            presionable.interactable = true;
        }
    }
    public void Click()
    {
        if (nivmejora<MAXMEJORA)
        {
            coste *= 2;
            nivmejora++;
            presionable.interactable = false;
            shoot disparotorreta = torreta.GetComponent<shoot>();
            cooldownimage.fillAmount = 1;
            incooldown = true;

            if (poder == "id")
            {
                disparotorreta.Dano+= 15;
            }

            else if (poder == "aoe")
            {
                disparotorreta.Rangoaoe++;
            }
            else
            {
                disparotorreta.Fuerza+= 5;
            }
            
        
        }
    }
}
