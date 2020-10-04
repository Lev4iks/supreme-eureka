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
    public Vector3 mainOffset;
    public Vector3 eventOffset;

    // Cache
    private Vector3 _desiredPosition;
    private Vector3 _smoothedPosition;

    
    private void Start()
    {
        if (!gameObject.CompareTag("Player") || !prefab) return;
        
        GameObject playerCamera = Instantiate(prefab, Vector3.zero, Quaternion.identity, null);
        playerCamera.GetComponent<PlayerCamera>().SetSettings(smoothSpeed, mainOffset, eventOffset);
        Destroy(this);
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

    private void SetSettings(float smoothSpeed, Vector3 mainOffset, Vector3 eventOffset)
    {
        this.smoothSpeed = smoothSpeed;
        this.mainOffset = mainOffset;
        this.eventOffset = eventOffset;
        transform.position += mainOffset;
    }

    public void Zoom(Vector3 newOffset, Vector3 newPosition)
    {
        _targetPosition = newPosition + newOffset; 
        _isZoomed = false;
    }

}