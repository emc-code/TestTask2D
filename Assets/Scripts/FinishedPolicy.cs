using UnityEngine;
public class FinishedPolicy : IMovementPolicy
{
    public Vector2 GetDirection()
    {
        return Vector2.zero;
    }
}