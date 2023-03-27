using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class RestartGameButton : MonoBehaviour
	{
		public void RestartGame()
		{
			SceneManager.LoadScene(0);
		}
	}
}