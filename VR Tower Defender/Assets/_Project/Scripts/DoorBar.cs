using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorBar : MonoBehaviour
{
    [SerializeField] private float initialHealth = 100.0f;

    private float _currentHealth;
    private int damage = 10;

    [SerializeField] private Slider barraVida;

    private void Start()
    {
        _currentHealth = initialHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _currentHealth -= damage;
            barraVida.value = _currentHealth;
            print(_currentHealth);
        }
    }
    public void LoseHealth(float damage)
    {
        _currentHealth -= damage;
        print(_currentHealth);
    }
}

