using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Castle : MonoBehaviour
    {
        [SerializeField] private float initialHealth = 100.0f;
        [SerializeField] private Slider barraVida;
    
        private float _currentHealth;

        private void Start()
        {
            _currentHealth = initialHealth;
            barraVida.maxValue = initialHealth;
            barraVida.value = initialHealth;
        }
    
        public void LoseHealth(float damage)
        {
            _currentHealth -= damage;
            barraVida.value = _currentHealth;
        }
    }
}

