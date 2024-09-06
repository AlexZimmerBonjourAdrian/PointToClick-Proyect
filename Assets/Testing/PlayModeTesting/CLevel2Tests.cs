using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.TestTools;
using System.Collections;
using UnityEditor.SceneManagement;

public class CLevel2Tests
{
//     private CLevel2 level2;
    
//     private SpriteRenderer spriteRenderer;
//     private MapData mapData;

//     [SetUp]
//     public void Setup()
//     {

//         EditorSceneManager.LoadScene(2);

//     }

//     // [TearDown]
//     // public void Teardown()
//     // {
//     //     // Clean up the GameObject after each test
//     //     Object.Destroy(level2.gameObject);
//     // }

//     [UnityTest]
//     public IEnumerator LoadRoomByTag_ValidTag_SetsRoomAccessible()
//     {


//         // Act
//         yield return new WaitForSeconds(4f);
        
//           level2 = GameObject.FindObjectOfType<CLevel2>();
//         level2._SprtR = spriteRenderer;

//         // Create a mock MapData
//         mapData = ScriptableObject.CreateInstance<MapData>();
//         mapData = level2.GetComponent<CLevel2>().GetRouterooms();
        
//         level2.SetRouterooms(mapData);
//         LogAssert.Expect(LogType.Warning, "La room 0 con tag Room1 es accesible.");

//         level2.LoadRoomByTag("Normal");

//         // Assert
//         Assert.IsTrue(level2.rooms[0].IsAccessible);
//         Assert.IsFalse(level2.rooms[1].IsAccessible);
//         Assert.IsTrue(level2.rooms[2].IsAccessible);
//     }

//      [UnityTest]
//     public IEnumerator LoadRoomByTag_InvalidTag_SetsAllRoomsInaccessible()
//     {
//         // Act
//         yield return new WaitForSeconds(4f);

//          level2 = GameObject.FindObjectOfType<CLevel2>();
//         level2._SprtR = spriteRenderer;

//         // Create a mock MapData
//         mapData = ScriptableObject.CreateInstance<MapData>();
//         mapData = level2.GetComponent<CLevel2>().GetRouterooms();
        
//         level2.SetRouterooms(mapData);
//         LogAssert.Expect(LogType.Warning, "La room 0 con tag Room1 es accesible.");
//         level2.LoadRoomByTag("InvalidTag");
        
//         // Assert
//         Assert.IsFalse(level2.rooms[0].IsAccessible);
//         Assert.IsFalse(level2.rooms[1].IsAccessible);
//         Assert.IsFalse(level2.rooms[2].IsAccessible);
//     }

//      [UnityTest]
//     public IEnumerator LoadRoomByTag_ValidTag_LogsCorrectMessage()
//     {
//         // Use LogAssert to check for warnings
//         yield return new WaitForSeconds(4f);

//          level2 = GameObject.FindObjectOfType<CLevel2>();
//         level2._SprtR = spriteRenderer;

//         // Create a mock MapData
//         mapData = ScriptableObject.CreateInstance<MapData>();
//         mapData = level2.GetComponent<CLevel2>().GetRouterooms();
        
//         level2.SetRouterooms(mapData);
//         LogAssert.Expect(LogType.Warning, "La room 0 con tag Room1 es accesible.");

//         // Act
//         level2.LoadRoomByTag("Normal");

//         Assert.IsFalse(level2.rooms[0].IsAccessible);
//         Assert.IsFalse(level2.rooms[1].IsAccessible);
//         Assert.IsFalse(level2.rooms[2].IsAccessible);
//     }
//   [UnityTest]
//     public IEnumerator LoadRoomByTag_InvalidTag_LogsCorrectMessage()
//     {
//         yield return new WaitForSeconds(4f);

//                level2 = GameObject.FindObjectOfType<CLevel2>();
//         level2._SprtR = spriteRenderer;

//         // Create a mock MapData
//         mapData = ScriptableObject.CreateInstance<MapData>();
//         mapData = level2.GetComponent<CLevel2>().GetRouterooms();
        
//         level2.SetRouterooms(mapData);
//         // Use LogAssert to check for warnings
//         LogAssert.Expect(LogType.Warning, "La room 0 con tag InvalidTag no es accesible.");
//         LogAssert.Expect(LogType.Warning, "La room 1 con tag InvalidTag no es accesible.");
//         LogAssert.Expect(LogType.Warning, "La room 2 con tag InvalidTag no es accesible.");

//         // Act
//         level2.LoadRoomByTag("InvalidTag");
//     }
}
