using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPPuerta : MonoBehaviour
{
    [SerializeField] private int vidaPuerta;
    [SerializeField] private Slider barraVida;
    [SerializeField] private int damage = 10;

    private void Update()
    {
        barraVida.value = vidaPuerta;
    }



    private void OnTriggerEnter(Collider other)
    {
        vidaPuerta -= damage;
    }


}
