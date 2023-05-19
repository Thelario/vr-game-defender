using UnityEngine;
using Valve.VR;

namespace Game
{
	public class Player : MonoBehaviour
	{
		public delegate void HandleGamePause();
		public static event HandleGamePause OnPause;
		public static event HandleGamePause OnResume;
		
		[SerializeField] private PlayerSpells playerSpells;

		private SteamVR_Action_Boolean _shoot;
		private SteamVR_Action_Boolean _pause;

		private bool _gameIsPaused;

        private void Start()
        {
			_shoot = SteamVR_Input.GetBooleanAction("GrabPinch");
			_pause = SteamVR_Input.GetBooleanAction("<<Insert Name Gere>>");

			_gameIsPaused = false;
        }

        private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape) || _pause.GetStateDown(SteamVR_Input_Sources.Any))
				HandlePause();

			if (_gameIsPaused)
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
			if (_gameIsPaused)
			{
				OnResume?.Invoke();
				Time.timeScale = 1f;
			}
			else
			{
				OnPause?.Invoke();
				Time.timeScale = 0f;
			}

			_gameIsPaused = !_gameIsPaused;
		}
	}
}