﻿using System.Text;
using vbSparkle.EvaluationObjects;
using static VBScriptParser;

namespace vbSparkle
{
    public class VbLtString : VBLiteral<LtStringContext>
    {
        public VbLtString(IVBScopeObject context, LtStringContext @object) 
            : base(context, @object)
        {
            string quoted = @object.GetText();
            Value = new DSimpleStringExpression(quoted.Substring(1, quoted.Length -2), Encoding.Unicode, context.Options);
        }
        
        public override string Prettify()
        {
            DSimpleStringExpression val = (DSimpleStringExpression) Value;
            return val.ToExpressionString();
        }
    }

}