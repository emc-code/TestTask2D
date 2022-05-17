using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    private CircleSpeed _circleSpeed;
    private CircleNavigator _circleNavigator;

    private bool _isMoving;

    private const float SLOW = 0.01f;

    public void Init(CircleSpeed circleSpeed, CircleNavigator circleNavigator, Transform startZone)
    {
        _isMoving = false;
        transform.position = startZone.position;
        _circleSpeed = circleSpeed;
        _circleNavigator = circleNavigator;        
    }

    public void StartMovement() => _isMoving = true;
    public void StopMovement() => _isMoving = false;

    public void TryMove()
    {
        if (_isMoving == true)
            Move();
    }

    private void Move()
    {
        Vector3 direction = _circleNavigator.GetDirection();
        transform.position += direction * _circleSpeed.GetValue() * SLOW;
    }
}
