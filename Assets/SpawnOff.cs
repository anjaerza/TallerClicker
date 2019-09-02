using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOff : MonoBehaviour
{
    private float tiempoTrans;
    private float tiempoTotal;
    // Start is called before the first frame update
    void Start()
    {
        tiempoTrans = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTrans += Time.deltaTime;
        if (tiempoTrans >= tiempoTotal)
        {
            GetComponent<Spawn>().enabled = true;
        }
    }

    public void ApagarSpawn(float tiempo)
    {
        GetComponent<Spawn>().enabled = false;
        tiempoTrans = 0;
        tiempoTotal = tiempo;
    }
}
