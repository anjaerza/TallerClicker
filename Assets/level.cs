using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class level : MonoBehaviour
{
    private Image barranivel;
    private GameObject textonivelactual;
    [SerializeField]private int nivelactual;
    [SerializeField] private int puntos;

    public int Nivelactual { get => nivelactual; set => nivelactual = value; }
    public int Puntos { get => puntos; set => puntos = value; }

    // Start is called before the first frame update
    void Start()
    {
        textonivelactual = GameObject.Find("NivelActual");
        barranivel = GetComponent<Image>();
        Puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {
         Text texto = textonivelactual.GetComponent<Text>();
        

        if (barranivel.fillAmount >= 1)
        {
            barranivel.fillAmount = 0;
            Nivelactual++;
            Puntos++;
        }
        texto.text = Nivelactual.ToString();
    }
}
