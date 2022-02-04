using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControi : MonoBehaviour
{

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 3f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 3f * Time.deltaTime);
        }
    }
}
