using UnityEngine;

public class Camerascript : MonoBehaviour
{
    public GameObject ball;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + offset;
    }
}
