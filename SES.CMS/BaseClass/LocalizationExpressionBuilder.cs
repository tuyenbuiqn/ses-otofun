using System.Web.Compilation;
using System;
using System.CodeDom;

    public class LocalizationExpressionBuilder : ExpressionBuilder
    {
        public override CodeExpression GetCodeExpression(System.Web.UI.BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            CodeExpression[] inputParams = new CodeExpression[] { new CodePrimitiveExpression(entry.Expression.Trim()), 
                                                    new CodeTypeOfExpression(entry.DeclaringType), 
                                                    new CodePrimitiveExpression(entry.PropertyInfo.Name) };

            // Return a CodeMethodInvokeExpression that will invoke the GetRequestedValue method using the specified input parameters 
            return new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(this.GetType()),
                                        "GetRequestedValue",
                                        inputParams);
        }

        public static object GetRequestedValue(string key, Type targetType, string propertyName)
        {
            // If we reach here, no type mismatch - return the value 
            return GetByText(key);
        }

        //Place holder until database is build
        public static string GetByText(string text)
        {
            return text;
        }
    }
