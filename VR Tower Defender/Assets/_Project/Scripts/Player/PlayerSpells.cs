using UnityEngine;

namespace Game
{
	public class PlayerSpells : MonoBehaviour
	{
		// Player mana at the start of the game
		[SerializeField] private int initialPlayerMana;

		// The spells that the player can cast
		[SerializeField] private Spell[] spells;

		// The index of the current spell that the player can cast
		[SerializeField] private int currentSpell;

		// The mana that the player currently has at this exact moment of the game
		[SerializeField] private int currentPlayerMana;

		private void Start()
		{
			currentSpell = 0;
			currentPlayerMana = initialPlayerMana;
			spells[currentSpell].EnableSpell(true);
		}

		public void CastSpell()
		{
			// We cast the current spell
			currentPlayerMana -= spells[currentSpell].CastSpell(currentPlayerMana);
		}

		public void ChangeSpell()
		{
			// We deactivate the current spell
			spells[currentSpell].EnableSpell(false);
			
			// TODO: if we implement the spell wheel, this will have to change
			// We calculate which is the next spell in the array
			currentSpell = (currentSpell + 1) % spells.Length;
			
			// We active the the new spell
			spells[currentSpell].EnableSpell(true);
			
			print("Changing spell");
		}
	}
}