using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * MemberwiseClone is a method that is available on all objects. 
 * It copies the values of all fields and any references, and returns a reference to this copy. 
 * However, it does not copy what the references in the object point to. 
 * That is, it performs what is known as a shallow copy. 
 * Many objects are simple, without references to other objects, and therefore shallow copies are adequate. 
 * To preserve the complete value of the object, including all its subobjects use a deep copy.
 * It is not easy to write a general algorithm to follow every link in a structure and recreate the arrangement elsewhere. 
 * However, algorithms do exist, and in the .NET Framework they are encapsulated in a process called serialization. 
 * Objects are copied to a given destination and can be brought back again at will. 
 * The options for serialization destinations are several, including disks and the Internet,
 * but the easiest one for serializing smallish objects is memory itself.
 * Thus a deep copy consists of serializing and deserializing in one method.
 * 
 */
namespace Prototype.cs
{
    public interface Prototype
    {
        Prototype Clone();
    }

    public class ConcretePrototypeA : Prototype
    {
        public Prototype Clone()
        {
            // Shallow Copy: only top-level objects are duplicated
            return (Prototype)MemberwiseClone();

            // Deep Copy: all objects are duplicated
            //return (Prototype)this.Clone();
        }
    }

    public class ConcretePrototypeB : Prototype
    {
        public Prototype Clone()
        {
            // Shallow Copy: only top-level objects are duplicated
            return (Prototype)MemberwiseClone();

            // Deep Copy: all objects are duplicated
            //return (Prototype)this.Clone();
        }
    }
}
