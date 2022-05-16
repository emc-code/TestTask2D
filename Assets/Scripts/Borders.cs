using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private Transform[] Instances;

    private const float BORDER_WIDTH = 0.2f;

    private void Awake() => Resize();

    private void Update() => Resize();

    private void Resize()
    {
        Vector2 _min = Camera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 _max = Camera.ViewportToWorldPoint(new Vector2(1, 1));

        Instances[0].position = new Vector3(_min.x - BORDER_WIDTH / 2, 0, 0);
        Instances[0].localScale = new Vector3(BORDER_WIDTH, _max.y * 2);

        Instances[1].position = new Vector3(_max.x + BORDER_WIDTH / 2, 0, 0);
        Instances[1].localScale = new Vector3(BORDER_WIDTH, _max.y * 2);

        Instances[2].position = new Vector3(0, _max.y + BORDER_WIDTH / 2, 0);
        Instances[2].localScale = new Vector3(_max.x * 2, BORDER_WIDTH);


        Instances[3].position = new Vector3(0, _min.y - BORDER_WIDTH / 2, 0);
        Instances[3].localScale = new Vector3(_max.x * 2, BORDER_WIDTH);
    }
}
