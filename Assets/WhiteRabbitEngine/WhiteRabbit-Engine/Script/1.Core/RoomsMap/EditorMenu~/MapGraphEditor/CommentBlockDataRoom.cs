using System;
using System.Collections.Generic;
using UnityEngine;

 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// This class represents the data for a comment block within the Room Map editor.
/// Comment blocks are visual elements used to group and annotate related nodes in the map graph.
/// They help improve the organization and readability of complex room structures.
/// </summary>
[Serializable]
public class CommentBlockDataRoom 
{
  
        /// <summary>
        /// A list of GUIDs (Globally Unique Identifiers) representing the child nodes contained within this comment block.
        /// Each GUID corresponds to a RoomNode's GUID.
        /// This allows the comment block to keep track of which room nodes it is visually grouping.
        /// </summary>
        public List<string> ChildNodes = new List<string>();

        /// <summary>
        /// The position of the comment block within the map graph editor.
        /// This is a 2D vector that represents the block's location.
        /// It is used to place the comment block in the correct location in the editor's visual interface.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// The title of the comment block, displayed in the editor.
        /// This helps to describe the purpose or content of the grouped nodes.
        ///  By default is "Comment Block".
        /// </summary>
        public string Title= "Comment Block";
}
}
