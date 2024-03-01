using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Transform CameraTransform;
    public float CameraSpeed;
    public List<Transform> Waypoints = new();

    private int _count;
    private int _index;
    private int _direction = 1;
    private Vector3 _targetPosition;
    
    private void Start()
    {
        _count = Waypoints.Count;
        _index = 1;
        _targetPosition = Waypoints[_index].transform.position;
    }

    private void Update()
    {
        Move();
        
        if (Vector3.Distance(CameraTransform.position, _targetPosition) < 0.5f)
        {
            ChooseNextPoint();    
        }
    }

    private void ChooseNextPoint()
    {
        if (_direction == -1 && _index == 0)
        {
            _direction = 1;
        }
        else if (_index == _count - 1)
        {
            _direction = -1;
        } 
        
        _index += _direction;
        _targetPosition = Waypoints[_index].transform.position;
    }
    
    private void Move()
    {
        CameraTransform.position = Vector3.Lerp(CameraTransform.position, _targetPosition, CameraSpeed * Time.deltaTime);
    }
}
