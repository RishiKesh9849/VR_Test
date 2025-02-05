using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowableKnife : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DetachFromParent()
    {
        transform.parent = null;
    }


    private void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                var knifeForward = transform.forward.normalized;
                var normal = contact.normal.normalized;

                var dotValue = Vector3.Dot(knifeForward, normal);
                Debug.Log("dot value : " + dotValue);

                if (dotValue < -0.7f)
                {
                    //forward -pointy end
                    rb.isKinematic = true;
                    transform.position = contact.point;
                }
                else
                {
                    //backward - blunt postion
                    rb.isKinematic = false;

                }
            }

        }
    }
}
