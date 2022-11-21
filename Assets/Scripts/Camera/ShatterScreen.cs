using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShatterScreen : MonoBehaviour
{
    [SerializeField] private Transform explosionPosition;

    public List<Vector3> _orginalPosition;
    private Vector3 _originalRotation;

    private void Awake()
    {
        _orginalPosition = new List<Vector3>();
        _originalRotation = new Vector3(320, 40, 330);
        RecordShattersStartPosition();
    }

    private void OnEnable()
    {
        StartCoroutine(FreezeFrame());
    }

    //test
    private IEnumerator FreezeFrame()
    {
        yield return new WaitForSecondsRealtime(2);
        ApplyForceToShatters();
        Invoke("DeActivateObject", 2);
    }

    private void OnDisable()
    {
        //rest position
        DeActivatePhysics();
        RewindShattersPosition();
        ResetShatterRotations();
    }

    private void RecordShattersStartPosition()
    {
        int index = 0;
        foreach (Transform shatter in transform)
        {
            _orginalPosition.Add(shatter.position);
        }
    }

    private void RewindShattersPosition()
    {
        int index = 0;
        while (index < _orginalPosition.Count)
        {
            transform.GetChild(index).position = _orginalPosition[index];
            index++;
        }
    }

    private void ResetShatterRotations()
    {
        int index = 0;
        while (index < _orginalPosition.Count)
        {
            transform.GetChild(index).Rotate(new Vector3(320, 40, 330));
            index++;
        }
    }

    private void ApplyForceToShatters()
    {
        foreach (Transform shatter in transform)
        {
            Rigidbody body;
            shatter.TryGetComponent<Rigidbody>(out body);
            body.isKinematic = false;
            body.AddExplosionForce(200, explosionPosition.position, 10);
        }
    }

    private async void DeActivatePhysics()
    {
        foreach (Transform shatter in transform)
        {
            Rigidbody body;
            shatter.TryGetComponent<Rigidbody>(out body);
            body.isKinematic = true;
        }
        await Task.Yield();
    }

    private void DeActivateObject() => gameObject.SetActive(false);
}