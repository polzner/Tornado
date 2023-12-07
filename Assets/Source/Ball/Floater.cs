using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField] private float _waterHeight;
    [SerializeField] private float _force;

    private List<Rigidbody> _floatings = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        _floatings.Add(other.GetComponent<Rigidbody>());
        Debug.Log(other);
    }

    private void FixedUpdate()
    {
        foreach (var item in _floatings)
        {
            //float difference = transform.position.y + _waterHeight - item.transform.position.y;

            //if ((transform.position.y + _waterHeight) > item.transform.position.y)
            //{
            //    item.AddForce(Vector3.up * -Physics.gravity.y * Mathf.Abs(difference) * _force, ForceMode.Acceleration);
            //}

            var toCenter = item.transform.position - transform.position;
            var velocity = item.velocity;
            Vector3.OrthoNormalize(ref toCenter, ref velocity);
            item.AddForce(velocity);
        }
    }
}
