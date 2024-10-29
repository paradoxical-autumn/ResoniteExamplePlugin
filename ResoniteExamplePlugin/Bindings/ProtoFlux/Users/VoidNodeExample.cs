using ProtoFlux.Core;

// Namespace must have FrooxEngine appended to the start.
namespace FrooxEngine.ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users;

// Component category must be the same as your code file but with `ProtoFlux/Runtimes/Execution/Nodes/` at the start.
[Category(new string[] { "ProtoFlux/Runtimes/Execution/Nodes/ExamplePlugin/Users" })] // For some reason, protoflux bindings need to have this weird string formatting for their category.
public class ATIYCPW : VoidNode<FrooxEngineContext> // This should match the class declaration in your code file.
{
    // Your INPUTS
    public readonly SyncRef<INodeObjectOutput<User>> User; // Variable names MUST match. NOTE: Inputs need to be wrapped in `SyncRef<t>` where `t` is either `INodeValueOutput<tt>` or `INodeObjectOutput<tt>`

    // Your OUTPUTS
    // Outputs are wrapped in `NodeObjectOutput` or `NodeValueOutput`, which are NOT wrapped in `SyncRef<t>`'s!
    // Also, these are not the interface variants found in the inputs. (basically don't put `I` at the start! `I` is for input!!*)
    public readonly NodeObjectOutput<string> name;
    public readonly NodeObjectOutput<string> ID;
    public readonly NodeObjectOutput<string> MachineID;
    public readonly NodeValueOutput<bool> CanKick;

    // This stuff is almost copy and paste between all bindings, but with adjusted paths
    // You're going to be typing out your `global::path` a lot. Copy and paste it.

    public override Type NodeType => typeof(global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.ATIYCPW);
    public global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.ATIYCPW TypedNodeInstance { get; private set; }
    public override INode NodeInstance => TypedNodeInstance;

    public override int NodeInputCount => base.NodeInputCount + 1; // CHANGE `1` TO THE NUMBER OF INPUTS YOU HAVE
    public override int NodeOutputCount => base.NodeOutputCount + 4; // CHANGE `4` TO THE NUMBER OF OUTPUTS YOU HAVE

    public override N Instantiate<N>()
    {
        if (TypedNodeInstance != null)
        {
            throw new InvalidOperationException("Node has already been instantiated");
        }
        global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.ATIYCPW atiycpw2 = (TypedNodeInstance = new global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.ATIYCPW());
        return atiycpw2 as N;
    }

    protected override void AssociateInstanceInternal(INode node)
    {
        if (node is global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.ATIYCPW typedNodeInstance)
        {
            TypedNodeInstance = typedNodeInstance;
            return;
        }
        throw new ArgumentException("Node instance is not of type " + typeof(global::ProtoFlux.Runtimes.Execution.Nodes.ExamplePlugin.Users.ATIYCPW));
    }

    public override void ClearInstance()
    {
        TypedNodeInstance = null;
    }

    // Get input and get output internal are things.
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
                index -= 1; // Set `1` to your number of INPUTS
                return null;
        }
    }

    // Note: output uses INodeOutput and not ISyncRef. Bear this in mind, this confused me for ages.
    protected override INodeOutput GetOutputInternal(ref int index)
    {
        INodeOutput outputInternal = base.GetOutputInternal(ref index);
        // Return outputInternal if not null
        if (outputInternal != null)
        {
            return outputInternal;
        }

        // You need to create case statements for all your outputs IN THE SAME ORDER as you defined them above.
        switch (index)
        {
            case 0:
                return name;
            case 1:
                return ID;
            case 2:
                return MachineID;
            case 3:
                return CanKick;
            default:
                index -= 4; // Set `4` to your number of INPUTS
                return null;
        }
    }
}

// * `I` is not for input. `I` is for `Interface` ~ P19
// It's just easier to remember the other way I guess.