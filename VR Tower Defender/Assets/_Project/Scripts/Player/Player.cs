using UnityEngine;
using Valve.VR;

namespace Game
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private PlayerSpells playerSpells;

		private SteamVR_Action_Boolean _shoot;

        private void Start()
        {
			_shoot = SteamVR_Input.GetBooleanAction("GrabPinch");
		}

        private void Update()
		{
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
	}
}