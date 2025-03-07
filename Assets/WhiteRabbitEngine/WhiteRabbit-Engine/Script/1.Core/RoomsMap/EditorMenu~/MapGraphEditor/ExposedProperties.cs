using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// The `ExposedProperties` class is designed to hold and manage a set of properties that can be exposed 
/// or modified within a visual editor or at runtime.
///
/// **Purpose:**
/// This class acts as a data container for various property values, primarily intended for use in a 
/// node-based editor or system, such as a room map editor or a dialogue graph editor.
/// The properties defined here can be linked to visual elements or functional components within the editor,
/// allowing users to configure them directly in the editor's interface.
/// 
/// **Key Features:**
/// 1. **Data Container:** Holds several string properties that can represent different kinds of data (e.g., names, values, assets).
/// 2. **Serializable:** The `[System.Serializable]` attribute allows instances of this class to be serialized,
///    meaning they can be saved to files, stored in data structures, and displayed in the Unity Editor's Inspector.
/// 3. **Static Factory Method:** The `CreateInstance()` method provides a simple way to create new instances of `ExposedProperties`.
/// 4. **Customizable Property Names:** It contains various properties, which suggest that is a generic class
///    that can be used in differents contexts, for example, character properties, generic properties, etc.
/// 
/// **Properties:**
/// - `PropertyNameCharacter`: A string property that could represent a character's name or a related identifier.
/// - `PropertyName`: A generic string property that can hold any text-based information.
/// - `PropertySprite`: A string property likely intended to store the name or path of a sprite asset.
/// - `PropertyValue`: A generic string property that can store any value as a string.
/// 
/// **How to Use:**
/// 1. **Instantiating:** Create a new `ExposedProperties` instance using `ExposedProperties.CreateInstance()`.
/// 2. **Accessing Properties:** Access and modify the string properties (e.g., `PropertyNameCharacter`, `PropertyName`) directly.
/// 3. **Serialization:** Store the `ExposedProperties` instance in a data structure that supports serialization (e.g., a list or a class).
/// 4. **Integration with Editors:** In a custom editor, expose the properties of an `ExposedProperties` instance to the user via UI elements.
/// 5. **Runtime Usage:** Load the properties from a serialized object and use the values to configure game elements at runtime.
/// 
/// **Example Use Cases:**
/// - **Room Map Editor:** An `ExposedProperties` instance could represent a room's metadata, such as its name, description, or linked assets.
/// - **Dialogue Graph Editor:** An `ExposedProperties` instance could store a dialogue node's text, character name, or associated sprite.
/// - **Game Object Configuration:** An `ExposedProperties` instance could hold configuration data for a game object, like a character's name or an object's description.
/// 
/// **Future Improvements:**
/// - **Type Safety:** Consider adding support for different data types (e.g., int, float, bool) instead of just strings, potentially using generics.
/// - **Property Attributes:** Use custom attributes to add metadata to properties, such as display names, ranges, or validation rules.
/// - **Property Change Events:** Implement events or callbacks to notify other parts of the system when a property value changes.
/// - **More Property:** This class could be expanded to hold more property depending the context.
/// - **Better name:** This class name could be more specific depending on the context in which it is used.
///
/// **Current Limitations:**
/// - **String-Based:** All properties are stored as strings, which may require parsing or conversion when used.
/// - **No Validation:** There is no built-in validation for property values.
/// - **No Metadata:** Properties do not have any associated metadata (e.g., display names or tooltips).
/// - **No events:** This class does not have any method to fire an event when a propertie change.
/// </summary>
[System.Serializable]
public class ExposedProperties
{
     /// <summary>
     /// Static method to create and return a new instance of the ExposedProperties class.
     /// This provides a simple way to create new ExposedProperties objects without needing to use the "new" keyword directly.
     /// </summary>
    public static ExposedProperties CreateInstance()
    {
        return new ExposedProperties();
    }

    /// <summary>
    /// A string property that could represent a character's name or a related identifier.
    /// </summary>
    public string PropertyNameCharacter = "New String";
    /// <summary>
    /// A generic string property that can hold any text-based information.
    /// </summary>
    public string PropertyName = "New String";
    /// <summary>
    /// A string property likely intended to store the name or path of a sprite asset.
    /// </summary>
    public string PropertySprite = "New Sprite";
    /// <summary>
    /// A generic string property that can store any value as a string.
    /// </summary>
    public string PropertyValue = "New Value";
}
}
