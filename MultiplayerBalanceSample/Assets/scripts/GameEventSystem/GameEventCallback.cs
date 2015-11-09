using System;

namespace Assets.Scripts.Utils.GameEvents
{
	public class GameEventCallback<T> where T : GameEventArgs
	{
		public int SubscriberId { get; private set; }
		public Action<T> Callback { get; private set; }
		
		public GameEventCallback(int subscriberId, Action<T> callback)
		{
			SubscriberId = subscriberId;
			Callback = callback;
		}
	}
}