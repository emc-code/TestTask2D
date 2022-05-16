using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out CircleHit circleHit))
        {
            ContactPoint2D[] contacts = new ContactPoint2D[2];
            collision.GetContacts(contacts);
            Vector2 dir = collision.contacts[0].normal;
            circleHit.BorderCollider(-dir);
        }
    }
}