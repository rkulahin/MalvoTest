using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
public interface IState
{
	void UpdateState();
	void InitState(Ball ball, State change);
}
