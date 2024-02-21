using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField] private float _waterHeight;
    [SerializeField] private float _force;

    private List<Rigidbody> _floatings = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        _floatings.Add(rigidbody);
        Vector3 direction = transform.position - rigidbody.position;
        rigidbody.useGravity = false;
        rigidbody.velocity = Vector3.zero;
        other.GetComponent<Rigidbody>().AddForce(new Vector3(direction.z, 0f, -direction.x).normalized, ForceMode.VelocityChange);
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

            var toCenter = transform.position.Vector3YZeroAxisPosition() - item.position.Vector3YZeroAxisPosition();
            var v2 = item.velocity.Vector3YZeroAxisPosition();
            var binormal = Vector3.up;
            Vector3.OrthoNormalize(ref toCenter, ref v2, ref binormal);
            Debug.Log(v2);
            item.AddForce(toCenter.normalized);

            //Vector3 forceDirection = (transform.position - item.position).normalized;
            //float distanceSqr = (transform.position - item.position).sqrMagnitude;
            //float strength = 10f / distanceSqr;

            //item.AddForce(forceDirection * strength);
        }
    }
}
