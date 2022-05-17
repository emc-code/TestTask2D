using UnityEngine;
using System.Collections.Generic;

public class CircleNavigator : MonoBehaviour, ICircleNavigator
{
    private IMovePolicy _aimPolicy;
    private List<IMovePolicy> _movePolicies = new List<IMovePolicy>();

    public void AddMovePolicy(IMovePolicy movePolicy) => _movePolicies.Add(movePolicy);

    public void Init(Transform target)
    {
        _aimPolicy = new AIMPolicy(transform, target);
    }

    public Vector3 GetDirection()
    {
        Vector2 result = GetDirection(_movePolicies);
        _movePolicies.Clear();
        return result.normalized;
    }

    private Vector2 GetDirection(List<IMovePolicy> movePolicies)
    {
        if (movePolicies.Count == 0)
            return _aimPolicy.GetDirection();

        if (movePolicies.Exists(x => x is FinishedPolicy))
            return Vector2.zero;

        if (movePolicies.Exists(x => x is BorderPolicy))
            return GetBordersDirection(movePolicies);

        return GetDirectionsSumm(movePolicies);
    }

    private Vector2 GetDirectionsSumm(List<IMovePolicy> movePolicies)
    {
        Vector2 result = Vector2.zero;
        foreach (var item in movePolicies)
            result += item.GetDirection();

        return result;
    }
    private Vector2 GetBordersDirection(List<IMovePolicy> movePolicies)
    {
        Vector2 result = Vector2.zero;
        foreach (var item in _movePolicies)
            if (item is BorderPolicy)
                result += item.GetDirection();

        return result;
    }
}