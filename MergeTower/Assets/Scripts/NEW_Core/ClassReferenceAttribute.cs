using System;
using UnityEngine;

namespace Core
{
    public class ClassReferenceAttribute : PropertyAttribute
    {
        public Type type;

        public ClassReferenceAttribute(Type type)
        {
            this.type = type;
        }
    }
}