using UnityEngine;

namespace Game
{
	public class PlayGameButton : MonoBehaviour
	{
		[SerializeField] private GameObject brickBlockBehind;
		[SerializeField] private Player player;
		
		public void PlayGame()
		{
			if (Time.timeScale == 0f)
				return;
			
			player.EnablePlayerShoot(true);
			Spawner.Instance.StartSpawning();
			gameObject.SetActive(false);
			brickBlockBehind.SetActive(false);
		}
	}
}