using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Castle : MonoBehaviour
    {
        [SerializeField] private float initialHealth = 100.0f;
        [SerializeField] private Slider barraVida;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button youLostButton;
        [SerializeField] private GameObject endPanel;
    
        private float _currentHealth;

        private void Start()
        {
            _currentHealth = initialHealth;
            barraVida.maxValue = initialHealth;
            barraVida.value = initialHealth;
            restartButton.gameObject.SetActive(false);
            youLostButton.gameObject.SetActive(false);
            endPanel.SetActive(false);
        }
    
        public void LoseHealth(float damage)
        {
            _currentHealth -= damage;
            barraVida.value = _currentHealth;
            if (barraVida.value <= 0 )
            {
                restartButton.gameObject.SetActive(true);
                youLostButton.gameObject.SetActive(true);
                endPanel.SetActive(true);
                Spawner.Instance.FinishSpawning();
            }
        }
    }
}

