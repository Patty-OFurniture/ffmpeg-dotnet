using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    // https://github.com/dotnet/csharplang/blob/main/proposals/unions.md

    public enum Kind { None = 0, AVChannelCustom, UInt64 }

    public interface IUnion
    {
        // The value of the union or null
        public object? Value { get; }
        public Kind kind { get; }
    }

    public class Union : IUnion
    {
        public Kind kind { get; protected set; }
        public object? Value { get; protected set; }
        public bool HasValue => kind != Kind.None;
        //Kind IUnion.kind => kind;
    }
}
