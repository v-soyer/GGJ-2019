using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject GameManager;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Init file = GameManager.GetComponent<Init>();
        rb = GetComponent<Rigidbody>();
        Debug.Log(file.all);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move_h = Input.GetAxis("Horizontal");
        float move_v = Input.GetAxis("Vertical");



        Vector3 move = new Vector3(move_h, 0.0f, move_v);
        rb.AddForce(move * 10);
    }
}
