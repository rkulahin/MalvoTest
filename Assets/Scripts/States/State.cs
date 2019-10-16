using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
	public class State : MonoBehaviour, IState
	{
		protected Ball _currentBall;
		protected State _changeState;
		protected Vector3 _currVec;
		protected Vector3 _nextVec;
		public int _counter;
		protected Transform _transform;
		protected LineRenderer _lineRenderer;

		public void InitState(Ball ball, State change)
		{
			_transform = transform;
			_lineRenderer = GetComponent<LineRenderer>();
			_changeState = change;
			_currentBall = ball;
		}
		public virtual void UpdateState()
		{
			
		}
		protected void BackToStart()
		{
			_counter = 0;
			_transform.position = _currentBall.myWaypoints[0];
			_lineRenderer.SetVertexCount(0);
		}

		public virtual void OnClick()
		{}

		public virtual void OnDoubleClick()
		{
			BackToStart();
		}
	}
}