using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveDotNet
{
    public sealed class LongestSequenceEnumerable : IEnumerable<SequenceStatistics>
    {
        private readonly Range<BigInteger> range;
        public LongestSequenceEnumerable(Range<BigInteger> range) => this.range = range;


        public struct LongestSequenceEnumerator : IEnumberator<SequenceStatistics>
        {
            private readonly Range<BigInteger> range;
            private BigInteger asdf;

            public bool MoveNext()
            {
                while (this.currentIndex < this.range.End)
                {

                }
            }
        }
    }
}
