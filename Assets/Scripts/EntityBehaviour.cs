using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBehaviour : MonoBehaviour
{
    protected bool _isPlaying = false;
    public virtual void Play() => _isPlaying = true;
    public virtual void Pause() => _isPlaying = false;

    protected abstract void EntityUpdate();

    private void FixedUpdate()
    {
        EntityUpdate();
    }

}