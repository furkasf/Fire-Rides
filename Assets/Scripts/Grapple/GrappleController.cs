using GenericPoolSystem;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GrappleController
{
    private LineRenderer _lineRenderer;
    private SpringJoint _joint;
    private Transform _rayout;
    private Transform _parent;
    private LayerMask _layerMask;
    private Vector3 _grapplePoint;
    private float _maxRayDistance = 100;

    public GrappleController(ref LineRenderer lineRenderer, LayerMask layerMask, Transform rayout, Transform parent = null)
    {
        _lineRenderer = lineRenderer;
        _rayout = rayout;
        _layerMask = layerMask;
        _parent = parent;
    }

    public void StartGrapple()
    {
        RaycastHit hit;

        GameObject.Destroy(_joint);

        _rayout.position = _parent.position;

        if (Physics.Raycast(_rayout.position, _rayout.forward, out hit, _maxRayDistance, _layerMask.value, QueryTriggerInteraction.Ignore))
        {
            _grapplePoint = hit.point;
            _joint = _parent.gameObject.AddComponent<SpringJoint>();

            //set joint configurations
            _joint.autoConfigureConnectedAnchor = false;
            _joint.connectedAnchor = _grapplePoint + (Vector3.up * 5);

            float distanceFromPoint = Vector3.Distance(_parent.position, _grapplePoint);

            _joint.maxDistance = distanceFromPoint * 0.8f;
            _joint.minDistance = distanceFromPoint * 0.25f;

            _joint.damper = 4.5f;//spring
            _joint.damper = 7f;
            _joint.massScale = 0.5f;

            _lineRenderer.positionCount = 2;

            ReplacePartical(_grapplePoint);
        }
    }

    public void StopGrapple()
    {
        _lineRenderer.positionCount = 0;
        GameObject.Destroy(_joint);
    }

    public void DrawRope()
    {
        if (!_joint) return;
        _lineRenderer.SetPosition(0, _parent.position);
        _lineRenderer.SetPosition(1, _grapplePoint);
    }

    private void ReplacePartical(Vector3 pos)
    {
        GameObject partical = PoolSignals.onGetObjectFormPool("SmallFire");
        partical.transform.position = pos;
    }
}