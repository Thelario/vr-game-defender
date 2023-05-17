using UnityEngine;

namespace Game
{
	public abstract class Spell : MonoBehaviour
	{
		[SerializeField] protected int initialManaCost;
		[SerializeField] protected float timeBetweenSpellCasts;
		[SerializeField] protected GameObject spellParticles;

		private int _currentManaCost;
		private float _timeBetweenSpellCastsCounter;
		private bool _isActive;
		private bool _canBeCasted;

		protected virtual void Start()
		{
			_timeBetweenSpellCastsCounter = 0f;
			_currentManaCost = initialManaCost;
		}

		protected virtual void Update()
		{
			if (!_isActive)
				return;

			if (_canBeCasted)
				return;
            
			_timeBetweenSpellCastsCounter -= Time.deltaTime;
			if (!(_timeBetweenSpellCastsCounter <= 0f))
				return;
            
			_canBeCasted = true;
			_timeBetweenSpellCastsCounter = timeBetweenSpellCasts;
			spellParticles.SetActive(_canBeCasted);
		}

		public void EnableSpell(bool active)
		{
			_isActive = active;
			spellParticles.SetActive(_canBeCasted);
		}

		public int CastSpell(int currentPlayerMana)
		{
			if (!_isActive)
			{
				print("Spell is not active");
				return 0;
			}

			if (!_canBeCasted)
			{
				print("Spell cannot be casted yet");
				return 0;
			}

			if (currentPlayerMana < _currentManaCost)
			{
				print("Not enough mana to cast spell");
				return 0;
			}
            
			CreateSpellRay(currentPlayerMana);
			_canBeCasted = false;
			spellParticles.SetActive(_canBeCasted);
            
			return _currentManaCost;
		}

		protected abstract void CreateSpellRay(int currentPlayerMana);
	}
}