using UnityEditor;
using UnityEngine;
using WhiteRabbit.Core;

 namespace WhiteRabbit.Specialization
{
    /// <summary>
    /// CQTEDataEditor is a custom editor for the CQTEData ScriptableObject.
    /// It allows for a more user-friendly and organized way to edit CQTEData properties in the Unity Inspector.
    /// This class extends the standard Unity editor to create a specialized interface for editing QTE data.
    ///
    /// **Key Responsibilities:**
    /// 1. **Custom Inspector:** Creates a custom inspector for `CQTEData` assets, allowing designers to edit QTE properties more intuitively.
    /// 2. **Property Handling:** Manages the display and modification of various properties within `CQTEData`, such as `QTEId`, `TypePuzzle`, `KeyToPress`, etc.
    /// 3. **Conditional Display:** Conditionally displays different properties based on the selected `QTETypePuzzle`.
    ///    - For example, it shows `KeyToPress` and `RequiredPresses` only when the `TypePuzzle` is `KeyPress`.
    /// 4. **Serialization:** Uses Unity's serialization system to handle the saving and loading of `CQTEData` properties.
    /// 5. **Data Integrity:** Helps ensure that the data entered by designers is appropriate for the selected QTE type.
    /// 6. **Organization:** Organizes the properties in the inspector, improving the design process.
    ///
    /// **How It Works:**
    /// - **CustomEditor Attribute:** The `[CustomEditor(typeof(CQTEData))]` attribute tells Unity that this class is a custom editor for `CQTEData`.
    /// - **Serialized Properties:** `SerializedProperty` objects are used to represent and manipulate the properties of the `CQTEData` asset.
    /// - **OnEnable:** In the `OnEnable` method, the script gets references to the `SerializedProperty` objects for each field in the `CQTEData` class.
    /// - **OnInspectorGUI:** The `OnInspectorGUI` method is where the custom inspector is drawn.
    ///   - `serializedObject.Update()`: This line refreshes the serialized object with any changes.
    ///   - `EditorGUILayout.PropertyField()`: This method is used to draw each property in the inspector.
    ///   - **Conditional Logic:** A `switch` statement is used to conditionally display different properties based on the `TypePuzzle` value.
    ///   - `serializedObject.ApplyModifiedProperties()`: This line applies any changes made in the inspector to the underlying object.
    /// - **QTETypePuzzle Specific Properties:** The code dynamically shows or hides properties based on the chosen QTE type.
    ///   - **KeyPress:** Shows `KeyToPress`, `Duration`, `incrementSpeedProp`,`successThresholdProp` and `partialSuccessThresholdProp`.
    ///   - **Sequence:** Displays a label indicating that sequence-specific properties will be implemented in the future.
    ///   - **Selection:** Displays a label indicating that selection-specific properties will be implemented in the future.
    ///
    /// **How to Use:**
    /// 1. **Create CQTEData Assets:** Create new `CQTEData` assets in your project (e.g., by right-clicking in the Project window and selecting "Create/Wherearethealices/QTE").
    /// 2. **Select a CQTEData Asset:** Select the `CQTEData` asset in the Project window.
    /// 3. **Edit Properties in Inspector:** The custom inspector defined by this class will be displayed in the Inspector panel, allowing you to set the properties of the QTE.
    /// 4. **Change the type of the QTE:** change the "Type puzzle" property to change the property to display.
    /// 5. **Save:** Unity will automatically save changes made in the inspector.
    ///
    /// **Example Use Case:**
    /// - A designer wants to create a new KeyPress QTE.
    /// - They create a new `CQTEData` asset and select it.
    /// - In the inspector, they see the custom editor provided by `CQTEDataEditor`.
    /// - They set the `TypePuzzle` to `KeyPress`.
    /// - Now, they see the `KeyToPress` property and can set it to `Space`, for example.
    /// - They can also set the `Duration`, `incrementSpeedProp` and other properties specific to `KeyPress`.
    /// - If they change `TypePuzzle` to `Sequence`, the properties change, and they are informed that these properties are not yet implemented.
    ///
    /// **Future Improvements:**
    /// - **Implement Sequence and Selection Properties:** Add proper fields to edit Sequence and Selection QTE types.
    /// - **Validation:** Add validation to prevent invalid values from being entered (e.g., negative duration).
    /// - **Visual Feedback:** Add visual feedback to indicate the state of the QTE configuration (e.g., if the required presses are out of the duration).
    /// - **Custom Layout:** Create a more custom layout for the inspector to improve its appearance.
    /// - **More complex logic**: implement more complex logic to handle the QTE.
    ///
    /// **Current Limitations:**
    /// - **Incomplete QTE Types:** Only `KeyPress` is fully implemented. `Sequence` and `Selection` are placeholders.
    /// - **Basic Validation:** There is no data validation.
    /// - **Basic Layout:** The layout is generated using the automatic unity layout.
    /// </summary>
    [CustomEditor(typeof(CQTEData))]
    public class CQTEDataEditor : Editor
    {
        // SerializedProperty objects to represent the properties of CQTEData.
        // Each one is a link to a property of the script CQTEData.cs
        private SerializedProperty qteIdProp;
        private SerializedProperty typePuzzleProp;
        private SerializedProperty keyToPressProp;
        private SerializedProperty durationProp;
        private SerializedProperty requiredPressesProp;
        private SerializedProperty incrementSpeedProp;
        private SerializedProperty debugTextProp;
        private SerializedProperty successThresholdProp;
        private SerializedProperty partialSuccessThresholdProp;



        /// <summary>
        /// Called when the editor becomes enabled and active.
        /// Finds and assigns the serialized properties of the CQTEData object.
        /// </summary>
        private void OnEnable()
        {
            // Gets a reference to each property in the CQTEData class.
            qteIdProp = serializedObject.FindProperty("QTEId");
            typePuzzleProp = serializedObject.FindProperty("TypePuzzle");
            keyToPressProp = serializedObject.FindProperty("KeyToPress");
            durationProp = serializedObject.FindProperty("Duration");
            requiredPressesProp = serializedObject.FindProperty("RequiredPresses");
            incrementSpeedProp = serializedObject.FindProperty("IncrementSpeed");
            debugTextProp = serializedObject.FindProperty("DebugText");
            successThresholdProp = serializedObject.FindProperty("SuccessThreshold");
            partialSuccessThresholdProp = serializedObject.FindProperty("PartialSuccessThreshold");

        }

        /// <summary>
        /// Called to draw the custom inspector GUI.
        /// This method is where the layout and functionality of the custom editor are defined.
        /// </summary>
        public override void OnInspectorGUI()
        {
            // Updates the serialized object to get any changes made outside the inspector.
            serializedObject.Update();

            // Draw each property in the inspector.
            EditorGUILayout.PropertyField(qteIdProp);
            EditorGUILayout.PropertyField(typePuzzleProp);
            EditorGUILayout.PropertyField(debugTextProp);


            // Get the selected QTE type.
            QTETypePuzzle type = (QTETypePuzzle)typePuzzleProp.enumValueIndex;

            // Switch based on the selected QTE type.
            switch (type)
            {
                case QTETypePuzzle.KeyPress:
                    // Draw properties specific to KeyPress QTE.
                    EditorGUILayout.PropertyField(keyToPressProp);
                    EditorGUILayout.PropertyField(durationProp);
                    EditorGUILayout.PropertyField(incrementSpeedProp);
                    EditorGUILayout.PropertyField(successThresholdProp);
                    EditorGUILayout.PropertyField(partialSuccessThresholdProp);

                    break;
                case QTETypePuzzle.Sequence:
                    // Draw a label to indicate that Sequence-specific properties are not yet implemented.
                    EditorGUILayout.LabelField("Sequence-specific properties (to be implemented)");
                    // Add properties for Sequence type here
                    break;
                case QTETypePuzzle.Selection:
                    // Draw a label to indicate that Selection-specific properties are not yet implemented.
                    EditorGUILayout.LabelField("Selection-specific properties (to be implemented)");
                    // Add properties for Selection type here
                    break;
            }

            // Apply any changes made in the inspector to the serialized object.
            serializedObject.ApplyModifiedProperties();
        }
    }
}
