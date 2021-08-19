using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class player : MonoBehaviour
{
    private int vida;
    public float distancia;
    public Transform campfire;
    public float frio;
    public float madeira;
    public Text madeiraTxt;
    public Slider sliderVida;
    public Slider sliderFrio;

    void Start()
    {
        vida = 100;
        frio = 0;
    }

    // Update is called once per frame
    void Update()
    {
        madeira = Mathf.Ceil(madeira);
        distancia = Vector3.Distance(transform.position, campfire.position);
        //print(distancia);
        //frio += 1 * Time.deltaTime;

        if(distancia <= 5)
        {
            frio -= 1 * Time.deltaTime;
        }
        else
        {
            frio += 1 * Time.deltaTime;
        }
        frio = Mathf.Clamp(frio, 0, 100);

        madeiraTxt.text = "Madeiras: " + madeira.ToString();
        sliderVida.value = vida;
        sliderFrio.value = frio;
    }
}
