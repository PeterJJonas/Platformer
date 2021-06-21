using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField] Transform[] _targetPosition;
    [SerializeField] float _platformSpeed = 1.0f;
    //[SerializeField] Transform _movingPlatform;
 
    private Transform _moveTowards;

    private void FixedUpdate()
    {
        if (transform.position == _targetPosition[0].position)
        {
            _moveTowards = _targetPosition[1];
        }

        else if (transform.position == _targetPosition[1].position)
        {
            _moveTowards = _targetPosition[0];
        }
        transform.position = Vector3.MoveTowards(transform.position, _moveTowards.position, _platformSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player hit platform");
            //other.transform.SetParent(_movingPlatform);
            other.transform.parent = this.transform;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player leaves the platform");
            //other.transform.SetParent(null);
            other.transform.parent = null;
        }
    }
}
