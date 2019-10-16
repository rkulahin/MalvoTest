using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	[SerializeField] private Transform _target;
	private Transform _transform;
	private Vector3 _newPos;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
		_newPos = _target.position;
		_newPos.z = -10;
        _transform.position = _newPos;
    }
}
