using System.Collections.Generic;
using Game.Managers;
using UnityEngine;

namespace Game
{
	public enum SfxType { EnemyDeath, EnemyHit, Explosion, Failure, Spell }

	[System.Serializable]
	public struct Sound
	{
		public SfxType sfxType;
		public AudioClip clip;
		public float volume;
	}
	
	public class SfxManager : Singleton<SfxManager>
	{
		[SerializeField] private AudioSource sfxSource;
		[SerializeField] private List<Sound> sounds;

		public void PlayClip(SfxType sfxType)
		{
			foreach (Sound s in sounds)
			{
				if (s.sfxType != sfxType)
					continue;
				
				sfxSource.PlayOneShot(s.clip, s.volume);
				return;
			}
		}
	}
}