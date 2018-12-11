using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;
    private Vector2 MV;
    private Vector2 Mp;
    public GameObject cam;
    public GameObject cube;
    public bool FixedCam;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        Mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 MI = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MV = MI.normalized * speed;
	}

    void FixedUpdate()
    {
        Vector2 rd = Mp - rb.position;
        float angle = Mathf.Atan2(rd.y, rd.x) * Mathf.Rad2Deg - 90f;
        rb.MovePosition(rb.position + MV * Time.fixedDeltaTime);
        rb.rotation = angle;
        if (FixedCam == true) {
            cam.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z - 10);
                              }
    }
}
