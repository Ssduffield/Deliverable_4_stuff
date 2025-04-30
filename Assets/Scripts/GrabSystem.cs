using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    [Header("Grab Settings")]
    public Camera playerCamera;
    public Transform holdPosition;
    public float interactDistance = 5f;
    public Transform gunPoint;

    public DropSoundEvent onDropSound;

    private IGrabbable _heldItem;
    private PlayerMovement _playerMovement;
    
    private float _baseWalkingSpeed;
    private float _baseRunningSpeed;
    private float _baseLookSpeed;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _baseWalkingSpeed = _playerMovement.walkSpeed;
        _baseRunningSpeed = _playerMovement.runSpeed;
        _baseLookSpeed = _playerMovement.lookSpeed;
    }

    void Update()
    {
        if (_heldItem != null)
        {
            MonoBehaviour heldMono = _heldItem as MonoBehaviour;
            if (heldMono != null)
            {
                // Use gunPoint for guns, otherwise use holdPosition.
                if (heldMono.GetComponent<GunItem>() != null)
                {
                    heldMono.transform.position = gunPoint.position;
                    heldMono.transform.rotation = gunPoint.rotation;
                }
                else
                {
                    heldMono.transform.position = holdPosition.position;
                    heldMono.transform.rotation = holdPosition.rotation;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_heldItem == null)
            {
                TryPickup();
            }
            else
            {
                DropItem();
            }
        }
    }

    private void TryPickup()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(this);
            }
        }
    }

    public void SetHeldItem(IGrabbable item)
    {
        _heldItem = item;
        float weight = (item.GetItemData() != null) ? item.GetItemData().weight : 0f;
        AdjustPlayerSpeed(weight);
        _playerMovement.canSprint = false;
    }

    private void DropItem()
    {
        if (_heldItem != null)
        {
            _heldItem.Drop(this);
            
            ResetPlayerSpeed();
            _playerMovement.canSprint = true;

            ItemData data = _heldItem.GetItemData();
            if (data != null && data.dropAudio != null)
            {
                float volume = CalculateVolume(data.weight);
                onDropSound.Invoke(data.dropAudio, volume);
            }
            
            _heldItem = null;
        }
    }

    private float CalculateVolume(float weight)
    {
        float volume = weight / 100f;
        return Mathf.Clamp(volume, 0f, 1f);
    }

    private void AdjustPlayerSpeed(float weight)
    {
        float speedFactor = 1f / (1f + weight * 0.25f);
        _playerMovement.walkSpeed = _baseWalkingSpeed * speedFactor;
        _playerMovement.runSpeed = _baseRunningSpeed * speedFactor;
        _playerMovement.lookSpeed = _baseLookSpeed * speedFactor;
    }

    private void ResetPlayerSpeed()
    {
        _playerMovement.walkSpeed = _baseWalkingSpeed;
        _playerMovement.runSpeed = _baseRunningSpeed;
        _playerMovement.lookSpeed = _baseLookSpeed;
    }

    public IGrabbable HeldItem => _heldItem;

}
