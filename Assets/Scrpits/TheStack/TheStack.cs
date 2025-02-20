using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheStack : MonoBehaviour
{
    private const float BoundSize = 3.5f;
    private const float MovingBoundSize = 3f;
    private const float StackMovingSpeed = 5.0f;
    private const float BlockMovingSpeed = 3.5f;
    private const float ErrorMargin = 0.1f;

    public GameObject originBlock;

    private Vector3 preBlockPosition;
    private Vector3 desiredPosition;
    private float stackBounds = BoundSize;

    Transform lastBlock = null;
    float blockTransition = 0f;

    int stackCount = -1;
    public int Score { get { return stackCount; } }

    int comboCount = 0;
    public int Combo { get { return comboCount; } }

    public Color prevColor;
    public Color nextColor;

    bool isLeft = true;

    int bestScore = 0;
    public int BestScore { get { return bestScore; } }

    public const string BestScoreKey = "Stack_BestScore";

    private bool isGameOver = true;
    // Start is called before the first frame update
    void Start()
    {
        if (originBlock == null)
        {
            Debug.Log("OriginBlock is NULL");
            return;
        }

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);

        prevColor = GetRandomColor();
        nextColor = GetRandomColor();

        preBlockPosition = Vector3.down;

        Spawn_Block();
        Spawn_Block();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !isGameOver)
        {
            if (PlaceBlock())
            {
                Spawn_Block();
            }
            else
            {
                Debug.Log("Game Over");
                UpdateScore();
                isGameOver = true;
                GameOverEffect();
                TheStack_UIManager.Instance.SetScoreUI();
            }
        }
        MoveBlock();
        transform.position = Vector3.Lerp(transform.position, desiredPosition, StackMovingSpeed * Time.deltaTime);
    }

    bool Spawn_Block()
    {
        if (lastBlock != null)
        {
            preBlockPosition = lastBlock.localPosition;
        }
        GameObject newBlock = null;
        Transform newTrans = null;

        newBlock = Instantiate(originBlock);

        if (newBlock == null)
        {
            Debug.Log("NewBlock Instantiate Failed");
            return false;
        }

        ColorChange(newBlock);

        newTrans = newBlock.transform;
        newTrans.parent = this.transform;
        newTrans.localPosition = preBlockPosition + Vector3.up;
        newTrans.localRotation = Quaternion.identity;
        newTrans.localScale = new Vector2(stackBounds, 1);

        stackCount++;

        desiredPosition = Vector3.down * stackCount;
        blockTransition = 0f;

        lastBlock = newTrans;

        isLeft = !isLeft;

        TheStack_UIManager.Instance.UpdateScore();
        return true;
    }

    Color GetRandomColor()
    {
        float r = Random.Range(100f, 250f) / 255f;
        float g = Random.Range(100f, 250f) / 255f;
        float b = Random.Range(100f, 250f) / 255f;

        return new Color(r, g, b);
    }

    void ColorChange(GameObject go)
    {
        Color applyColor = Color.Lerp(prevColor, nextColor, (stackCount % 11) / 10f);

        Renderer rn = go.GetComponent<Renderer>();

        if (rn == null)
        {
            Debug.Log("Renderer is NULL");
            return;
        }

        rn.material.color = applyColor;

        Camera.main.backgroundColor = applyColor - new Color(0.2f, 0.2f, 0.2f);

        if (applyColor.Equals(nextColor))
        {
            prevColor = nextColor;
            nextColor = GetRandomColor();
        }
    }

    void MoveBlock()
    {
        blockTransition += Time.deltaTime * BlockMovingSpeed;

        float movePosition = Mathf.PingPong(blockTransition, BoundSize) - BoundSize / 2;

        if (isLeft)
        {
            lastBlock.localPosition = new Vector3(movePosition * MovingBoundSize, stackCount, 0);
        }
        else
        {
            lastBlock.localPosition = new Vector3(-movePosition * MovingBoundSize, stackCount, 0);
        }
    }

    bool PlaceBlock()
    {
        Vector3 lastPosition = lastBlock.localPosition;

        float deltaX = preBlockPosition.x - lastPosition.x;
        bool isNegativeNum = (deltaX < 0);

        deltaX = Mathf.Abs(deltaX);
        if (deltaX > ErrorMargin)
        {
            stackBounds -= deltaX;
            if (stackBounds <= 0)
            {
                return false;
            }

            float middle = (preBlockPosition.x + lastPosition.x) / 2f;
            lastBlock.localScale = new Vector2(stackBounds, 1);

            Vector3 tempPosition = lastBlock.localPosition;
            tempPosition.x = middle;
            lastBlock.localPosition = lastPosition = tempPosition;

            float rubbleHalfScale = deltaX / 2f;
            CreateRubble(
                new Vector3(
                    isNegativeNum
                    ? lastPosition.x + stackBounds / 2 + rubbleHalfScale
                    : lastPosition.x - stackBounds / 2 - rubbleHalfScale
                    , lastPosition.y
                    , lastPosition.z
                    ),
                    new Vector3(deltaX, 1, 0)
                );

            comboCount = 0;
        }
        else
        {
            ComboCheck();
            lastBlock.localPosition = preBlockPosition + Vector3.up;
        }



        return true;
    }

    void CreateRubble(Vector3 pos, Vector3 scale)
    {
        GameObject go = Instantiate(lastBlock.gameObject);
        go.transform.parent = this.transform;

        go.transform.localPosition = pos;
        go.transform.localScale = scale;
        go.transform.localRotation = Quaternion.identity;

        go.AddComponent<Rigidbody2D>();
        go.name = "Rubble";
    }

    void ComboCheck()
    {
        comboCount++;

        if ((comboCount % 5) == 0)
        {
            Debug.Log("5 Combo Success!");
            stackBounds += 0.5f;
            stackBounds = (stackBounds > BoundSize) ? BoundSize : stackBounds;
        }
    }

    void UpdateScore()
    {
        if (bestScore < stackCount)
        {
            Debug.Log("최고 점수 갱신");
            bestScore = stackCount;

            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
    }

    void GameOverEffect()
    {
        int childCount = this.transform.childCount;

        for (int i = 1; i < 20; i++)
        {
            if (childCount < i) break;

            GameObject go = transform.GetChild(childCount - i).gameObject;

            if (go.name.Equals("Rubble")) continue;

            Rigidbody2D rigid = go.AddComponent<Rigidbody2D>();
            rigid.AddForce((Vector2.up * Random.Range(0, 10f) + Vector2.right * (Random.Range(0, 10f) - 5f)) * 100f);
        }
    }

    public void Restart()
    {
        int childCount = this.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        isGameOver = false;

        lastBlock = null;
        desiredPosition = Vector3.zero;
        stackBounds = BoundSize;

        stackCount = -1;
        isLeft = true;
        blockTransition = 0f;

        comboCount = 0;

        preBlockPosition = Vector3.down;

        prevColor = GetRandomColor();
        nextColor = GetRandomColor();

        Spawn_Block();
        Spawn_Block();
    }
}
