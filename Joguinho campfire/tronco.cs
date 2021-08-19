using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronco : MonoBehaviour
{
    public player player ;
    public LayerMask lplayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] chequeplayer = Physics.OverlapSphere(transform.position, 1, lplayer);
        if (chequeplayer.Length != 0)
        {
            player.madeira += 60 * Time.deltaTime;
            Destroy(gameObject);
        }
    }
}
    