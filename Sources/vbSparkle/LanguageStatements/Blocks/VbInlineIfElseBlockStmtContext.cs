﻿using System.Text;
using static VBScriptParser;

namespace vbSparkle
{
    public class VbInlineIfElseBlockStmtContext
        : VbStatement<InlineElseBlockStmtContext>
    {
        public VbInlineSimpleStackBlock CodeBlock { get; set; }

        public VbInlineIfElseBlockStmtContext(IVBScopeObject context, InlineElseBlockStmtContext bloc)
            : base(context, bloc)
        {
            CodeBlock = new VbInlineSimpleStackBlock(context, bloc.inlineBlock()) ;
        }

        public override DExpression Prettify(bool partialEvaluation = false)
        {
            StringBuilder retCode = new StringBuilder();

            retCode.AppendLine("Else");
            retCode.Append(Helpers.IndentLines(Context.Options.IndentSpacing, CodeBlock.Exp(partialEvaluation)));

            return new DCodeBlock(retCode.ToString());
        }
    }
}