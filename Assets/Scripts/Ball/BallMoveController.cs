using Assets.Scripts;
using UnityEngine;

namespace Ball
{
    public class BallMoveController : MonoBehaviour
    {
        [SerializeField] private Transform rayout;
        [SerializeField] private LayerMask layer;

        private LineRenderer _lineRenderer;
        private Rigidbody _rigidbody;
        private GrappleController _grappleController;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _rigidbody = GetComponent<Rigidbody>();
            _grappleController = new GrappleController(ref _lineRenderer, layer, rayout, transform);
            _rigidbody.maxAngularVelocity = .5f;
        }

        private void Start()
        {
            CameraSiganls.onGetTargetPos(transform);
        }

        private void Update()
        {
            LockTheRotation();
            if (Input.GetMouseButtonDown(0))
            {
                UISignals.onGameStart();
                _rigidbody.isKinematic = false;
                _grappleController.StartGrapple();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _grappleController.StopGrapple();
            }
        }

        private void LateUpdate()
        {
            _grappleController.DrawRope();
        }

        private void LockTheRotation()
        {
            if (_rigidbody.angularVelocity.x > 1)
            {
                //_rigidbody.angularVelocity = Vector3.zero;
            }
            if (_rigidbody.angularVelocity.x < -1)
            {
                _rigidbody.angularVelocity = Vector3.right;
                return;
            }
        }
    }
}