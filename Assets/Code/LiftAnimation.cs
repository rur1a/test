using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code
{
    public class LiftAnimation : MonoBehaviour
    {
        [SerializeField] private float _height;
        [SerializeField] private float _duration;
        private Coroutine _coroutine;

        public void Play()
        {
            _coroutine = StartCoroutine(AnimationRoutine());
        }

        public void Stop()
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator AnimationRoutine()
        {
            Vector3 startPosition = transform.position;
            for (float i = 0; i < 1; i += Time.deltaTime / _duration)
            {
                Vector3 endPosition = Input.mousePosition.AsWorldPositionFor(transform.position.WithY(_height));
                transform.position = Vector3.Lerp(startPosition, endPosition, i);
                yield return null;
            }
        }
    }
}