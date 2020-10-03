using UnityEngine;


public class PlayerCamera : MonoBehaviour
{
    #region Singleton
    
    public static PlayerCamera Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
        
    }
    
    #endregion

    private bool _isZoomed = true;
    private Vector3 _targetPosition;

    public GameObject prefab;
    public float smoothSpeed;
    public Vector3 offset;

    // Cache
    private Vector3 _desiredPosition;
    private Vector3 _smoothedPosition;

    
    private void Start()
    {
        if (!gameObject.CompareTag("Player") || !prefab) return;
        
        GameObject playerCamera = Instantiate(prefab, Vector3.zero, Quaternion.identity, null);
        playerCamera.GetComponent<PlayerCamera>().SetSettings(smoothSpeed, offset);
    }

    private void FixedUpdate()
    {
        if (!_isZoomed)
        {
            if (transform.position == _targetPosition)
                _isZoomed = true;

            _desiredPosition = _targetPosition; 
            _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = _smoothedPosition;
        }

    }

    public void SetSettings(float smoothSpeed, Vector3 offset)
    {
        this.smoothSpeed = smoothSpeed;
        this.offset = offset;
        transform.position += offset;
    }

    public void Zoom(Vector3 newOffset, Vector3 newPosition)
    {
        offset = newOffset;
        _targetPosition = newPosition + offset; 
        _isZoomed = false;
    }

}