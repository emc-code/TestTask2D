using UnityEngine;
public class AIMPolicy : IMovementPolicy
{
    private Transform _circle;
    private Transform _target;

    public AIMPolicy(Transform circle, Transform target)
    {
        _circle = circle;
        _target = target;
    }

    public Vector2 GetDirection() => _target.position - _circle.transform.position;
}