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
    }

    private void FixedUpdate()
    {
        foreach (var item in _floatings)
        {

            float difference = (transform.position.y + _waterHeight) - item.transform.position.y;

            if (difference < 0)
            {
                item.AddForce(Vector3.up * Mathf.Abs(difference) * _force, ForceMode.Acceleration);
            }
        }
    }
}
