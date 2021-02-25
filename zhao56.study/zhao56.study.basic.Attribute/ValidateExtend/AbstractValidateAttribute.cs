using System;
using System.Collections.Generic;
using System.Text;

namespace zhao56.study.basic.AttributeExtend
{
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object oValue);
    }
}
