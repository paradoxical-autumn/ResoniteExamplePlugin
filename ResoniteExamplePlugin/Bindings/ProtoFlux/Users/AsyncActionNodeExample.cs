using ProtoFlux.Core;

// Namespace must have FrooxEngine appended to the start.
namespace FrooxEngine.ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users;

// Component category must be the same as your code file but with `ProtoFlux/Runtimes/Execution/Nodes/` at the start.
[Category(new string[] { "ProtoFlux/Runtimes/Execution/Nodes/ExamplePlugin/Users" })] // For some reason, protoflux bindings need to have this weird string formatting for their category.
public class RespawnUser : AsyncActionNode<FrooxEngineContext>
{
    // inputs
    public SyncRef<INodeObjectOutput<User>> User;

    // calls and continuations
    // these share the same object type in bindings.
    public readonly SyncRef<INodeOperation> OnStarted;
    public readonly SyncRef<INodeOperation> OnDestroyed;
    public readonly SyncRef<INodeOperation> OnFailed;

    // This stuff is almost copy and paste between all bindings, but with adjusted paths
    // You're going to be typing out your `global::path` a lot. Copy and paste it.

    public override Type NodeType => typeof(global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.RespawnUser);
    public global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.RespawnUser TypedNodeInstance { get; private set; }
    public override INode NodeInstance => TypedNodeInstance;

    public override int NodeInputCount => base.NodeInputCount + 1; // CHANGE `1` TO THE NUMBER OF INPUTS YOU HAVE
    public override int NodeImpulseCount => base.NodeImpulseCount + 3; // CHANGE `3` TO THE NUMBER OF IMPULSES YOU HAVE

    public override N Instantiate<N>()
    {
        if (TypedNodeInstance != null)
        {
            throw new InvalidOperationException("Node has already been instantiated");
        }
        global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.RespawnUser respawnUser2 = (TypedNodeInstance = new global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.RespawnUser());
        return respawnUser2 as N;
    }

    protected override void AssociateInstanceInternal(INode node)
    {
        if (node is global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.RespawnUser typedNodeInstance)
        {
            TypedNodeInstance = typedNodeInstance;
            return;
        }
        throw new ArgumentException("Node instance is not of type " + typeof(global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.RespawnUser));
    }

    public override void ClearInstance()
    {
        TypedNodeInstance = null;
    }

    // GetXInternals are things. I'm sure you know this by now (if this is your first binding then I guess you wont xD)
    protected override ISyncRef GetInputInternal(ref int index)
    {
        ISyncRef inputInternal = base.GetInputInternal(ref index);
        // Return inputInternal if not null.
        if (inputInternal != null)
        {
            return inputInternal;
        }

        // You need to create case statements for all your inputs IN THE SAME ORDER as you defined them above.
        switch (index)
        {
            case 0:
                return User;
            default:
                index -= 2; // Set `1` to your number of INPUTS
                return null;
        }
    }

    protected override ISyncRef GetImpulseInternal(ref int index)
    {
        ISyncRef impulseInternal = base.GetImpulseInternal(ref index);
        // return impulseInternal if not null.
        if (impulseInternal != null)
        {
            return impulseInternal;
        }

        // You need to create case statements for all your inputs IN THE SAME ORDER as you defined them above.
        switch (index)
        {
            case 0:
                return OnStarted;
            case 1:
                return OnDestroyed;
            case 2:
                return OnFailed;
            default:
                index -= 3; // Set `3` to your number of IMPULSES
                return null;
        }
    }

    // If needed, you would add:
    // protected override INodeOutput GetOutputInternal(ref int index)
    // if you had any outputs.
    // see the binding for VoidNodeExample for more information!
}