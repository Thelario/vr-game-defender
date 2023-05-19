using UnityEngine;
using Valve.VR;

namespace Game
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private PlayerSpells playerSpells;
		[SerializeField] private float interpolationPeriod = 1f;
		
		private SteamVR_Action_Boolean _shoot;
		private SteamVR_Action_Boolean _pause;

		private bool _gameIsPaused;
		private bool _canShoot;
		private float _time;
		
        private void Start()
        {
			_shoot = SteamVR_Input.GetBooleanAction("GrabPinch");
			_pause = SteamVR_Input.GetBooleanAction("<<Insert Name Gere>>");

			_gameIsPaused = false;
			_canShoot = false;
        }

        private void Update()
        {
	        _time += Time.deltaTime;
	        if (_time >= interpolationPeriod)
	        {
		        _time = 0f;
		        playerSpells.RefillMana(1);
	        }
			
			if (Input.GetKeyDown(KeyCode.Escape) || _pause.GetStateDown(SteamVR_Input_Sources.RightHand) || _pause.GetStateDown(SteamVR_Input_Sources.LeftHand))
				HandlePause();

			if (_gameIsPaused || !_canShoot)
				return;
			
			if (Input.GetMouseButtonDown(0) || _shoot.GetStateDown(SteamVR_Input_Sources.RightHand))
				CastSpell();
			
			if (Input.GetMouseButtonDown(1) || _shoot.GetStateDown(SteamVR_Input_Sources.LeftHand))
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

		private void HandlePause()
		{
			Time.timeScale = _gameIsPaused ? 1f : 0f;
			
			_gameIsPaused = !_gameIsPaused;
		}

		public void EnablePlayerShoot(bool enabled)
		{
			_canShoot = enabled;
		}
	}
}