using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public float speed = 20.0f;

    float limitLeft = -3.5f;
    float limitRight = 3.5f;

    void Awake()
    {
        PlayerBehaviour.instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey) && limitLeft < transform.position.x)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(rightKey) && limitRight > transform.position.x)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }

    public Vector3 GetPosition() {
        return transform.position;
    }
}
