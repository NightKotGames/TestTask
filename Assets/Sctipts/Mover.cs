using System;
using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [Header("Options:")]
    [Tooltip("Travel speed")]
    [SerializeField, Range(1, 10)] private float _speed;

    public static event Action<float> DistanceToTarget = delegate { };
    public static event Action<Vector3> MoveCompleted = delegate { };

    
    private Transform _mainTransform;
    private float _distance;

    private void Awake()
    {
        _mainTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        MoveQueue.StartMove += Move;
        SpeedHandle.SetSpeedHandle += OnSetSpeedMove;
    }
    private void OnDisable()
    {
        MoveQueue.StartMove -= Move;
        SpeedHandle.SetSpeedHandle -= OnSetSpeedMove;
    }

    private void OnSetSpeedMove(float _speed)
    {
        this._speed = _speed;
    }

    private void Move(Vector3 _endPoint)
    {
                
        _distance = (_endPoint - gameObject.transform.position).magnitude;

        StartCoroutine(StartMove());
        IEnumerator StartMove()
        {
            
            while(_distance > 1f)
            {

                yield return new WaitForSeconds(.01f);
                _distance = (_endPoint - gameObject.transform.position).magnitude;
                _mainTransform.position = Vector3.MoveTowards(_mainTransform.position, new Vector3(_endPoint.x, 1f, _endPoint.z), _speed * Time.deltaTime);

                DistanceToTarget.Invoke(_distance);
                if (_distance <= 1)
                {
                    MoveCompleted.Invoke(_endPoint);
                    
                }

            }
            
        }
        StopCoroutine(StartMove());
        


    }




}
