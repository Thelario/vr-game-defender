using UnityEngine;

namespace Game
{
	public class ExitGameButton : MonoBehaviour
	{
		public void ExitGame()
		{
			if (Time.timeScale == 0f)
				return;
			
			Application.Quit();
		}
	}
}