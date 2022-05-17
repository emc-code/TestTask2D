using UnityEngine;
using System.Collections.Generic;

public class CircleNavigator : MonoBehaviour, ICircleNavigator
{
    private IMovePolicy _toTargetMovePolicy;
    private List<IMovePolicy> _movePolicies = new List<IMovePolicy>();

    private bool _stopMovement = false;

    public void AddMovePolicy(IMovePolicy movePolicy) => _movePolicies.Add(movePolicy);

    public void Init(Transform target)
    {
        _toTargetMovePolicy = new ToTargetMovePolicy(transform, target);
    }

    public Vector3 GetDirection()
    {
        if (_stopMovement)
            return Vector2.zero;

        Vector2 result = GetDirection(_movePolicies);
        _movePolicies.Clear();
        return result.normalized;
    }

    private Vector2 GetDirection(List<IMovePolicy> movePolicies)
    {
        if (_stopMovement == true)
            return Vector2.zero;

        if (movePolicies.Count == 0)
            return _toTargetMovePolicy.GetDirection();

        if (movePolicies.Exists(x => x is FinishMovePolicy))
        {
            _stopMovement = true;
            return Vector2.zero;
        }

        if (movePolicies.Exists(x => x is BorderMovePolicy))
            return GetPushBordersDirection(movePolicies);

        return GetDirectionsSumm(movePolicies);
    }

    private Vector2 GetDirectionsSumm(List<IMovePolicy> movePolicies)
    {
        Vector2 result = Vector2.zero;
        foreach (var item in movePolicies)
            result += item.GetDirection();

        return result;
    }
    private Vector2 GetPushBordersDirection(List<IMovePolicy> movePolicies)
    {
        Vector2 result = Vector2.zero;
        foreach (var item in _movePolicies)
            if (item is BorderMovePolicy)
                result += item.GetDirection();

        return result;
    }
}