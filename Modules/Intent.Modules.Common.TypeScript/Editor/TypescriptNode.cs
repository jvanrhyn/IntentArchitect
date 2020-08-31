using System;
using System.Collections.Generic;
using System.Linq;
using Zu.TypeScript.Change;
using Zu.TypeScript.TsTypes;

namespace Intent.Modules.Common.TypeScript.Editor
{
    //public interface ITypeScriptNodeVisitor
    //{
    //    void Visit(TypeScriptClass typeScriptClass);
    //}

    public abstract class TypeScriptNode
    {
        protected internal Node Node;
        public readonly TypeScriptFile File;
        public ChangeAST Change => File.Change;
        public string NodePath;

        public TypeScriptNode(Node node, TypeScriptFile file)
        {
            Node = node;
            File = file;
            File.Register(this);
            NodePath = GetPath(node);
        }

        private string GetPath(Node startNode)
        {
            var path = "";
            var current = startNode;
            while (current != File.Ast.RootNode)
            {
                path = $"{current.Kind}{(current.IdentifierStr != null ? ":" + current.IdentifierStr : "")}{(startNode != current ? "/" : "")}{path}";
                current = (Node) current.Parent;
            }

            return path;
        }

        public bool NodeExists(string path)
        {
            return FindNode(path) != null;
        }

        /// <summary>
        /// e.g. Decorator/CallExpression:NgModule/PropertyAssignment:providers/ArrayLiteralExpression
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Node FindNode(string path)
        {
            return FindNode(Node, path);
        }

        public Node FindNode(Node node, string path)
        {
            return FindNodes(node, path).FirstOrDefault();
        }

        public IList<Node> FindNodes(Node node, string path)
        {
            var pathParts = path.Split('/');
            var part = pathParts[0];

            var syntaxKindValue = part.Split(':')[0];
            var identifier = part.Split(':').Length > 1 ? part.Split(':')[1] : null;

            if (node == null || !Enum.TryParse(syntaxKindValue, out SyntaxKind syntaxKind))
                return null;

            if (pathParts.Length == 1)
            {
                return node.GetDescendants().OfKind(syntaxKind).Where(x => identifier == null || x.IdentifierStr == identifier).ToList();
            }

            if (identifier == null)
            {
                foreach (var descendant in node.GetDescendants().OfKind(syntaxKind))
                {
                    var found = FindNodes(descendant, path.Substring(path.IndexOf("/", StringComparison.Ordinal) + 1));
                    if (found != null)
                    {
                        return found;
                    }
                }

                return null;
            }

            return FindNodes(node.GetDescendants().OfKind(syntaxKind).FirstOrDefault(x => x.IdentifierStr == identifier), path.Substring(path.IndexOf("/", StringComparison.Ordinal) + 1));
        }

        //public string GetText()
        //{
        //    return Node.GetText();
        //}

        public string GetTextWithComments()
        {
            return Node.GetTextWithComments();
        }

        public abstract bool IsIgnored();

        public void Remove()
        {
            File.ReplaceNode(Node, "");
            File.Unregister(this);
            UpdateChanges();
        }

        public void ReplaceWith(string replaceWith)
        {
            if (string.IsNullOrWhiteSpace(replaceWith))
            {
                throw new ArgumentException("Cannot replace a method with an empty string", nameof(replaceWith));
            }
            if (Node.GetTextWithComments() == replaceWith)
            {
                return;
            }
            Change.ChangeNode(Node, replaceWith);
            UpdateChanges();
            //if (IsIgnored())
            //{
            //    throw new Exception($"Cannot add method to TypeScript node [{ToString()}] as it has been decorated with @IntentIgnore()");
            //}
            //File.ReplaceNode(Node, replaceWith);
            //Node = File.Ast.GetDescendants().OfKind(Node.Kind).Single(x => x.Pos == Node.Pos);
        }

        public virtual void UpdateChanges()
        {
            if (IsIgnored())
            {
                throw new Exception($"Cannot add method to TypeScript node [{ToString()}] as it has been decorated with @IntentIgnore()");
            }
            File.UpdateChanges();
            //Node = File.Ast.GetDescendants().OfKind(Node.Kind).Single(x => x.Pos == Node.Pos);
        }

        internal virtual void UpdateNode()
        {
            Node = FindNode(File.Ast.RootNode, NodePath) ?? throw new Exception("Could not find node for path: " + NodePath);
        }
    }
}