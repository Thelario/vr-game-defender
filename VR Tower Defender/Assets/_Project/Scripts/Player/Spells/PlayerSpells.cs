using Game.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class PlayerSpells : Singleton<PlayerSpells>
	{
		[SerializeField] private int maxMana;
		[SerializeField] private Spell[] spells;
		[SerializeField] private int currentSpell;
		[SerializeField] private int currentPlayerMana;
		[SerializeField] private Slider manaSlider;

		private void Start()
		{
			currentSpell = 0;
			currentPlayerMana = maxMana;
			spells[currentSpell].EnableSpell(true);
			manaSlider.maxValue = maxMana;
			manaSlider.value = currentPlayerMana;
		}

		public void CastSpell()
		{
			currentPlayerMana -= spells[currentSpell].CastSpell(currentPlayerMana);
			manaSlider.value = currentPlayerMana;
		}

		public void ChangeSpell()
		{
			spells[currentSpell].EnableSpell(false);
			
			currentSpell = (currentSpell + 1) % spells.Length;
			
			spells[currentSpell].EnableSpell(true);
		}

		public void RefillMana(int mana)
        {
			currentPlayerMana = Mathf.Clamp(currentPlayerMana + mana, 0, maxMana);
			manaSlider.value = currentPlayerMana;
		}
	}
}