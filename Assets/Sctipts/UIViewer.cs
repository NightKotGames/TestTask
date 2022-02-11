using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIViewer : MonoBehaviour
{

    private TextMeshProUGUI _text;
    private float _speed;
    private int _targetAmount;
    private float _distance;
    private Vector3 _currentTarget;



    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

    }

    private void OnEnable()
    {
        SpeedHandle.SetSpeedHandle += OnSetSpeed;
        MoveQueue.TargetAmount += OnSetTargetCounter;
        MoveQueue.StartMove += OnSetCurrentMove;
        Mover.DistanceToTarget += OnSetDistanceToTarget;
    }
    private void OnDisable()
    {
        SpeedHandle.SetSpeedHandle -= OnSetSpeed;
        MoveQueue.TargetAmount -= OnSetTargetCounter;
        MoveQueue.StartMove -= OnSetCurrentMove;
        Mover.DistanceToTarget -= OnSetDistanceToTarget;
    }

    private void OnSetSpeed(float _speed)
    {
        this._speed = _speed;
    }

    private void OnSetCurrentMove(Vector3 _currentTarget)
    {
        this._currentTarget = _currentTarget;
    }

    private void OnSetDistanceToTarget(float _distance)
    {
        this._distance = _distance;
    }

    private void OnSetTargetCounter(int _targetAmount)
    {
        this._targetAmount = _targetAmount;
    }

    private void OnGUI()
    {
        _text.text = $"Current Speed: {_speed}   Target Amount: {_targetAmount} Distance To Target: {_distance} Current Target: {_currentTarget}";
    }







}
