using UnityEngine;

public class FinishCollider : MonoBehaviour
{
    [SerializeField] private Vector3 FinishPosition;

    private void Update() => FinishPosition = transform.position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ICircleNavigator circleNavigator))
            OnFinishEnter(collision.transform, circleNavigator);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ICircleNavigator circleNavigator))
            OnFinishEnter(collision.transform, circleNavigator);
    }

    private void OnFinishEnter(Transform circle, ICircleNavigator circleNavigator)
    {
        if (Vector3.Distance(FinishPosition, circle.position) < 0.05f)
        {
            FinishMovePolicy finishMovePolicy = new FinishMovePolicy();
            circleNavigator.AddMovePolicy(finishMovePolicy);
            // Debug.Log(transform.position); ??                
        }
    }
}