using ProtoFlux.Core;

// Namespace must have FrooxEngine appended to the start.
namespace FrooxEngine.ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users;

// Component category must be the same as your code file but with `ProtoFlux/Runtimes/Execution/Nodes/` at the start.
[Category(new string[] { "ProtoFlux/Runtimes/Execution/Nodes/ExamplePlugin/Users" })] // For some reason, protoflux bindings need to have this weird string formatting for their category.
public class CSVUserInfo : ObjectFunctionNode<FrooxEngineContext, string> // This should match the class declaration in your code file.
{
    // Your INPUTS. Remember: For VFN and OFN, we do not need to specify outputs.
    public readonly SyncRef<INodeObjectOutput<User>> usr; // Variable names MUST match. NOTE: Inputs need to be wrapped in `SyncRef<t>` where `t` is either `INodeValueOutput<tt>` or `INodeObjectOutput<tt>`

    // This stuff is almost copy and paste between all bindings, but with adjusted paths
    // You're going to be typing out your `global::path` a lot. Copy and paste it.
    public override Type NodeType => typeof(global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.CSVUserInfo);
    public global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.CSVUserInfo TypedNodeInstance { get; private set; }
    public override INode NodeInstance => TypedNodeInstance;
    public override int NodeInputCount => base.NodeInputCount + 1; // CHANGE `1` TO THE NUMBER OF INPUTS YOU HAVE.

    public override N Instantiate<N>()
    {
        if (TypedNodeInstance != null)
        {
            throw new InvalidOperationException("Node has already been instantiated");
        }
        global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.CSVUserInfo CSVUserInfo2 = (TypedNodeInstance = new global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.CSVUserInfo());
        return CSVUserInfo2 as N;
    }

    protected override void AssociateInstanceInternal(INode node)
    {
        if (node is global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.CSVUserInfo typedNodeInstance)
        {
            TypedNodeInstance = typedNodeInstance;
            return;
        }
        throw new ArgumentException("Node instance is not of type " + typeof(global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.CSVUserInfo));
    }

    public override void ClearInstance()
    {
        TypedNodeInstance = null;
    }

    // GetInputInternal is a thing. I don't really understand how it works.
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
                return usr;
            default:
                index -= 1; // Set `1` to your number of INPUTS
                return null;
        }
    }
}