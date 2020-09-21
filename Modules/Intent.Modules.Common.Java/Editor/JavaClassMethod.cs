﻿using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;

namespace Intent.Modules.Common.Java.Editor
{
    public class JavaClassMethod : JavaNode
    {
        private readonly Java9Parser.MethodDeclarationContext _context;

        public JavaClassMethod(Java9Parser.MethodDeclarationContext context, JavaClass parent) : base(context, parent)
        {
            _context = context;
            Name = _context.methodHeader().methodDeclarator().identifier().GetText();
        }

        public string Name { get; }

        public override string GetIdentifier(ParserRuleContext context)
        {
            var name = ((Java9Parser.MethodDeclarationContext)context).methodHeader().methodDeclarator().identifier().GetText();

            IEnumerable<string> parameterTypes = ((Java9Parser.MethodDeclarationContext) context)
                .methodHeader().methodDeclarator().formalParameterList()?.GetParameterTypes() ?? new List<string>();
            return $"{name}({string.Join(", ", parameterTypes)})";
        }
    }
}