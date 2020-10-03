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
    
    private Transform _target;

    public GameObject prefab;
    public float smoothSpeed;
    public Vector3 offset;
    
    // Cache
    private Vector3 _desiredPosition;
    private Vector3 _smoothedPosition;

    
    private void Start()
    {
        if (!gameObject.CompareTag("Player") || !prefab) return;
        
        GameObject playerCamera = Instantiate(prefab, transform.position, Quaternion.identity, null);
        playerCamera.GetComponent<PlayerCamera>().SetSettings(smoothSpeed, offset);
    }

    private void FixedUpdate()
    {
        _desiredPosition = _target.position + offset; 
        _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = _smoothedPosition;
    }

    public void SetSettings(float smoothSpeed, Vector3 offset)
    {
        this.smoothSpeed = smoothSpeed;
        this.offset = offset;
        _target = FindObjectOfType<PlayerBase>().gameObject.transform;
        transform.position = _target.position + offset;
    }
    
}