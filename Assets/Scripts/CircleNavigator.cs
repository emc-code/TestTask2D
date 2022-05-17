using UnityEngine;
using System.Collections.Generic;

public class CircleNavigator : MonoBehaviour, ICircleNavigator
{
    private IMovementPolicy _aimPolicy;
    private List<IMovementPolicy> _movementPolicies = new List<IMovementPolicy>();

    public void AddMovePolicy(IMovementPolicy movePolicy) => _movementPolicies.Add(movePolicy);

    public void Init(Transform target)
    {
        _aimPolicy = new AIMPolicy(transform, target);
    }

    public Vector3 GetDirection()
    {
        Vector2 result = GetDirection(_movementPolicies);
        _movementPolicies.Clear();
        return result.normalized;
    }

    private Vector2 GetDirection(List<IMovementPolicy> movementPolicies)
    {
        if (movementPolicies.Count == 0)
            return _aimPolicy.GetDirection();

        if (movementPolicies.Exists(x => x is FinishedPolicy))
            return Vector2.zero;

        if (movementPolicies.Exists(x => x is BorderPolicy))
            return GetBordersDirection(movementPolicies);

        return GetDirectionsSumm(movementPolicies);
    }

    private Vector2 GetDirectionsSumm(List<IMovementPolicy> movementPolicies)
    {
        Vector2 result = Vector2.zero;
        foreach (var item in movementPolicies)
            result += item.GetDirection();

        return result;
    }
    private Vector2 GetBordersDirection(List<IMovementPolicy> movementPolicies)
    {
        Vector2 result = Vector2.zero;
        foreach (var item in movementPolicies)
            if (item is BorderPolicy)
                result += item.GetDirection();

        return result;
    }
}