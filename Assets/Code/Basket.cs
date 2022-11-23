using UnityEngine;

namespace Code
{
    public class Basket : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _goalParticle;
        [SerializeField] private Score _score;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out Ball ball)) 
                return;

            if (ball.gameObject.layer == gameObject.layer)
            {
                _score.AddPoint(1);
                _goalParticle.Play();
            }
            ball.ResetPosition();
        }
    }
}