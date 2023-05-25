using TMPro;
using UnityEngine;

namespace Game
{
	public class PurchaseButton : MonoBehaviour
	{
		[SerializeField] private TMP_Text text;
		[SerializeField] private TMP_Text costText;
		[SerializeField] private Spell spell;
		[SerializeField] private bool purchased;
		[SerializeField] private int initialCost;

		private bool _purchased;
		private int _currentCost;

		private void Start()
		{
			_purchased = purchased;
			_currentCost = initialCost;
			costText.text = "Cost: " + _currentCost;
			if (_purchased)
				text.text = "Upgrade";
		}

		public void Purchase()
		{
			if (!Shop.Instance.CanSubstractMoney(_currentCost))
				return;
			
			if (_purchased)
			{
				spell.UpgradeSpell();
				Shop.Instance.SubstractMoney(_currentCost);
			}
			else
			{
				PlayerSpells.Instance.AddSpell(spell);
				_purchased = true;
				Shop.Instance.SubstractMoney(_currentCost);
				text.text = "Upgrade";
			}
		}
	}
}