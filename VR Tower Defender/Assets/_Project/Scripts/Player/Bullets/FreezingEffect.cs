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

			other.GetComponent<IFreezable>().Freeze(_freezeTime);
		}
	}
}