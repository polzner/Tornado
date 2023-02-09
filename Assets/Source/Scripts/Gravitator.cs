using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitator : MonoBehaviour
{
    [SerializeField] private float _force = 100f;
    [SerializeField] private Vector3 _startTorque = new Vector3(0, 10f, 10f);

    private List<GravitateRoutine> _routines = new List<GravitateRoutine>();

    public void Gravitate(Transform target, GameObject item)
    {
        Rigidbody rigidbody = item.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        _routines.Add(new GravitateRoutine(item, StartCoroutine(GravitateRoutine(target, rigidbody))));
    }

    public void StopGravitate(GameObject item)
    {
        foreach (var routine in _routines)
        {
            if (routine.GravitatingObject == item)
            {
                StopCoroutine(routine.Routine);
                _routines.Remove(routine);
                return;
            }
        }

        throw new System.ArgumentException("cant find item");
    }

    private IEnumerator GravitateRoutine(Transform target, Rigidbody item)
    {
        item.AddTorque(_startTorque, ForceMode.VelocityChange);

        while (true)
        {
            Vector3 direction = (target.position - item.position).normalized;
            item.AddForce(direction * _force, ForceMode.Acceleration);
            yield return null;
        }
    }
}
