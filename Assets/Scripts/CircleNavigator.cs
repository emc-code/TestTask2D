using UnityEngine;

public class CircleNavigator : MonoBehaviour
{
    public PlayerHit hit;
    public Camera Camera;

    public bool _isEscape = false;
    public bool _hasBorderCollision = false;

    private Transform _target;
    private Vector2 _borderDirection;
    

    public void Init(Transform target)
    {
        _target = target;
    }

    public Vector3 GetDirection()
    {


        if (_hasBorderCollision == true)
        {
            Vector2 dir = _borderDirection.normalized;

            _hasBorderCollision = false;
            _borderDirection = Vector2.zero;

            return Vector2.zero;
        }

        if (_isEscape == true)
            return GetEscapeDirection().normalized;


        return (_target.position - transform.position).normalized;
    }

    public Vector3 GetEscapeDirection()
    {
        Vector3 escapeDirection = transform.position - hit.transform.position;
        return escapeDirection;
    }

    public void AddBorderDirection(Vector2 vector2)
    {
        _borderDirection += vector2;
        _hasBorderCollision = true;
    }
}