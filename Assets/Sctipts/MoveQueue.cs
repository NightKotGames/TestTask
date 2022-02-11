using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQueue : MonoBehaviour
{
    public static event Action<Vector3> StartMove = delegate { };
    public static event Action<int> TargetAmount = delegate { };
    

    public Vector3 CurrentTarget
    {
        get { return _currentTarget; }    
    }

    private Vector3 _currentTarget;
    private Queue<Vector3> _flyQueue;


    private void Awake()
    {
        _flyQueue = new Queue<Vector3>();
    }

    private void OnEnable()
    {
        EarthClicked.OnClick += AddTatgetFly;
        Mover.MoveCompleted += NextTarget;

    }
    private void OnDisable()
    {
        EarthClicked.OnClick -= AddTatgetFly;
        Mover.MoveCompleted -= NextTarget;
    }

    private void AddTatgetFly(Vector3 _target)
    {
        _flyQueue.Enqueue(_target);
        ActivatedMoveToTarget();
        TargetAmount.Invoke(_flyQueue.Count);
    }

    private void ActivatedMoveToTarget()
    {
       
        if(_flyQueue.Count > 0)
        {
            _currentTarget = _flyQueue.Peek();
            StartMove.Invoke(_currentTarget);
        }        
        TargetAmount.Invoke(_flyQueue.Count);

    }

    private void NextTarget(Vector3 _target)
    {
        if(_flyQueue.Count > 0 && _target == _currentTarget)
        {
            _flyQueue.Dequeue();
            ActivatedMoveToTarget();
        }
        
        TargetAmount.Invoke(_flyQueue.Count);
    }

}
