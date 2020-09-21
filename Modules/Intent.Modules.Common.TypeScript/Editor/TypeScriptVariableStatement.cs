using System;
using System.Collections.Generic;
using System.Linq;
using Zu.TypeScript.TsTypes;

namespace Intent.Modules.Common.TypeScript.Editor
{
    public class TypeScriptVariableStatement : TypeScriptNode
    {
        public TypeScriptVariableStatement(Node node, TypeScriptNode parent) : base(node, parent)
        {
            //Name = Node.OfKind(SyntaxKind.VariableDeclaration).First().IdentifierStr ?? throw new ArgumentException("Variable Name could not be determined for node: " + this);
            //NodePath = this.GetNodePath(Node.OfKind(SyntaxKind.VariableDeclaration).First());
        }

        public override string GetIdentifier(Node node)
        {
            return node.OfKind(SyntaxKind.VariableDeclaration).First().IdentifierStr;
        }

        public T GetAssignedValue<T>()
            where T : TypeScriptNode
        {
            var arrayLiteral = Node.Children.FirstOrDefault(x => x.Kind == SyntaxKind.ArrayLiteralExpression);
            if (arrayLiteral != null)
            {
                return new TypeScriptArrayLiteralExpression(arrayLiteral, this) as T;
            }
            var objectLiteral = Node.Children.FirstOrDefault(x => x.Kind == SyntaxKind.ObjectLiteralExpression);
            if (objectLiteral != null)
            {
                return new TypeScriptObjectLiteralExpression(objectLiteral, this) as T;
            }
            // TODO: ValueLiteral

            return null;
        }

        public override void UpdateNode(Node node)
        {
            base.UpdateNode(node);
            var index = 0;
            foreach (var child in node.OfKind(SyntaxKind.VariableDeclaration).FirstOrDefault()?.Children ?? new List<Node>())
            {
                switch (child.Kind)
                {
                    case SyntaxKind.ObjectLiteralExpression:
                        this.InsertOrUpdateChildNode(child, index, () => new TypeScriptObjectLiteralExpression(child, this));
                        index++;
                        continue;
                    case SyntaxKind.ArrayLiteralExpression:
                        this.InsertOrUpdateChildNode(child, index, () => new TypeScriptArrayLiteralExpression(child, this));
                        index++;
                        continue;
                    case SyntaxKind.PropertyAssignment:
                        this.InsertOrUpdateChildNode(child, index, () => new TypeScriptPropertyAssignment(child, this));
                        index++;
                        continue;
                }
            }
        }

    }
}