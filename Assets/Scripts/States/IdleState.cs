using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
	public class IdleState : State
	{
		public override void UpdateState()
		{
			
		}
		
		public override void OnClick()
		{
			_currentBall.ChangeState(_changeState);
		}
	}
}