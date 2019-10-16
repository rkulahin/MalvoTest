using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using States;

public class Ball : MonoBehaviour
{
	[SerializeField] private TextAsset dataText;
	[SerializeField] private Slider _slider;
	private string jsonStr;
	public State _currentState;
    private ActiveState _activeState;
	private IdleState _idleState;
	private Data path;
	private float doubleClickDelay = 0.4f;
    private float doubleClickCount; 
	public List<Vector3> myWaypoints;
	public int waypointsLen;
	private float _speed = 5;
	public float step;
	private void Awake()
	{
		jsonStr = dataText.text;
		path = JsonUtility.FromJson<Data>(jsonStr);
		InitWaypoint();
		InitRender();
		_activeState = GetComponent<ActiveState>();
		_idleState = GetComponent<IdleState>();
		_activeState.InitState(this, _idleState);
		_idleState.InitState(this, _activeState);
        ChangeState(_idleState);
	}
    private void Start()
    {
		
    }

    // Update is called once per frame
    private void Update()
    {
		step = _speed * _slider.value;
        _currentState.UpdateState();
    }
	private void InitRender()
	{
		//GetComponent<LineRenderer>().SetVertexCount(2);
	}
	private void InitWaypoint()
	{
		for(int i = 0; i < path.x.Length; i++)
		{
			myWaypoints.Add(GetVector(i));
			waypointsLen++;
		}
	}

	private Vector3 GetVector(int i)
	{
		Debug.Log(i);
		return new Vector3(path.x[i],path.y[i],path.z[i]);
	}
	public void ChangeState(State newState)
	{
		_currentState = newState;
	}

	private void OnMouseUp()
    {
		doubleClickCount++;
        if (doubleClickCount == 2)
        {
            CancelInvoke("OneClick");
            DoubleClick();
            return;
        }
        
        Invoke("OneClick", doubleClickDelay);
    }

    void OneClick()
    {
		doubleClickCount = 0;
        _currentState.OnClick();
    }

    void DoubleClick()
    {
		doubleClickCount = 0;
        _currentState.OnDoubleClick();
		Debug.Log("Double");
    }
	
}
