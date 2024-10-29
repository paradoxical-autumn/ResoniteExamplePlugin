// Outputs a lot of information relating to the target user

using FrooxEngine;
using FrooxEngine.ProtoFlux;
using ProtoFlux.Core;

// ProtoFlux namespaces must have `ProtoFlux.Runtimes.Execution.Nodes` appended to the start.
namespace ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users;

// Set Node Category
[NodeCategory("ExamplePlugin/Users")]
[NodeName("All the info you could possibly want.")] // Sets a friendly name for the node (name shown on the node itself, rather than the node browser)
public class ATIYCPW : VoidNode<FrooxEngineContext> // `FrooxEngineContext` is sometimes changed for `ExecutionContext` (when in doubt, use FEC). We do not need to specify a type for void nodes.
{
    // Remember, inputs and outputs need to be wrapped (as with almost everything in FrooxEngine)

    // Your inputs.
    public readonly ObjectInput<User> User;

    // Your outputs.
    public readonly ObjectOutput<string> name;
    public readonly ObjectOutput<string> ID;
    public readonly ObjectOutput<string> MachineID;
    public readonly ValueOutput<bool> CanKick;

    // Void nodes call `ComputeOutputs` when updated.
    // The return type should be void (make sense now?). We don't return from our amazing adventure :(
    protected override void ComputeOutputs(FrooxEngineContext context)
    {
        // NULL HANDLING!!
        // You can return in void nodes, to prevent broken code from executing
        // But outputs only update when written to. They return to being null (or whatever the default value is for your data type) if not written to.
        if (User.Evaluate(context) == null) { return; }

        // Write to your outputs with the .Write() function. Second argument needs to be context.
        User usr = User.Evaluate(context);
        name.Write(usr.UserName, context);
        ID.Write(usr.UserID, context);
        MachineID.Write(usr.MachineID, context);
        CanKick.Write(usr.CanKick(), context); // A grim reminder that all plugins can be dangerous. They can ban everyone if they so please.
    }

    // VoidNodes need to initialise all their OUTPUTS.
    public ATIYCPW()
    {
        name = new ObjectOutput<string>(this);
        ID = new ObjectOutput<string>(this);
        MachineID = new ObjectOutput<string>(this);
        CanKick = new ValueOutput<bool>(this);
    }
}