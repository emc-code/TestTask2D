using UnityEngine;
public class FinishedPolicy : IMovePolicy
{
    public Vector2 GetDirection()
    {
        return Vector2.zero;
    }
}