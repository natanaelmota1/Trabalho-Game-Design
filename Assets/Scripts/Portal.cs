using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        switch (transform.position.x)
        {
            case < 0f when transform.position.y > 0f:
                transform.rotation = Quaternion.Euler(0f, 0f, 135f);
                break;
            case > 0f when transform.position.y > 0f:
                transform.rotation = Quaternion.Euler(0f, 0f, 45f);
                break;
            case < 0f when transform.position.y < 0f:
                transform.rotation = Quaternion.Euler(0f, 0f, 225f);
                break;
            case > 0f when transform.position.y < 0f:
                transform.rotation = Quaternion.Euler(0f, 0f, 315f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.3f);
    }
}
