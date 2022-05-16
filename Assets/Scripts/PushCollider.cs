using UnityEngine;

public interface IMovePolicy
{
    Vector2 GetDirection();
}


public class ToTargetMovePolicy : IMovePolicy
{
    private Transform _circle;
    private Transform _target;

    public ToTargetMovePolicy(Transform circle, Transform target)
    {
        _circle = circle;
        _target = target;
    }

    public Vector2 GetDirection()
    {
        return _target.position - _circle.transform.position;
    }
}

public class PlayerMovePolicy : IMovePolicy
{
    private Transform _player;
    private Transform _circle;

    public PlayerMovePolicy(Transform player, Transform circle)
    {
        _player = player;
        _circle = circle;
    }

    public Vector2 GetDirection()
    {
        return _circle.position - _player.transform.position;
    }
}

public class BorderMovePolicy : IMovePolicy
{
    private Collision2D _collision2D;
    public BorderMovePolicy(Collision2D collision2D)
    {
        _collision2D = collision2D;
    }

    public Vector2 GetDirection()
    {
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        _collision2D.GetContacts(contacts);
        Vector2 direction = _collision2D.contacts[0].normal;
        return -direction;
    }
}