using System.Collections;

namespace Game
{
	public interface IFreezable
	{
		public IEnumerator Co_Freeze(float freezeTime);
	}
}