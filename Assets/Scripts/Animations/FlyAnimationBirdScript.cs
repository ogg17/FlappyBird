using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FlyAnimationBirdScript : MonoBehaviour
    {
        [SerializeField] private float fallValue;
    
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;

        private Vector3 _fall;
        private Vector3 _rise;
        private void Start()
        {
            _transform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _fall = new Vector3(fallValue, -1, 0);
            _rise = new Vector3(fallValue, 1, 0);
        }

        private void Update()
        {
            _transform.right = _rigidbody2D.velocity.y switch
            {
                > 0 => _rise,
                < 0 => _fall,
                _ => Vector3.right
            };
        }
    }
}
