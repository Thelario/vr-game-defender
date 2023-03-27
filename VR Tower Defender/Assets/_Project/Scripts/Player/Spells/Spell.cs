using UnityEngine;

namespace Game
{
	public abstract class Spell : MonoBehaviour
	{
		// The initial mana cost of the spell
		[SerializeField] protected int initialManaCost; 
		
		// The time that it takes a spell to cast after a previous cast
		[SerializeField] protected float timeBetweenSpellCasts;

		// The current cost of the spell at the current moment of the game
		protected int currentManaCost;
		
		// A counter variable to check for the time between spell casts
		protected float timeBetweenSpellCastsCounter;

		// A flag variable to determine whether the spell is active or not
		protected bool isActive;
        
		// A flag variable to determine if the spell can be casted or not
		protected bool canBeCasted;

		protected virtual void Start()
		{
			timeBetweenSpellCastsCounter = timeBetweenSpellCasts;
			currentManaCost = initialManaCost;
		}

		protected void Update()
		{
			// If the current spell is not active, we do nothing
			if (!isActive)
				return;

			// If the current spell canBeCasted, then we do nothing
			if (canBeCasted)
				return;
            
			// If the current spell is active and cannot be casted,
			// then we check for the time since the last cast
			timeBetweenSpellCastsCounter -= Time.deltaTime;
			if (!(timeBetweenSpellCastsCounter <= 0f))
				return;
            
			// We set the spell to be able to be casted and restart the counter
			canBeCasted = true;
			timeBetweenSpellCastsCounter = timeBetweenSpellCasts;
		}

		public void EnableSpell(bool active)
		{
			isActive = active;
		}

		public int CastSpell(int currentPlayerMana)
		{
			// If the spell is not active, then do nothing
			if (!isActive)
			{
				print("Spell is not active");
				return 0;
			}

			// If the spell cannot be casted, then do nothing
			if (!canBeCasted)
			{
				print("Spell cannot be casted yet");
				return 0;
			}

			// If the player doesn't have enough mana for the spell, then do nothing
			if (currentPlayerMana < currentManaCost)
			{
				print("Not enough mana to cast spell");
				return 0;
			}
            
			CreateSpellRay(currentPlayerMana);
            
			return currentManaCost;
		}

		protected abstract void CreateSpellRay(int currentPlayerMana);
	}
}