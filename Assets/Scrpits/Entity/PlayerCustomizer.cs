using UnityEngine;

public class PlayerCustomizer : MonoBehaviour
{
    [SerializeField] private GameObject playerSprite;

    private PlayerController playerController;
    private AnimationHandler animationHandler;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        animationHandler = GetComponent<AnimationHandler>();//플레이어 애니메이션핸들러

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

    public void OnSelectSprite(GameObject prefab)//선택한 스프라이트 생성
    {
        if (playerSprite != null)//스프라이트가 이미 있으면
        {
            Destroy(playerSprite);
        }

        GameObject mannequinPrefab = prefab;

        if (mannequinPrefab == null)//선택한 스프라이트가 없으면
        {
            Debug.LogWarning("MannequinHolder에 MannequinPrefab이 할당되지 않았습니다.");
            return;
        }

        GameObject newPlayer = Instantiate(mannequinPrefab);//생성

        newPlayer.transform.parent = this.transform;
        newPlayer.transform.localPosition = Vector3.zero;
        newPlayer.transform.localRotation = Quaternion.identity;
        newPlayer.transform.localScale = Vector3.one;

        playerSprite = newPlayer;
        playerController.characterRenderer = newPlayer.GetComponent<SpriteRenderer>();
        animationHandler.SetPlayerAnimator(playerSprite);
        GameManager.Instance.playerSprite = prefab;//게임매니저에 저장
    }
}
