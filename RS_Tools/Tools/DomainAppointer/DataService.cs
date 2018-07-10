using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_Tools.Tools.DomainAppointer
{
    public enum DomainCode
    {
        Code0 = 0,
        Code1,
        Code2,
        Code3,
        Code4,
        Code5,
        Code6,
        Code7,
        Code8,
        Code9,
        Code10,
        Code11,
        Code12,
        Code13,
        Code14,
        Code15,
        Code16,
        Code17,
        Code18,
        Code19
    };

    public delegate void ApplyDomainDelegate(DomainCode code);
    public delegate void ApplyDomainNullDelegate();
}
