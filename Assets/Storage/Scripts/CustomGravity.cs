﻿using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour {

    private new Rigidbody rigidbody;

    public GameObject target;
    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

	void Start () {
        this.rigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
            target = hit.collider.gameObject;*/
	}

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 target_face = target.transform.position + target.transform.TransformDirection(Vector3.back * transform.localScale.z)/2;
            Vector3 newRot = target.transform.rotation.eulerAngles + new Vector3(-90, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(fixR(newRot.x),fixR(newRot.y),fixR(newRot.z)), 0.2f);
            transform.position = Vector3.Lerp(transform.position, target_face, 0.2f);
        }
    }

    float fixR(float f)
    {
        return f % 360;
    }
}
