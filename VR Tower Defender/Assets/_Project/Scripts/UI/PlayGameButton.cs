using UnityEngine;

namespace Game
{
	public class PlayGameButton : MonoBehaviour
	{
		[SerializeField] private GameObject brickBlockBehind;
		
		public void PlayGame()
		{
			Spawner.Instance.StartSpawning();
			gameObject.SetActive(false);
			brickBlockBehind.SetActive(false);
		}
	}
}