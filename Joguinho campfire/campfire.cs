using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfire : MonoBehaviour
{
    public float madeiras;
    public float tempoPorMadeira;
    public LayerMask lp;
    int maxmadeiras = 20;
    public player player;
    void Start()
    {
        madeiras = maxmadeiras / 2;
    }

    // Update is called once per frame
    void Update()
    {
        madeiras -= 1 * Time.deltaTime / tempoPorMadeira;
        Collider[]chequeplayer = Physics.OverlapSphere(transform.position, 1, lp);
        if (chequeplayer.Length != 0){
            madeiras += player.madeira;
            player.madeira = 0;
            player.madeira = 0;
        }
    }
}
