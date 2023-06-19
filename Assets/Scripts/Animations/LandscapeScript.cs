using UnityEngine;

namespace Animations
{
    public class LandscapeScript : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private Vector3 endPosition;
        [SerializeField] private Vector3 startPosition;

        private Transform _transform;

        private void Start()
        {
            _transform = this.transform;
            _transform.position = startPosition;
        }

        // Update is called once per frame
        private void Update()
        {
            _transform.Translate(Vector3.left * (speed * Time.deltaTime));
            if (_transform.position.x <= endPosition.x) _transform.position = startPosition;
        }
    }
}
