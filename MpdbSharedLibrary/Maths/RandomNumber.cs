using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
    /// <summary>
    /// Contains utilies for random number generation
    /// </summary>
    public static class RandomNumber
    {
        /// <summary>
        /// Creates a seed that does not depend on the system clock. 
        /// A unique value will be created with each invocation.
        /// 
        /// Taken from code samples for , Parallel Programming with Microsoft .NET
        /// http://msdn.microsoft.com/en-us/library/ff963553.aspx
        /// 
        /// </summary>
        /// <returns>An integer that can be used to seed a random generator</returns>
        /// <remarks>This method is thread safe.</remarks>
        public static int MakeRandomSeed()
        {
            return Guid.NewGuid().ToString().GetHashCode();
        } 
        
    }
}
