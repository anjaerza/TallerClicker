using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]private float rate;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int tamano;
    [SerializeField] private GameObject[] spawnPoints;
    private int rnd;
    private int rnd2;

    // Start is called before the first frame update
    void Start()
    {
        /*PoolingEnemigos.PreInstanciar(prefab, tamano);
        InvokeRepeating("Generar", 1, rate);
        Random rnd = new Random();*/

        InvokeRepeating("Instanciar", 2, rate);
    }

    // Update is called once per frame
    void Update()
    {
         rnd = Random.Range(0, 3);
        rnd2 = Random.Range(0, 9);
        
        
    }

    void Instanciar()
    {
        Instantiate(prefabs[rnd2], spawnPoints[rnd].transform.position, Quaternion.identity);
    }

}
