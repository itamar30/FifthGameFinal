using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed;
    float offscreenY;
    // Start is called before the first frame update
    void Start()
    {
        offscreenY = Camera.main.ViewportToScreenPoint(new Vector3(1, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > offscreenY)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

        }
    }
}
