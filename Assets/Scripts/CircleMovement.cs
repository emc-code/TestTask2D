using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    private CircleSpeed _circleSpeed;
    private CircleNavigator _circleNavigator;

    private bool _isMoving = false;

    private const float SLOW = 0.01f;

    private void Awake()
    {
        _circleSpeed = GetComponent<CircleSpeed>();
        _circleNavigator = GetComponent<CircleNavigator>();
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
        transform.position += direction * _circleSpeed.Value * SLOW;
    }
}
