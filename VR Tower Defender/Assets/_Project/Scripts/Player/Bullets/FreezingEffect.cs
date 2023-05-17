using UnityEngine;

namespace Game
{
	public class FreezingEffect : MonoBehaviour
	{
		private float _freezeTime;

		public void ConfiguraFreezeTime(float freezeTime)
		{
			_freezeTime = freezeTime;
		}
		
		protected void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Enemy"))
				return;

			StartCoroutine(other.GetComponent<IFreezable>().Co_Freeze(_freezeTime));
		}
	}
}