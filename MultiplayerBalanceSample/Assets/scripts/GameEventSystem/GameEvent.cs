using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utils.GameEvents
{
	public class GameEvent<T> where T : GameEventArgs
	{
		private readonly List<GameEventCallback<T>> _callbacks; 
		
		public GameEvent()
		{
			_callbacks = new List<GameEventCallback<T>>();
		}
		
		public void Subscribe(int subscriberId, Action<T> callback)
		{
			_callbacks.Add(new GameEventCallback<T>(subscriberId, callback));
		}
		
		public void Publish(T eventArgs)
		{
			foreach (GameEventCallback<T> callback in _callbacks)
				callback.Callback(eventArgs);
		}
		
		public void UnSubscribe(int subscriberId)
		{
			foreach(GameEventCallback<T> callback in _callbacks.ToArray())
				if (callback.SubscriberId == subscriberId)
					_callbacks.Remove(callback);
		}
	}
}