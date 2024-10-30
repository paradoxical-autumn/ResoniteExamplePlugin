// Respawns the target user.

using FrooxEngine;
using FrooxEngine.ProtoFlux;
using ProtoFlux.Core;

// ProtoFlux namespaces must have `ProtoFlux.Runtimes.Execution.Nodes` appended to the start.
namespace ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users;

// Set Node Category
[NodeCategory("ExamplePlugin/Users")]
public class RespawnUser : AsyncActionNode<FrooxEngineContext> // `FrooxEngineContext` is sometimes changed for `ExecutionContext` (when in doubt, use FEC) and `string` is your return type.
{
    // Your inputs.
    // Remember, inputs and outputs need to be wrapped (as with almost everything in FrooxEngine)
    public ObjectInput<User> User;

    // You can put inputs here, this node doesn't need any though.
    // You'd write to them in the same way as a void node.

    // Your calls
    // Calls are things you CALL to allow for further node execution, before returing to YOUR code.
    public AsyncCall OnStarted;

    // Your continuations
    // Continuations are things you return when your code is completed executing, or when your code doesn't need to continue.
    public Continuation OnDestroyed;
    public Continuation OnFailed;

    // Async nodes need `IOperation` to be wrapped in `Task<t>`, and `Run` to be replaced with `RunAsync`
    protected override async Task<IOperation> RunAsync(FrooxEngineContext context)
    {
        User usr = User.Evaluate(context);
        if (usr == null)
        {
            // As this is a continuation, we return the target.
            // We do not need to finish executing.
            return OnFailed.Target;
        }

        await OnStarted.ExecuteAsync(context);

        Slot slot = usr.Root?.Slot;
        if (slot == null)
        {
            // see above
            return OnFailed.Target;
        }

        slot.Destroy();
        return OnDestroyed.Target;
    }
}