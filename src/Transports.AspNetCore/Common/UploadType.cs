using GraphQL.Language.AST;
using GraphQL.Types;
using System;

namespace GraphQL.Server.Transports.AspNetCore.Common
{
    public class UploadType : ScalarGraphType
    {
        public UploadType()
        {
            Name = "Upload";
        }

        public override object ParseLiteral(IValue value)
        {
            return Convert.FromBase64String(value.Value as string);
        }

        public override object ParseValue(object value)
        {
            return Convert.ToBase64String(value as byte[]);
        }

        public override object Serialize(object value)
        {
            return Convert.ToBase64String(value as byte[]);
        }
    }
}
