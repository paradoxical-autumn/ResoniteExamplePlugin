// Outputs the value inputted +1
// This function only handles INTs, as I do not know how to create overloaded functions ~ P19

using FrooxEngine;
using FrooxEngine.ProtoFlux;
using ProtoFlux.Core;

// ProtoFlux namespaces must have `ProtoFlux.Runtimes.Execution.Nodes` appended to the start.
namespace ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Math;

// Set Node Category
[NodeCategory("ExamplePlugin/Math")]
[NodeName("++")] // Sets a friendly name for the node (name shown on the node itself, rather than the node browser)
public class ValuePlusPlus : ValueFunctionNode<FrooxEngineContext, int> // See ObjFuncExample for reasonings for these.
{
    // Your inputs. ObjectFunction and ValueFunction nodes only have one output, so you don't need to list them.
    // Remember, inputs and outputs need to be wrapped (as with almost everything in FrooxEngine)
    [DefaultValueAttribute(0)] // This is how you can set default values for inputs.
    public readonly ValueInput<int> num;

    // The `Compute` function is the function called when the node updates.
    // The return type must match the type you set in your class declaration
    protected override int Compute(FrooxEngineContext context)
    {
        // Handle NULL cases. It shouldn't happen here but we need to just be sure.
        if (num.Evaluate(context) == null) { return 0; }
        return num.Evaluate(context) + 1;
    }
}

// We're not done yet! Now it needs to be bound.
// See Bindings/ProtoFlux/Math/ValFuncExample.cs