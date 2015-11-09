using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Utils.GameEvents
{
	public abstract class CommandMonoBehaviour : MonoBehaviour
    {
		private readonly Queue<PendingCommand> _pendingCommands;
		private readonly int _subscriberId;
		private static int _counter;
		
		protected CommandMonoBehaviour()
		{
			_pendingCommands = new Queue<PendingCommand>();
			_subscriberId = ++_counter;
		}
		
		public void CommandsUpdate()
		{
			while (_pendingCommands.Any())
			{
				_pendingCommands.Dequeue().Execute();
			}
		}
		
		protected void Subscribe<T>(GameEvent<T> gameEvent, Action<T> action)
			where T : GameEventArgs
		{
			gameEvent.Subscribe(_subscriberId, (zzz) => { EnqueuePendingCommand(action, zzz);});
		}

		private void EnqueuePendingCommand<T>(Action<T> action, T args)
			where T : GameEventArgs
		{
			_pendingCommands.Enqueue(new PendingCommand<T>(action, args));
		}
		
		protected void UnSubscribe<T>(GameEvent<T> gameEvent)
			where T : GameEventArgs
		{
			gameEvent.UnSubscribe(_subscriberId);
		}
	}
	
}