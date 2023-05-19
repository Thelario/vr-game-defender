using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class RestartGameButton : MonoBehaviour
	{
		public void RestartGame()
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene(0);
		}
	}
}