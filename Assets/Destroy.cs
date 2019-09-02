using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public void Destruirse()
    {
        if (this.gameObject.tag != "Shock")
        {
            Destroy(this.transform.parent.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
