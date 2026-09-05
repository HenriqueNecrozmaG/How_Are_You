using Firebase.Database;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string userID;
    private DatabaseReference dbReference = FirebaseDatabase.DefaultInstance.RootReference;

    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
    }

    public void CreateUser()
    {
        User newUser = new User(CollaboratorsNew.lastPlayerInput, UIMinigame.score);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("Users").Child(userID).SetRawJsonValueAsync(json);
    }
}