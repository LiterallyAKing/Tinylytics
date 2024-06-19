using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScriptForEditorTesting))]
public class EditorScriptForScriptForEditorTesting : Editor {

	SerializedProperty prop1, prop2, prop3;

	void OnEnable() {
		//myObjectRef = serializedObject.targetObject as BRAND_AnalyticsTracker;
		prop1 = serializedObject.FindProperty("eg1");
		prop2 = serializedObject.FindProperty("eg2");
		prop3 = serializedObject.FindProperty("eg3");
	}

	bool showfoldout = true;

	public override void OnInspectorGUI() {

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.HelpBox(
					  "Helpbox with messagetype warning",
					  MessageType.Warning);
					

		EditorGUILayout.BeginVertical();
		EditorGUILayout.HelpBox("Helpbox with messagetype info", MessageType.Info);

		EditorGUILayout.HelpBox("Helpbox with messagetype error", MessageType.Error);

		EditorGUILayout.HelpBox("Helpbox with messagetype none", MessageType.None);

		EditorGUILayout.EndVertical();
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();

		string[] teststringarray = new string[] {"one","two","three"};
		Rect rect = EditorGUILayout.GetControlRect(true);
		float iconSize = rect.height + 4;
		rect.width -= iconSize;
		EditorGUI.Popup(rect, "Popup Test", 0, teststringarray);
		EditorGUILayout.EndHorizontal();

		rect.x += rect.width; rect.width = iconSize; rect.height = iconSize;
		EditorGUILayout.BeginHorizontal();
		if (GUI.Button(rect, EditorGUIUtility.IconContent("_Popup"), GUI.skin.label)) {
			GenericMenu menu = new GenericMenu();
			menu.AddItem(new GUIContent("Edit"), false, () => Selection.activeObject = prop1.objectReferenceValue);

			menu.AddSeparator("");
			menu.AddItem(new GUIContent("Locate"), false, () => EditorGUIUtility.PingObject(prop1.objectReferenceValue));
			
			menu.ShowAsContext();
		}

		EditorGUILayout.EndHorizontal();
		
		EditorGUI.DrawRect(rect, Color.red);
		EditorGUI.DropShadowLabel(EditorGUILayout.GetControlRect(true), "drop shadow");

		//PreferencesSectionBox

		//showfoldout = EditorGUI.Foldout(EditorGUILayout.GetControlRect(true), showfoldout, "Foldout content / folds out",true);
		showfoldout = EditorGUI.Foldout(EditorGUILayout.GetControlRect(true), showfoldout, "Foldout content / folds out", true, "PreferencesSectionBox");

		if (showfoldout) {
			EditorGUILayout.BeginHorizontal();
			rect = EditorGUILayout.GetControlRect(true);
			//rect.y += EditorGUIUtility.singleLineHeight;
			EditorGUI.LabelField(rect, "label");
			EditorGUILayout.EndHorizontal();
		}


		EditorGUI.DropShadowLabel(EditorGUILayout.GetControlRect(true), "drop shadow");

		EditorGUILayout.BeginVertical("PreferencesSectionBox");

		EditorGUILayout.LabelField("outside");

		EditorGUILayout.BeginHorizontal();

		EditorGUILayout.BeginVertical("GroupBox");

		EditorGUILayout.LabelField("INSIDE");

		EditorGUILayout.EndVertical();

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.EndVertical();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Button("-", EditorStyles.miniButtonLeft, GUILayout.Width(20));
		GUILayout.Button("T", EditorStyles.miniButtonMid, GUILayout.Width(20));
		GUILayout.Button("+", EditorStyles.miniButtonRight, GUILayout.Width(20));
		EditorGUILayout.EndHorizontal();
	}



}
