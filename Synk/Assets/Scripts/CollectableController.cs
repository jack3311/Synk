using UnityEngine;
using System.Collections;

enum CollectibleType
{
    HARPOON,
    SHIELD,
    BOOTS
}

public class CollectableController : MonoBehaviour {

    [SerializeField]
    private CollectibleType collectibleType;

    [SerializeField]
    private GameObject collectEffect;

    [SerializeField]
    private GameObject cameraObject;

	void Start () {
	
	}
	
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (collectibleType)
            {
                case CollectibleType.HARPOON:
                    other.GetComponent<HarpoonController>().ActivateHarpoon();
                    break;

                case CollectibleType.SHIELD:
                    other.GetComponent<ShieldController>().ActivateShield();
                    break;

                case CollectibleType.BOOTS:
                    other.GetComponent<BootsController>().ActivateBoots();
                    break;
            }


            cameraObject.GetComponent<CameraShake>().ShakeFor(0.3f);
            Object collectEffectInstance = Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(collectEffectInstance, 1f);
            Destroy(this.gameObject);
        }
    }
}
