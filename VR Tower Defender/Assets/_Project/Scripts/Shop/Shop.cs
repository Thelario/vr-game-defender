using System.Collections.Generic;
using Game.Managers;
using TMPro;
using UnityEngine;

namespace Game
{
	public class Shop : Singleton<Shop>
	{
		[SerializeField] private TMP_Text moneyText;
		[SerializeField] private List<GameObject> disableShopItems;
		
		private int _currentPlayerMoney = 50;

		private void Start()
		{
			moneyText.text = "Money: " + _currentPlayerMoney;
			DisableItems();
		}

		public void AddMoney(int money)
		{
			_currentPlayerMoney += money;
			moneyText.text = "Money: " + _currentPlayerMoney;
		}

		public void SubstractMoney(int money)
		{
			_currentPlayerMoney = Mathf.Clamp(_currentPlayerMoney - money, 0, 99999999);
			moneyText.text = "Money: " + _currentPlayerMoney;
		}

		public bool CanSubstractMoney(int money)
		{
			return money <= _currentPlayerMoney;
		}

		public void DisableItems()
		{
			foreach (GameObject go in disableShopItems)
				go.SetActive(false);
		}

		public void EnableItems()
		{
			foreach (GameObject go in disableShopItems)
				go.SetActive(true);
		}
	}
}