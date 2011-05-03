using System;
using NUnit.Framework;
using NMock2;

namespace TDWorld.Framework.Tests
{
	class StartState : IGameLogicState
	{
		public string Name { get { return "Start"; } }

		public void Enter ()
		{
		}
	
		public void Exit ()
		{
		}
	
		public void Update (IGameTime gameTime)
		{
			throw new System.NotImplementedException ();
		}

	}
	
	class MenuState : IGameLogicState
	{
		public string Name { get { return "Menu"; } }

		public void Enter ()
		{
			throw new System.NotImplementedException ();
		}
	
		public void Exit ()
		{
			throw new System.NotImplementedException ();
		}
	
		public void Update (IGameTime gameTime)
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
			var start = new StartState();
			var menu = new MenuState();
			
			var manager = new StateManager<IGameLogicState>(null);

			manager.AddState(start);
			manager.AddState(menu);
			
			Assert.AreEqual(2, manager.StateCount);
			
			manager.RemoveState("Menu");
			
			Assert.AreEqual(1, manager.StateCount);
		}
		
		[Test()]
		public void StateRemovalShouldBeCaseInsensitive ()
		{
			var start = new StartState();
			
			var manager = new StateManager<IGameLogicState>(null);

			manager.AddState(start);
			
			Assert.AreEqual(1, manager.StateCount);
			manager.RemoveState("start");
			Assert.AreEqual(0, manager.StateCount);
		}
		
		[Test]
		public void ShouldSetCurrentToStartStateWhenCreated ()
		{
			var start = new StartState();
			var manager = new StateManager<IGameLogicState>(start);

			Assert.AreSame(start, manager.Current);
		}

		[Test()]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ShouldFailWhenTryingToAddTheSameStateTwice ()
		{
			var start = new StartState();
			
			var manager = new StateManager<IGameLogicState>(null);

			manager.AddState(start);
			manager.AddState(start);
		}
		
		[Test()]
		public void ChangingStateShouldCallEnterInNewState()
		{
			var manager = new StateManager<IGameLogicState>(null);
			
			var mocks = new Mockery();
			var first = mocks.NewMock<IGameLogicState>();
			
			Stub.On(first).
				GetProperty("Name").
            	Will(Return.Value("first"));
						
			Expect.Once.On(first).
				Method("Enter");

			manager.AddState(first);
			manager.ChangeState("first");
			
			mocks.VerifyAllExpectationsHaveBeenMet();
		}
		
		[Test()]
		public void ChangingStateShouldCallExitInOldState()
		{
			var manager = new StateManager<IGameLogicState>(null);
			var mocks = new Mockery();

			var first = mocks.NewMock<IGameLogicState>();
			var second = mocks.NewMock<IGameLogicState>();

			Stub.On(first).GetProperty("Name").Will(Return.Value("first"));
			Stub.On(second).GetProperty("Name").Will(Return.Value("second"));
			
			manager.AddState(first);
			manager.AddState(second);
			
			Expect.Once.On(first).Method("Enter");
			Expect.Once.On(first).Method("Exit");
			Expect.Once.On(second).Method("Enter");

			manager.ChangeState("first");
			manager.ChangeState("second");
			
			mocks.VerifyAllExpectationsHaveBeenMet();
		}
	}
}

