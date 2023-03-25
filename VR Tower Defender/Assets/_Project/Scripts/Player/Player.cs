using UnityEngine;

namespace Game
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private PlayerSpells playerSpells;

		private void Update()
		{
			// TODO: handle input if the player clicks on the hair trigger
			if (Input.GetMouseButtonDown(0))
				CastSpell();
			
			// TODO: handle input if the player clicks on the touchpad where x = 0, y = 1
			if (Input.GetMouseButtonDown(1))
				ChangeSpell();
		}

		private void CastSpell()
		{
			playerSpells.CastSpell();
		}

		private void ChangeSpell()
		{
			playerSpells.ChangeSpell();
		}
	}
}