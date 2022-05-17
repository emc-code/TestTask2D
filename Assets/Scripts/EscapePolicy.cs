using UnityEngine;

public class EscapePolicy : IMovePolicy
{
    private Transform _player;
    private Transform _circle;

    public EscapePolicy(Transform player, Transform circle)
    {
        _player = player;
        _circle = circle;
    }

    public Vector2 GetDirection() => _circle.position - _player.transform.position;
}