using UnityEngine;

public class BorderCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnBorderEnter(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        OnBorderEnter(collision);
    }

    private void OnBorderEnter(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out ICircleNavigator circleNavigator))
        {
            BorderPolicy borderPolicy = new BorderPolicy(collision);
            circleNavigator.AddMovePolicy(borderPolicy);
        }
    }
}
