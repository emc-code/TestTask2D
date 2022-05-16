using UnityEngine;

public class BorderCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out ICircleNavigator circleNavigator))
            OnCircleCollision(collision, circleNavigator);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out ICircleNavigator circleNavigator))
            OnCircleCollision(collision, circleNavigator);
    }

    private void OnCircleCollision(Collision2D collision, ICircleNavigator circleNavigator)
    {
        BorderMovePolicy borderMovePolicy = new BorderMovePolicy(collision);
        circleNavigator.AddMovePolicy(borderMovePolicy);
    }
}
