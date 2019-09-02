using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockmove : MonoBehaviour
{
    [SerializeField] private GameObject destino;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        destino = GameObject.Find("centro");
        transform.position=Vector3.MoveTowards(transform.position, destino.transform.position, 100 * Time.deltaTime);
    }
}
