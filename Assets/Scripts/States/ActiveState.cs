using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace States
{
	public class ActiveState : State
	{
		public override void UpdateState()
		{
			BallMovement();
		}

		private bool IsDot()
		{
			if (Vector3.Distance(_currVec, _nextVec) <= 0.001)
				return true;
			return false;
		} 

		private void BallMovement() 
		{
			if(Vector3.Distance(_currentBall.myWaypoints[_counter], transform.position) <= 0) 
			{
				_counter++;
				if(_counter < _currentBall.waypointsLen)
				_lineRenderer.SetVertexCount(_counter + 1);
			}
			
			if(_counter >= _currentBall.waypointsLen) 
			{
				_currentBall.ChangeState(_changeState);
				_counter = 0;
				return;
			}
			_transform.position = Vector3.MoveTowards(transform.position, _currentBall.myWaypoints[_counter], _currentBall.step * Time.deltaTime);
			_lineRenderer.SetPosition(_counter,_transform.position);
		}

		public override void OnDoubleClick()
		{
			BackToStart();
			_currentBall.ChangeState(_changeState);
		}
	}
}