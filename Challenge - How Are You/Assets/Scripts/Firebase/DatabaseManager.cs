using Firebase.Database;
using System;
using System.Collections
    ;
using System.Xml.Linq;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string userID;
    private DatabaseReference dbReference;

    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

        GetInfo();
    }

    public void CreateUser()
    {
        User newUser = new User(CollaboratorsNew.lastPlayerInput, UIMinigame.score);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("Users").Child(userID).SetRawJsonValueAsync(json);
    }

    void GetInfo()
    {
        StartCoroutine(GetInput((string lastPlayerInput) =>
        {
            CollaboratorsNew.lastPlayerInput = lastPlayerInput;
        }));

        StartCoroutine(GetScore((int score) =>
        {
            UIMinigame.score = score;
        }));
    }

    public IEnumerator GetInput(Action<String> onCallback)
    {
        var userInputData = dbReference.Child("users").Child(userID).Child("lastPlayerInput").GetValueAsync();

        yield return new WaitUntil(predicate: () => userInputData.IsCompleted);

        if (userInputData != null)
        {
            DataSnapshot snapshot = userInputData.Result;
            onCallback.Invoke((string)snapshot.Value);
        }
    }

    public IEnumerator GetScore(Action<int> onCallback)
    {
        var userScoreData = dbReference.Child("users").Child(userID).Child("score").GetValueAsync();

        yield return new WaitUntil(predicate: () => userScoreData.IsCompleted);

        if (userScoreData != null)
        {
            DataSnapshot snapshot = userScoreData.Result;
            onCallback.Invoke((int)snapshot.Value);
        }
    }
}
