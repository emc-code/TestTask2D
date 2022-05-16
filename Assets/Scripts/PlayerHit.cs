using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    public float Radius => _radius;

    private float _radius;

    private void Awake()
    {
        SetRadius(Slider.value);
        Slider.onValueChanged.AddListener(SetRadius);
    }

    private void SetRadius(float value)
    {
        if (value < 0)
            throw new System.ArgumentOutOfRangeException(nameof(value));

        _radius = value;
    }
}