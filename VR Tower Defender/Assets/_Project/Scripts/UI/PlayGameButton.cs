using UnityEngine;

namespace Game
{
	public class PlayGameButton : MonoBehaviour
	{
		public void PlayGame()
		{
			Spawner.Instance.StartSpawning();
			gameObject.SetActive(false);
		}
	}
}