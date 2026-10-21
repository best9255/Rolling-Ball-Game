using UnityEngine;

public class CoinControlscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(360 * Time.deltaTime, 0, 0);
    }
}
