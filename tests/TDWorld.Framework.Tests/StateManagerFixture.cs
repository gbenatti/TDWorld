using System;
using NUnit.Framework;
using Moq;

namespace TDWorld.Framework.Tests
{
	class StartState : IGameLogicState
	{
		public void Enter ()
		{
		}
	
		public void Exit ()
		{
		}
	
		public void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			throw new System.NotImplementedException ();
		}
	}
	
	class MenuState : IGameLogicState
	{
		public void Enter ()
		{
			throw new System.NotImplementedException ();
		}
	
		public void Exit ()
		{
			throw new System.NotImplementedException ();
		}
	
		public void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			throw new System.NotImplementedException ();
		}
	}
	
	[TestFixture()]
	public class StateManagerFixture
	{
		[Test()]
		public void ShouldBeCreatedWithNoStates ()
		{
			var manager = new StateManager<IGameLogicState>(null);

			Assert.AreEqual(0, manager.StateCount);
			Assert.IsNull(manager.Current);
		}
		
		[Test()]
		public void ShouldSupportStatesBeingAdded ()
		{
			var manager = new StateManager<IGameLogicState>(null);

			manager.AddState(new StartState());
			Assert.AreEqual(1, manager.StateCount);
			
			manager.AddState(new MenuState());
			Assert.AreEqual(2, manager.StateCount);
		}
		
		[Test()]
		public void ShouldSupportStatesBeingRemoved ()
		{
			var state1 = new StartState();
			var state2 = new MenuState();
			
			var manager = new StateManager<IGameLogicState>(null);

			manager.AddState(state1);
			manager.AddState(state2);
			
			Assert.AreEqual(2, manager.StateCount);
			
			manager.RemoveState(state1);
			
			Assert.AreEqual(1, manager.StateCount);
		}
		
		[Test]
		public void ShouldSetCurrentToStartStateWhenCreated ()
		{
			var state = new StartState();
			var manager = new StateManager<IGameLogicState>(state);

			Assert.AreSame(state, manager.Current);
		}

		[Test()]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ShouldFailWhenTryingToAddTheSameStateTwice ()
		{
			var state = new StartState();
			
			var manager = new StateManager<IGameLogicState>(null);

			manager.AddState(state);
			manager.AddState(state);
		}
		
		[Test()]
		public void ChangingStateShouldCallEnterInNewState()
		{
			var manager = new StateManager<IGameLogicState>(null);
			var state = new Mock<IGameLogicState>();
			
			manager.ChangeState(state as IGameLogicState);
			
			state.Verify(foo => foo.Enter());
		}
	}
}

