// Outputs a CSV of `username,userID` of the user inputted.
// Strings are OBJECTS in ProtoFlux, so this works. Don't ask me why.

using FrooxEngine;
using FrooxEngine.ProtoFlux;
using ProtoFlux.Core;

// ProtoFlux namespaces must have `ProtoFlux.Runtimes.Execution.Nodes` appended to the start.
namespace ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users;

// Set Node Category
[NodeCategory("ExamplePlugin/Users")]
[NodeName("User Info")] // Sets a friendly name for the node (name shown on the node itself, rather than the node browser)
public class CSVUserInfo : ObjectFunctionNode<FrooxEngineContext, string> // `FrooxEngineContext` is sometimes changed for `ExecutionContext` (when in doubt, use FEC) and `string` is your return type.
{
    // Your inputs. ObjectFunction and ValueFunction nodes only have one output, so you don't need to list them.
    // Remember, inputs and outputs need to be wrapped (as with almost everything in FrooxEngine)
    public readonly ObjectInput<User> usr;

    // The `Compute` function is the function called when the node updates.
    // The return type must match the type you set in your class declaration
    protected override string Compute(FrooxEngineContext context)
    {
        // Remember to handle null inputs.
        // To see how to do this with default values, see ValFuncExample.cs
        if (usr.Evaluate(context) == null)
        {
            return null;
        }

        User ext_usr = usr.Evaluate(context);
        return String.Format("{0},{1}", ext_usr.UserName, ext_usr.UserID);
    }
}

// We're not done yet! Now it needs to be bound.
// See Bindings/ProtoFlux/Math/ObjFuncExample.cs