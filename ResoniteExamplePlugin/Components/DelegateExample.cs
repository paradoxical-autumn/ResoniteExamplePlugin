using Elements.Core;
using Elements.Assets;
using FrooxEngine;
using FrooxEngine.UIX;

namespace ExamplePlugin.Components;
[Category("ExamplePlugin")]

// Our component needs to inherit from:
// Component: Well, it is one so it needs to inherit it.
// ICustomInspector: We need to generate a custom inspector UI for the button
public class DelegateExampleComponent : Component, ICustomInspector
{
    // Create a new variable to show what happens when the delegates are called.
    public readonly Sync<string> data;

    // OnAttach, set `data`'s value to "hi!!"
    protected override void OnAttach()
    {
        // Call base.OnAttach(). I don't know why. Just do it. I need someone else to explain why. ~ paradoxical-autumn // P19
        base.OnAttach();
        data.Value = "hi!!";
    }

    // For this to be called, your class needs to inherit from ICustomInspector. Creates the custom UI for the component.
    public void BuildInspectorUI(UIBuilder ui)
    {
        ui.PushStyle(); // Always ALWAYS call this first when creating `BuildInspectorUI`

        // Anything you put between these two lines is placed ABOVE the component fields.

        ui.PopStyle(); // Should always come before `WorkerInspector.BuildInspectorUI`, I don't know why ~ P19
        WorkerInspector.BuildInspectorUI(this, ui); // Tells the inspector to generate the fields

        LocaleString text = "hi im button text"; // You can use `LocaleString` for text objects which aren't locale keys. If using locale keys, put `.AsLocaleKey()` at the end of it.
        ui.Button(in text, SetDataWithButton); // Create a button which has a callback to SetDataWithButton
    }

    // The `SyncMethod` attribute takes in two arguments. MethodType (type) and GenericMapping (IReadOnlyList<string>)
    // This is why we use `typeof(t)` everywhere in this code.

    [SyncMethod(typeof(Delegate), null)] // Button-called SyncMethods should be `typeof(Delegate)`. The second argument to this attribute should be `null` (I don't know why ~ P19)
    private void SetDataWithButton(IButton button, ButtonEventData eventData) // They also need these two inputs, to allow you to do things with both the button and the eventData.
    {
        data.Value = "SetDataWithButton was called.";
    }

    // For these two, the SyncMethod attribute needs an empty string as its second argument. I do not know why ~ P19

    [SyncMethod(typeof(Action), new string[] { })] // Actions are SyncMethods that do NOT return a value.
    public void ActionSetData()
    {
        data.Value = "ActionSetData() was called.";
    }

    [SyncMethod(typeof(Func<bool>), new string[] { })] // Func<t> is a SyncMethod that returns `t`. Here, we return a bool, so `t` is `bool`.
    public bool FuncSetData()
    {
        data.Value = "FuncSetData() was called.";
        return true;
    }
}