using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class PlayerSpells : MonoBehaviour
	{
		// Player mana at the start of the game
		[SerializeField] private int maxMana;

		// The spells that the player can cast
		[SerializeField] private Spell[] spells;

		// The index of the current spell that the player can cast
		[SerializeField] private int currentSpell;

		// The mana that the player currently has at this exact moment of the game
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
			// We cast the current spell
			currentPlayerMana -= spells[currentSpell].CastSpell(currentPlayerMana);
			manaSlider.value = currentPlayerMana;
		}

		public void ChangeSpell()
		{
			// We deactivate the current spell
			spells[currentSpell].EnableSpell(false);
			
			// We calculate which is the next spell in the array
			currentSpell = (currentSpell + 1) % spells.Length;
			
			// We active the the new spell
			spells[currentSpell].EnableSpell(true);
			
			print("Changing spell");
		}

		public void RefillMana(int mana)
        {
			currentPlayerMana = Mathf.Clamp(currentPlayerMana + mana, 0, maxMana);
			manaSlider.value = currentPlayerMana;
		}
	}
}