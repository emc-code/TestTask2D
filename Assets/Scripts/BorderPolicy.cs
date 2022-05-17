using UnityEngine;

public class BorderPolicy : IMovePolicy
{
    private Collision2D _collision2D;
    public BorderPolicy(Collision2D collision2D) => _collision2D = collision2D;

    public Vector2 GetDirection()
    {
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        _collision2D.GetContacts(contacts);

        Vector2 direction = _collision2D.contacts[0].normal;
        return -direction;
    }
}