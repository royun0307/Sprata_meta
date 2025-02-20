using UnityEngine;

public class PlayerCustomizer : MonoBehaviour
{
    [SerializeField] private GameObject playerSprite;

    private PlayerController playerController;
    private AnimationHandler animationHandler;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animationHandler = GetComponent<AnimationHandler>();

        OnSelectSprite(GameManager.Instance.playerSprite);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mannequin") && Input.GetKey(KeyCode.F))
        {
            GameObject go = collision.gameObject;
            MannequinHolder mh = go.GetComponent<MannequinHolder>();

            OnSelectSprite(mh.mannequinPrefab);
        }
    }

    public void OnSelectSprite(GameObject prefab)
    {
        if (playerSprite != null)
        {
            Destroy(playerSprite);
        }

        GameObject mannequinPrefab = prefab;
        if (mannequinPrefab == null)
        {
            Debug.LogWarning("MannequinHolder에 knightMannequinPrefab이 할당되지 않았습니다.");
            return;
        }

        GameObject newPlayer = Instantiate(mannequinPrefab);

        newPlayer.transform.parent = this.transform;
        newPlayer.transform.localPosition = Vector3.zero;
        newPlayer.transform.localRotation = Quaternion.identity;
        newPlayer.transform.localScale = Vector3.one;

        playerSprite = newPlayer;
        playerController.characterRenderer = newPlayer.GetComponent<SpriteRenderer>();
        animationHandler.SetPlayerAnimator(playerSprite);
        GameManager.Instance.playerSprite = prefab;
    }
}
