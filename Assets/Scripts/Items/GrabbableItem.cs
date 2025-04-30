using UnityEngine;

public class GrabbableItem : MonoBehaviour, IGrabbable
{
    public ItemData itemData;

    private Renderer _itemRenderer;
    private Rigidbody _rb;
    private Collider _itemCollider;
    private Collider _playerCollider;

    private void Awake()
    {
        _itemRenderer = GetComponent<Renderer>();
        if (_itemRenderer != null)
        {
            // Creates an instance of the material so changes affect only this item.
            _itemRenderer.material = new Material(_itemRenderer.material);
        }
        _rb = GetComponent<Rigidbody>();
        
        _itemCollider = GetComponent<Collider>();
        // Assuming the player's collider is on the same GameObject as the PlayerMovement component
        _playerCollider = FindObjectOfType<PlayerMovement>()?.GetComponent<Collider>();
    }

    public void SetTransparency(float alpha)
    {
        if (_itemRenderer != null)
        {
            Material mat = _itemRenderer.material;
            
            // Configure the material for transparency (works with the Standard shader)
            mat.SetFloat("_Mode", 2);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
            
            // Set the alpha value.
            Color newColor = mat.color;
            newColor.a = alpha;
            mat.color = newColor;
        }
    }

    public ItemData GetItemData()
    {
        return itemData;
    }

    // IInteractable implementation.
    // When interacted with, pick up the item if nothing is held.
    public void Interact(GrabSystem grabSystem)
    {
        Debug.Log("Item Interact triggered.");

        if (grabSystem.HeldItem == null)
        {
            Pickup(grabSystem);
        }
    }

    // IGrabbable implementation.
    public void Pickup(GrabSystem grabSystem)
    {
        // Ignore collisions between the player and this held item.
        if (_playerCollider != null && _itemCollider != null)
        {
            Physics.IgnoreCollision(_playerCollider, _itemCollider, true);
        }

        grabSystem.SetHeldItem(this);

        // Disable physics so the item can follow the hold position.
        if (_rb != null)
        {
            _rb.isKinematic = true;
        }

        // Change transparency to indicate the item is held.
        SetTransparency(0.75f);
    }

    public void Drop(GrabSystem grabSystem)
    {
        // Revert transparency.
        SetTransparency(1f);

        // Re-enable collisions.
        if (_playerCollider != null && _itemCollider != null)
        {
            Physics.IgnoreCollision(_playerCollider, _itemCollider, false);
        }
        
        // Re-enable physics.
        if (_rb != null)
        {
            _rb.isKinematic = false;
        }
    }
}
