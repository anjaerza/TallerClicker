using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    private Vector3 mouseposition;
    private Vector3 angulos;
    private int tasadisparos;
    [SerializeField] private GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z >= 0 && transform.rotation.z<=180)
        {
            mouseposition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(mouseposition.y, mouseposition.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
           
           
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

       


    }
}
