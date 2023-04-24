using Game.Managers;
using UnityEngine;

namespace Game
{
	public class Castle : Singleton<Castle>
	{
		[SerializeField] private float initialHealth = 100.0f;
		
		private float _currentHealth;

		private void Start()
		{
			_currentHealth = initialHealth;
		}

		public void LoseHealth(float damage)
		{
			_currentHealth -= damage;
			print(_currentHealth);
		}
	}
}