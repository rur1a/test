using UnityEngine;
using UnityEngine.EventSystems;

namespace Code
{
    public class Ball : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LiftAnimation _liftAnimation;
        private Vector3 _cachedPosition;

        private void Awake()
        {
            _cachedPosition = transform.position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rigidbody.isKinematic = true;
            _liftAnimation.Play();
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.AsWorldPositionFor(transform.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _rigidbody.isKinematic = false;
            _liftAnimation.Stop();
        }

        public void ResetPosition()
        {
            transform.position = _cachedPosition;
            _rigidbody.velocity = Vector3.zero;
        }
    }
}