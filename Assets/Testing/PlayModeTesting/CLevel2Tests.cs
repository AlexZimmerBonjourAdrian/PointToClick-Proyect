using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine.SceneManagement;

// Assuming CLevelGeneric is a base class, you might need to mock it or provide a test implementation
public class CLevel2Tests 
{
    // private CLevel2 level2;
    // private SpriteRenderer spriteRenderer;

    // [SetUp]
    // public void Setup()
    // {
    //     SceneManager.LoadScene(2);
    //     // Create a new GameObject and attach the CLevel2 component
    //     GameObject gameObject = new GameObject("BackGround");
    //     level2 = gameObject.AddComponent<CLevel2>();

    //     // Create a mock SpriteRenderer and assign it
    //     spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    //     level2._SprtR= spriteRenderer;

    //     //List<CLevel2.Room> roomsTesting = level2.GetRooms();
    //     // Create some test rooms 
    // }

    // // [TearDown]
    // // public void Teardown()
    // // {
    // //     // Clean up the GameObject after each test
    // //     Object.Destroy(level2.gameObject);
    // // }

    // [Test]
    // public void LoadRoom_ValidIndex_LoadsRoom()
    // {

    //     // Arrange
    //     GameObject gameObject = new GameObject("BackGround");
    //     level2 = gameObject.AddComponent<CLevel2>();

    //     // Create a mock SpriteRenderer and assign it
    //     spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    //     level2._SprtR= spriteRenderer;

    //     // Act
    //     level2.LoadRoom(0);

    //     // Assert
    //     Assert.AreEqual(level2.GetRooms()[0].RoomImage, spriteRenderer.sprite);
    //     Assert.AreEqual(0, level2.GetCurrentRoomIndex());
    // }

    // [Test]
    // public void LoadRoom_InaccessibleRoom_LogsWarning()
    // {
    //     //Arrage
    //       GameObject gameObject = new GameObject("BackGround");
    //     level2 = gameObject.AddComponent<CLevel2>();

    //     // Create a mock SpriteRenderer and assign it
    //     spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    //     level2._SprtR= spriteRenderer;

    //     // Use LogAssert to check for warnings
    //     LogAssert.Expect(LogType.Warning, "La room 1 no es accesible.");

    //     // Act
    //     level2.LoadRoom(1);

    //     // Assert that the room was not loaded
    //     Assert.AreNotEqual(level2.GetRooms()[1].RoomImage, spriteRenderer.sprite);
    // }

    // [Test]
    // public void LoadRoom_InvalidIndex_LogsError()
    // {

    //     // Arrange
    //       GameObject gameObject = new GameObject("BackGround");
    //     level2 = gameObject.AddComponent<CLevel2>();

    //     // Create a mock SpriteRenderer and assign it
    //     spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    //     level2._SprtR= spriteRenderer;

    //     // Use LogAssert to check for errors
    //     LogAssert.Expect(LogType.Error, "Índice de room inválido: -1");

    //     // Act
    //     level2.LoadRoom(-1);

    //     // Assert (no specific assertion needed for the error, LogAssert handles it)
    // }

    // [Test]
    // public void GoToNextRoom_WithinBounds_LoadsNextRoom()
    // {
    //     //Arrage
    //       GameObject gameObject = new GameObject("BackGround");
    //     level2 = gameObject.AddComponent<CLevel2>();

    //     // Create a mock SpriteRenderer and assign it
    //     spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    //     level2._SprtR= spriteRenderer;

    //     // Start at the first room
    //     level2.LoadRoom(0);

    //     // Act
    //     level2.GoToNextRoom();

    //     // Assert
    //     Assert.AreEqual(2, level2.GetCurrentRoomIndex()); 
    //     Assert.AreEqual(level2.GetRooms()[2].RoomImage, spriteRenderer.sprite);
    // }

    // [Test]
    // public void GoToNextRoom_OutOfBounds_DoesNotLoadRoom()
    // {
    //     //Arrage
    //       GameObject gameObject = new GameObject("BackGround");
    //     level2 = gameObject.AddComponent<CLevel2>();

    //     // Create a mock SpriteRenderer and assign it
    //     spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    //     level2._SprtR= spriteRenderer;

    //     // Start at the last room
    //     level2.LoadRoom(2);

    //     // Act
    //     level2.GoToNextRoom();

    //     // Assert that the room index and sprite did not change
    //     Assert.AreEqual(2, level2.GetCurrentRoomIndex());
    //     Assert.AreEqual(level2.GetRooms()[2].RoomImage, spriteRenderer.sprite);
    // }

    // [Test]
    // public void GoToPreviousRoom_WithinBounds_LoadsPreviousRoom()
    // {
    //     //Arrage
    //       GameObject gameObject = new GameObject("BackGround");
    //     level2 = gameObject.AddComponent<CLevel2>();

    //     // Create a mock SpriteRenderer and assign it
    //     spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    //     level2._SprtR= spriteRenderer;

    //     // Start at the third room
    //     level2.LoadRoom(2);

    //     // Act
    //     level2.GoToPreviousRoom();

    //     // Assert
    //     Assert.AreEqual(0, level2.GetCurrentRoomIndex()); 
    //     Assert.AreEqual(level2.GetRooms()[0].RoomImage, spriteRenderer.sprite);
    // }

    // [Test] 
    // public void GoToPreviousRoom_OutOfBounds_DoesNotLoadRoom()
    // {
    //     //Arrage
    //       GameObject gameObject = new GameObject("BackGround");
    //     level2 = gameObject.AddComponent<CLevel2>();

    //     // Create a mock SpriteRenderer and assign it
    //     spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    //     level2._SprtR= spriteRenderer;

    //     // Start at the first room
    //     level2.LoadRoom(0);

    //     // Act
    //     level2.GoToPreviousRoom();

    //     // Assert that the room index and sprite did not change
    //     Assert.AreEqual(0, level2.GetCurrentRoomIndex());
    //     Assert.AreEqual(level2.GetRooms()[0].RoomImage, spriteRenderer.sprite);
    // }
}
