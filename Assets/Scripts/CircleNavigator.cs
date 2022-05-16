using UnityEngine;
using System.Collections.Generic;

public class CircleNavigator : MonoBehaviour, ICircleNavigator
{
    private IMovePolicy _toTargetMovePolicy;
    private List<IMovePolicy> _movePolicies = new List<IMovePolicy>();

    public void AddMovePolicy(IMovePolicy movePolicy) => _movePolicies.Add(movePolicy);

    public void Init(Transform target)
    {
        _toTargetMovePolicy = new ToTargetMovePolicy(transform, target);
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
            return _toTargetMovePolicy.GetDirection();

        if (movePolicies.Exists(x => x is BorderMovePolicy))
            return GetPushBordersDirection(movePolicies);

        return GetDirectionsSumm(movePolicies);
    }

    private Vector2 GetDirectionsSumm(List<IMovePolicy> movePolicies)
    {
        Debug.Log(movePolicies.Count + " summ  ");


        Vector2 result = Vector2.zero;
        foreach (var item in movePolicies)
        {
            result += item.GetDirection();
        }

        return result;
    }
    private Vector2 GetPushBordersDirection(List<IMovePolicy> movePolicies)
    {
        Debug.Log(movePolicies.Count);

        Vector2 result = Vector2.zero;
        foreach (var item in _movePolicies)
            if (item is BorderMovePolicy)
                result += item.GetDirection();

        return result;
    }
}