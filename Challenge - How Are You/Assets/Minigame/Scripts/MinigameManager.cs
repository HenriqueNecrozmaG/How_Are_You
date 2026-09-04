using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    int[] orders = { 11000, 11001, 11010, 11011, 11100, 11101, 11110, 11111 };
    public static int [] orderValue = { 0, 0, 0, 0, 0 };
    public static int [] plateValue = { 0, 0, 0, 0, 0};
    public static float [] orderTime = {60, 60, 60, 60, 60};

    public static int plateNumber = 0;
    public static float plateXPosition = -8;
    [SerializeField] GameObject plateSelector;

    public SpriteRenderer[] currentPicture;
    public float platePosition;
    public Sprite[] orderPicture;

    public static float emptyPlate = 1;
    void Start()
    {
        int randomOrder1 = Random.Range(0, orders.Length);
        orderValue[0] = orders[randomOrder1];
        int randomOrder2 = Random.Range(0, orders.Length);
        orderValue[1] = orders[randomOrder2];
        int randomOrder3 = Random.Range(0, orders.Length);
        orderValue[2] = orders[randomOrder3];
        int randomOrder4 = Random.Range(0, orders.Length);
        orderValue[3] = orders[randomOrder4];
        int randomOrder5 = Random.Range(0, orders.Length);
        orderValue[4] = orders[randomOrder5];
    }

    void Update()
    {
        platePosition = plateXPosition;
        for (int i = 0; i < 5; i++)
        {
            if (orderValue[i] == 11000)
            {
                currentPicture[i].sprite = orderPicture[0];
            }
            if (orderValue[i] == 11001)
            {
                currentPicture[i].sprite = orderPicture[1];
            }
            if (orderValue[i] == 11010)
            {
                currentPicture[i].sprite = orderPicture[2];
            }
            if (orderValue[i] == 11011)
            {
                currentPicture[i].sprite = orderPicture[3];
            }
            if (orderValue[i] == 11100)
            {
                currentPicture[i].sprite = orderPicture[4];
            }
            if (orderValue[i] == 11101)
            {
                currentPicture[i].sprite = orderPicture[5];
            }
            if (orderValue[i] == 11110)
            {
                currentPicture[i].sprite = orderPicture[6];
            }
            if (orderValue[i] == 11111)
            {
                currentPicture[i].sprite = orderPicture[7];
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            plateNumber += 1;
            plateXPosition += 2;

            if(plateNumber > 4)
            {
                plateNumber = 0;
                plateXPosition = -8;
            }
        }

        orderTime[0] -= Time.deltaTime;
        orderTime[1] -= Time.deltaTime;
        orderTime[2] -= Time.deltaTime;
        orderTime[3] -= Time.deltaTime;
        orderTime[4] -= Time.deltaTime;

        plateSelector.transform.position = new Vector2(plateXPosition, -4.25f);
        TimeOver();
    }

    public void TimeOver()
    {
        if (orderTime[0] <= 0)
        {
            plateValue[0] = 0;
            orderTime[0] = 60;
            print(plateValue[0]);
            int randomOrder1 = Random.Range(0, orders.Length);
            orderValue[0] = orders[randomOrder1];
            print(orderValue[0]);
        }
        if (orderTime[1] <= 0)
        {
            plateValue[1] = 0;
            orderTime[1] = 60;
            print(plateValue[1]);
            int randomOrder2 = Random.Range(0, orders.Length);
            orderValue[1] = orders[randomOrder2];
            print(orderValue[1]);
        }
        if (orderTime[2] <= 0)
        {
            plateValue[2] = 0;
            orderTime[2] = 60;
            print(plateValue[2]);
            int randomOrder3 = Random.Range(0, orders.Length);
            orderValue[2] = orders[randomOrder3];
            print(orderValue[2]);
        }
        if (orderTime[3] <= 0)
        {
            plateValue[3] = 0;
            orderTime[3] = 60;
            print(plateValue[3]);
            int randomOrder4 = Random.Range(0, orders.Length);
            orderValue[3] = orders[randomOrder4];
            print(orderValue[3]);
        }
        if (orderTime[4] <= 0)
        {
            plateValue[4] = 0;
            orderTime[4] = 60;
            print(plateValue[4]);
            int randomOrder5 = Random.Range(0, orders.Length);
            orderValue[4] = orders[randomOrder5];
            print(orderValue[4]);
        }
    }
}