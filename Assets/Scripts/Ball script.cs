using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Ballscript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private float jumpForce;
    public bool onGround;
    private int coin;
    public TextMeshProUGUI coinUI;
    public int targetScore = 5;
    public string nextSceneName;
    private AudioSource coinSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coin = 0;
        coinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = InputSystem.actions["Horizontal"].ReadValue<float>();
        float verticalMove = InputSystem.actions["Vertical"].ReadValue<float>();
        if (InputSystem.actions["Jump"].triggered && onGround)
        {
            jumpForce = jumpSpeed;
            onGround = false;
        }
        else
        {
            jumpForce = 0f;
        }
        Vector3 movement = new Vector3(horizontalMove, jumpForce, verticalMove);
        rb.AddForce(movement * speed * Time.deltaTime);

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinSound.Play();
            Destroy(other.gameObject);
            transform.localScale *= 1.2f;
            coin++;
            coinUI.text = "Coin: " + coin;
            targetScore--;
            if (targetScore <= 0)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
        else if (other.gameObject.tag == "Boundary")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
