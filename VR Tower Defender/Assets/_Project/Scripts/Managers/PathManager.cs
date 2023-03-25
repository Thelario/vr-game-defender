using UnityEngine;
using Game.Managers;

namespace Game
{
	[System.Serializable]
	public struct Camino
	{
		public Transform[] caminos;
	}
	
	public class PathManager : Singleton<PathManager>
	{
		[Header("Caminos")]
		[SerializeField] private Camino[] paths;

		public Transform[] GetRandomPath() { return paths[Random.Range(0, paths.Length)].caminos; }
	}
}